using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace MOTHER3SpriteEditor
{
    public class Sprite
    {
        #region Static constants
        private static byte[,] sprHeightConst = 
        { 
            {1, 2, 4, 8},
            {1, 1, 2, 4},
            {2, 4, 4, 8}
        };
        private static byte[,] sprWidthConst = 
        {
            {1, 2, 4, 8},
            {2, 4, 4, 8},
            {1, 1, 2, 4}
        };
        #endregion

        public class SubSprite
        {
            public int Tile;
            public int Width;
            public int Height;
            public int OffsetX;
            public int OffsetY;
            public bool FlipX;
            public bool FlipY;
            public Tileset tileSet;
            public Palette pal;
            public int Size;
            public int Shape;

            public ROMHandler romFile;
            public int romAddress;

            public int WidthInPixels
            {
                get { return Width << 3; }
            }

            public int HeightInPixels
            {
                get { return Height << 3; }
            }

            public byte GetPixel(int x, int y)
            {
                // Figure out what tile we're on
                x = (FlipX ? (Width << 3) - 1 - x : x);
                y = (FlipY ? (Height << 3) - 1 - y : y);
                int tx = x >> 3;
                int ty = y >> 3;
                int tileNum = tx + (ty * Width) + Tile;
                x -= (tx << 3);
                y -= (ty << 3);

                return tileSet.GetPixel(tileNum, x, y);
            }

            public void SetPixel(int x, int y, byte value)
            {
                // Figure out what tile we're on
                x = (FlipX ? (Width << 3) - 1 - x : x);
                y = (FlipY ? (Height << 3) - 1 - y : y);
                int tx = x >> 3;
                int ty = y >> 3;
                int tileNum = tx + (ty * Width) + Tile;
                x -= (tx << 3);
                y -= (ty << 3);

                tileSet.SetPixel(tileNum, x, y, value);
            }

            public void RenderSubSprite(Bitmap render, int x, int y, 
                int scale, bool drawTransparent)
            {
                FastPixel fs = new FastPixel();
                fs.New(render);
                fs.Lock();

                byte[,] pixels;
                for (int j = 0; j < Height; j++)
                    for (int i = 0; i < Width; i++)
                    {
                        pixels = tileSet.GetTile(Tile + i + (j * Width));
                        for (int yy = 0; yy < 8; yy++)
                            for (int xx = 0; xx < 8; xx++)
                            {
                                for (int ys = 0; ys < scale; ys++)
                                    for (int xs = 0; xs < scale; xs++)
                                    {
                                        byte pix = pixels[FlipY ? 7 - yy : yy, FlipX ? 7 - xx : xx];
                                        if (!((pix == 0) && !drawTransparent))
                                            fs.SetPixel(
                                                xs + ((x + xx + (FlipX ? Width - 1 - i : i) * 8) * scale),
                                                ys + ((y + yy + (FlipY ? Height - 1 - j : j) * 8) * scale),
                                                pal.GetColor(pix));
                                    }
                            }
                    }

                fs.Unlock();
            }

            public void SaveProperties()
            {
                romFile.Seek(romAddress);
                romFile.WriteByte((byte)OffsetY);
                romFile.WriteByte((byte)OffsetX);
                int tmp = (Tile & 0x3FF);
                tmp |= (FlipX ? 1 << 10 : 0);
                tmp |= (FlipY ? 1 << 11 : 0);
                tmp |= ((Size & 3) << 12);
                tmp |= ((Shape & 3) << 14);
                romFile.WriteByte((byte)(tmp & 0xFF));
                romFile.WriteByte((byte)((tmp >> 8) & 0xFF));
            }
        }
        List<SubSprite> subSprites;
        public int NumSubSprites;
        public int NumSprites;

        // Tileset
        Tileset tSet;

        // Palette
        Palette pal;

        // Other relevant info
        ROMHandler romFile;
        int bank;
        int mainEntry;
        int spriteEntry;
        private int infoAddress;

        public Palette Pal
        {
            get { return pal; }
            set { pal = value; }
        }

        public Sprite(ROMHandler ROMFile, int Bank, int MainEntry, int SpriteEntry)
        {
            int entryCounter = 0;

            romFile = ROMFile;
            bank = Bank;
            mainEntry = MainEntry;
            spriteEntry = SpriteEntry;

            // Instantiate the tileset and palette
            tSet = new Tileset(romFile, bank, mainEntry);
            pal = new Palette(romFile, bank, mainEntry);
            
            // Parse the sub sprite information
            infoAddress = ROMInfo.sprStartAddress[bank] + romFile.ReadWord(
                ROMInfo.sprStartAddress[bank] + 4 + (mainEntry * 4)) +
                8;
            NumSprites = romFile.ReadHWord(infoAddress);
            infoAddress += 2;

            while (spriteEntry > entryCounter)
            {
                infoAddress += (romFile.ReadHWord(infoAddress) + 1) * 4;
                entryCounter++;
            }

            ComputeSubSprites();
        }

        public void ComputeSubSprites()
        {
            romFile.Seek(infoAddress);
            NumSubSprites = romFile.ReadHWord();
            SubSprite retVal;
            subSprites = new List<SubSprite>();
            int tmp;
            for (int i = 0; i < NumSubSprites; i++)
            {
                retVal = new SubSprite();
                retVal.romAddress = (int)romFile.Address;
                retVal.romFile = romFile;

                retVal.OffsetY = romFile.ReadByte();
                retVal.OffsetX = romFile.ReadByte();
                if (retVal.OffsetY >= 0x80) retVal.OffsetY -= 0x100; // Sign the offsets
                if (retVal.OffsetX >= 0x80) retVal.OffsetX -= 0x100;
                tmp = romFile.ReadHWord();
                retVal.Tile = (tmp & 0x3FF);
                retVal.FlipX = (((tmp >> 10) & 1) == 1);
                retVal.FlipY = (((tmp >> 11) & 1) == 1);
                retVal.Width = sprWidthConst[(tmp >> 14) & 3, (tmp >> 12) & 3];
                retVal.Height = sprHeightConst[(tmp >> 14) & 3, (tmp >> 12) & 3];
                retVal.Size = (tmp >> 12) & 3;
                retVal.Shape = (tmp >> 14) & 3;

                retVal.tileSet = tSet;
                retVal.pal = pal;

                subSprites.Add(retVal);
            }
        }

        public SubSprite GetSubSprite(int subEntry)
        {
            return subSprites[subEntry];
        }

        public void AddSubSpriteToCache(int subEntry)
        {
            tSet.AddTileToCache(subSprites[subEntry].Tile,
                subSprites[subEntry].Width * subSprites[subEntry].Height);
        }

        public void ApplyChanges()
        {
            tSet.ApplyChanges();
            for (int i = 0; i < NumSubSprites; i++)
                subSprites[i].SaveProperties();
        }

        public Color GetPalColor(int index)
        {
            return pal.GetColor(index);
        }

        public void SetPalColor(int index, Color value)
        {
            pal.SetColor(index, value);
        }

        private Point GetSpriteTopLeft()
        {
            // First, we need to figure out how large our Bitmap should be
            // Go through each sub-sprite, get the most extreme coordinates, and
            // calculate the difference

            int x1 = 0; // Left-most X coord
            int y1 = 0; // Top-most Y coord

            SubSprite sSprite = subSprites[0];

            // Set the initial values manually
            x1 = sSprite.OffsetX;
            y1 = sSprite.OffsetY;

            // Go through the rest
            for (int i = 1; i < NumSubSprites; i++)
            {
                sSprite = subSprites[i];
                if (sSprite.OffsetX < x1) x1 = sSprite.OffsetX;
                if (sSprite.OffsetY < y1) y1 = sSprite.OffsetY;
            }

            return new Point(x1, y1);
        }

        private Point GetSpriteBottomRight()
        {
            int x2 = 0; // Right-most X coord
            int y2 = 0; // Bottom-most Y coord

            SubSprite sSprite = subSprites[0];

            // Set the initial values manually
            x2 = sSprite.OffsetX + (sSprite.Width * 8);
            y2 = sSprite.OffsetY + (sSprite.Height * 8);

            // Go through the rest
            for (int i = 1; i < NumSubSprites; i++)
            {
                sSprite = subSprites[i];
                if ((sSprite.OffsetX + (sSprite.Width * 8)) > x2) x2 = sSprite.OffsetX + (sSprite.Width * 8);
                if ((sSprite.OffsetY + (sSprite.Height * 8)) > y2) y2 = sSprite.OffsetY + (sSprite.Height * 8);
            }

            return new Point(x2, y2);
        }

        public Size GetSpriteSize()
        {
            Point topLeft = GetSpriteTopLeft();
            Point bottomRight = GetSpriteBottomRight();
            return new Size(bottomRight.X - topLeft.X,
                bottomRight.Y - topLeft.Y);
        }

        public void RenderSprite(Bitmap render, int x, int y, int scale)
        {
            RenderSprite(render, x, y, scale, -1);
        }

        public void RenderSprite(Bitmap render, int x, int y, int scale, int highlight)
        {
            Size spriteSize = GetSpriteSize();
            if ((render.Width < spriteSize.Width) || (render.Height < spriteSize.Height))
                throw new Exception("Render area is smaller than sprite size.");

            // Get the top-left corner
            Point topLeft = GetSpriteTopLeft();

            // Render each subSprite
            for (int i = 0; i < NumSubSprites; i++)
            {
                subSprites[i].RenderSubSprite(render,
                    subSprites[i].OffsetX - topLeft.X + x,
                    subSprites[i].OffsetY - topLeft.Y + y,
                    scale, highlight == i);
            }
        }
    }
}

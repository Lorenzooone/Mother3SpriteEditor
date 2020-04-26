using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace MOTHER3SpriteEditor
{
    // TODO: Make this better for palette editing, etc.

    public class Palette
    {
        Color[] _pal = new Color[16];

        private int palAddress;
        private ROMHandler rom;
        private int mainentry;
        private Color? transparentColor;

        public int palSubBank;
        public int palBank;

        public int Address
        {
            get { return palAddress; }
        }

        public Palette(ROMHandler romFile, int bank, int mainEntry):this(romFile, bank, mainEntry, null){}

        public Palette(ROMHandler romFile, int bank, int mainEntry, Color? transparentColor)
        {
            // Bank is irrelevant? Requires ROM research; check if the
            // [0x100, 0x26B] custom range is applicable beyond bank 0
            
            //int palAddress;
            rom = romFile;
            mainentry = mainEntry;

            // Compute palBank
            palBank = ((mainEntry > 0xFF) && (mainEntry < 0x26C)) ? mainEntry - 0xFF : 0;

            // Compute palSubBank
            rom.Seek(ROMInfo.palInfoAddress + (mainEntry * 12));
            palSubBank = ((mainEntry > 0xFF) && (mainEntry < 0x26C)) ? 0 : (romFile.ReadByte() & 0xF);
            this.transparentColor = transparentColor;

            ComputePal();
        }

        public void ComputePal()
        {
            // Compute palAddress
            palAddress = ROMInfo.palStartAddress + rom.ReadWord(
                ROMInfo.palStartAddress + 4 + (palBank * 4)) +
                (palSubBank * 32);

            // Parse the palette data
            rom.Seek(palAddress);
            for (int i = 0; i < 16; i++)
            {
                if (i == 0 && transparentColor != null)
                {
                    _pal[i] = (Color)transparentColor;
                }
                else
                {
                    _pal[i] = rom.ReadColor();
                }
            }
        }

        public void SetPalSubBank(int palSubBank)
        {
            //Update palSubBank
            this.palSubBank = ((mainentry > 0xFF) && (mainentry < 0x26C)) ? 0 : (palSubBank & 0xF);
            
            ComputePal();
        }

        public bool savePalSubBank()
        {
            if (!((mainentry > 0xFF) && (mainentry < 0x26C)))
            {
                rom.Seek(ROMInfo.palInfoAddress + (mainentry * 12));
                int starting = rom.ReadByte();
                int rest = starting & 0xF0;
                int ending = rest | this.palSubBank;
                if (ending != starting)
                {
                    
                    rom.WriteByte(ROMInfo.palInfoAddress + (mainentry * 12), (byte)(rest | this.palSubBank));
                    return true;
                }
            }
            return false;
        }

        public Color[] GetPalette()
        {
            return _pal;
        }

        public Color GetColor(int index)
        {
            return _pal[index];
        }

        public void SetColor(int index, Color col)
        {
            _pal[index] = col;
        }

        public static void SetPalette(ROMHandler romFile, int entry, byte pal)
        {
            if (entry <= 0xFF || entry >= 0x26C)
            {
                int address = ROMInfo.palInfoAddress + (entry * 12);
                byte palSubBank = (byte)
                    (romFile.ReadByte(address) & 0xF0);
                palSubBank |= (byte)(pal & 0xF);
                romFile.WriteByte(address, palSubBank);
            }
        }

        public void SavePalette()
        {
            if (mainentry > 0xFF && mainentry < 0x26C)
            {
                int palBank;

                // Compute palBank
                palBank = mainentry - 0xFF;

                // Compute palSubBank
                rom.Seek(ROMInfo.palInfoAddress + (mainentry * 12));

                // Compute palAddress
                palAddress = ROMInfo.palStartAddress + rom.ReadWord(
                    ROMInfo.palStartAddress + 4 + (palBank << 2));
            }
            else
            {
                palAddress = ROMInfo.palStartAddress + rom.ReadWord(
                ROMInfo.palStartAddress + 4) + (palSubBank * 32);
            }

            // Write the colours
            rom.Seek(palAddress);
            for (int i = 0; i < 16; i++)
                rom.WriteColor(_pal[i]);
        }
    }
}

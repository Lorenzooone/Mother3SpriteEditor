using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;

/* TODO:
 * Copy/paste/etc
 */

namespace MOTHER3SpriteEditor
{
    public enum EditorTools
    {
        Erase = 0, Select,
        Eyedropper, Bucket,
        Pencil, Text,
        Line, Rect,
        Ellipse, RoundRect
    }

    public partial class frmMain : Form
    {
        // The ROM file handle
        FileStream romFile;
        ROMHandler romHandle;

        // The sprite handle
        Sprite sprite;

        // Editor objects
        ToolStripMenuItem[] mnuZoomLevels = new ToolStripMenuItem[5];
        ToolStripButton[] tbrTool = new ToolStripButton[10];
        ToolStripButton tbrToolFlipX;
        ToolStripButton tbrToolFlipY;
        ImageList imlTools = new ImageList();
        frmSpriteProperties frmProperties = new frmSpriteProperties();

        // The character names list
        string[] charNames;

        int curBank;
        int curTool = -1;
        int lastFind = -1;

        private int CurTool
        {
            get { return curTool; }
            set
            {
                int tmp = value;
                tbrTool_Checked(tbrTool[tmp], null);
                curTool = tmp;
            }
        }

        public frmMain()
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(frmMain_Closing);

            // Load the sprite names
            charNames = Properties.Resources.spriteNames.Split(new string[] { "\r\n" },
               StringSplitOptions.None);
            for (int i = 0; i < 1000; i++)
                charNames[i] = charNames[i].Substring(7);

            // Add the zoom menus
            for (int i = 0; i < mnuZoomLevels.Length; i++)
            {
                mnuZoomLevels[i] = new ToolStripMenuItem(((1 << i) * 100).ToString() + "%");
                mnuZoomLevels[i].Tag = (int)(1 << i);
                mnuZoomLevels[i].Click += new EventHandler(mnuZoomLevel_Click);
            }
            mnuZoom.DropDownItems.AddRange(mnuZoomLevels);
            //tbrZoom.DropDownItems.AddRange(mnuZoomLevels);

            // Add the tools
            toolStripTools.ImageList = imlTools;
            int visibleItemCount = 12;
            for (int i = 0; i < 10; i++)
            {
                tbrTool[i] = new ToolStripButton();
                tbrTool[i].Visible = true;
                tbrTool[i].Tag = i;
                tbrTool[i].Click += new EventHandler(tbrTool_Checked);
                switch ((EditorTools)i)
                {
                    case EditorTools.Ellipse:
                    case EditorTools.Line:
                    case EditorTools.Rect:
                    case EditorTools.RoundRect:
                    case EditorTools.Select:
                    case EditorTools.Text:
                        tbrTool[i].Enabled = false;
                        tbrTool[i].Visible = false;
                        visibleItemCount--;
                        break;
                }
            }

            tbrToolFlipX = new ToolStripButton();
            tbrToolFlipX.Visible = true;
            tbrToolFlipX.Click += new EventHandler(tbrToolFlipX_Click);

            tbrToolFlipY = new ToolStripButton();
            tbrToolFlipY.Visible = true;
            tbrToolFlipY.Click += new EventHandler(tbrToolFlipY_Click);

            #region Distinct properties
            tbrTool[0].Image = Properties.Resources.eraser;
            tbrTool[1].Image = Properties.Resources.select;
            tbrTool[2].Image = Properties.Resources.eyedropper;
            tbrTool[3].Image = Properties.Resources.bucket;
            tbrTool[4].Image = Properties.Resources.pencil;
            tbrTool[5].Image = Properties.Resources.text;
            tbrTool[6].Image = Properties.Resources.line;
            tbrTool[7].Image = Properties.Resources.rect;
            tbrTool[8].Image = Properties.Resources.ellipse;
            tbrTool[9].Image = Properties.Resources.roundrect;
            tbrToolFlipX.Image = Properties.Resources.arrow_leftright;
            tbrToolFlipY.Image = Properties.Resources.arrow_updown;

            tbrTool[0].ToolTipText = "Erase";
            tbrTool[1].ToolTipText = "Select";
            tbrTool[2].ToolTipText = "Dropper";
            tbrTool[3].ToolTipText = "Fill";
            tbrTool[4].ToolTipText = "Pencil";
            tbrTool[5].ToolTipText = "Text";
            tbrTool[6].ToolTipText = "Line";
            tbrTool[7].ToolTipText = "Rectangle";
            tbrTool[8].ToolTipText = "Ellipse";
            tbrTool[9].ToolTipText = "Rounded rectangle";
            tbrToolFlipX.ToolTipText = "Flip horizontally";
            tbrToolFlipY.ToolTipText = "Flip vertically";

            #endregion

            toolStripTools.Items.AddRange(tbrTool);
            toolStripTools.Items.Add(tbrToolFlipX);
            toolStripTools.Items.Add(tbrToolFlipY);

            toolStripTools.Height = ((visibleItemCount + 1) >> 1) * 23;
                
            lblZoom.Top = toolStripTools.Top + toolStripTools.Height + 6;
            trackZoom.Top = lblZoom.Top + lblZoom.Height + 6;

            // Anchor the editors
            spriteViewer.Left = this.ClientSize.Width - spriteViewer.Width - 6;
            lblSpritePreview.Left = spriteViewer.Left - 3;
            
            spriteEditor.Height = this.ClientSize.Height - spriteEditor.Top - 6;
            spriteEditor.Width = this.ClientSize.Width - spriteEditor.Left -
                spriteViewer.Width - 12;

            this.MinimumSize = new Size(
                grpSpriteSelector.Left + grpSpriteSelector.Width + 6 +
                (this.Width - this.ClientSize.Width),
                trackZoom.Top + trackZoom.Height + 6 +
                (this.Height - this.ClientSize.Height));

            mnuTxtFindSprite.KeyPress += new KeyPressEventHandler(mnuTxtFindSprite_KeyPress);
            mnuTxtFindSprite.GotFocus += new EventHandler(mnuTxtFindSprite_GotFocus);

            mnuTxtFindSprite.Text = "Type, then press Enter.";
            mnuTxtFindSprite.ForeColor = Color.Gray;

            EnableControls(false);
        }

        void mnuTxtFindSprite_GotFocus(object sender, EventArgs e)
        {
            mnuTxtFindSprite.Text = "";
            mnuTxtFindSprite.ForeColor = SystemColors.ControlText;
        }

        void mnuTxtFindSprite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !mnuTxtFindSprite.Text.Equals(""))
            {
                FindSprite(mnuTxtFindSprite.Text);
            }
        }

        void FindSprite(string find)
        {
            if (lastFind == -1)
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (charNames[i].ToLower().Contains(find.ToLower()))
                    {
                        lastFind = i;
                        cboMainEntry.SelectedIndex = i;
                        return;
                    }
                }
            }

            for (int i = lastFind + 1; i < 1000; i++)
            {
                if (charNames[i].ToLower().Contains(find.ToLower()))
                {
                    lastFind = i;
                    cboMainEntry.SelectedIndex = i;
                    return;
                }
            }
            for (int i = 0; i < lastFind; i++)
            {
                if (charNames[i].ToLower().Contains(find.ToLower()))
                {
                    lastFind = i;
                    cboMainEntry.SelectedIndex = i;
                    return;
                }
            }
        }

        void tbrToolFlipX_Click(object sender, EventArgs e)
        {
            // Flip vertically
            spriteEditor.FlipX();
        }

        void tbrToolFlipY_Click(object sender, EventArgs e)
        {
            // Flip horizontally
            spriteEditor.FlipY();
        }

        private void EnableControls(bool e)
        {
            mnuFileSave.Enabled =
                mnuFileClose.Enabled =
                spriteViewer.Enabled =
                spriteEditor.Enabled =
                trackZoom.Enabled =
                mnuZoom.Enabled =
                mnuGridLines.Enabled =
                mnuGridColor.Enabled =
                cboMainEntry.Enabled =
                nudSpriteEntry.Enabled =
                nudSubSprite.Enabled =
                rbtBank0.Enabled =
                rbtBank1.Enabled =
                rbtBank2.Enabled =
                rbtBank3.Enabled =
                toolStripTools.Enabled =
                mnuCopyImage.Enabled =
                mnuCopyImageFull.Enabled =
                mnuCopyImageSub.Enabled =
                mnuSavePNG.Enabled =
                mnuSavePNGFull.Enabled =
                mnuSavePNGSub.Enabled =
                //mnuEditCut.Enabled =
                //mnuEditCopy.Enabled =
                //mnuEditPaste.Enabled =
                //tbrCut.Enabled =
                //tbrCopy.Enabled =
                //tbrPaste.Enabled =
                mnuSpriteProperties.Enabled =
                mnuAutoSave.Enabled =
                mnuClearImage.Enabled =
                mnuFlipX.Enabled =
                mnuFlipY.Enabled =
                paletteSelector.Enabled =
                mnuGenerateSpritesheet.Enabled =
                mnuFindSprite.Enabled =
                mnuTxtFindSprite.Enabled =
                mnuFindNext.Enabled =
                mnuSwap.Enabled =
                mnuSelCol.Enabled =
                paletteBox.Enabled =
                confirmPalNumChange.Enabled = 
                e;
            foreach (Control c in grpSpriteSelector.Controls)
                c.Enabled = e;
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadFile()
        {
            // Assume romFile is not null, but check anyways
            if (romFile == null) 
                throw new Exception(
                    "Horrible error! Tried to load from a null FileStream.");

            // Initialize the sprite selector stuff
            rbtBank0.Checked = true;
            curBank = 0;
            cboMainEntry.Items.Clear();
            for (int i = 0; i < 1000; i++)
            {
                cboMainEntry.Items.Add(
                    String.Format("[{0}] {1}", i.ToString("X4"),
                    charNames[i]));
            }
            cboMainEntry.SelectedIndex = 0;

            sprite = new Sprite(romHandle, curBank,
                cboMainEntry.SelectedIndex,
                (int)nudSpriteEntry.Value);

            spriteViewer.Sprite = sprite;
            spriteEditor.Sprite = sprite;
            paletteSelector.Sprite = sprite;
            frmProperties.Sprite = sprite;

            spriteEditor.AddViewer(spriteViewer);
            spriteEditor.AddViewer(frmProperties.SpriteViewer);
            frmProperties.AddViewer(spriteViewer);
            frmProperties.AddEditor(spriteEditor);
            paletteSelector.AddEditor(spriteEditor);
            spriteEditor.PalSelector = paletteSelector;
            spriteEditor.PalIndex = paletteSelector.PalIndex;

            spriteEditor.ScaleFactor = trackZoom.Value;
            spriteEditor.GridLines = mnuGridLines.Checked;
            spriteEditor.GridColor = dlgGridColor.Color;
            spriteEditor.SelColor = Color.Blue;

            spriteViewer.ScaleFactor = 1;

            EnableControls(true);

            tbrTool_Checked(tbrTool[(int)EditorTools.Pencil], null);
        }

        private void ApplyChanges()
        {
            if (spriteEditor.IsChanged)
            {
                sprite.Pal.SavePalette();
                sprite.ApplyChanges();
                //spriteEditor.IsChanged = false;
            }
        }

        private void CloseROM()
        {
            sprite = null;
            spriteEditor.Sprite = null;
            spriteViewer.Sprite = null;
            paletteSelector.Sprite = null;
            frmProperties.Sprite = null;
            spriteEditor.IsChanged = false;
            spriteEditor.RenderSelection = false;
            romFile.Close();
            romFile = null;
            romHandle = null;
            tbrTool[curTool].Checked = false;
            curTool = -1;
            EnableControls(false); 
        }

        private void frmMain_Closing(object sender, FormClosingEventArgs e)
        {
            if (romFile == null)
            {
                return;
            }

            if (spriteEditor.IsChanged)
            {
                switch (MessageBox.Show(
                    "Do you wish to save your changes?",
                    "Save changes",
                    MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        return;
                    case DialogResult.Yes:
                        ApplyChanges();
                        break;
                    default:
                        break;
                }
            }

            CloseROM();
            Properties.Settings.Default.Save();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout fAbout = new frmAbout();
            fAbout.ShowDialog();
            fAbout.Dispose();
        }

        private void mnuFileOpenROM_Click(object sender, EventArgs e)
        {
            // If a file is already open, ask if they want to save changes
            //   If yes, save changes
            //   If cancel, return
            //   Close the rom
            // Open new rom

            // TODO: Generalize this stuff into one method
            if (romFile != null)
            {
                if (spriteEditor.IsChanged)
                {
                    switch (MessageBox.Show(
                        "Do you wish to save your changes?",
                        "Save changes",
                        MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Yes:
                            ApplyChanges();
                            break;
                        default:
                            break;
                    }
                }
                CloseROM();
            }

            if (dlgOpenROM.ShowDialog() == DialogResult.OK)
            {
                romFile = File.Open(dlgOpenROM.FileName, FileMode.Open);
                if (!ROMInfo.IsMother3ROM(romFile))
                {
                    MessageBox.Show("The selected ROM could not be identified as MOTHER 3.", "Error");
                    CloseROM();
                    return;
                }
                Application.DoEvents();
                romHandle = new ROMHandler(romFile);
                LoadFile();
            }
        }

        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            if (spriteEditor.IsChanged)
            {
                switch (MessageBox.Show(
                    "Do you wish to save your changes?",
                    "Save changes",
                    MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        ApplyChanges();
                        break;
                    default:
                        break;
                }
            }

            CloseROM();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            romHandle.SaveChanges();
            spriteEditor.IsChanged = false;
        }

        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            spriteEditor.ScaleFactor = trackZoom.Value;
        }

        private void mnuZoomLevel_Click(object sender, EventArgs e)
        {
            trackZoom.Value = (int)((ToolStripMenuItem)sender).Tag;
            trackZoom_Scroll(null, null);
        }

        private void mnuGridLines_Click(object sender, EventArgs e)
        {
            spriteEditor.GridLines = mnuGridLines.Checked;
        }

        private void mnuGridColor_Click(object sender, EventArgs e)
        {
            if (dlgGridColor.ShowDialog() == DialogResult.OK)
            {
                spriteEditor.GridColor = dlgGridColor.Color;
            }
        }

        private void nudSpriteEntry_ValueChanged(object sender, EventArgs e)
        {
            ApplyChanges();
            nudSubSprite.Value = 0;
            UpdateReferences();
            if (sprite.NumSubSprites <= 0)
            {
                nudSubSprite.Enabled = false;
            }
            else
            {
                nudSubSprite.Enabled = true;
                nudSubSprite.Maximum = sprite.NumSubSprites - 1;
            }
        }

        private void CheckBanks()
        {
            if (rbtBank0.Checked) curBank = 0;
            if (rbtBank1.Checked) curBank = 1;
            if (rbtBank2.Checked) curBank = 2;
            if (rbtBank3.Checked) curBank = 3;

            sprite = new Sprite(romHandle, curBank, cboMainEntry.SelectedIndex, 0);
            UpdateReferences();
            cboMainEntry_SelectedIndexChanged(null, null);
        }

        private void cboMainEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyChanges();
            nudSpriteEntry.Value = 0;
            nudSubSprite.Value = 0;
            UpdateReferences();

            if (sprite.NumSprites <= 0)
            {
                nudSpriteEntry.Enabled = false;
            }
            else
            {
                nudSpriteEntry.Enabled = true;
                nudSpriteEntry.Maximum = sprite.NumSprites - 1;
            }

            if (sprite.NumSubSprites <= 0)
            {
                nudSubSprite.Enabled = false;
            }
            else
            {
                nudSubSprite.Enabled = true;
                nudSubSprite.Maximum = sprite.NumSubSprites - 1;
            }
        }

        private void UpdateReferences()
        {
            sprite = new Sprite(romHandle, curBank,
                cboMainEntry.SelectedIndex,
                (int)nudSpriteEntry.Value);
            updateEditors();
            paletteBox.setSprite(sprite);
        }

        private void nudSubSprite_ValueChanged(object sender, EventArgs e)
        {
            spriteEditor.SubSprite = (int)nudSubSprite.Value;
        }

        private void rbtBank0_CheckedChanged(object sender, EventArgs e)
        {
            CheckBanks();
        }

        private void rbtBank1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBanks();
        }

        private void rbtBank2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBanks();
        }

        private void rbtBank3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBanks();
        }

        private void tbrTool_Checked(object sender, EventArgs e)
        {
            int index;
            for (index = 0; index < 10; index++)
            {
                if (tbrTool[index] == sender) break;
            }
            if (index >= 10) return;
            if (index == curTool) return;

            if (curTool >= 0) tbrTool[curTool].Checked = false;
            tbrTool[index].Checked = true;
            spriteEditor.curTool = (EditorTools)index;
            if ((EditorTools)curTool == EditorTools.Select)
                spriteEditor.PasteSelection();

            curTool = index;
        }

        private void mnuCopyImageFull_Click(object sender, EventArgs e)
        {
            Size spriteSize = sprite.GetSpriteSize();
            Bitmap toSave = new Bitmap(spriteSize.Width, 
                spriteSize.Height, 
                PixelFormat.Format32bppArgb);
            sprite.RenderSprite(toSave, 0, 0, 1);
            Clipboard.SetImage(toSave);
            toSave.Dispose();
        }

        private void mnuCopyImageSub_Click(object sender, EventArgs e)
        {
            Sprite.SubSprite subSprite = spriteEditor.GetSubSprite;
            Bitmap toSave = new Bitmap(subSprite.WidthInPixels,
                subSprite.HeightInPixels, 
                PixelFormat.Format32bppArgb);
            subSprite.RenderSubSprite(toSave, 0, 0, 1, false);
            Clipboard.SetImage(toSave);
            toSave.Dispose();
        }

        private void mnuSavePNGFull_Click(object sender, EventArgs e)
        {
            if (dlgSavePNG.ShowDialog() == DialogResult.OK)
            {
                Size spriteSize = sprite.GetSpriteSize();
                Bitmap toSave = new Bitmap(spriteSize.Width,
                    spriteSize.Height,
                    PixelFormat.Format32bppArgb);
                sprite.RenderSprite(toSave, 0, 0, 1);
                toSave.Save(dlgSavePNG.FileName, ImageFormat.Png);
                toSave.Dispose();
            }
        }

        private void mnuSavePNGSub_Click(object sender, EventArgs e)
        {
            if (dlgSavePNG.ShowDialog() == DialogResult.OK)
            {
                Sprite.SubSprite subSprite = spriteEditor.GetSubSprite;
                Bitmap toSave = new Bitmap(subSprite.WidthInPixels,
                    subSprite.HeightInPixels,
                    PixelFormat.Format32bppArgb);
                subSprite.RenderSubSprite(toSave, 0, 0, 1, false);
                toSave.Save(dlgSavePNG.FileName, ImageFormat.Png);
                toSave.Dispose();
            }
        }

        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            CurTool = (int)EditorTools.Select;
            spriteEditor.CutSelection();
        }

        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            CurTool = (int)EditorTools.Select;
            spriteEditor.CopySelection();
        }

        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            CurTool = (int)EditorTools.Select;
            spriteEditor.RenderSelection = true;
        }

        private void mnuSpriteProperties_Click(object sender, EventArgs e)
        {
            frmProperties.Show();
        }

        private void mnuClearImage_Click(object sender, EventArgs e)
        {
            spriteEditor.ClearImage();
        }

        private void mnuFlipX_Click(object sender, EventArgs e)
        {
            tbrToolFlipX_Click(null, null);
        }

        private void mnuFlipY_Click(object sender, EventArgs e)
        {
            tbrToolFlipY_Click(null, null);
        }

        private void mnuGenerateSpritesheet_Click(object sender, EventArgs e)
        {
            if (dlgSavePNG.ShowDialog() == DialogResult.OK)
            {
                int margin = 12; // margin on all sides
                int spacing = 8; // pixels between each sprite on all sides
                int cols = 8; // number of columns of sprites
                int curEntry = cboMainEntry.SelectedIndex;

                // Figure out how large the sheet should be

                // For each row, get the largest height and width
                Sprite curSprite;
                Size sprSize;
                int maxHeight = 0;
                int maxWidth = 0;
                int ctHeight = margin;
                int ctWidth = margin;
                int numSprites = 0;
                for (int j = 0; j < sprite.NumSprites; j += cols)
                {
                    ctWidth = margin;
                    maxHeight = 0;
                    for (int i = 0; i < cols && (i + j) < sprite.NumSprites; i++)
                    {
                        curSprite = new Sprite(romHandle, curBank,
                            curEntry, i + j);
                        if (curSprite.NumSubSprites > 0)
                        {
                            numSprites++;
                            sprSize = curSprite.GetSpriteSize();
                            ctWidth += sprSize.Width + spacing;
                            if (sprSize.Height > maxHeight)
                                maxHeight = sprSize.Height;
                        }
                    }
                    ctHeight += maxHeight + spacing;
                    if (ctWidth > maxWidth)
                        maxWidth = ctWidth;
                }

                int textHeight = 32;
                Bitmap bSheet = new Bitmap(maxWidth - spacing + margin,
                    ctHeight - spacing + margin + textHeight,
                    PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bSheet);
                g.FillRectangle(Brushes.White, 0, 0, bSheet.Width, bSheet.Height);

                // Write some text info
                g.DrawString(String.Format(
                    "Bank {0}, Entry 0x{1:X4}: \"{2}\"\n" +
                    "{3} sprites total",
                    curBank, curEntry, charNames[curEntry], numSprites),
                    SystemFonts.DefaultFont, Brushes.Black, 0, 0,
                    StringFormat.GenericDefault);

                g.Dispose();

                // Render the sheet
                ctWidth = margin;
                ctHeight = margin + textHeight;
                for (int j = 0; j < sprite.NumSprites; j += cols)
                {
                    ctWidth = margin;
                    maxHeight = 0;
                    for (int i = 0; i < cols && (i + j) < sprite.NumSprites; i++)
                    {
                        curSprite = new Sprite(romHandle, curBank,
                            cboMainEntry.SelectedIndex, i + j);
                        if (curSprite.NumSubSprites > 0)
                        {
                            curSprite.RenderSprite(bSheet, ctWidth, ctHeight, 1);
                            sprSize = curSprite.GetSpriteSize();
                            ctWidth += sprSize.Width + spacing;
                            if (sprSize.Height > maxHeight)
                                maxHeight = sprSize.Height;
                        }
                    }
                    ctHeight += maxHeight + spacing;
                }

                bSheet.Save(dlgSavePNG.FileName, ImageFormat.Png);
            }
        }

        private void mnuFindNext_Click(object sender, EventArgs e)
        {
            FindSprite(mnuTxtFindSprite.Text);
        }

        private void mnuAutoSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoSave =
                mnuAutoSave.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // not done yet
            Palette.SetPalette(romHandle, cboMainEntry.SelectedIndex, 1);
            sprite.Pal = new Palette(romHandle, curBank, cboMainEntry.SelectedIndex);
            cboMainEntry_SelectedIndexChanged(null, null);
        }

        private void mnuSwap_Click(object sender, EventArgs e)
        {
            frmSwap f = new frmSwap(cboMainEntry, romHandle, curBank);
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.OK)
            {
                cboMainEntry_SelectedIndexChanged(null, null);
            }
        }

        private void paletteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            paletteBox.sprite = sprite;
            paletteBox.setSpriteSubPalette();
            spriteViewer.UpdateView();
            spriteEditor.UpdateView();
            paletteSelector.UpdateView();
            frmProperties.Sprite = sprite;
        }

        private void updateEditors()
        {
            spriteViewer.Sprite = sprite;
            spriteEditor.Sprite = sprite;
            paletteSelector.Sprite = sprite;
            frmProperties.Sprite = sprite;
        }

        private void confirmPalNumChange_Click(object sender, EventArgs e)
        {
            if (sprite.Pal.savePalSubBank())
                spriteEditor.IsChanged = true;
        }
    }
}

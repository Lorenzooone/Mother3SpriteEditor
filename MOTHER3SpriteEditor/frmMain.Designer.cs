namespace MOTHER3SpriteEditor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dlgOpenROM = new System.Windows.Forms.OpenFileDialog();
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenROM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGridColor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelCol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFindSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTxtFindSprite = new System.Windows.Forms.ToolStripTextBox();
            this.mnuFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSavePNG = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSavePNGFull = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSavePNGSub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyImageFull = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyImageSub = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGenerateSpritesheet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSpriteProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSwap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboZoomEditor = new System.Windows.Forms.ToolStripComboBox();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.dlgGridColor = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMainEntry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSpriteEntry = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSubSprite = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtBank0 = new System.Windows.Forms.RadioButton();
            this.rbtBank1 = new System.Windows.Forms.RadioButton();
            this.rbtBank2 = new System.Windows.Forms.RadioButton();
            this.rbtBank3 = new System.Windows.Forms.RadioButton();
            this.lblZoom = new System.Windows.Forms.Label();
            this.lblSpritePreview = new System.Windows.Forms.Label();
            this.grpSpriteSelector = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paletteSelector = new MOTHER3SpriteEditor.PaletteSelector();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.pPalette = new System.Windows.Forms.PictureBox();
            this.dlgSavePNG = new System.Windows.Forms.SaveFileDialog();
            this.dlgSelColor = new System.Windows.Forms.ColorDialog();
            this.paletteLbl = new System.Windows.Forms.Label();
            this.paletteBox = new MOTHER3SpriteEditor.SubPaletteSpriteSelector();
            this.spriteEditor = new MOTHER3SpriteEditor.EditorInterface();
            this.spriteViewer = new MOTHER3SpriteEditor.ViewerInterface();
            this.confirmPalNumChange = new System.Windows.Forms.Button();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpriteEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubSprite)).BeginInit();
            this.grpSpriteSelector.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpenROM
            // 
            this.dlgOpenROM.Filter = "GBA Files (*.gba)|*.gba|All Files (*.*)|*.*";
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuImage,
            this.mnuTools,
            this.mnuAbout});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(701, 24);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenROM,
            this.mnuFileSave,
            this.mnuFileClose,
            this.toolStripMenuItem1,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpenROM
            // 
            this.mnuFileOpenROM.Image = global::MOTHER3SpriteEditor.Properties.Resources.open;
            this.mnuFileOpenROM.Name = "mnuFileOpenROM";
            this.mnuFileOpenROM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpenROM.Size = new System.Drawing.Size(193, 22);
            this.mnuFileOpenROM.Text = "&Open ROM...";
            this.mnuFileOpenROM.Click += new System.EventHandler(this.mnuFileOpenROM_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Enabled = false;
            this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(193, 22);
            this.mnuFileSave.Text = "&Save changes";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileClose
            // 
            this.mnuFileClose.Enabled = false;
            this.mnuFileClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileClose.Image")));
            this.mnuFileClose.Name = "mnuFileClose";
            this.mnuFileClose.Size = new System.Drawing.Size(193, 22);
            this.mnuFileClose.Text = "&Close ROM";
            this.mnuFileClose.Click += new System.EventHandler(this.mnuFileClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(193, 22);
            this.mnuFileExit.Text = "&Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.toolStripMenuItem2,
            this.mnuZoom,
            this.mnuGridLines,
            this.mnuGridColor,
            this.mnuSelCol,
            this.toolStripMenuItem4,
            this.mnuFindSprite,
            this.mnuFindNext});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Enabled = false;
            this.mnuEditCut.Image = global::MOTHER3SpriteEditor.Properties.Resources.cut;
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.Size = new System.Drawing.Size(161, 22);
            this.mnuEditCut.Text = "C&ut";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Enabled = false;
            this.mnuEditCopy.Image = global::MOTHER3SpriteEditor.Properties.Resources.page_copy;
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.Size = new System.Drawing.Size(161, 22);
            this.mnuEditCopy.Text = "&Copy";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Enabled = false;
            this.mnuEditPaste.Image = global::MOTHER3SpriteEditor.Properties.Resources.paste_plain;
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.Size = new System.Drawing.Size(161, 22);
            this.mnuEditPaste.Text = "&Paste";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuZoom
            // 
            this.mnuZoom.Enabled = false;
            this.mnuZoom.Image = global::MOTHER3SpriteEditor.Properties.Resources.zoom;
            this.mnuZoom.Name = "mnuZoom";
            this.mnuZoom.Size = new System.Drawing.Size(161, 22);
            this.mnuZoom.Text = "&Zoom";
            // 
            // mnuGridLines
            // 
            this.mnuGridLines.Checked = true;
            this.mnuGridLines.CheckOnClick = true;
            this.mnuGridLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuGridLines.Enabled = false;
            this.mnuGridLines.Name = "mnuGridLines";
            this.mnuGridLines.Size = new System.Drawing.Size(161, 22);
            this.mnuGridLines.Text = "&Grid lines";
            this.mnuGridLines.Click += new System.EventHandler(this.mnuGridLines_Click);
            // 
            // mnuGridColor
            // 
            this.mnuGridColor.Enabled = false;
            this.mnuGridColor.Name = "mnuGridColor";
            this.mnuGridColor.Size = new System.Drawing.Size(161, 22);
            this.mnuGridColor.Text = "G&rid color...";
            this.mnuGridColor.Click += new System.EventHandler(this.mnuGridColor_Click);
            // 
            // mnuSelCol
            // 
            this.mnuSelCol.Enabled = false;
            this.mnuSelCol.Name = "mnuSelCol";
            this.mnuSelCol.Size = new System.Drawing.Size(161, 22);
            this.mnuSelCol.Text = "Selection color...";
            this.mnuSelCol.Visible = false;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuFindSprite
            // 
            this.mnuFindSprite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTxtFindSprite});
            this.mnuFindSprite.Enabled = false;
            this.mnuFindSprite.Name = "mnuFindSprite";
            this.mnuFindSprite.Size = new System.Drawing.Size(161, 22);
            this.mnuFindSprite.Text = "Find sprite";
            // 
            // mnuTxtFindSprite
            // 
            this.mnuTxtFindSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mnuTxtFindSprite.Enabled = false;
            this.mnuTxtFindSprite.Name = "mnuTxtFindSprite";
            this.mnuTxtFindSprite.Size = new System.Drawing.Size(150, 23);
            // 
            // mnuFindNext
            // 
            this.mnuFindNext.Enabled = false;
            this.mnuFindNext.Name = "mnuFindNext";
            this.mnuFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mnuFindNext.Size = new System.Drawing.Size(161, 22);
            this.mnuFindNext.Text = "Find next";
            this.mnuFindNext.Click += new System.EventHandler(this.mnuFindNext_Click);
            // 
            // mnuImage
            // 
            this.mnuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClearImage,
            this.mnuFlipX,
            this.mnuFlipY});
            this.mnuImage.Name = "mnuImage";
            this.mnuImage.Size = new System.Drawing.Size(52, 20);
            this.mnuImage.Text = "&Image";
            // 
            // mnuClearImage
            // 
            this.mnuClearImage.Enabled = false;
            this.mnuClearImage.Name = "mnuClearImage";
            this.mnuClearImage.Size = new System.Drawing.Size(158, 22);
            this.mnuClearImage.Text = "&Clear image";
            this.mnuClearImage.Click += new System.EventHandler(this.mnuClearImage_Click);
            // 
            // mnuFlipX
            // 
            this.mnuFlipX.Enabled = false;
            this.mnuFlipX.Image = global::MOTHER3SpriteEditor.Properties.Resources.arrow_leftright;
            this.mnuFlipX.Name = "mnuFlipX";
            this.mnuFlipX.Size = new System.Drawing.Size(158, 22);
            this.mnuFlipX.Text = "Flip &horizontally";
            this.mnuFlipX.Click += new System.EventHandler(this.mnuFlipX_Click);
            // 
            // mnuFlipY
            // 
            this.mnuFlipY.Enabled = false;
            this.mnuFlipY.Image = global::MOTHER3SpriteEditor.Properties.Resources.arrow_updown;
            this.mnuFlipY.Name = "mnuFlipY";
            this.mnuFlipY.Size = new System.Drawing.Size(158, 22);
            this.mnuFlipY.Text = "Flip &vertically";
            this.mnuFlipY.Click += new System.EventHandler(this.mnuFlipY_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSavePNG,
            this.mnuCopyImage,
            this.mnuGenerateSpritesheet,
            this.toolStripMenuItem3,
            this.mnuSpriteProperties,
            this.mnuAutoSave,
            this.mnuSwap,
            this.toolStripMenuItem5,
            this.importToolStripMenuItem});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuSavePNG
            // 
            this.mnuSavePNG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSavePNGFull,
            this.mnuSavePNGSub});
            this.mnuSavePNG.Enabled = false;
            this.mnuSavePNG.Name = "mnuSavePNG";
            this.mnuSavePNG.Size = new System.Drawing.Size(205, 22);
            this.mnuSavePNG.Text = "Save as &PNG";
            // 
            // mnuSavePNGFull
            // 
            this.mnuSavePNGFull.Enabled = false;
            this.mnuSavePNGFull.Name = "mnuSavePNGFull";
            this.mnuSavePNGFull.Size = new System.Drawing.Size(137, 22);
            this.mnuSavePNGFull.Text = "Full sprite...";
            this.mnuSavePNGFull.Click += new System.EventHandler(this.mnuSavePNGFull_Click);
            // 
            // mnuSavePNGSub
            // 
            this.mnuSavePNGSub.Enabled = false;
            this.mnuSavePNGSub.Name = "mnuSavePNGSub";
            this.mnuSavePNGSub.Size = new System.Drawing.Size(137, 22);
            this.mnuSavePNGSub.Text = "Sub-sprite...";
            this.mnuSavePNGSub.Click += new System.EventHandler(this.mnuSavePNGSub_Click);
            // 
            // mnuCopyImage
            // 
            this.mnuCopyImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopyImageFull,
            this.mnuCopyImageSub});
            this.mnuCopyImage.Enabled = false;
            this.mnuCopyImage.Name = "mnuCopyImage";
            this.mnuCopyImage.Size = new System.Drawing.Size(205, 22);
            this.mnuCopyImage.Text = "&Copy image to clipboard";
            // 
            // mnuCopyImageFull
            // 
            this.mnuCopyImageFull.Enabled = false;
            this.mnuCopyImageFull.Name = "mnuCopyImageFull";
            this.mnuCopyImageFull.Size = new System.Drawing.Size(128, 22);
            this.mnuCopyImageFull.Text = "Full sprite";
            this.mnuCopyImageFull.Click += new System.EventHandler(this.mnuCopyImageFull_Click);
            // 
            // mnuCopyImageSub
            // 
            this.mnuCopyImageSub.Enabled = false;
            this.mnuCopyImageSub.Name = "mnuCopyImageSub";
            this.mnuCopyImageSub.Size = new System.Drawing.Size(128, 22);
            this.mnuCopyImageSub.Text = "Sub-sprite";
            this.mnuCopyImageSub.Click += new System.EventHandler(this.mnuCopyImageSub_Click);
            // 
            // mnuGenerateSpritesheet
            // 
            this.mnuGenerateSpritesheet.Enabled = false;
            this.mnuGenerateSpritesheet.Name = "mnuGenerateSpritesheet";
            this.mnuGenerateSpritesheet.Size = new System.Drawing.Size(205, 22);
            this.mnuGenerateSpritesheet.Text = "Generate spritesheet...";
            this.mnuGenerateSpritesheet.Click += new System.EventHandler(this.mnuGenerateSpritesheet_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 6);
            // 
            // mnuSpriteProperties
            // 
            this.mnuSpriteProperties.Enabled = false;
            this.mnuSpriteProperties.Name = "mnuSpriteProperties";
            this.mnuSpriteProperties.Size = new System.Drawing.Size(205, 22);
            this.mnuSpriteProperties.Text = "&Sprite properties...";
            this.mnuSpriteProperties.Click += new System.EventHandler(this.mnuSpriteProperties_Click);
            // 
            // mnuAutoSave
            // 
            this.mnuAutoSave.Checked = global::MOTHER3SpriteEditor.Properties.Settings.Default.AutoSave;
            this.mnuAutoSave.CheckOnClick = true;
            this.mnuAutoSave.Enabled = false;
            this.mnuAutoSave.Name = "mnuAutoSave";
            this.mnuAutoSave.Size = new System.Drawing.Size(205, 22);
            this.mnuAutoSave.Text = "&Auto-save";
            this.mnuAutoSave.Visible = false;
            this.mnuAutoSave.Click += new System.EventHandler(this.mnuAutoSave_Click);
            // 
            // mnuSwap
            // 
            this.mnuSwap.Enabled = false;
            this.mnuSwap.Name = "mnuSwap";
            this.mnuSwap.Size = new System.Drawing.Size(205, 22);
            this.mnuSwap.Text = "Swap entries...";
            this.mnuSwap.Click += new System.EventHandler(this.mnuSwap_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem5.Text = "Export binary...";
            this.toolStripMenuItem5.Enabled = false;
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(61, 20);
            this.mnuAbout.Text = "&About...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboZoomEditor});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // cboZoomEditor
            // 
            this.cboZoomEditor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZoomEditor.Items.AddRange(new object[] {
            "100%",
            "200%",
            "400%",
            "800%",
            "1600%"});
            this.cboZoomEditor.Name = "cboZoomEditor";
            this.cboZoomEditor.Size = new System.Drawing.Size(121, 23);
            // 
            // trackZoom
            // 
            this.trackZoom.Enabled = false;
            this.trackZoom.LargeChange = 1;
            this.trackZoom.Location = new System.Drawing.Point(6, 280);
            this.trackZoom.Maximum = 16;
            this.trackZoom.Minimum = 1;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackZoom.Size = new System.Drawing.Size(45, 128);
            this.trackZoom.TabIndex = 4;
            this.trackZoom.Value = 8;
            this.trackZoom.Scroll += new System.EventHandler(this.trackZoom_Scroll);
            // 
            // dlgGridColor
            // 
            this.dlgGridColor.AnyColor = true;
            this.dlgGridColor.Color = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Character:";
            // 
            // cboMainEntry
            // 
            this.cboMainEntry.DropDownHeight = 210;
            this.cboMainEntry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMainEntry.Enabled = false;
            this.cboMainEntry.FormattingEnabled = true;
            this.cboMainEntry.IntegralHeight = false;
            this.cboMainEntry.Location = new System.Drawing.Point(70, 19);
            this.cboMainEntry.Name = "cboMainEntry";
            this.cboMainEntry.Size = new System.Drawing.Size(216, 21);
            this.cboMainEntry.TabIndex = 7;
            this.cboMainEntry.SelectedIndexChanged += new System.EventHandler(this.cboMainEntry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sprite:";
            // 
            // nudSpriteEntry
            // 
            this.nudSpriteEntry.Enabled = false;
            this.nudSpriteEntry.Location = new System.Drawing.Point(70, 46);
            this.nudSpriteEntry.Name = "nudSpriteEntry";
            this.nudSpriteEntry.Size = new System.Drawing.Size(55, 20);
            this.nudSpriteEntry.TabIndex = 9;
            this.nudSpriteEntry.ValueChanged += new System.EventHandler(this.nudSpriteEntry_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sub-sprite:";
            // 
            // nudSubSprite
            // 
            this.nudSubSprite.Enabled = false;
            this.nudSubSprite.Location = new System.Drawing.Point(231, 46);
            this.nudSubSprite.Name = "nudSubSprite";
            this.nudSubSprite.Size = new System.Drawing.Size(55, 20);
            this.nudSubSprite.TabIndex = 11;
            this.nudSubSprite.ValueChanged += new System.EventHandler(this.nudSubSprite_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bank:";
            // 
            // rbtBank0
            // 
            this.rbtBank0.AutoSize = true;
            this.rbtBank0.Checked = true;
            this.rbtBank0.Enabled = false;
            this.rbtBank0.Location = new System.Drawing.Point(333, 20);
            this.rbtBank0.Name = "rbtBank0";
            this.rbtBank0.Size = new System.Drawing.Size(59, 17);
            this.rbtBank0.TabIndex = 13;
            this.rbtBank0.TabStop = true;
            this.rbtBank0.Text = "Bank 0";
            this.rbtBank0.UseVisualStyleBackColor = true;
            this.rbtBank0.CheckedChanged += new System.EventHandler(this.rbtBank0_CheckedChanged);
            // 
            // rbtBank1
            // 
            this.rbtBank1.AutoSize = true;
            this.rbtBank1.Enabled = false;
            this.rbtBank1.Location = new System.Drawing.Point(398, 20);
            this.rbtBank1.Name = "rbtBank1";
            this.rbtBank1.Size = new System.Drawing.Size(59, 17);
            this.rbtBank1.TabIndex = 14;
            this.rbtBank1.Text = "Bank 1";
            this.rbtBank1.UseVisualStyleBackColor = true;
            this.rbtBank1.CheckedChanged += new System.EventHandler(this.rbtBank1_CheckedChanged);
            // 
            // rbtBank2
            // 
            this.rbtBank2.AutoSize = true;
            this.rbtBank2.Enabled = false;
            this.rbtBank2.Location = new System.Drawing.Point(333, 43);
            this.rbtBank2.Name = "rbtBank2";
            this.rbtBank2.Size = new System.Drawing.Size(59, 17);
            this.rbtBank2.TabIndex = 15;
            this.rbtBank2.Text = "Bank 2";
            this.rbtBank2.UseVisualStyleBackColor = true;
            this.rbtBank2.CheckedChanged += new System.EventHandler(this.rbtBank2_CheckedChanged);
            // 
            // rbtBank3
            // 
            this.rbtBank3.AutoSize = true;
            this.rbtBank3.Enabled = false;
            this.rbtBank3.Location = new System.Drawing.Point(398, 43);
            this.rbtBank3.Name = "rbtBank3";
            this.rbtBank3.Size = new System.Drawing.Size(59, 17);
            this.rbtBank3.TabIndex = 16;
            this.rbtBank3.Text = "Bank 3";
            this.rbtBank3.UseVisualStyleBackColor = true;
            this.rbtBank3.CheckedChanged += new System.EventHandler(this.rbtBank3_CheckedChanged);
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(7, 264);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(37, 13);
            this.lblZoom.TabIndex = 17;
            this.lblZoom.Text = "Zoom:";
            // 
            // lblSpritePreview
            // 
            this.lblSpritePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpritePreview.AutoSize = true;
            this.lblSpritePreview.Location = new System.Drawing.Point(580, 207);
            this.lblSpritePreview.Name = "lblSpritePreview";
            this.lblSpritePreview.Size = new System.Drawing.Size(77, 13);
            this.lblSpritePreview.TabIndex = 18;
            this.lblSpritePreview.Text = "Sprite preview:";
            // 
            // grpSpriteSelector
            // 
            this.grpSpriteSelector.Controls.Add(this.cboMainEntry);
            this.grpSpriteSelector.Controls.Add(this.label1);
            this.grpSpriteSelector.Controls.Add(this.label2);
            this.grpSpriteSelector.Controls.Add(this.nudSpriteEntry);
            this.grpSpriteSelector.Controls.Add(this.rbtBank3);
            this.grpSpriteSelector.Controls.Add(this.label3);
            this.grpSpriteSelector.Controls.Add(this.rbtBank2);
            this.grpSpriteSelector.Controls.Add(this.nudSubSprite);
            this.grpSpriteSelector.Controls.Add(this.rbtBank1);
            this.grpSpriteSelector.Controls.Add(this.label4);
            this.grpSpriteSelector.Controls.Add(this.rbtBank0);
            this.grpSpriteSelector.Location = new System.Drawing.Point(217, 27);
            this.grpSpriteSelector.Name = "grpSpriteSelector";
            this.grpSpriteSelector.Size = new System.Drawing.Size(462, 75);
            this.grpSpriteSelector.TabIndex = 19;
            this.grpSpriteSelector.TabStop = false;
            this.grpSpriteSelector.Text = "Sprite selector";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.paletteSelector);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 75);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Palette";
            // 
            // paletteSelector
            // 
            this.paletteSelector.Enabled = false;
            this.paletteSelector.Location = new System.Drawing.Point(8, 22);
            this.paletteSelector.Name = "paletteSelector";
            this.paletteSelector.Size = new System.Drawing.Size(182, 38);
            this.paletteSelector.Sprite = null;
            this.paletteSelector.TabIndex = 5;
            // 
            // toolStripTools
            // 
            this.toolStripTools.AutoSize = false;
            this.toolStripTools.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripTools.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripTools.Enabled = false;
            this.toolStripTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripTools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripTools.Location = new System.Drawing.Point(2, 108);
            this.toolStripTools.Name = "toolStripTools";
            this.toolStripTools.Size = new System.Drawing.Size(57, 156);
            this.toolStripTools.TabIndex = 21;
            // 
            // pPalette
            // 
            this.pPalette.Image = global::MOTHER3SpriteEditor.Properties.Resources.palette;
            this.pPalette.Location = new System.Drawing.Point(11, 26);
            this.pPalette.Name = "pPalette";
            this.pPalette.Size = new System.Drawing.Size(16, 16);
            this.pPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pPalette.TabIndex = 23;
            this.pPalette.TabStop = false;
            // 
            // dlgSavePNG
            // 
            this.dlgSavePNG.Filter = "PNG Image|*.png";
            // 
            // dlgSelColor
            // 
            this.dlgSelColor.AnyColor = true;
            this.dlgSelColor.Color = System.Drawing.Color.Blue;
            // 
            // paletteLbl
            // 
            this.paletteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteLbl.AutoSize = true;
            this.paletteLbl.Location = new System.Drawing.Point(597, 264);
            this.paletteLbl.Name = "paletteLbl";
            this.paletteLbl.Size = new System.Drawing.Size(43, 13);
            this.paletteLbl.TabIndex = 24;
            this.paletteLbl.Text = "Palette:";
            // 
            // paletteBox
            // 
            this.paletteBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteBox.DropDownHeight = 210;
            this.paletteBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paletteBox.Enabled = false;
            this.paletteBox.FormattingEnabled = true;
            this.paletteBox.IntegralHeight = false;
            this.paletteBox.Location = new System.Drawing.Point(600, 280);
            this.paletteBox.Name = "paletteBox";
            this.paletteBox.Size = new System.Drawing.Size(91, 21);
            this.paletteBox.TabIndex = 17;
            this.paletteBox.SelectedIndexChanged += new System.EventHandler(this.paletteBox_SelectedIndexChanged);
            // 
            // spriteEditor
            // 
            this.spriteEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteEditor.AutoScroll = true;
            this.spriteEditor.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.spriteEditor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spriteEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spriteEditor.Enabled = false;
            this.spriteEditor.GridColor = System.Drawing.Color.Empty;
            this.spriteEditor.GridLines = false;
            this.spriteEditor.IsChanged = false;
            this.spriteEditor.Location = new System.Drawing.Point(52, 108);
            this.spriteEditor.Name = "spriteEditor";
            this.spriteEditor.PalSelector = null;
            this.spriteEditor.RenderSelection = false;
            this.spriteEditor.ScaleFactor = 1;
            this.spriteEditor.SelColor = System.Drawing.Color.Empty;
            this.spriteEditor.Size = new System.Drawing.Size(525, 273);
            this.spriteEditor.Sprite = null;
            this.spriteEditor.SubSprite = 0;
            this.spriteEditor.TabIndex = 2;
            // 
            // spriteViewer
            // 
            this.spriteViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteViewer.AutoScroll = true;
            this.spriteViewer.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.spriteViewer.BackColor = System.Drawing.SystemColors.Control;
            this.spriteViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spriteViewer.Enabled = false;
            this.spriteViewer.Location = new System.Drawing.Point(583, 108);
            this.spriteViewer.Name = "spriteViewer";
            this.spriteViewer.ScaleFactor = 1;
            this.spriteViewer.Size = new System.Drawing.Size(96, 96);
            this.spriteViewer.Sprite = null;
            this.spriteViewer.TabIndex = 1;
            // 
            // confirmPalNumChange
            // 
            this.confirmPalNumChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmPalNumChange.Location = new System.Drawing.Point(600, 308);
            this.confirmPalNumChange.Name = "confirmPalNumChange";
            this.confirmPalNumChange.Size = new System.Drawing.Size(91, 23);
            this.confirmPalNumChange.TabIndex = 25;
            this.confirmPalNumChange.Text = "Save Pal Num";
            this.confirmPalNumChange.UseVisualStyleBackColor = true;
            this.confirmPalNumChange.Click += new System.EventHandler(this.confirmPalNumChange_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Enabled = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 444);
            this.Controls.Add(this.confirmPalNumChange);
            this.Controls.Add(this.paletteBox);
            this.Controls.Add(this.paletteLbl);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.pPalette);
            this.Controls.Add(this.mnuMainStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSpriteSelector);
            this.Controls.Add(this.spriteEditor);
            this.Controls.Add(this.spriteViewer);
            this.Controls.Add(this.lblSpritePreview);
            this.Controls.Add(this.toolStripTools);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainStrip;
            this.Name = "frmMain";
            this.Text = "MOTHER 3 Sprite Editor";
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpriteEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubSprite)).EndInit();
            this.grpSpriteSelector.ResumeLayout(false);
            this.grpSpriteSelector.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pPalette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpenROM;
        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenROM;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private ViewerInterface spriteViewer;
        private EditorInterface spriteEditor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cboZoomEditor;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuZoom;
        private System.Windows.Forms.ToolStripMenuItem mnuGridLines;
        private System.Windows.Forms.ToolStripMenuItem mnuGridColor;
        private System.Windows.Forms.ColorDialog dlgGridColor;
        private PaletteSelector paletteSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMainEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSpriteEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudSubSprite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtBank0;
        private System.Windows.Forms.RadioButton rbtBank1;
        private System.Windows.Forms.RadioButton rbtBank2;
        private System.Windows.Forms.RadioButton rbtBank3;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label lblSpritePreview;
        private System.Windows.Forms.GroupBox grpSpriteSelector;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStripTools;
        private System.Windows.Forms.PictureBox pPalette;
        private System.Windows.Forms.SaveFileDialog dlgSavePNG;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCut;
        private System.Windows.Forms.ToolStripMenuItem mnuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSpriteProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoSave;
        private System.Windows.Forms.ToolStripMenuItem mnuImage;
        private System.Windows.Forms.ToolStripMenuItem mnuClearImage;
        private System.Windows.Forms.ToolStripMenuItem mnuSavePNG;
        private System.Windows.Forms.ToolStripMenuItem mnuSavePNGFull;
        private System.Windows.Forms.ToolStripMenuItem mnuSavePNGSub;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyImage;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyImageFull;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyImageSub;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuFlipX;
        private System.Windows.Forms.ToolStripMenuItem mnuFlipY;
        private System.Windows.Forms.ToolStripMenuItem mnuGenerateSpritesheet;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuFindSprite;
        private System.Windows.Forms.ToolStripTextBox mnuTxtFindSprite;
        private System.Windows.Forms.ToolStripMenuItem mnuFindNext;
        private System.Windows.Forms.ToolStripMenuItem mnuSwap;
        private System.Windows.Forms.ColorDialog dlgSelColor;
        private System.Windows.Forms.ToolStripMenuItem mnuSelCol;
        private System.Windows.Forms.Label paletteLbl;
        private SubPaletteSpriteSelector paletteBox;
        private System.Windows.Forms.Button confirmPalNumChange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
    }
}


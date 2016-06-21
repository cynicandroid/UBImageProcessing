namespace UBImageProcessing
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdjust = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuGrayScale = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuColor = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuBrightness = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuContrast = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuInvertColor = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuGamma = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mixerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuSharpen = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuMeanRemoval = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSimiliarImages = new System.Windows.Forms.ToolStripMenuItem();
            this.subMenuSimiliarImages = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuAdjust,
            this.toolStripMenuItem1,
            this.zoomToolStripMenuItem,
            this.mixerToolStripMenuItem,
            this.menuSimiliarImages});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuOpen,
            this.subMenuSave,
            this.subMenuReload,
            this.subMenuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "File";
            // 
            // subMenuOpen
            // 
            this.subMenuOpen.Name = "subMenuOpen";
            this.subMenuOpen.Size = new System.Drawing.Size(152, 22);
            this.subMenuOpen.Text = "Open";
            this.subMenuOpen.Click += new System.EventHandler(this.subMenuOpen_Click);
            // 
            // subMenuSave
            // 
            this.subMenuSave.Name = "subMenuSave";
            this.subMenuSave.Size = new System.Drawing.Size(152, 22);
            this.subMenuSave.Text = "Save";
            this.subMenuSave.Click += new System.EventHandler(this.subMenuSave_Click);
            // 
            // subMenuReload
            // 
            this.subMenuReload.Name = "subMenuReload";
            this.subMenuReload.Size = new System.Drawing.Size(152, 22);
            this.subMenuReload.Text = "Reload Image";
            this.subMenuReload.Click += new System.EventHandler(this.subMenuReload_Click);
            // 
            // subMenuExit
            // 
            this.subMenuExit.Name = "subMenuExit";
            this.subMenuExit.Size = new System.Drawing.Size(152, 22);
            this.subMenuExit.Text = "Exit";
            this.subMenuExit.Click += new System.EventHandler(this.subMenuExit_Click);
            // 
            // menuAdjust
            // 
            this.menuAdjust.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuGrayScale,
            this.subMenuColor,
            this.subMenuBrightness,
            this.subMenuContrast,
            this.subMenuInvertColor,
            this.subMenuGamma});
            this.menuAdjust.Name = "menuAdjust";
            this.menuAdjust.Size = new System.Drawing.Size(50, 20);
            this.menuAdjust.Text = "Adjust";
            // 
            // subMenuGrayScale
            // 
            this.subMenuGrayScale.Name = "subMenuGrayScale";
            this.subMenuGrayScale.Size = new System.Drawing.Size(152, 22);
            this.subMenuGrayScale.Text = "GrayScale";
            this.subMenuGrayScale.Click += new System.EventHandler(this.subMenuGrayScale_Click);
            // 
            // subMenuColor
            // 
            this.subMenuColor.Name = "subMenuColor";
            this.subMenuColor.Size = new System.Drawing.Size(152, 22);
            this.subMenuColor.Text = "Color";
            this.subMenuColor.Click += new System.EventHandler(this.subMenuColor_Click);
            // 
            // subMenuBrightness
            // 
            this.subMenuBrightness.Name = "subMenuBrightness";
            this.subMenuBrightness.Size = new System.Drawing.Size(152, 22);
            this.subMenuBrightness.Text = "Brightness";
            this.subMenuBrightness.Click += new System.EventHandler(this.subMenuBrightness_Click);
            // 
            // subMenuContrast
            // 
            this.subMenuContrast.Name = "subMenuContrast";
            this.subMenuContrast.Size = new System.Drawing.Size(152, 22);
            this.subMenuContrast.Text = "Contrast";
            this.subMenuContrast.Click += new System.EventHandler(this.subMenuContrast_Click);
            // 
            // subMenuInvertColor
            // 
            this.subMenuInvertColor.Name = "subMenuInvertColor";
            this.subMenuInvertColor.Size = new System.Drawing.Size(152, 22);
            this.subMenuInvertColor.Text = "Invert Color";
            this.subMenuInvertColor.Click += new System.EventHandler(this.subMenuInvertColor_Click);
            // 
            // subMenuGamma
            // 
            this.subMenuGamma.Name = "subMenuGamma";
            this.subMenuGamma.Size = new System.Drawing.Size(152, 22);
            this.subMenuGamma.Text = "Gamma";
            this.subMenuGamma.Click += new System.EventHandler(this.subMenuGamma_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuZoom100,
            this.subMenuZoom25,
            this.subMenuZoom50,
            this.subMenuZoom200});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // subMenuZoom100
            // 
            this.subMenuZoom100.Name = "subMenuZoom100";
            this.subMenuZoom100.Size = new System.Drawing.Size(152, 22);
            this.subMenuZoom100.Text = "100 %";
            this.subMenuZoom100.Click += new System.EventHandler(this.subMenuZoom100_Click);
            // 
            // subMenuZoom25
            // 
            this.subMenuZoom25.Name = "subMenuZoom25";
            this.subMenuZoom25.Size = new System.Drawing.Size(152, 22);
            this.subMenuZoom25.Text = "25 %";
            this.subMenuZoom25.Click += new System.EventHandler(this.subMenuZoom25_Click);
            // 
            // subMenuZoom50
            // 
            this.subMenuZoom50.Name = "subMenuZoom50";
            this.subMenuZoom50.Size = new System.Drawing.Size(152, 22);
            this.subMenuZoom50.Text = "50 % ";
            this.subMenuZoom50.Click += new System.EventHandler(this.subMenuZoom50_Click);
            // 
            // subMenuZoom200
            // 
            this.subMenuZoom200.Name = "subMenuZoom200";
            this.subMenuZoom200.Size = new System.Drawing.Size(152, 22);
            this.subMenuZoom200.Text = "200 %";
            this.subMenuZoom200.Click += new System.EventHandler(this.subMenuZoom200_Click);
            // 
            // mixerToolStripMenuItem
            // 
            this.mixerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothToolStripMenuItem,
            this.subMenuSharpen,
            this.subMenuBlur,
            this.subMenuMeanRemoval});
            this.mixerToolStripMenuItem.Name = "mixerToolStripMenuItem";
            this.mixerToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.mixerToolStripMenuItem.Text = "Mixer";
            // 
            // smoothToolStripMenuItem
            // 
            this.smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            this.smoothToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.smoothToolStripMenuItem.Text = "Smooth";
            this.smoothToolStripMenuItem.Click += new System.EventHandler(this.smoothToolStripMenuItem_Click);
            // 
            // subMenuSharpen
            // 
            this.subMenuSharpen.Name = "subMenuSharpen";
            this.subMenuSharpen.Size = new System.Drawing.Size(158, 22);
            this.subMenuSharpen.Text = "Sharpen";
            this.subMenuSharpen.Click += new System.EventHandler(this.subMenuSharpen_Click);
            // 
            // subMenuBlur
            // 
            this.subMenuBlur.Name = "subMenuBlur";
            this.subMenuBlur.Size = new System.Drawing.Size(158, 22);
            this.subMenuBlur.Text = "Blur";
            this.subMenuBlur.Click += new System.EventHandler(this.subMenuBlur_Click);
            // 
            // subMenuMeanRemoval
            // 
            this.subMenuMeanRemoval.Name = "subMenuMeanRemoval";
            this.subMenuMeanRemoval.Size = new System.Drawing.Size(158, 22);
            this.subMenuMeanRemoval.Text = "Mean Removal ";
            this.subMenuMeanRemoval.Click += new System.EventHandler(this.subMenuMeanRemoval_Click);
            // 
            // menuSimiliarImages
            // 
            this.menuSimiliarImages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuSimiliarImages});
            this.menuSimiliarImages.Name = "menuSimiliarImages";
            this.menuSimiliarImages.Size = new System.Drawing.Size(129, 20);
            this.menuSimiliarImages.Text = "Similiar Image Detector";
            // 
            // subMenuSimiliarImages
            // 
            this.subMenuSimiliarImages.Name = "subMenuSimiliarImages";
            this.subMenuSimiliarImages.Size = new System.Drawing.Size(178, 22);
            this.subMenuSimiliarImages.Text = "Find Similiar Images";
            this.subMenuSimiliarImages.Click += new System.EventHandler(this.subMenuSimiliarImages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 263);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UB Image Processor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem subMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem subMenuSave;
        private System.Windows.Forms.ToolStripMenuItem subMenuReload;
        private System.Windows.Forms.ToolStripMenuItem subMenuExit;
        private System.Windows.Forms.ToolStripMenuItem menuAdjust;
        private System.Windows.Forms.ToolStripMenuItem subMenuGrayScale;
        private System.Windows.Forms.ToolStripMenuItem subMenuColor;
        private System.Windows.Forms.ToolStripMenuItem subMenuBrightness;
        private System.Windows.Forms.ToolStripMenuItem subMenuContrast;
        private System.Windows.Forms.ToolStripMenuItem subMenuInvertColor;
        private System.Windows.Forms.ToolStripMenuItem subMenuGamma;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subMenuZoom100;
        private System.Windows.Forms.ToolStripMenuItem subMenuZoom25;
        private System.Windows.Forms.ToolStripMenuItem subMenuZoom50;
        private System.Windows.Forms.ToolStripMenuItem subMenuZoom200;
        private System.Windows.Forms.ToolStripMenuItem mixerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subMenuSharpen;
        private System.Windows.Forms.ToolStripMenuItem subMenuBlur;
        private System.Windows.Forms.ToolStripMenuItem subMenuMeanRemoval;
        private System.Windows.Forms.ToolStripMenuItem menuSimiliarImages;
        private System.Windows.Forms.ToolStripMenuItem subMenuSimiliarImages;
    }
}


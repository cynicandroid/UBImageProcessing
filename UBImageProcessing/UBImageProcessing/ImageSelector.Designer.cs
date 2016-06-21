namespace UBImageProcessing
{
    partial class ImageSelector
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnProcess = new System.Windows.Forms.Button();
            this.imageFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.lstImageResult = new System.Windows.Forms.ListView();
            this.lstImageDupe = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colSimilarity = new System.Windows.Forms.ColumnHeader();
            this.sourceImage = new System.Windows.Forms.PictureBox();
            this.similarImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(29, 13);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(105, 13);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "Select Picture Folder";
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.Location = new System.Drawing.Point(140, 13);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(140, 20);
            this.txtImageFolder.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(286, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(108, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select Folder";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(286, 52);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(106, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lstImageResult
            // 
            this.lstImageResult.Location = new System.Drawing.Point(32, 96);
            this.lstImageResult.Name = "lstImageResult";
            this.lstImageResult.Size = new System.Drawing.Size(121, 308);
            this.lstImageResult.TabIndex = 5;
            this.lstImageResult.UseCompatibleStateImageBehavior = false;
            this.lstImageResult.View = System.Windows.Forms.View.List;
            this.lstImageResult.SelectedIndexChanged += new System.EventHandler(this.lstImageResult_SelectedIndexChanged);
            // 
            // lstImageDupe
            // 
            this.lstImageDupe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSimilarity});
            this.lstImageDupe.Location = new System.Drawing.Point(185, 220);
            this.lstImageDupe.Name = "lstImageDupe";
            this.lstImageDupe.Size = new System.Drawing.Size(334, 193);
            this.lstImageDupe.TabIndex = 7;
            this.lstImageDupe.UseCompatibleStateImageBehavior = false;
            this.lstImageDupe.View = System.Windows.Forms.View.Details;
            this.lstImageDupe.SelectedIndexChanged += new System.EventHandler(this.lstImageDupe_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Image Name";
            this.colName.Width = 160;
            // 
            // colSimilarity
            // 
            this.colSimilarity.Text = "Matching Percentage";
            this.colSimilarity.Width = 166;
            // 
            // sourceImage
            // 
            this.sourceImage.Location = new System.Drawing.Point(183, 96);
            this.sourceImage.Name = "sourceImage";
            this.sourceImage.Size = new System.Drawing.Size(155, 109);
            this.sourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourceImage.TabIndex = 8;
            this.sourceImage.TabStop = false;
            // 
            // similarImage
            // 
            this.similarImage.Location = new System.Drawing.Point(344, 96);
            this.similarImage.Name = "similarImage";
            this.similarImage.Size = new System.Drawing.Size(163, 109);
            this.similarImage.TabIndex = 9;
            this.similarImage.TabStop = false;
            // 
            // ImageSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 85);
            this.Controls.Add(this.similarImage);
            this.Controls.Add(this.sourceImage);
            this.Controls.Add(this.lstImageDupe);
            this.Controls.Add(this.lstImageResult);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtImageFolder);
            this.Controls.Add(this.lblSelect);
            this.Name = "ImageSelector";
            this.Text = "ImageSelector";
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.FolderBrowserDialog imageFolderBrowser;
        private System.Windows.Forms.ListView lstImageResult;
        private System.Windows.Forms.ListView lstImageDupe;
        private System.Windows.Forms.PictureBox sourceImage;
        private System.Windows.Forms.PictureBox similarImage;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSimilarity;
    }
}
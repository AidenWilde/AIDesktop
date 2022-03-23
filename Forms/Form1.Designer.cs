namespace AIDesktop
{
    partial class FormAIDesktop
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectRegion = new System.Windows.Forms.Button();
            this.listBoxDisplays = new System.Windows.Forms.ListBox();
            this.pictureBoxScreenshotSection = new System.Windows.Forms.PictureBox();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonShowAiFunctions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshotSection)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectRegion
            // 
            this.buttonSelectRegion.Location = new System.Drawing.Point(12, 8);
            this.buttonSelectRegion.Name = "buttonSelectRegion";
            this.buttonSelectRegion.Size = new System.Drawing.Size(95, 30);
            this.buttonSelectRegion.TabIndex = 0;
            this.buttonSelectRegion.Text = "Select Region";
            this.buttonSelectRegion.UseVisualStyleBackColor = true;
            this.buttonSelectRegion.Click += new System.EventHandler(this.buttonSelectRegion_Click);
            // 
            // listBoxDisplays
            // 
            this.listBoxDisplays.FormattingEnabled = true;
            this.listBoxDisplays.ItemHeight = 15;
            this.listBoxDisplays.Location = new System.Drawing.Point(220, 8);
            this.listBoxDisplays.Name = "listBoxDisplays";
            this.listBoxDisplays.Size = new System.Drawing.Size(255, 64);
            this.listBoxDisplays.TabIndex = 2;
            this.listBoxDisplays.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplays_SelectedIndexChanged);
            // 
            // pictureBoxScreenshotSection
            // 
            this.pictureBoxScreenshotSection.Location = new System.Drawing.Point(12, 80);
            this.pictureBoxScreenshotSection.Name = "pictureBoxScreenshotSection";
            this.pictureBoxScreenshotSection.Size = new System.Drawing.Size(463, 288);
            this.pictureBoxScreenshotSection.TabIndex = 3;
            this.pictureBoxScreenshotSection.TabStop = false;
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(12, 44);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(95, 30);
            this.buttonSaveImage.TabIndex = 4;
            this.buttonSaveImage.Text = "Save";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonShowAiFunctions
            // 
            this.buttonShowAiFunctions.Location = new System.Drawing.Point(113, 25);
            this.buttonShowAiFunctions.Name = "buttonShowAiFunctions";
            this.buttonShowAiFunctions.Size = new System.Drawing.Size(95, 30);
            this.buttonShowAiFunctions.TabIndex = 5;
            this.buttonShowAiFunctions.Text = "AI Functions";
            this.buttonShowAiFunctions.UseVisualStyleBackColor = true;
            this.buttonShowAiFunctions.Click += new System.EventHandler(this.buttonShowAiFunctions_Click);
            // 
            // FormAIDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 379);
            this.Controls.Add(this.buttonShowAiFunctions);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.pictureBoxScreenshotSection);
            this.Controls.Add(this.listBoxDisplays);
            this.Controls.Add(this.buttonSelectRegion);
            this.Name = "FormAIDesktop";
            this.Text = "AI Desktop";
            this.Load += new System.EventHandler(this.FormAIDesktop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshotSection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSelectRegion;
        private ListBox listBoxDisplays;
        private PictureBox pictureBoxScreenshotSection;
        private Button buttonSaveImage;
        private Button buttonShowAiFunctions;
    }
}
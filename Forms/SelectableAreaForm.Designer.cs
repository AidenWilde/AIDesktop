﻿namespace AIDesktop
{
    partial class SelectableAreaForm
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
            this.pictureBoxScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxScreenshot
            // 
            this.pictureBoxScreenshot.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxScreenshot.Name = "pictureBoxScreenshot";
            this.pictureBoxScreenshot.Size = new System.Drawing.Size(1213, 630);
            this.pictureBoxScreenshot.TabIndex = 0;
            this.pictureBoxScreenshot.TabStop = false;
            // 
            // SelectableAreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 636);
            this.Controls.Add(this.pictureBoxScreenshot);
            this.Name = "SelectableAreaForm";
            this.ShowIcon = false;
            this.Text = "SelectableAreaForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectableAreaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBoxScreenshot;
    }
}
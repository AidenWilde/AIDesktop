namespace AIDesktop.Forms
{
    partial class AiFunctionsForm
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
            this.buttonReadTextFromImage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReadTextFromImage
            // 
            this.buttonReadTextFromImage.Location = new System.Drawing.Point(12, 12);
            this.buttonReadTextFromImage.Name = "buttonReadTextFromImage";
            this.buttonReadTextFromImage.Size = new System.Drawing.Size(117, 33);
            this.buttonReadTextFromImage.TabIndex = 0;
            this.buttonReadTextFromImage.Text = "Read Text";
            this.buttonReadTextFromImage.UseVisualStyleBackColor = true;
            this.buttonReadTextFromImage.Click += new System.EventHandler(this.buttonReadTextFromImage_Click);
            // 
            // AiFunctionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReadTextFromImage);
            this.Name = "AiFunctionsForm";
            this.Text = "AiFunctionsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonReadTextFromImage;
    }
}
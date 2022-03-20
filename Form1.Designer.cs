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
            this.buttonLookup = new System.Windows.Forms.Button();
            this.listBoxDisplays = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonSelectRegion
            // 
            this.buttonSelectRegion.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectRegion.Name = "buttonSelectRegion";
            this.buttonSelectRegion.Size = new System.Drawing.Size(95, 30);
            this.buttonSelectRegion.TabIndex = 0;
            this.buttonSelectRegion.Text = "Select Region";
            this.buttonSelectRegion.UseVisualStyleBackColor = true;
            this.buttonSelectRegion.Click += new System.EventHandler(this.buttonSelectRegion_Click);
            // 
            // buttonLookup
            // 
            this.buttonLookup.Location = new System.Drawing.Point(113, 12);
            this.buttonLookup.Name = "buttonLookup";
            this.buttonLookup.Size = new System.Drawing.Size(95, 30);
            this.buttonLookup.TabIndex = 1;
            this.buttonLookup.Text = "Lookup";
            this.buttonLookup.UseVisualStyleBackColor = true;
            this.buttonLookup.Click += new System.EventHandler(this.buttonLookup_Click);
            // 
            // listBoxDisplays
            // 
            this.listBoxDisplays.FormattingEnabled = true;
            this.listBoxDisplays.ItemHeight = 15;
            this.listBoxDisplays.Location = new System.Drawing.Point(214, 8);
            this.listBoxDisplays.Name = "listBoxDisplays";
            this.listBoxDisplays.Size = new System.Drawing.Size(265, 64);
            this.listBoxDisplays.TabIndex = 2;
            this.listBoxDisplays.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplays_SelectedIndexChanged);
            // 
            // FormAIDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxDisplays);
            this.Controls.Add(this.buttonLookup);
            this.Controls.Add(this.buttonSelectRegion);
            this.Name = "FormAIDesktop";
            this.Text = "AI Desktop";
            this.Load += new System.EventHandler(this.FormAIDesktop_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSelectRegion;
        private Button buttonLookup;
        private ListBox listBoxDisplays;
    }
}
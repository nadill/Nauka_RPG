namespace RpgGenerator
{
    partial class frmStart
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
            this.btnNewChar = new System.Windows.Forms.Button();
            this.btnLoadChar = new System.Windows.Forms.Button();
            this.lnkAuthor = new System.Windows.Forms.LinkLabel();
            this.pbWitchcraftLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWitchcraftLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNewChar
            // 
            this.btnNewChar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewChar.BackColor = System.Drawing.Color.Silver;
            this.btnNewChar.FlatAppearance.BorderSize = 0;
            this.btnNewChar.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewChar.Location = new System.Drawing.Point(341, 193);
            this.btnNewChar.Name = "btnNewChar";
            this.btnNewChar.Size = new System.Drawing.Size(301, 51);
            this.btnNewChar.TabIndex = 3;
            this.btnNewChar.Text = "New character";
            this.btnNewChar.UseVisualStyleBackColor = false;
            this.btnNewChar.Click += new System.EventHandler(this.btnNewChar_Click);
            // 
            // btnLoadChar
            // 
            this.btnLoadChar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadChar.BackColor = System.Drawing.Color.Silver;
            this.btnLoadChar.FlatAppearance.BorderSize = 0;
            this.btnLoadChar.FlatAppearance.CheckedBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLoadChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadChar.Location = new System.Drawing.Point(341, 277);
            this.btnLoadChar.Name = "btnLoadChar";
            this.btnLoadChar.Size = new System.Drawing.Size(301, 51);
            this.btnLoadChar.TabIndex = 4;
            this.btnLoadChar.Text = "Load character";
            this.btnLoadChar.UseVisualStyleBackColor = false;
            this.btnLoadChar.Click += new System.EventHandler(this.btnLoadChar_Click);
            // 
            // lnkAuthor
            // 
            this.lnkAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAuthor.AutoSize = true;
            this.lnkAuthor.LinkColor = System.Drawing.Color.WhiteSmoke;
            this.lnkAuthor.Location = new System.Drawing.Point(706, 573);
            this.lnkAuthor.Name = "lnkAuthor";
            this.lnkAuthor.Size = new System.Drawing.Size(266, 29);
            this.lnkAuthor.TabIndex = 6;
            this.lnkAuthor.TabStop = true;
            this.lnkAuthor.Text = "Created by: Michał Mikulski";
            this.lnkAuthor.VisitedLinkColor = System.Drawing.Color.WhiteSmoke;
            // 
            // pbWitchcraftLogo
            // 
            this.pbWitchcraftLogo.Location = new System.Drawing.Point(264, 38);
            this.pbWitchcraftLogo.Name = "pbWitchcraftLogo";
            this.pbWitchcraftLogo.Size = new System.Drawing.Size(443, 131);
            this.pbWitchcraftLogo.TabIndex = 7;
            this.pbWitchcraftLogo.TabStop = false;
            // 
            // frmStart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.pbWitchcraftLogo);
            this.Controls.Add(this.lnkAuthor);
            this.Controls.Add(this.btnLoadChar);
            this.Controls.Add(this.btnNewChar);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Witchcraft - RPG Generator";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.pbWitchcraftLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNewChar;
        private System.Windows.Forms.Button btnLoadChar;
        private System.Windows.Forms.LinkLabel lnkAuthor;
        private System.Windows.Forms.PictureBox pbWitchcraftLogo;
    }
}


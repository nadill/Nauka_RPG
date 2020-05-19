namespace RpgGenerator
{
    partial class FrmCharCreation
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
            this.pnlCreationSteps = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblStepName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlStep = new System.Windows.Forms.Panel();
            this.pnlCreationSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCreationSteps
            // 
            this.pnlCreationSteps.Controls.Add(this.btnNext);
            this.pnlCreationSteps.Controls.Add(this.lblStepName);
            this.pnlCreationSteps.Controls.Add(this.btnBack);
            this.pnlCreationSteps.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCreationSteps.Location = new System.Drawing.Point(0, 0);
            this.pnlCreationSteps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCreationSteps.Name = "pnlCreationSteps";
            this.pnlCreationSteps.Size = new System.Drawing.Size(1476, 81);
            this.pnlCreationSteps.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(1380, 18);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 35);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "Next step";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblStepName
            // 
            this.lblStepName.AutoSize = true;
            this.lblStepName.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStepName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblStepName.Location = new System.Drawing.Point(20, 20);
            this.lblStepName.Name = "lblStepName";
            this.lblStepName.Size = new System.Drawing.Size(171, 48);
            this.lblStepName.TabIndex = 2;
            this.lblStepName.Text = "Basic info";
            // 
            // btnBack
            // 
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(1253, 18);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 35);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlStep
            // 
            this.pnlStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep.Location = new System.Drawing.Point(0, 81);
            this.pnlStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlStep.Name = "pnlStep";
            this.pnlStep.Size = new System.Drawing.Size(1476, 632);
            this.pnlStep.TabIndex = 1;
            // 
            // FrmCharCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1476, 713);
            this.Controls.Add(this.pnlStep);
            this.Controls.Add(this.pnlCreationSteps);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCharCreation";
            this.Text = "Witchcraft - Character creation";
            this.Load += new System.EventHandler(this.FrmCharCreation_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmCharCreation_MouseMove);
            this.pnlCreationSteps.ResumeLayout(false);
            this.pnlCreationSteps.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCreationSteps;
        private System.Windows.Forms.Label lblStepName;
        private System.Windows.Forms.Panel pnlStep;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
    }
}
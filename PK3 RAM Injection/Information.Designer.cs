namespace PK3_RAM_Injection
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            BuildLBL = new Label();
            CreatorLBL = new Label();
            DepLBL = new Label();
            PKHeXLBL = new Label();
            SuspendLayout();
            // 
            // BuildLBL
            // 
            BuildLBL.AutoSize = true;
            BuildLBL.Location = new Point(12, 9);
            BuildLBL.Name = "BuildLBL";
            BuildLBL.Size = new Size(88, 15);
            BuildLBL.TabIndex = 0;
            BuildLBL.Text = "Build: 20240626";
            // 
            // CreatorLBL
            // 
            CreatorLBL.AutoSize = true;
            CreatorLBL.Location = new Point(12, 24);
            CreatorLBL.Name = "CreatorLBL";
            CreatorLBL.Size = new Size(115, 15);
            CreatorLBL.TabIndex = 1;
            CreatorLBL.Text = "Developed by: PokeJ";
            // 
            // DepLBL
            // 
            DepLBL.AutoSize = true;
            DepLBL.Location = new Point(12, 39);
            DepLBL.Name = "DepLBL";
            DepLBL.Size = new Size(123, 15);
            DepLBL.TabIndex = 2;
            DepLBL.Text = "Dependencies: PKHeX";
            // 
            // PKHeXLBL
            // 
            PKHeXLBL.AutoSize = true;
            PKHeXLBL.Location = new Point(12, 54);
            PKHeXLBL.Name = "PKHeXLBL";
            PKHeXLBL.Size = new Size(141, 15);
            PKHeXLBL.TabIndex = 3;
            PKHeXLBL.Text = "PKHeX creator: Kaphotics";
            // 
            // Information
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(214, 82);
            Controls.Add(PKHeXLBL);
            Controls.Add(DepLBL);
            Controls.Add(CreatorLBL);
            Controls.Add(BuildLBL);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(230, 121);
            MinimumSize = new Size(230, 121);
            Name = "Information";
            Text = "Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BuildLBL;
        private Label CreatorLBL;
        private Label DepLBL;
        private Label PKHeXLBL;
    }
}
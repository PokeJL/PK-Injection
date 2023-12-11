namespace PK3_RAM_Injection.View
{
    partial class PK3_RAM_Hex_Editor
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
            pidLBL = new Label();
            pidNUD1 = new NumericUpDown();
            pidGB = new GroupBox();
            pidNUD4 = new NumericUpDown();
            pidNUD3 = new NumericUpDown();
            pidNUD2 = new NumericUpDown();
            idGB = new GroupBox();
            idLBL = new Label();
            idNUD2 = new NumericUpDown();
            idNUD1 = new NumericUpDown();
            sidGB = new GroupBox();
            sidLBL = new Label();
            sidNUD2 = new NumericUpDown();
            sidNUD1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pidNUD1).BeginInit();
            pidGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pidNUD4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pidNUD3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pidNUD2).BeginInit();
            idGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)idNUD2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idNUD1).BeginInit();
            sidGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sidNUD2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sidNUD1).BeginInit();
            SuspendLayout();
            // 
            // pidLBL
            // 
            pidLBL.AutoSize = true;
            pidLBL.Location = new Point(6, 48);
            pidLBL.Name = "pidLBL";
            pidLBL.Size = new Size(38, 15);
            pidLBL.TabIndex = 2;
            pidLBL.Text = "label1";
            // 
            // pidNUD1
            // 
            pidNUD1.Hexadecimal = true;
            pidNUD1.Location = new Point(6, 22);
            pidNUD1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            pidNUD1.Name = "pidNUD1";
            pidNUD1.Size = new Size(37, 23);
            pidNUD1.TabIndex = 3;
            pidNUD1.ValueChanged += pidNUD1_ValueChanged;
            // 
            // pidGB
            // 
            pidGB.Controls.Add(pidNUD4);
            pidGB.Controls.Add(pidLBL);
            pidGB.Controls.Add(pidNUD3);
            pidGB.Controls.Add(pidNUD2);
            pidGB.Controls.Add(pidNUD1);
            pidGB.Location = new Point(12, 12);
            pidGB.Name = "pidGB";
            pidGB.Size = new Size(180, 71);
            pidGB.TabIndex = 4;
            pidGB.TabStop = false;
            pidGB.Text = "PID";
            // 
            // pidNUD4
            // 
            pidNUD4.Hexadecimal = true;
            pidNUD4.Location = new Point(135, 22);
            pidNUD4.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            pidNUD4.Name = "pidNUD4";
            pidNUD4.Size = new Size(37, 23);
            pidNUD4.TabIndex = 6;
            pidNUD4.ValueChanged += pidNUD4_ValueChanged;
            // 
            // pidNUD3
            // 
            pidNUD3.Hexadecimal = true;
            pidNUD3.Location = new Point(92, 22);
            pidNUD3.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            pidNUD3.Name = "pidNUD3";
            pidNUD3.Size = new Size(37, 23);
            pidNUD3.TabIndex = 5;
            pidNUD3.ValueChanged += pidNUD3_ValueChanged;
            // 
            // pidNUD2
            // 
            pidNUD2.Hexadecimal = true;
            pidNUD2.Location = new Point(49, 22);
            pidNUD2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            pidNUD2.Name = "pidNUD2";
            pidNUD2.Size = new Size(37, 23);
            pidNUD2.TabIndex = 4;
            pidNUD2.ValueChanged += pidNUD2_ValueChanged;
            // 
            // idGB
            // 
            idGB.Controls.Add(idLBL);
            idGB.Controls.Add(idNUD2);
            idGB.Controls.Add(idNUD1);
            idGB.Location = new Point(198, 12);
            idGB.Name = "idGB";
            idGB.Size = new Size(95, 71);
            idGB.TabIndex = 5;
            idGB.TabStop = false;
            idGB.Text = "ID";
            // 
            // idLBL
            // 
            idLBL.AutoSize = true;
            idLBL.Location = new Point(5, 48);
            idLBL.Name = "idLBL";
            idLBL.Size = new Size(38, 15);
            idLBL.TabIndex = 6;
            idLBL.Text = "label1";
            // 
            // idNUD2
            // 
            idNUD2.Hexadecimal = true;
            idNUD2.Location = new Point(49, 22);
            idNUD2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            idNUD2.Name = "idNUD2";
            idNUD2.Size = new Size(37, 23);
            idNUD2.TabIndex = 5;
            idNUD2.ValueChanged += TwoByteUpdate;
            // 
            // idNUD1
            // 
            idNUD1.Hexadecimal = true;
            idNUD1.Location = new Point(6, 22);
            idNUD1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            idNUD1.Name = "idNUD1";
            idNUD1.Size = new Size(37, 23);
            idNUD1.TabIndex = 4;
            idNUD1.ValueChanged += TwoByteUpdate;
            // 
            // sidGB
            // 
            sidGB.Controls.Add(sidLBL);
            sidGB.Controls.Add(sidNUD2);
            sidGB.Controls.Add(sidNUD1);
            sidGB.Location = new Point(299, 12);
            sidGB.Name = "sidGB";
            sidGB.Size = new Size(95, 71);
            sidGB.TabIndex = 6;
            sidGB.TabStop = false;
            sidGB.Text = "SID";
            // 
            // sidLBL
            // 
            sidLBL.AutoSize = true;
            sidLBL.Location = new Point(5, 48);
            sidLBL.Name = "sidLBL";
            sidLBL.Size = new Size(38, 15);
            sidLBL.TabIndex = 6;
            sidLBL.Text = "label1";
            // 
            // sidNUD2
            // 
            sidNUD2.Hexadecimal = true;
            sidNUD2.Location = new Point(49, 22);
            sidNUD2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            sidNUD2.Name = "sidNUD2";
            sidNUD2.Size = new Size(37, 23);
            sidNUD2.TabIndex = 5;
            sidNUD2.ValueChanged += TwoByteUpdate;
            // 
            // sidNUD1
            // 
            sidNUD1.Hexadecimal = true;
            sidNUD1.Location = new Point(6, 22);
            sidNUD1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            sidNUD1.Name = "sidNUD1";
            sidNUD1.Size = new Size(37, 23);
            sidNUD1.TabIndex = 4;
            sidNUD1.ValueChanged += TwoByteUpdate;
            // 
            // PK3_RAM_Hex_Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sidGB);
            Controls.Add(idGB);
            Controls.Add(pidGB);
            Name = "PK3_RAM_Hex_Editor";
            Text = "PK3_RAM_Hex_Editor";
            ((System.ComponentModel.ISupportInitialize)pidNUD1).EndInit();
            pidGB.ResumeLayout(false);
            pidGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pidNUD4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pidNUD3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pidNUD2).EndInit();
            idGB.ResumeLayout(false);
            idGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)idNUD2).EndInit();
            ((System.ComponentModel.ISupportInitialize)idNUD1).EndInit();
            sidGB.ResumeLayout(false);
            sidGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sidNUD2).EndInit();
            ((System.ComponentModel.ISupportInitialize)sidNUD1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label pidLBL;
        private NumericUpDown pidNUD1;
        private GroupBox pidGB;
        private NumericUpDown pidNUD4;
        private NumericUpDown pidNUD3;
        private NumericUpDown pidNUD2;
        private Label idLBL;
        private NumericUpDown idNUD2;
        private NumericUpDown idNUD1;
        private GroupBox sidGB;
        private Label sidLBL;
        private NumericUpDown sidNUD2;
        private NumericUpDown sidNUD1;
        public GroupBox idGB;
    }
}
namespace PK3_RAM_Injection
{
    partial class PK3_RAM_Injection
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
            this.OpenFileBTN = new System.Windows.Forms.Button();
            this.OpenFileTXB = new System.Windows.Forms.TextBox();
            this.FindPkmnBTN = new System.Windows.Forms.Button();
            this.RipProgressBar = new System.Windows.Forms.ProgressBar();
            this.ExtractBTN = new System.Windows.Forms.Button();
            this.PkmnSelectCB = new System.Windows.Forms.ComboBox();
            this.ImportBTN = new System.Windows.Forms.Button();
            this.EditBTN = new System.Windows.Forms.Button();
            this.InjectBTN = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.FoundTXB = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // OpenFileBTN
            // 
            this.OpenFileBTN.Location = new System.Drawing.Point(12, 12);
            this.OpenFileBTN.Name = "OpenFileBTN";
            this.OpenFileBTN.Size = new System.Drawing.Size(75, 23);
            this.OpenFileBTN.TabIndex = 0;
            this.OpenFileBTN.Text = "Open File";
            this.OpenFileBTN.UseVisualStyleBackColor = true;
            this.OpenFileBTN.Click += new System.EventHandler(this.OpenFileBTN_Click);
            // 
            // OpenFileTXB
            // 
            this.OpenFileTXB.Location = new System.Drawing.Point(12, 41);
            this.OpenFileTXB.Name = "OpenFileTXB";
            this.OpenFileTXB.Size = new System.Drawing.Size(156, 23);
            this.OpenFileTXB.TabIndex = 1;
            // 
            // FindPkmnBTN
            // 
            this.FindPkmnBTN.Location = new System.Drawing.Point(12, 70);
            this.FindPkmnBTN.Name = "FindPkmnBTN";
            this.FindPkmnBTN.Size = new System.Drawing.Size(75, 23);
            this.FindPkmnBTN.TabIndex = 2;
            this.FindPkmnBTN.Text = "Find PK";
            this.FindPkmnBTN.UseVisualStyleBackColor = true;
            this.FindPkmnBTN.Click += new System.EventHandler(this.FindPkmnBTN_Click);
            // 
            // RipProgressBar
            // 
            this.RipProgressBar.Location = new System.Drawing.Point(12, 99);
            this.RipProgressBar.Name = "RipProgressBar";
            this.RipProgressBar.Size = new System.Drawing.Size(156, 23);
            this.RipProgressBar.TabIndex = 3;
            // 
            // ExtractBTN
            // 
            this.ExtractBTN.Location = new System.Drawing.Point(12, 157);
            this.ExtractBTN.Name = "ExtractBTN";
            this.ExtractBTN.Size = new System.Drawing.Size(75, 23);
            this.ExtractBTN.TabIndex = 4;
            this.ExtractBTN.Text = "Extract PK";
            this.ExtractBTN.UseVisualStyleBackColor = true;
            this.ExtractBTN.Click += new System.EventHandler(this.ExtractBTN_Click);
            // 
            // PkmnSelectCB
            // 
            this.PkmnSelectCB.FormattingEnabled = true;
            this.PkmnSelectCB.Location = new System.Drawing.Point(12, 128);
            this.PkmnSelectCB.Name = "PkmnSelectCB";
            this.PkmnSelectCB.Size = new System.Drawing.Size(156, 23);
            this.PkmnSelectCB.TabIndex = 5;
            this.PkmnSelectCB.SelectedIndexChanged += new System.EventHandler(this.PkmnSelectCB_SelectedIndexChanged);
            // 
            // ImportBTN
            // 
            this.ImportBTN.Location = new System.Drawing.Point(12, 186);
            this.ImportBTN.Name = "ImportBTN";
            this.ImportBTN.Size = new System.Drawing.Size(75, 23);
            this.ImportBTN.TabIndex = 6;
            this.ImportBTN.Text = "Import PK";
            this.ImportBTN.UseVisualStyleBackColor = true;
            // 
            // EditBTN
            // 
            this.EditBTN.Location = new System.Drawing.Point(93, 186);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(75, 23);
            this.EditBTN.TabIndex = 7;
            this.EditBTN.Text = "Edit PK";
            this.EditBTN.UseVisualStyleBackColor = true;
            // 
            // InjectBTN
            // 
            this.InjectBTN.Location = new System.Drawing.Point(12, 215);
            this.InjectBTN.Name = "InjectBTN";
            this.InjectBTN.Size = new System.Drawing.Size(75, 23);
            this.InjectBTN.TabIndex = 8;
            this.InjectBTN.Text = "Inject PK";
            this.InjectBTN.UseVisualStyleBackColor = true;
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(93, 215);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(75, 23);
            this.SaveBTN.TabIndex = 9;
            this.SaveBTN.Text = "Save RAM";
            this.SaveBTN.UseVisualStyleBackColor = true;
            // 
            // FoundTXB
            // 
            this.FoundTXB.Location = new System.Drawing.Point(174, 12);
            this.FoundTXB.Multiline = true;
            this.FoundTXB.Name = "FoundTXB";
            this.FoundTXB.ReadOnly = true;
            this.FoundTXB.Size = new System.Drawing.Size(156, 110);
            this.FoundTXB.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(174, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(156, 110);
            this.textBox1.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // PK3_RAM_Injection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 250);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FoundTXB);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.InjectBTN);
            this.Controls.Add(this.EditBTN);
            this.Controls.Add(this.ImportBTN);
            this.Controls.Add(this.PkmnSelectCB);
            this.Controls.Add(this.ExtractBTN);
            this.Controls.Add(this.RipProgressBar);
            this.Controls.Add(this.FindPkmnBTN);
            this.Controls.Add(this.OpenFileTXB);
            this.Controls.Add(this.OpenFileBTN);
            this.Name = "PK3_RAM_Injection";
            this.Text = "PK3 RAM Injection";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PK3_RAM_Injection_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.PK3_RAM_Injection_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button OpenFileBTN;
        private TextBox OpenFileTXB;
        private Button FindPkmnBTN;
        private ProgressBar RipProgressBar;
        private Button ExtractBTN;
        private ComboBox PkmnSelectCB;
        private Button ImportBTN;
        private Button EditBTN;
        private Button InjectBTN;
        private Button SaveBTN;
        private TextBox FoundTXB;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private SaveFileDialog saveFileDialog1;
    }
}
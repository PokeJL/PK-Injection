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
            OpenFileBTN = new Button();
            OpenFileTXB = new TextBox();
            FindPkmnBTN = new Button();
            RipProgressBar = new ProgressBar();
            ExtractBTN = new Button();
            PkmnSelectCB = new ComboBox();
            ImportBTN = new Button();
            EditBTN = new Button();
            InjectBTN = new Button();
            SaveBTN = new Button();
            FoundTXB = new TextBox();
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            TidTXT = new TextBox();
            SuspendLayout();
            // 
            // OpenFileBTN
            // 
            OpenFileBTN.Location = new Point(12, 12);
            OpenFileBTN.Name = "OpenFileBTN";
            OpenFileBTN.Size = new Size(75, 23);
            OpenFileBTN.TabIndex = 0;
            OpenFileBTN.Text = "Open File";
            OpenFileBTN.UseVisualStyleBackColor = true;
            OpenFileBTN.Click += OpenFileBTN_Click;
            // 
            // OpenFileTXB
            // 
            OpenFileTXB.Location = new Point(12, 41);
            OpenFileTXB.Name = "OpenFileTXB";
            OpenFileTXB.Size = new Size(156, 23);
            OpenFileTXB.TabIndex = 1;
            // 
            // FindPkmnBTN
            // 
            FindPkmnBTN.Location = new Point(12, 70);
            FindPkmnBTN.Name = "FindPkmnBTN";
            FindPkmnBTN.Size = new Size(75, 23);
            FindPkmnBTN.TabIndex = 2;
            FindPkmnBTN.Text = "Find PK";
            FindPkmnBTN.UseVisualStyleBackColor = true;
            FindPkmnBTN.Click += FindPkmnBTN_Click;
            // 
            // RipProgressBar
            // 
            RipProgressBar.Location = new Point(12, 99);
            RipProgressBar.Name = "RipProgressBar";
            RipProgressBar.Size = new Size(156, 23);
            RipProgressBar.TabIndex = 3;
            // 
            // ExtractBTN
            // 
            ExtractBTN.Location = new Point(12, 157);
            ExtractBTN.Name = "ExtractBTN";
            ExtractBTN.Size = new Size(75, 23);
            ExtractBTN.TabIndex = 4;
            ExtractBTN.Text = "Extract PK";
            ExtractBTN.UseVisualStyleBackColor = true;
            ExtractBTN.Click += ExtractBTN_Click;
            // 
            // PkmnSelectCB
            // 
            PkmnSelectCB.FormattingEnabled = true;
            PkmnSelectCB.Location = new Point(12, 128);
            PkmnSelectCB.Name = "PkmnSelectCB";
            PkmnSelectCB.Size = new Size(156, 23);
            PkmnSelectCB.TabIndex = 5;
            PkmnSelectCB.SelectedIndexChanged += PkmnSelectCB_SelectedIndexChanged;
            // 
            // ImportBTN
            // 
            ImportBTN.Location = new Point(12, 186);
            ImportBTN.Name = "ImportBTN";
            ImportBTN.Size = new Size(75, 23);
            ImportBTN.TabIndex = 6;
            ImportBTN.Text = "Import PK";
            ImportBTN.UseVisualStyleBackColor = true;
            ImportBTN.Click += ImportBTN_Click;
            // 
            // EditBTN
            // 
            EditBTN.Location = new Point(93, 186);
            EditBTN.Name = "EditBTN";
            EditBTN.Size = new Size(75, 23);
            EditBTN.TabIndex = 7;
            EditBTN.Text = "Edit PK";
            EditBTN.UseVisualStyleBackColor = true;
            EditBTN.Click += EditBTN_Click;
            // 
            // InjectBTN
            // 
            InjectBTN.Location = new Point(12, 215);
            InjectBTN.Name = "InjectBTN";
            InjectBTN.Size = new Size(75, 23);
            InjectBTN.TabIndex = 8;
            InjectBTN.Text = "Inject PK";
            InjectBTN.UseVisualStyleBackColor = true;
            InjectBTN.Click += InjectBTN_Click;
            // 
            // SaveBTN
            // 
            SaveBTN.Location = new Point(93, 215);
            SaveBTN.Name = "SaveBTN";
            SaveBTN.Size = new Size(75, 23);
            SaveBTN.TabIndex = 9;
            SaveBTN.Text = "Save RAM";
            SaveBTN.UseVisualStyleBackColor = true;
            SaveBTN.Click += SaveBTN_Click;
            // 
            // FoundTXB
            // 
            FoundTXB.Location = new Point(174, 12);
            FoundTXB.Multiline = true;
            FoundTXB.Name = "FoundTXB";
            FoundTXB.ReadOnly = true;
            FoundTXB.Size = new Size(156, 110);
            FoundTXB.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(174, 128);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(156, 110);
            textBox1.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // TidTXT
            // 
            TidTXT.Location = new Point(93, 12);
            TidTXT.Name = "TidTXT";
            TidTXT.Size = new Size(75, 23);
            TidTXT.TabIndex = 12;
            // 
            // PK3_RAM_Injection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 250);
            Controls.Add(TidTXT);
            Controls.Add(textBox1);
            Controls.Add(FoundTXB);
            Controls.Add(SaveBTN);
            Controls.Add(InjectBTN);
            Controls.Add(EditBTN);
            Controls.Add(ImportBTN);
            Controls.Add(PkmnSelectCB);
            Controls.Add(ExtractBTN);
            Controls.Add(RipProgressBar);
            Controls.Add(FindPkmnBTN);
            Controls.Add(OpenFileTXB);
            Controls.Add(OpenFileBTN);
            Name = "PK3_RAM_Injection";
            Text = "PK3 RAM Injection";
            ResumeLayout(false);
            PerformLayout();
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
        private SaveFileDialog saveFileDialog1;
        private TextBox TidTXT;
    }
}
using RAM_Injection_Data.Controller;

namespace PK3_RAM_Injection
{
    public partial class PK3_RAM_Injection : Form
    {
        public Form_File_Manager fileManager;
        public Form_Function_Manager functionManager;
        public Run_Time_Manager runTimeManager;

        public PK3_RAM_Injection()
        {
            InitializeComponent();

            fileManager = new();
            functionManager = new();
            runTimeManager = new();
        }

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            fileManager.OpenFile(runTimeManager, openFileDialog1, OpenFileTXB);
        }

        private void ExtractBTN_Click(object sender, EventArgs e)
        {
            fileManager.ExtractData(runTimeManager);
        }

        private void FindPkmnBTN_Click(object sender, EventArgs e)
        {
            functionManager.FindData(runTimeManager, PkmnSelectCB, TidTXT, openFileDialog1, RipProgressBar);
        }

        private void PkmnSelectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            functionManager.SelectedData(runTimeManager, PkmnSelectCB);
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            var editor = new PK3_RAM_Hex_Editor();
            editor.Show();
        }

        private void ImportBTN_Click(object sender, EventArgs e)
        {
            fileManager.ImportData(runTimeManager, openFileDialog1);
        }

        private void InjectBTN_Click(object sender, EventArgs e)
        {
            functionManager.InjectData(runTimeManager);
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            fileManager.SaveData(runTimeManager);
        }
    }
}
using RAM_Injection_Data.Controller;
using System.Windows.Forms;

namespace PK3_RAM_Injection
{
    public partial class PK3_RAM_Injection : Form
    {
        public Form_File_Manager fileManager;
        public Form_Function_Manager functionManager;
        public Run_Time_Manager runTimeManager;
        public Form_Hex_Manager hexManager;
        public Form_Display_Manager displayManager;
        public Form_Validation_Manager validationManager;
        public List<List<NumericUpDown>> numericUpDowns = new List<List<NumericUpDown>>();

        public PK3_RAM_Injection()
        {
            InitializeComponent();

            fileManager = new();
            functionManager = new();
            runTimeManager = new();
            validationManager = new();
            hexManager = new();
            displayManager = new();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            functionManager.LoadNumericUpDown(tabPage1, numericUpDowns);
            runTimeManager.ApplicatonValues().Gen = 3;
            runTimeManager.ApplicatonValues().SubGen = 0;
            runTimeManager.SetValues().GameSetValues(runTimeManager.GameValues(), 3, 0);
            runTimeManager.SetValues().OffsetSetValues(runTimeManager.OffestData(), 3, 0);
            displayManager.InitializeHex(runTimeManager, numericUpDowns);
            PkrusCB1.SelectedIndex = 0;
            PkrusCB2.SelectedIndex = 0;
        }

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            fileManager.OpenFile(runTimeManager, openFileDialog1, OpenFileTXB);
        }

        private void ExtractBTN_Click(object sender, EventArgs e)
        {
            fileManager.ExtractData(runTimeManager, numericUpDowns);
        }

        private void FindPkmnBTN_Click(object sender, EventArgs e)
        {
            functionManager.FindData(runTimeManager, TidTXT, openFileDialog1, RipProgressBar, DisplayDGV);
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            functionManager.LoadEdit(runTimeManager, DisplayDGV, numericUpDowns);
        }

        private void ImportBTN_Click(object sender, EventArgs e)
        {
            fileManager.ImportData(runTimeManager, openFileDialog1);
            displayManager.SetHexToEdit(runTimeManager.ArrayManager().ArrayToPokemon(runTimeManager.ApplicatonValues().ImportData, runTimeManager.OffestData()), numericUpDowns);
        }

        private void InjectBTN_Click(object sender, EventArgs e)
        {
            runTimeManager.ArrayManager().CommitEditToObject(functionManager.HexToInject(runTimeManager, numericUpDowns), runTimeManager.PokemonGen3s()[runTimeManager.ApplicatonValues().SelectIndex]);
            functionManager.DisplayPokemon(DisplayDGV, runTimeManager.FindData(), runTimeManager.PokemonGen3s());
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            fileManager.SaveData(runTimeManager);
        }

        private void EncryptedCB_CheckedChanged(object sender, EventArgs e)
        {
            functionManager.Encrypted(runTimeManager, EncryptedCB);
        }

        private void NumUpDownToTextboxDecimal(object sender, EventArgs e)
        {
            hexManager.NumUpDownToTextboxDecimal(sender);
        }

        private void TextBoxDecimalToNumUpDown(object sender, EventArgs e)
        {
            hexManager.TextBoxDecimalToNumUpDown(sender);
        }

        private void TextboxLeave(object sender, EventArgs e)
        {
            validationManager.NumberFormatting(sender);
        }

        private void NumUpDownToTextboxHex(object sender, EventArgs e)
        {
            hexManager.NumUpDownToTextboxHex(sender);
        }

        private void TextBoxHexToNumUpDown(object sender, EventArgs e)
        {
            hexManager.TextBoxHexToNumUpDown(sender);
        }

        private void NumUpDownToDropMenu(object sender, EventArgs e)
        {
            hexManager.NumUpDownToDropMenu(sender);
        }

        private void DropMenuToComboBox(object sender, EventArgs e)
        {
            hexManager.DropMenuToNumUpDown(sender);
        }

        private void PKRuSStrainDropDownMenu(object sender, EventArgs e)
        {
            hexManager.PKRuSStrainDropDownMenu(sender);
        }

        private void PKRuSDayDropDownMenu(object sender, EventArgs e)
        {
            hexManager.PKRuSDayDropDownMenu(sender);
        }

        private void PPUPToNumUpDown(object sender, EventArgs e)
        {
            hexManager.PPUPToNumUpDown(sender);
        }

        private void NumUpDownToPPUP(object sender, EventArgs e)
        {
            hexManager.NumUpDownToPPUP(sender);
        }

        private void NumUpDownToStringTextbox(object sender, EventArgs e)
        {
            hexManager.NumUpDownToStringTextbox(sender);
        }

        private void StringTextboxToNumUpDown(object sender, EventArgs e)
        {
            hexManager.StringTextboxToNumUpDown(sender);
        }

        private void NumUpDownToControls(object sender, EventArgs e)
        {
            hexManager.NumUpDownToControls(sender);
        }

        private void TextBoxAndComboToNumUpDown(object sender, EventArgs e)
        {
            hexManager.TextBoxAndComboToNumUpDown(sender);
        }

        private void ComboBoxAndTextToNumUpDown(object sender, EventArgs e)
        {
            hexManager.ComboBoxAndTextToNumUpDown(sender);
        }

        private void DataGridViewRowSelect(object sender, DataGridViewCellEventArgs e)
        {
            runTimeManager.ApplicatonValues().SelectIndex = Convert.ToInt32(DisplayDGV.Rows[DisplayDGV.CurrentCell.RowIndex].Index);
        }

        private void OrginNumUpDownToControls(object sender, EventArgs e)
        {
            hexManager.OrginNumUpDownToControls(sender);
        }

        private void OrginTextBoxAndComboToNumUpDown(object sender, EventArgs e)
        {
            hexManager.OrginTextBoxAndComboToNumUpDown(sender);
        }

        private void OrginComboBoxAndTextToNumUpDown(object sender, EventArgs e)
        {
            hexManager.OrginComboBoxAndTextToNumUpDown(sender);
        }

        private void ValidID(object sender, EventArgs e)
        {
            validationManager.IsNumber(sender, 65535);
        }
    }
}
using PK3_RAM_Injection.Controller;
using PK3_RAM_Injection.Data;
using PK3_RAM_Injection.Model;
using PK3_RAM_Injection.View;
using System.ComponentModel;
using System.Security;

namespace PK3_RAM_Injection
{
    public partial class PK3_RAM_Injection : Form
    {
        readonly Data_Conversion hex;
        readonly Dex_Conversion dex;
        readonly Pokemon_Data data;
        readonly File_Manager fm;
        readonly Data_Ripper rip;
        readonly Applicaton_Values val;
        readonly Offest_data offest;
        readonly Game_Values gv;
        Set_Values sv;
        readonly List<string> list;
        readonly List<List<byte>> pokemon;

        private delegate void DataSetMethodInvoker();
        public delegate void MaxProgressMethodInvoker(int amount);
        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();

        public PK3_RAM_Injection()
        {
            InitializeComponent();

            hex = new();
            dex = new();
            data = new();
            fm = new();
            rip = new();
            val = new();
            offest = new();
            gv = new();
            sv = new();
            pokemon = new List<List<byte>>();
            list = new List<string>();

            fm.MP += new File_Manager.MaxProgressMethodInvoker(SetAmount);
            rip.CP += new Data_Ripper.CurrentProgressMethodInvoker(UpdateProgress);
            rip.End += new Data_Ripper.EndThread(Stopper);
        }

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                FileOpen();
        }

        // <summary>
        /// Opens the selected file
        /// </summary>
        private void FileOpen()
        {
            try
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                OpenFileTXB.Text = string.Format("{0}", openFileDialog1.FileName); //Show file path in textbox
                val.FileAdded = true; //fileAdded = true;
                val.Path = string.Format("{0}", openFileDialog1.FileName);
                FileInfo fi = new(val.Path);
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        private void PK3_RAM_Injection_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files && files.Any() && OpenFileBTN.Enabled == true)
            {
                openFileDialog1.FileName = files.First();
                FileOpen();
            }
        }

        private void PK3_RAM_Injection_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ExtractBTN_Click(object sender, EventArgs e)
        {
            SaveDialog(val.SelectIndex);
        }

        private void SaveDialog(int slot)
        {
            SaveFileDialog saveFileDialog1 = new();

            saveFileDialog1.Filter = "PK3|*.pk3";

            saveFileDialog1.Title = "Save Pokemon";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != string.Empty)
            {
                byte[] saveData = new byte[gv.StorageDataSize];
                //Stores the selected Pokemon into a separate array
                for (int i = 0; i < gv.StorageDataSize; i++)
                {
                    saveData[i] = pokemon[slot][i];
                }

                fm.WriteFile(string.Format("{0}", saveFileDialog1.FileName), saveData);
            }
        }

        private void FindPkmnBTN_Click(object sender, EventArgs e)
        {
            pokemon.Clear();
            if (!backgroundWorker1.IsBusy) //If search hasn't began
            {
                sv.ApplicationPartReset(val);
                backgroundWorker1.WorkerSupportsCancellation = true;
                val.EndTask = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else //If the search if forcfully stopped
            {
                backgroundWorker1.CancelAsync();
                val.EndTask = true;
                PkmnSelectCB.Items.Clear();
                RipProgressBar.Value = 0;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            RipProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Force stops the search
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (val.FileAdded == true) //Searches for a Pokemon
            {
                //Set values for main line game
                SetClasses(3, 0);

                int intID = Convert.ToInt32(TidTXT.Text);
                byte temp = 0x00;
                var tid = new byte[2];
                tid[0] = (byte)(intID >> 8);
                tid[1] = (byte)intID;

                temp = tid[0];
                tid[0] = tid[1];
                tid[1] = temp;

                fm.LoadData(string.Format("{0}", openFileDialog1.FileName), val);
                rip.SearchPokemon(pokemon, val, offest, gv, tid);

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(val.Found.ToString() + " Pokemon found.");

            BindComboBoxData(); //Adds found Pokemon to combo box
        }

        private void SetClasses(int gen, int subGen)
        {
            val.Gen = gen;
            val.SubGen = subGen;
            sv.GameSetValues(gv, gen, subGen);
            sv.OffsetSetValues(offest, gen, subGen);
        }

        private void BindComboBoxData()
        {
            if (PkmnSelectCB.InvokeRequired)
                PkmnSelectCB.Invoke(new DataSetMethodInvoker(BindComboBoxData));// Worker thread
            else
            {
                object[] ItemObject = new object[val.Found];
                if (val.Found != 0)
                {
                    PkmnSelectCB.Items.Clear();
                    for (int i = 0; i < val.Found; i++)
                    {
                        val.DexNum = dex.Gen3GetDexNum(hex.LittleEndian2D(pokemon, i, offest.Dex, offest.SizeDex, gv.Invert));

                        ItemObject[i] = data.GetPokemonName(val.DexNum);
                    }
                    PkmnSelectCB.Items.AddRange(ItemObject);
                    PkmnSelectCB.SelectedIndex = 0;
                }
            }
        }

        private void SetAmount(int amount)
        {
            if (RipProgressBar.InvokeRequired)
                RipProgressBar.Invoke(new MaxProgressMethodInvoker(SetAmount), amount);
            else
            {
                RipProgressBar.Maximum = amount;
                RipProgressBar.Value = 0;
            }
        }

        private void UpdateProgress(int amount)
        {
            if (RipProgressBar.InvokeRequired)
                RipProgressBar.Invoke(new CurrentProgressMethodInvoker(UpdateProgress), amount);
            else
                RipProgressBar.Value = amount;
        }

        public bool Stopper()
        {
            return val.EndTask;
        }

        private void PkmnSelectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            val.SelectIndex = PkmnSelectCB.SelectedIndex;

            if (list.Count == 0)
                list.Add("1");

            /*
             Add textbox message code here.
             */
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            var editor = new PK3_RAM_Hex_Editor();
            editor.Show();
        }
    }
}
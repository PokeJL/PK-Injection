using RAM_Injection_Data.Controller;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using ProgressBar = System.Windows.Forms.ProgressBar;
using RAM_Injection_Data.Model;
using PKHeX.Core;
using System.Windows.Forms;

namespace PK3_RAM_Injection
{
    public class Form_Function_Manager
    {
        public Form_Function_Manager() {}

        public async void FindData(Run_Time_Manager rt, ComboBox comboBox, TextBox textBox, OpenFileDialog openFileDialog, ProgressBar progressBar, DataGridView dataGridView)
        {
            int updateTime = 0;
            //rt.ApplicatonValues().Found = 0;
            rt.PokemonGen3s().Clear();
            comboBox.Items.Clear();

            if (rt.ApplicatonValues().FileAdded == true) //Searches for a Pokemon
            {
                ////Set values for main line game
                //rt.ApplicatonValues().Gen = 3;
                //rt.ApplicatonValues().SubGen = 0;
                //rt.SetValues().GameSetValues(rt.GameValues(), 3, 0);
                //rt.SetValues().OffsetSetValues(rt.OffestData(), 3, 0);

                int intID = Convert.ToInt32(textBox.Text);
                byte temp = 0x00;
                var tid = new byte[2];
                tid[0] = (byte)(intID >> 8);
                tid[1] = (byte)intID;

                temp = tid[0];
                tid[0] = tid[1];
                tid[1] = temp;

                rt.FileManager().LoadData(string.Format("{0}", openFileDialog.FileName), rt.ApplicatonValues());
                progressBar.Maximum = rt.ApplicatonValues().FileData.Length;
                progressBar.Value = 0;
                updateTime = UpdateProgressBar(rt.ApplicatonValues().FileData.Length); //Gets update intervals

                IProgress<int> progress = new Progress<int>(percent => progressBar.Value = percent);

                await Task.Run(() =>
                {
                    for (int i = 0; i < rt.ApplicatonValues().FileData.Length && rt.ApplicatonValues().FileData.Length >= rt.GameValues().PartyDataSize; i++)
                    {
                        ProgressUpdate(i, updateTime, rt.ApplicatonValues().FileData, progress);
                        rt.FindData().SearchPokemon(rt.PokemonGen3s(), rt.ApplicatonValues(), rt.OffestData(), rt.GameValues(), tid, i);
                    }
                });
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(rt.PokemonGen3s().Count.ToString() + " Pokemon found.");

            BindComboBoxData(rt, comboBox); //Adds found Pokemon to combo box
            DisplayPokemon(dataGridView, rt.FindData(), rt.PokemonGen3s());
        }

        public void InjectData(Run_Time_Manager rt)
        {
            rt.ArrayManager().CommitEditToObject(rt.InjectPokemon() , rt.PokemonGen3s()[rt.ApplicatonValues().SelectIndex]);
        }

        public void SelectedData(Run_Time_Manager rt, ComboBox comboBox)
        {
            rt.ApplicatonValues().SelectIndex = comboBox.SelectedIndex;

            if (rt.List().Count == 0)
                rt.List().Add("1");

            /*
             Add textbox message code here.
             */
        }

        public void Encrypted(Run_Time_Manager rt, CheckBox checkBox)
        {
            if(checkBox.Checked)
                rt.GameValues().IsEncrypted = true;
            else rt.GameValues().IsEncrypted = false;
        }

        public void LoadNumericUpDown(TabPage sender, List<List<NumericUpDown>> num)
        {
            foreach (var t in sender.Parent.Controls.OfType<TabPage>())
            {
                foreach (var g in t.Controls.OfType<GroupBox>())
                {
                    foreach (var n in g.Controls.OfType<NumericUpDown>())
                    {
                        if(num.Count == 0)
                        {
                            num.Add(new List<NumericUpDown>());
                            num[0].Add(n);
                        }
                        else if (num[num.Count - 1][0].Tag == n.Tag)
                        {
                            num[num.Count - 1].Add(n);
                        }
                        else
                        {
                            num.Add(new List<NumericUpDown>());
                            num[num.Count - 1].Add(n);
                        }
                    }
                }
            }
        }

        private void ProgressUpdate(int amount, int time, byte[] data, IProgress<int> progress)
        {
            if (amount % time == 0) //Update bar if module is 0
                progress.Report(amount);
            else if (amount + 1 == data.Length) //Update bar if the next loop is the last
                progress.Report(amount);
        }

        //163 allows for update intervals that don't slow down the process by delaying the update by a bit
        static private int UpdateProgressBar(int size)
        {
            int timing;
            if (size <= 163)
                timing = size;
            else
                timing = (int)(size / 163);
            return timing;
        }

        private void DisplayPokemon(DataGridView dataGridView, Data_Ripper search, List<Pokemon_Gen3> list)
        {
            List<Display_Data> display = new List<Display_Data>();
            dataGridView.Columns.Clear();

            for(int i = 0; i < list.Count; i++) 
            { 
                display.Add(search.AddData(list[i]));
            }

            dataGridView.DataSource = display;
        }

        private void BindComboBoxData(Run_Time_Manager rt, ComboBox comboBox)
        {
            object[] ItemObject = new object[rt.PokemonGen3s().Count];
            if (rt.PokemonGen3s().Count != 0)
            {
                comboBox.Items.Clear();
                for (int i = 0; i < rt.PokemonGen3s().Count; i++)
                {
                    rt.ApplicatonValues().DexNum = rt.DexConversion().Gen3GetDexNum(rt.DataConversion().LittleEndianObject(rt.PokemonGen3s()[i].PokemonID, rt.GameValues().Invert));

                    ItemObject[i] = rt.PokemonData().GetPokemonName(rt.ApplicatonValues().DexNum);
                }
                comboBox.Items.AddRange(ItemObject);
                comboBox.SelectedIndex = 0;
            }
        }
    }
}

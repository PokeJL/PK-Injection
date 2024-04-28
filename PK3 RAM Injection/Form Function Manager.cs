using RAM_Injection_Data.Controller;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using ProgressBar = System.Windows.Forms.ProgressBar;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace PK3_RAM_Injection
{
    public class Form_Function_Manager
    {
        public Form_Function_Manager() {}

        public async void FindData(Run_Time_Manager rt, ComboBox comboBox, TextBox textBox, OpenFileDialog openFileDialog, ProgressBar progressBar)
        {
            int updateTime = 0;
            rt.PokemonGen3s().Clear();
            comboBox.Items.Clear();
            //RipProgressBar.Value = 0;

            if (rt.ApplicatonValues().FileAdded == true) //Searches for a Pokemon
            {
                //Set values for main line game
                rt.ApplicatonValues().Gen = 3;
                rt.ApplicatonValues().SubGen = 0;
                rt.SetValues().GameSetValues(rt.GameValues(), 3, 0);
                rt.SetValues().OffsetSetValues(rt.OffestData(), 3, 0);

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
                        //if (i % updateTime == 0) //Update bar if module is 0
                        //    progress.Report(i);
                        //else if (i + 1 == rt.ApplicatonValues().FileData.Length) //Update bar if the next loop is the last
                        //    progress.Report(i);
                        rt.FindData().SearchPokemon(rt.PokemonGen3s(), rt.ApplicatonValues(), rt.OffestData(), rt.GameValues(), tid, i);
                    }
                });
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No file added.");
            }

            System.Windows.Forms.MessageBox.Show(rt.ApplicatonValues().Found.ToString() + " Pokemon found.");

            BindComboBoxData(rt, comboBox); //Adds found Pokemon to combo box
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

        private void BindComboBoxData(Run_Time_Manager rt, ComboBox comboBox)
        {
            object[] ItemObject = new object[rt.ApplicatonValues().Found];
            if (rt.ApplicatonValues().Found != 0)
            {
                comboBox.Items.Clear();
                for (int i = 0; i < rt.ApplicatonValues().Found; i++)
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

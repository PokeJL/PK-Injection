using RAM_Injection_Data.Controller;
using RAM_Injection_Data.Data;
using RAM_Injection_Data.Model;
using System.Security;
using TextBox = System.Windows.Forms.TextBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using ProgressBar = System.Windows.Forms.ProgressBar;

namespace PK3_RAM_Injection
{
    public class Form_File_Manager
    {
        public Form_File_Manager() {}

        public void OpenFile(Run_Time_Manager rt, OpenFileDialog openFileDialog, TextBox textBox)
        {
            openFileDialog.FileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenDialog(rt, openFileDialog, 1);
                textBox.Text = string.Format("{0}", openFileDialog.FileName); //Show file path in textbox
            }
        }

        public void ExtractData(Run_Time_Manager rt)
        {
            SaveDialog(rt, rt.ApplicatonValues().SelectIndex, "PK3|*.pk3", "Save Pokemon");
        }

        public void SaveData(Run_Time_Manager rt)
        {
            SaveDialog(rt, rt.ApplicatonValues().SelectIndex, "DMP|*.dmp", "Save RAM");
        }

        public void ImportData(Run_Time_Manager rt, OpenFileDialog openFileDialog)
        {
            openFileDialog.FileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                OpenDialog(rt, openFileDialog, 2);
            rt.FileManager().LoadDataImport(string.Format("{0}", openFileDialog.FileName), rt.ApplicatonValues());
            rt.ArrayManager().CopyPokemonObject(rt.InjectPokemon(), rt.ArrayManager().ArrayToPokemon(rt.ApplicatonValues().ImportData, rt.OffestData()), rt.OffestData());
        }

        /// <summary>
        /// Opens the selected file
        /// </summary>
        private void OpenDialog(Run_Time_Manager rt, OpenFileDialog openFileDialog, int openType)
        {
            try
            {
                var sr = new StreamReader(openFileDialog.FileName);
                if(openType == 1)
                {
                    //textBox.Text = string.Format("{0}", openFileDialog.FileName); //Show file path in textbox
                    rt.ApplicatonValues().FileAdded = true; //fileAdded = true;
                    rt.ApplicatonValues().Path = string.Format("{0}", openFileDialog.FileName);
                    FileInfo fi = new(rt.ApplicatonValues().Path);
                }
                else
                {
                    rt.ApplicatonValues().InjectFileAdded = true; //fileAdded = true;
                    rt.ApplicatonValues().InjectFilePath = string.Format("{0}", openFileDialog.FileName);
                    FileInfo fi = new(rt.ApplicatonValues().InjectFilePath);
                }
                
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }

        public void SaveDialog(Run_Time_Manager rt, int slot, string extention, string title)
        {
            SaveFileDialog saveFileDialog1 = new();

            saveFileDialog1.Filter = extention;

            saveFileDialog1.Title = title;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != string.Empty && title == "Save Pokemon")
            {
                byte[] saveData = new byte[rt.GameValues().StorageDataSize];
                rt.ArrayManager().PokemonToArray(saveData, rt.PokemonGen3s()[slot], rt.OffestData());
                rt.DataConversion().ChecksumCalculation(saveData, rt.OffestData());
                rt.FileManager().WriteFile(string.Format("{0}", saveFileDialog1.FileName), saveData);
            }
            else if (saveFileDialog1.FileName != string.Empty && title == "Save RAM")
            {

                for (int i = 0; i < rt.PokemonGen3s().Count; i++)
                {
                    if (rt.PokemonGen3s()[i].Edited)
                        rt.ArrayManager().PokemonToArrayInject(rt.ApplicatonValues(), rt.PokemonGen3s()[i], rt.OffestData());
                }
                rt.FileManager().WriteFile(string.Format("{0}", saveFileDialog1.FileName), rt.ApplicatonValues().FileData);
            }
        }
    }
}

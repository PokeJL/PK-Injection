using RAM_Injection_Data.Controller;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using ProgressBar = System.Windows.Forms.ProgressBar;
using RAM_Injection_Data.Model;

namespace PK3_RAM_Injection
{
    public class Form_Function_Manager
    {
        public Form_Function_Manager() {}

        public async void FindData(Run_Time_Manager rt, TextBox textBox, OpenFileDialog openFileDialog, ProgressBar progressBar, DataGridView dataGridView)
        {
            int updateTime = 0;
            rt.PokemonGen3s().Clear();

            if (rt.ApplicatonValues().FileAdded == true) //Searches for a Pokemon
            {
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
        }

        public void Encrypted(Run_Time_Manager rt, CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                rt.GameValues().IsEncrypted = true;
                checkBox.Text = "Data encrypted";
            }
            else
            {
                rt.GameValues().IsEncrypted = false;
                checkBox.Text = "Data not encrypted";
            }
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

        public void LoadEdit(Run_Time_Manager rt, DataGridView dg , List<List<NumericUpDown>>list)
        {
            Form_Display_Manager display = new();

            display.SetHexToEdit(rt.PokemonGen3s()[Convert.ToInt32(dg.Rows[dg.CurrentCell.RowIndex].Index)], list);
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

        public void DisplayPokemon(DataGridView dataGridView, Data_Ripper search, List<Pokemon_Gen3> list)
        {
            List<Display_Data> display = new List<Display_Data>();
            dataGridView.Columns.Clear();

            for(int i = 0; i < list.Count; i++) 
            { 
                display.Add(search.AddData(list[i]));
            }

            dataGridView.DataSource = display;

            //----Everything below this point is to make the display of the data grid view nice.----
            //Format column headers
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe", 12, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //Colour of everyother row
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            string sprite = string.Empty;
            dataGridView.Columns.Insert(0, img);
            if (dataGridView.RowCount > 0)
            {
                for (int i = 0; i < dataGridView.RowCount; i ++)
                { 
                    sprite = "a_" + dataGridView.Rows[i].Cells[1].Value.ToString();
                    dataGridView.Rows[i].Cells[0].Value = Properties.Resources.ResourceManager.GetObject(sprite);
                    dataGridView.Rows[i].Height = 56;
                }
            }

            dataGridView.Columns["SpeciesId"].Visible = false;

            //Species column
            dataGridView.Columns[0].HeaderText = "Pokémon";

            //Name column
            dataGridView.Columns[0].HeaderText = "Nickname";

            //Move 1 column
            dataGridView.Columns[0].HeaderText = "Move 1";

            //Move 2 column
            dataGridView.Columns[0].HeaderText = "Move 2";

            //Move 3 column
            dataGridView.Columns[0].HeaderText = "Move 3";

            //Move 4 column
            dataGridView.Columns[0].HeaderText = "Move 4";

            //Format columns loop to reduce redundant code.
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView.Columns[i].Width = 90;
            }
        }

        public Pokemon_Gen3 HexToInject(Run_Time_Manager rt, List<List<NumericUpDown>> sendersList)
        {
            Pokemon_Gen3 p = new();
            byte[] data = new byte[100];

            for (int i = 0; i < sendersList.Count; i++)
            {
                if (sendersList[i][0].Tag == "pid")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PID.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "species")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PokemonID.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "language")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Language.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "pkrus")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PKRus.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "item")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Item.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "version")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Orgins.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "met")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.MetLocation.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "m1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Move1.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "m2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Move2.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "m3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Move3.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "m4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Move4.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "mpp1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PP1.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "mpp2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PP2.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "mpp3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PP3.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "mpp4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PP4.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ppup")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.PPUps.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "exp")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.EXP.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "iv")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.IV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.HPEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.AttackEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.DefenceEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.SpAttackEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev5")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.SpDefenceEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ev6")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.SpeedEV.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "friend")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Friendship.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "id")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.TrainerID.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "sid")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.SecretID.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ot")
                {
                    for (int j = 0, n = sendersList[i].Count - 1; j < sendersList[i].Count; j++, n--)
                    {
                        p.OTName.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "nickname")
                {
                    for (int j = 0, n = sendersList[i].Count - 1; j < sendersList[i].Count; j++, n--)
                    {
                        p.Nickname.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Cool.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Cute.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Beauty.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Tough.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest5")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Smart.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "contest6")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Feel.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "ribbon")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Ribbion.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "unknown")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Unknown.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "unused")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Unused.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "misc")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Misc.Add((byte)sendersList[i][j].Value);
                    }
                }
                else if (sendersList[i][0].Tag == "mark")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        p.Marks.Add((byte)sendersList[i][j].Value) ;
                    }
                }
            }

            rt.ArrayManager().PokemonToArray(data, p, rt.OffestData());
            rt.DataConversion().ChecksumCalculation(data, rt.OffestData());
            p = rt.ArrayManager().ArrayToPokemon(data, rt.OffestData());

            return p;
        }
    }
}

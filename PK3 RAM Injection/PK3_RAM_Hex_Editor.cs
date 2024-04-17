using RAM_Injection_Data;
using RAM_Injection_Data.Controller;
using RAM_Injection_Data.View;
using static System.Buffers.Binary.BinaryPrimitives;

namespace PK3_RAM_Injection
{
    public partial class PK3_RAM_Hex_Editor : Form
    {
        Pokemon_Data pd;
        public PK3_RAM_Hex_Editor()
        {
            InitializeComponent();
            pd = new();
            //pidTB.Text = FourBitHex(pidNUD4.Value, pidNUD3.Value, pidNUD2.Value, pidNUD1.Value);
            //idTB.Text = TwoBitHex(idNUD2.Value, idNUD1.Value);
            //sidTB.Text = TwoBitHex(sidNUD2.Value, sidNUD1.Value);
            eggCB.SelectedIndex = 0;
            abilityCB.SelectedIndex = 0;
            speciesCB.SelectedIndex = 0;
            move1CB.SelectedIndex = 0;
            move2CB.SelectedIndex = 0;
            move3CB.SelectedIndex = 0;
            move4CB.SelectedIndex = 0;
            ppUpCB1.SelectedIndex = 0;
            ppUpCB2.SelectedIndex = 0;
            ppUpCB3.SelectedIndex = 0;
            ppUpCB4.SelectedIndex = 0;
        }

        //private string[] FourBitHex(decimal[] data, string[] str)
        //{
        //    for (int i = data.Length - 1; i >= 0; i--)
        //        str[0] += Convert.ToInt32(Math.Round(data[i], 0)).ToString("X").PadLeft(2, '0');
        //    return str;
        //}

        //private string[] TwoBitHex(decimal[] data, string[] str)
        //{
        //    str[0] = (Convert.ToInt32(
        //        Convert.ToInt32(Math.Round(data[1], 0)).ToString("X").PadLeft(2, '0') +
        //        Convert.ToInt32(Math.Round(data[0], 0)).ToString("X").PadLeft(2, '0'), 16)).ToString().PadLeft(5, '0');
        //    return str;
        //}

        //private string EightByteHex(decimal[] data/*, decimal b, decimal c, decimal d, decimal e, decimal f*/)
        //{
        //string bin = string.Empty;
        //string hex = string.Empty;
        //int[] temp = new int[data.Length];

        //for (int i = 0; i < data.Length; i++)
        //    temp[i] = Convert.ToInt32(Math.Round(data[i], 0));
        //for (int i = temp.Length - 1; i > 1; i--)
        //    bin += Convert.ToString(temp[i], 2).PadLeft(5, '0');
        //bin += Convert.ToString(temp[1], 2);
        //bin += Convert.ToString(temp[0], 2);
        //bin = bin.PadRight(32, '0');
        //for (int i = 0; i < bin.Length; i += 8)
        //{
        //    string eightBits = bin.Substring(i, 8);
        //    hex += string.Format("{0:X2}", Convert.ToByte(eightBits, 2));
        //}
        //return hex;
        //}

        private void ivCalc(decimal[] data, string[] str, int[] cb)
        {
            byte[] dataByte = new byte[data.Length];
            dataByte[0] = Decimal.ToByte(data[3]);
            dataByte[1] = Decimal.ToByte(data[2]);
            dataByte[2] = Decimal.ToByte(data[1]);
            dataByte[3] = Decimal.ToByte(data[0]);

            int iv = ReadInt32LittleEndian(dataByte.AsSpan(0));
            str[5] = (iv & 31).ToString(); //hp
            str[4] = ((iv >> 5) & 31).ToString(); //att
            str[3] = ((iv >> 10) & 31).ToString(); //def
            str[2] = ((iv >> 15) & 31).ToString(); //speed
            str[1] = ((iv >> 20) & 31).ToString(); //spa
            str[0] = ((iv >> 25) & 31).ToString(); //spd
            cb[0] = (iv >> 30) & 1;
            cb[1] = (iv >> 31) & 1;
        }

        //private string[] ByteToName(decimal[] data, string[] str)
        //{
        //    Name_Characters nc = new();
        //    for (int i = data.Length - 1; i >= 0; i--)
        //        str[0] += nc.GetLetter(Convert.ToInt32(Math.Round(data[i], 0)));

        //    return str;
        //}

        //private void TwoHexCombo(decimal[] data, int[] cb)
        //{
        //    cb[0] = Convert.ToInt32(
        //        Convert.ToInt32(Math.Round(data[1], 0)).ToString("X").PadLeft(2, '0') +
        //        Convert.ToInt32(Math.Round(data[0], 0)).ToString("X").PadLeft(2, '0'), 16);
        //}

        private void StringLengthNUBTXT(decimal[] data, string[] str)
        {
            if (data.Length == 2 && str.Length == 1)
            {
                str[0] = (Convert.ToInt32(
                Convert.ToInt32(Math.Round(data[1], 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(data[0], 0)).ToString("X").PadLeft(2, '0'), 16)).ToString().PadLeft(5, '0');
                //return str;
                //return TwoBitHex(data, str);
            }
            else if (data.Length == 10 || data.Length == 7 && str.Length == 1)
            {
                Name_Characters nc = new();
                for (int i = data.Length - 1; i >= 0; i--)
                    str[0] += nc.GetLetter(Convert.ToInt32(Math.Round(data[i], 0)));

                //return str;
                //return ByteToName(data, str);
            }
            else if (data.Length == 4 && str.Length == 1)
            {
                for (int i = data.Length - 1; i >= 0; i--)
                    str[0] += Convert.ToInt32(Math.Round(data[i], 0)).ToString("X").PadLeft(2, '0');
                //return str;
                //return FourBitHex(data, str);
            }
        }

        private void StringLengthNUBTXTCB(decimal[] data, string[] str, int[] cb)
        {
            if (data.Length == 4 && str.Length == 6 && cb.Length == 2)
                ivCalc(data, str, cb);
            else;
        }

        private void ComboBoxSelect(decimal[] data, int[] cb)
        {
            if (data.Length == 2 && cb.Length == 1)
            {
                cb[0] = Convert.ToInt32(
                Convert.ToInt32(Math.Round(data[1], 0)).ToString("X").PadLeft(2, '0') +
                Convert.ToInt32(Math.Round(data[0], 0)).ToString("X").PadLeft(2, '0'), 16);
            }
            else if (data.Length == 1 && cb.Length == 4)
            {
                int pp = Convert.ToInt32(Math.Round(data[0], 0));
                cb[3] = pp & 3;
                cb[2] = (pp >> 2) & 3;
                cb[1] = (pp >> 4) & 3;
                cb[0] = (pp >> 6) & 3;
            }
        }

        private void ByteUpdate(object sender, EventArgs e)
        {
            string gbName;
            if (sender.GetType() == typeof(NumericUpDown))
            {
                gbName = ((NumericUpDown)sender).Parent.Name;
            }
            else if (sender.GetType() == typeof(TextBox))
            {
                gbName = ((TextBox)sender).Parent.Name;
            }
            else
            {
                gbName = ((ComboBox)sender).Parent.Name;
            }

            foreach (Control control in this.Controls)
            {
                if (control.Name == gbName)
                {
                    var children = control.Controls.OfType<Control>();
                    bool textboxExist = false;
                    bool comboboxExists = false;
                    int index = 0;
                    decimal[] resultDec = new decimal[children.OfType<NumericUpDown>().Count()];
                    foreach (var child in children.OfType<NumericUpDown>())
                    {
                        resultDec[index] = child.Value;
                        index++;
                    }

                    if (children.OfType<TextBox>().Any())
                        textboxExist = true;
                    if (children.OfType<ComboBox>().Any())
                        comboboxExists = true;
                    index = 0;
                    if (!comboboxExists && textboxExist)
                    {
                        string[] resultStr = new string[children.OfType<TextBox>().Count()];
                        StringLengthNUBTXT(resultDec, resultStr);
                        foreach (var child in children.OfType<TextBox>())
                        {
                            child.Text = resultStr[index];
                            index++;
                        }
                        break;
                    }
                    else if (comboboxExists && !textboxExist)
                    {
                        int[] resultCB = new int[children.OfType<ComboBox>().Count()];
                        ComboBoxSelect(resultDec, resultCB);
                        foreach (var child in children.OfType<ComboBox>())
                        {
                            child.SelectedIndex = resultCB[index];
                            index++;
                        }
                        break;
                    }
                    else
                    {
                        string[] resultStr = new string[children.OfType<TextBox>().Count()];
                        int[] resultCB = new int[children.OfType<ComboBox>().Count()];
                        StringLengthNUBTXTCB(resultDec, resultStr, resultCB);
                        foreach (var child in children.OfType<TextBox>())
                        {
                            child.Text = resultStr[index];
                            index++;
                        }
                        index = 0;
                        foreach (var child in children.OfType<ComboBox>())
                        {
                            child.SelectedIndex = resultCB[index];
                            index++;
                        }
                        break;
                    }


                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Buffers.Binary.BinaryPrimitives;
using System.Security;
using System.Windows.Forms;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using PKHeX.Core;
using System.Reflection;

namespace PK3_RAM_Injection
{
    public class Form_Hex_Manager
    {
        Form_Validation_Manager val = new();
        public Form_Hex_Manager() { }

        public void NumUpDownToTextboxDecimal(object sender)
        {
            if (sender.GetType() == typeof(NumericUpDown))
            {
                decimal[] resultDec = NumUpDownToArray(sender);
                string resultStr = string.Empty;

                //foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
                //{
                //    TextBoxDecimalToNumUpDown(child);
                //}

                for (int i = resultDec.Length - 1; i >= 0; i--) 
                    resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

                resultStr = (Convert.ToInt32(resultStr, 16)).ToString().PadLeft(5, '0');

                foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
                {
                    child.Text = resultStr;
                }
            }
        }

        public void NumUpDownToTextboxHex(object sender)
        {
            if (sender.GetType() == typeof(NumericUpDown))
            {
                decimal[] resultDec = NumUpDownToArray(sender);
                string resultStr = string.Empty;

                for (int i = resultDec.Count() - 1; i >= 0; i--)
                    resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

                foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
                {
                    child.Text = resultStr;
                }
            }
        }

        private decimal[] NumUpDownToArray(object sender)
        {
            int index = 0;
            decimal[] resultDec = new decimal[((NumericUpDown)sender).Parent.Controls.Count - 1];
            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                resultDec[index] = child.Value;
                index++;
            }

            return resultDec;
        }

        //private string DecimalArrayToString(decimal[] resultDec)
        //{
        //    string resultStr = string.Empty;

        //    for (int i = resultDec.Count() - 1; i >= 0; i--)
        //        resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

        //    return resultStr;
        //}

        public void TextBoxDecimalToNumUpDown(object sender)
        {
            if (sender.GetType() == typeof(TextBox) /*&& val.IsNumber(sender)*/)
            {
                val.NumberFormatting(sender);
                val.NumberInRangeTextbox(sender);

                int index = 0;

                uint num = uint.Parse(((TextBox)sender).Text, System.Globalization.NumberStyles.Integer);

                byte[] resultByte = BitConverter.GetBytes(num);
                //byte[] resultByte = BitConverter.GetBytes(Convert.ToInt32(((TextBox)sender).Text));
                //try
                //{
                //    resultByte = BitConverter.GetBytes(Convert.ToInt32(((TextBox)sender).Text));
                //}
                //catch 
                //{
                //    resultByte = BitConverter.GetBytes(0);
                //}
                byte[] temp = new byte[((TextBox)sender).Parent.Controls.Count - 1];
                for (int i = 0; i < ((TextBox)sender).Parent.Controls.Count - 1; i++)
                    temp[i] = resultByte[i];

                foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
                {
                    child.Value = temp[index];
                    index++;
                }
            }
            //else if (((TextBox)sender).Focused && !val.IsNumber(sender))
            //    val.NumberFormatting(sender);
        }

        public void TextBoxHexToNumUpDown(object sender)
        {
            if (sender.GetType() == typeof(TextBox) /*&& val.IsNumberHex(sender)*/)
            {
                val.NumberFormattingHex(sender);

                int index = 0;

                uint num = uint.Parse(((TextBox)sender).Text, System.Globalization.NumberStyles.AllowHexSpecifier);

                byte[] temp = BitConverter.GetBytes(num);

                foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
                {
                    child.Value = temp[index];
                    index++;
                }
            }
            //else if (((TextBox)sender).Focused && !val.IsNumberHex(sender))
            //    val.NumberFormattingHex(sender);
        }

        public void NumUpDownToDropMenu(object sender)
        {
            if (sender.GetType() == typeof(NumericUpDown))
            {
                decimal[] resultDec = NumUpDownToArray(sender);
                string resultStr = string.Empty;

                for (int i = resultDec.Length - 1; i >= 0; i--)
                    resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

                resultStr = (Convert.ToInt32(resultStr, 16)).ToString().PadLeft(5, '0');

                foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<ComboBox>())
                {
                    if(Convert.ToInt32(resultStr) < child.Items.Count - 1)
                        child.SelectedIndex = Convert.ToInt32(resultStr);
                    else
                        child.SelectedIndex = child.Items.Count - 1;
                }
            }
        }

        public void DropMenuToNumUpDown(object sender)
        {
            if (sender.GetType() == typeof(ComboBox) /*&& val.IsNumber(sender)*/)
            {
                int index = 0;
                int selectedIndex = ((ComboBox)sender).SelectedIndex;
                byte[] resultByte = BitConverter.GetBytes(selectedIndex);
                byte[] temp = new byte[((ComboBox)sender).Parent.Controls.Count - 1];

                for (int i = 0; i < ((ComboBox)sender).Parent.Controls.Count - 1; i++)
                    temp[i] = resultByte[i];

                foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
                {
                    child.Value = temp[index];
                    index++;
                }
            }
        }

        public void PKRuSStrainDropDownMenu(object sender)
        {
            if (sender.GetType() == typeof(ComboBox) ) 
            {
                int maxDays = 0;
                //string infection;

                if (((ComboBox)sender).SelectedIndex == 4 ||
                    ((ComboBox)sender).SelectedIndex == 8 ||
                    ((ComboBox)sender).SelectedIndex == 12)
                    maxDays = 1;
                else if (((ComboBox)sender).SelectedIndex == 1 ||
                    ((ComboBox)sender).SelectedIndex == 5 ||
                    ((ComboBox)sender).SelectedIndex == 9 ||
                    ((ComboBox)sender).SelectedIndex == 13)
                    maxDays = 2;
                else if (((ComboBox)sender).SelectedIndex == 2 ||
                    ((ComboBox)sender).SelectedIndex == 6 ||
                    ((ComboBox)sender).SelectedIndex == 10 ||
                    ((ComboBox)sender).SelectedIndex == 14)
                    maxDays = 3;
                else if (((ComboBox)sender).SelectedIndex == 3 ||
                    ((ComboBox)sender).SelectedIndex == 7 ||
                    ((ComboBox)sender).SelectedIndex == 11 ||
                    ((ComboBox)sender).SelectedIndex == 15)
                    maxDays = 4;

                int[] days = new int[maxDays + 1];
                for (int i = 0; i < maxDays + 1; i++)
                {
                    days[i] = i;
                }

                foreach(var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
                {
                    if (((ComboBox)sender).Name != child.Name)
                        child.DataSource = days;
                }

                Infection(0, ((ComboBox)sender).SelectedIndex, sender);
                //infection = 0.ToString("X") + ((ComboBox)sender).SelectedIndex.ToString("X");

                //int index = 0;

                //uint num = uint.Parse(infection, System.Globalization.NumberStyles.AllowHexSpecifier);

                //byte[] temp = BitConverter.GetBytes(num);

                //foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
                //{
                //    child.Value = temp[index];
                //    index++;
                //}
            }
        }

        public void PKRuSDayDropDownMenu(object sender)
        {
            if (sender.GetType() == typeof(ComboBox))
            {
                int strain = 0;
                foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
                {
                    if (((ComboBox)sender).Name != child.Name)
                        strain = child.SelectedIndex;
                }

                Infection(((ComboBox)sender).SelectedIndex, strain, sender);
            }
        }

        private void Infection(int day, int strain, object sender)
        {
            string infection = day.ToString("X") + strain.ToString("X");
            int index = 0;

            uint num = uint.Parse(infection, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] temp = BitConverter.GetBytes(num);

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = temp[index];
                index++;
            }
        }

        public void PPUPToNumUpDown(object sender)
        {
            string binary = string.Empty;
            int result;
            int index = 0;
            //binary += Convert.ToString(((ComboBox)sender).SelectedIndex, 2);
            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                binary += Convert.ToString(child.SelectedIndex, 2);
            }

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);
            //byte[] temp = new byte[((ComboBox)sender).Parent.Controls.Count - 1];

            //for (int i = 0; i < ((ComboBox)sender).Parent.Controls.Count - 1; i++)
            //    temp[i] = resultByte[i];

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index++;
            }
        }
    }
}

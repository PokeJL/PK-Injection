using static System.Buffers.Binary.BinaryPrimitives;
using RAM_Injection_Data.Data;

namespace PK3_RAM_Injection
{
    public class Form_Hex_Manager
    {
        Form_Validation_Manager val = new();
        public Form_Hex_Manager() { }

        /// <summary>
        /// Loads data from numeric up downs as a decimal number into a textbox
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToTextboxDecimal(object sender)
        {
            decimal[] resultDec = NumUpDownToArray(sender);
            string resultStr = string.Empty;

            for (int i = resultDec.Length - 1; i >= 0; i--)
                resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

            resultStr = (Convert.ToInt32(resultStr, 16)).ToString().PadLeft(5, '0');

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
            {
                child.Text = resultStr;
            }
        }

        /// <summary>
        /// Loads data from numeric updowns as hex into a textbox
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToTextboxHex(object sender)
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

        /// <summary>
        /// Loads all numeric up downs into an array that belong to the same parent control
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Converts a decimal number from a textbox to numeric up downs
        /// </summary>
        /// <param name="sender"></param>
        public void TextBoxDecimalToNumUpDown(object sender)
        {
            val.NumberFormatting(sender);
            val.NumberInRangeTextbox(sender);

            int index = 0;

            uint num = uint.Parse(((TextBox)sender).Text, System.Globalization.NumberStyles.Integer);

            byte[] resultByte = BitConverter.GetBytes(num);
            byte[] temp = new byte[((TextBox)sender).Parent.Controls.Count - 1];
            for (int i = 0; i < ((TextBox)sender).Parent.Controls.Count - 1; i++)
                temp[i] = resultByte[i];

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = temp[index];
                index++;
            }
        }

        /// <summary>
        /// Converts a hex number from textbox to numeric up downs
        /// </summary>
        /// <param name="sender"></param>
        public void TextBoxHexToNumUpDown(object sender)
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

        /// <summary>
        /// Updates the selected index of a combo box from what numeric up down read
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToDropMenu(object sender)
        {
            decimal[] resultDec = NumUpDownToArray(sender);
            string resultStr = string.Empty;

            for (int i = resultDec.Length - 1; i >= 0; i--)
                resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

            resultStr = (Convert.ToInt32(resultStr, 16)).ToString().PadLeft(5, '0');

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<ComboBox>())
            {
                if (Convert.ToInt32(resultStr) < child.Items.Count - 1)
                    child.SelectedIndex = Convert.ToInt32(resultStr);
                else
                    child.SelectedIndex = child.Items.Count - 1;
            }
        }

        /// <summary>
        /// Updates numeric up down value to the selected index of a combo box
        /// </summary>
        /// <param name="sender"></param>
        public void DropMenuToNumUpDown(object sender)
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

        /// <summary>
        /// Updates a numeric up down from one of 2 combo boxes
        /// </summary>
        /// <param name="sender"></param>
        public void PKRuSStrainDropDownMenu(object sender)
        {
            int maxDays = 0;

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

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                if (((ComboBox)sender).Name != child.Name)
                    child.DataSource = days;
            }

            Infection(0, ((ComboBox)sender).SelectedIndex, sender);
        }

        /// <summary>
        /// Updates a numeric up down from one of 2 combo boxes
        /// </summary>
        /// <param name="sender"></param>
        public void PKRuSDayDropDownMenu(object sender)
        {
            int strain = 0;
            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                if (((ComboBox)sender).Name != child.Name)
                    strain = child.SelectedIndex;
            }

            Infection(((ComboBox)sender).SelectedIndex, strain, sender);
        }

        /// <summary>
        /// Sets the value of a numeric up down from 2 combo boxes
        /// </summary>
        /// <param name="day"></param>
        /// <param name="strain"></param>
        /// <param name="sender"></param>
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

        /// <summary>
        /// Takes the values of 4 combo boxes and displays the numeric result in 1 numeric up down
        /// </summary>
        /// <param name="sender"></param>
        public void PPUPToNumUpDown(object sender)
        {
            string binary = string.Empty;
            int result;
            int index = 0;
            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                binary += Convert.ToString(child.SelectedIndex, 2);
            }

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index++;
            }
        }

        /// <summary>
        /// Takes value from one numeric up down and adjusts 4 combo boxes index to match
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToPPUP(object sender)
        {
            decimal[] resultDec = NumUpDownToArray(sender);
            int[] selections = new int[4];
            string resultStr = string.Empty;
            int index = 0;

            for (int i = resultDec.Length - 1; i >= 0; i--)
                resultStr += Convert.ToInt32(Math.Round(resultDec[i], 0)).ToString("X").PadLeft(2, '0');

            resultStr = (Convert.ToInt32(resultStr, 16)).ToString().PadLeft(5, '0');

            resultStr = Convert.ToString(Convert.ToInt32(resultStr), 2).PadLeft(8, '0');

            for (int i = 0; i < 4; i++)
                selections[i] = Convert.ToInt32(resultStr.Substring(i * 2, 2), 2);

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<ComboBox>())
            {
                child.SelectedIndex = selections[index];
                index++;
            }
        }

        /// <summary>
        /// Builds a string of characters from values pulled from numeric up downs and stores the string into a textbox
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToStringTextbox(object sender)
        {
            Name_Characters nc = new();

            int index = 0;
            decimal[] resultNum = new decimal[((NumericUpDown)sender).Parent.Controls.Count - 1];
            string [] resultString = new string[1];

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                resultNum[index] = child.Value;
                index++;
            }
            index = 0;
            for (int i = ((NumericUpDown)sender).Parent.Controls.Count - 2; i >= 0; i--)
            {
                if(Convert.ToInt32(Math.Round(resultNum[i], 0)) < 247)
                    resultString[0] += nc.GetLetter(Convert.ToInt32(Math.Round(resultNum[i], 0)));
                else 
                {
                    resultString[0] += nc.GetLetter(255);
                    break;
                }
            }

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
            {
                child.Text = resultString[index];
                index++;
            }
        }

        /// <summary>
        /// Takes a string of characters and updates numeric up downs to the character corriponding values
        /// </summary>
        /// <param name="sender"></param>
        public void StringTextboxToNumUpDown(object sender) 
        {
            Name_Characters nc = new();

            int index = 0;
            decimal[] resultNum = new decimal[((TextBox)sender).Parent.Controls.Count - 1];
            for(int i = 0; i < ((TextBox)sender).Parent.Controls.Count - 1; i++)
            {
                resultNum[i] = 255;
            }

            for (int i = 0; i < ((TextBox)sender).Text.Length; i++)
            {
                resultNum[i] = nc.GetIndex(((TextBox)sender).Text.Substring(i, 1));
            }

            if(((TextBox)sender).Text.Length < ((TextBox)sender).Parent.Controls.Count - 1)
                resultNum[((TextBox)sender).Text.Length] = 255;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultNum[((TextBox)sender).Parent.Controls.Count - 2 - index];
                index++;
            }
        }

        /// <summary>
        /// Takes numeric updowns and get the overall binarry number to update textboxes and combo boxes
        /// </summary>
        /// <param name="sender"></param>
        public void NumUpDownToControls(object sender) 
        {
            byte[] dataByte = new byte[4];
            string[] str = new string[6];
            int[] cb = new int[2];
            int index = 3;

            foreach(var child in ((NumericUpDown)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                dataByte[index] = Decimal.ToByte(child.Value);
                index--;
            }

            int iv = ReadInt32LittleEndian(dataByte.AsSpan(0));
            str[5] = (iv & 31).ToString(); //hp
            str[4] = ((iv >> 5) & 31).ToString(); //att
            str[3] = ((iv >> 10) & 31).ToString(); //def
            str[2] = ((iv >> 15) & 31).ToString(); //speed
            str[1] = ((iv >> 20) & 31).ToString(); //spa
            str[0] = ((iv >> 25) & 31).ToString(); //spd
            cb[0] = (iv >> 30) & 1;
            cb[1] = (iv >> 31) & 1;

            index = 0;
            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
            {
                child.Text = str[index];
                index++;
            }

            index = 0;
            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<ComboBox>())
            {
                child.SelectedIndex = cb[index];
                index++;
            }
        }

        /// <summary>
        /// Gets the binary number from textboxes and comboboxes to store in numeric updowns.
        /// The sender object in a textbox
        /// </summary>
        /// <param name="sender"></param>
        public void TextBoxAndComboToNumUpDown(object sender)
        {
            val.NumberFormatting(sender);
            val.NumberInRangeTextbox(sender);

            int[] ivBinary = new int[6];
            int[] cbBinary = new int[2];
            char[] charArray;
            string binary = string.Empty;
            int result;
            int index = 0;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<TextBox>())
            {
                ivBinary[index] = Convert.ToInt32(child.Text);
                index++;
            }

            index = 0;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                cbBinary[index] = child.SelectedIndex;
                index++;
            }

            index = 3;

            for (int i = cbBinary.Length - 1; i >= 0; i--)
                binary += Convert.ToString(cbBinary[i], 2);

            for (int i = 0; i < ivBinary.Length; i++)
                binary += Convert.ToString(ivBinary[i], 2).PadLeft(5, '0');

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index--;
            }
        }

        /// <summary>
        /// Gets the binary number from textboxes and comboboxes to store in numeric updowns.
        /// The sender object in a combo box
        /// </summary>
        /// <param name="sender"></param>
        public void ComboBoxAndTextToNumUpDown(object sender)
        {
            int[] ivBinary = new int[6];
            int[] cbBinary = new int[2];
            char[] charArray;
            string binary = string.Empty;
            int result;
            int index = 0;

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<TextBox>())
            {
                ivBinary[index] = Convert.ToInt32(child.Text);
                index++;
            }

            index = 0;

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                cbBinary[index] = child.SelectedIndex;
                index++;
            }

            index = 3;

            for (int i = cbBinary.Length - 1; i >= 0; i--)
                binary += Convert.ToString(cbBinary[i], 2);

            for (int i = 0; i < ivBinary.Length; i++)
                binary += Convert.ToString(ivBinary[i], 2).PadLeft(5, '0');

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index--;
            }
        }

        /// <summary>
        /// Gets the binary from numeric up downs that update textbox and combo boxes accordingly
        /// </summary>
        /// <param name="sender"></param>
        public void OrginNumUpDownToControls(object sender)
        {
            string binary = string.Empty;
            string[] temp = new string[2];
            int[] binInt = new int[3];
            int level = 0;
            int index = 0;

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                temp[index] = Convert.ToString(Decimal.ToByte(child.Value), 2).PadLeft(8, '0');
                index++;
            }
            index = 0;

            binary = temp[1] + temp[0];

            binInt[2] = Convert.ToInt32(binary.Substring(0, 1), 2);
            binInt[1] = Convert.ToInt32(binary.Substring(1, 4), 2);
            binInt[0] = Convert.ToInt32(binary.Substring(5, 4), 2);
            level = Convert.ToInt32(binary.Substring(9, 7), 2);

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<ComboBox>())
            {
                if (binInt[1] < child.Items.Count - 1)
                    child.SelectedIndex = binInt[1];
                else
                    child.SelectedIndex = child.Items.Count - 1;
                index++;
            }

            foreach (var child in ((NumericUpDown)sender).Parent.Controls.OfType<TextBox>())
            {
                child.Text = level.ToString();
            }
        }

        /// <summary>
        /// Gets the binary number from textboxes and comboboxes to store in numeric updowns.
        /// The sender object in a textbox
        /// </summary>
        /// <param name="sender"></param>
        public void OrginTextBoxAndComboToNumUpDown(object sender)
        {
            val.NumberFormatting(sender);
            val.NumberInRangeTextbox(sender);

            int[] txtBinary = new int[1];
            int[] cbBinary = new int[3];
            char[] charArray;
            string binary = string.Empty;
            string[] sbin = new string[3];
            int result;
            int index = 0;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<TextBox>())
            {
                txtBinary[index] = Convert.ToInt32(child.Text);
                index++;
            }

            index = 0;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                cbBinary[index] = child.SelectedIndex;
                index++;
            }

            index = 0;

            sbin[2] = Convert.ToString(cbBinary[2], 2);

            for (int i = cbBinary.Length - 2; i >= 0; i--)
                sbin[i] = Convert.ToString(cbBinary[i], 2).PadLeft(4, '0');

            for (int i = sbin.Length - 1; i >= 0; i--)
                binary += sbin[i];

            for (int i = 0; i < txtBinary.Length; i++)
                binary += Convert.ToString(txtBinary[i], 2).PadLeft(7, '0');

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index++;
            }
        }

        /// <summary>
        /// Gets the binary number from textboxes and comboboxes to store in numeric updowns.
        /// The sender object in a combo box
        /// </summary>
        /// <param name="sender"></param>
        public void OrginComboBoxAndTextToNumUpDown(object sender)
        {
            int[] txtBinary = new int[1];
            int[] cbBinary = new int[3];
            char[] charArray;
            string binary = string.Empty;
            string[] sbin = new string[3];
            int result;
            int index = 0;

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<TextBox>())
            {
                txtBinary[index] = Convert.ToInt32(child.Text);
                index++;
            }

            index = 0;

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<ComboBox>())
            {
                cbBinary[index] = child.SelectedIndex;
                index++;
            }

            index = 0;

            sbin[2] = Convert.ToString(cbBinary[2], 2);

            for (int i = cbBinary.Length - 2; i >= 0; i--)
                sbin[i] = Convert.ToString(cbBinary[i], 2).PadLeft(4, '0');

            for (int i = sbin.Length - 1; i >= 0; i--)
                binary += sbin[i];

            for (int i = 0; i < txtBinary.Length; i++)
                binary += Convert.ToString(txtBinary[i], 2).PadLeft(7, '0');

            result = Convert.ToInt32(binary, 2);

            byte[] resultByte = BitConverter.GetBytes(result);

            foreach (var child in ((ComboBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                child.Value = resultByte[index];
                index++;
            }
        }
    }
}

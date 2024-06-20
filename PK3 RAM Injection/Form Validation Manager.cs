using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PK3_RAM_Injection
{
    public class Form_Validation_Manager
    {
        public Form_Validation_Manager() { }

        public bool IsNumber(object sender)
        {
            if (int.TryParse(((TextBox)sender).Text, out int value))
                return true;
            return false;
        }

        public bool IsNumberHex(object sender)
        {
            string character;
            for(int i = 0; i < ((TextBox)sender).Text.Length; i++) 
            {
                character = ((TextBox)sender).Text.Substring(i, 1).ToUpper();
                if (!int.TryParse(character , out int value))
                {
                    if ((character == "A" || character == "B" || character == "C" ||
                        character == "D" || character == "E" || character == "F") == false)
                        return false;
                }
            }
            return true;
        }

        public void NumberFormattingHex(object sender)
        {
            char[] arr;
            string temp = string.Empty;

            if (((TextBox)sender).Text != string.Empty)
            {
                arr = ((TextBox)sender).Text.ToUpper().ToCharArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (int.TryParse(arr[i].ToString(), out int value))
                        temp += arr[i].ToString();
                    else if (arr[i] == 'A' || arr[i] == 'B' || arr[i] == 'C' ||
                        arr[i] == 'D' || arr[i] == 'E' || arr[i] == 'F')
                        temp += arr[i].ToString();
                }
                ((TextBox)sender).Text = temp;
            }

            if (((TextBox)sender).Text == string.Empty)
                ((TextBox)sender).Text = "0";
        }

        public void NumberFormatting(object sender)
        {
            char[] arr;
            string temp = string.Empty;

            if (((TextBox)sender).Text != string.Empty)
            {
                arr = ((TextBox)sender).Text.ToCharArray();

                for(int i  = 0; i < arr.Length; i++) 
                {
                    if (int.TryParse(arr[i].ToString(), out int value))
                        temp += arr[i].ToString();
                }
                ((TextBox)sender).Text = temp;
            }

            if (((TextBox)sender).Text == string.Empty)
                ((TextBox)sender).Text = "0";
        }

        public void NumberInRangeTextbox(object sender)
        {
            int max = 0;
            //int count = NumUpDownCount(sender);

            //foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            //{
            //    count++;
            //}
            if (((TextBox)sender).MaxLength == 5)
                max = 65535;
            else if (((TextBox)sender).MaxLength == 3)
                max = 100;
            else
                max = 1640000;

            if (Convert.ToInt32(((TextBox)sender).Text) > max)
                ((TextBox)sender).Text = max.ToString();
            else if (Convert.ToInt32(((TextBox)sender).Text) < 0)
                ((TextBox)sender).Text = "0";
        }

        private int NumUpDownCount(object sender)
        {
            int count = 0;

            foreach (var child in ((TextBox)sender).Parent.Controls.OfType<NumericUpDown>())
            {
                count++;
            }

            return count;
        }
    }
}

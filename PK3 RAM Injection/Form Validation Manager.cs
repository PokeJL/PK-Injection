namespace PK3_RAM_Injection
{
    public class Form_Validation_Manager
    {
        public Form_Validation_Manager() { }

        /// <summary>
        /// Ensures that a string of characters is a valid positive number within a range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public bool IsNumber(object sender, int max)
        {
            if (int.TryParse(((TextBox)sender).Text, out int value))
            { 
                if (Convert.ToInt32(((TextBox)sender).Text) <= max && (Convert.ToInt32(((TextBox)sender).Text)) > -1)
                    return true;
            }

            ((TextBox)sender).Text = "00000";

            return false;
        }

        /// <summary>
        /// Ensures that a string of characters is a valid hex number
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Ensures that a sting of characters is a properly formatted hex number
        /// </summary>
        /// <param name="sender"></param>
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

        /// <summary>
        /// Makes sure a string of character is a properly formatted integer number
        /// </summary>
        /// <param name="sender"></param>
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

        /// <summary>
        /// Makes sure an integer numer is in a range of values
        /// </summary>
        /// <param name="sender"></param>
        public void NumberInRangeTextbox(object sender)
        {
            int max = 0;

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
    }
}

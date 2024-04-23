using PKHeX.Core;
using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class Data_Conversion
    {
        public Data_Conversion() { }

        /// <summary>
        /// Converts one hex byte to an int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int ConOneHex(byte hex)
        {
            return Convert.ToInt32(hex);
        }

        /// <summary>
        /// Converts a hex string stored in
        /// Little Endian to and int
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns the converted hex value as an int</returns>
        public int LittleEndian(byte[] hex, int start, int length, bool invertData)
        {
            byte[] buffer = new byte[length];

            Extract(hex, buffer, start, length);

            return LE(buffer, length, invertData);
        }

        public int LittleEndianObject(List<byte> hex, bool invertData)
        {
            byte[] buffer = new byte[hex.Count];

            for(int i = 0; i < buffer.Length; i++)
                buffer[i] = hex[i];

            return LE(buffer, buffer.Length, invertData);
        }

        private int LE(byte[] hex, int length, bool invertData)
        {
            int value = 0;

            if (invertData == true)
                Invert(hex);

            if (length == 1)
                value = ConOneHex(hex[0]);
            if (length == 2)
                value = Int16(hex);
            if (length == 3)
                value = Int24(hex);
            if (length == 4)
                value = Int32(hex);

            return value;
        }

        /// <summary>
        /// Extracts a hex string from a array of hex values
        /// </summary>
        /// <param name="hex">Hex array</param>
        /// <param name="start">Starting index in array</param>
        /// <param name="end">Last index in array</param>
        /// <returns>Returns array of extracted values</returns>
        private void Extract(byte[] hex, byte[] buffer, int start, int length) 
        {
            for(int i = 0; i < length; i++)
                buffer[i] = hex[i + start];
        }

        /// <summary>
        /// Inverts a 1D array
        /// </summary>
        /// <param name="buffer">Data needing to be inverted</param>
        private void Invert(byte[] buffer)
        {
            int m = buffer.Length - 1;
            byte temp;
            for (int i = 0; i < m; i++, m--)
            {
                temp = buffer[i];
                buffer[i] = buffer[m];
                buffer[m] = temp;
            }
        }

        //Two byte hex to int
        private int Int16(byte[] buffer)
        {
            return buffer[0] << 8 | buffer[1];
        }

        //Three byte hex to int.
        private int Int24(byte[] buffer)
        {
            return buffer[0] << 16 | buffer[1] << 8 | buffer[2];
        }

        //Four byte hex to int.
        private int Int32(byte[] buffer)
        {
            return buffer[0] << 32 | buffer[1] << 16 | buffer[2] << 8 | buffer[3];
        }

        public void ChecksumCalculation(byte[] arr, Offest_data od)
        {
            ushort chk = 0;
            for (int i = 32; i < 80; i += 2)
                chk += BitConverter.ToUInt16(arr, i);
            var bytes = BitConverter.GetBytes(chk);
            
            arr[od.Checksum + 1] = bytes[1];
            arr[od.Checksum] = bytes[0];
        }
    }
}

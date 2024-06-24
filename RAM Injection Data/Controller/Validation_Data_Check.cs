using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    class Validation_Data_Check
    {
        readonly Data_Conversion hex;
        readonly Offest_data offset_Data;
        readonly Bit_Check bit;
        Set_Values sv;

        public Validation_Data_Check()
        {
            hex = new();
            offset_Data = new();
            bit = new();
            sv = new();
        }

        /// <summary>
        /// Ensures the IVs are valid
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool IVs(byte[] inputFile, int option)
        {
            if (option == 0) //IVs stored in 3 bytes
            {
                if (bit.IV(inputFile, offset_Data.IV))
                    return true;
            }
            else if (option == 1) //IVs stored in 6 bytes
            {
                if (inputFile[offset_Data.IV] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 2] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 3] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 4] <= 31 &&
                    inputFile[offset_Data.IV + offset_Data.SizeIV * 5] <= 31)
                    return true;
            }
            else if (option == 2 || option == 3)
            {
                return true; //Checking IVs in gens 1 and 2 is pointless
            }

            return false;
        }

        /// <summary>
        /// Checks if Pkrus is valid
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool Pkrus(byte[] inputFile, int option)
        {
            if (option == 0 || option == 3) //PkRus single byte
            {
                return Bit_Check.Pokerus(inputFile[offset_Data.Pkrus]);
            }
            else if (option == 1) //PkRus Split in 2 bytes
            {
                int skip;
                if (offset_Data.Pkrus == 0xCA)
                    skip = 3; //Colo
                else
                    skip = 2; //XD

                byte[] tempArr = { inputFile[offset_Data.Pkrus] };
                string byte1 = Convert.ToHexString(tempArr);
                tempArr[0] = inputFile[offset_Data.Pkrus + skip];
                string byte2 = Convert.ToHexString(tempArr);
                byte pkrus;

                byte1 += byte2;
                tempArr = Convert.FromHexString(byte1);
                pkrus = tempArr[0];
                return Bit_Check.Pokerus(pkrus);
            }
            else if (option == 2)
                return true;

            return false;
        }

        /// <summary>
        /// Ensures the EV total is valid
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="totalEV"></param>
        /// <param name="invert"></param>
        /// <param name="gen"></param>
        /// <param name="subGen"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool EV(byte[] buffer, int totalEV, bool invert, int gen, int subGen, int option)
        {
            sv.OffsetSetValues(offset_Data, gen, subGen);

            if (hex.LittleEndian(buffer, offset_Data.HPEV, offset_Data.SizeHPEV, invert) +
                hex.LittleEndian(buffer, offset_Data.AttEV, offset_Data.SizeAttEV, invert) +
                hex.LittleEndian(buffer, offset_Data.DefEV, offset_Data.SizeDefEV, invert) +
                hex.LittleEndian(buffer, offset_Data.SpeedEV, offset_Data.SizeSpeedEV, invert) +
                hex.LittleEndian(buffer, offset_Data.SpAttEV, offset_Data.SizeSpAttEV, invert) +
                hex.LittleEndian(buffer, offset_Data.SpDefEV, offset_Data.SizeSpDefEV, invert) <= totalEV)
                return true;

            return false;
        }

        /// <summary>
        /// Checks if nickname and OT name is valid
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool NameCheck(byte[]buffer, int start, int length)
        {
            int count = 0;

            for (int i = start; i < start + length; i++)
            {
                if (hex.ConOneHex(buffer[i]) > 246)
                    break;
                else
                    count += hex.ConOneHex(buffer[i]);
            }

            if (count == 0)
                return false;

            return true;
        }
    }
}

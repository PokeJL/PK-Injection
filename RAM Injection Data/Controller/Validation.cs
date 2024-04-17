using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    class Validation
    {
        readonly Data_Conversion hex;
        readonly Offest_data offset_Data;
        Set_Values sv;

        public Validation() 
        {
            hex = new();
            offset_Data = new();
        }

        /// <summary>
        /// Does basic check at start of loop to determine
        /// if the data is Pokemon like and worth checking further
        /// </summary>
        /// <param name="inputFile">Potential Pokemon data</param>
        /// <param name="option">Which run of the program are we using</param>
        /// <param name="i">index</param>
        /// <param name="gen">Target gen</param>
        /// <param name="subGen">Helps determine which gen of the gen 
        /// is being targeted</param>
        /// <param name="inversion">Is data in little edian</param>
        /// <returns></returns>
        public bool ChecksumStart(byte[] inputFile, int option, int i, int gen, int subGen, bool inversion)
        {
            Offest_data offset = new();
            sv.OffsetSetValues(offset, gen, subGen);

            if (hex.LittleEndian(inputFile, i + offset_Data.Checksum, 2, inversion) != 0)
                return true;

            return false;
        }
    }
}

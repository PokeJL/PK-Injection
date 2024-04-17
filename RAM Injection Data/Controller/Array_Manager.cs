using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class Array_Manager
    {
        public Array_Manager() { }

        /// <summary>
        /// Adds a 1D array to a list of lists
        /// </summary>
        /// <param name="a2d">the list of lists</param>
        /// <param name="row">index of the list</param>
        /// <param name="column">length of 1D array</param>
        /// <param name="a1d">1D array</param>
        public void Array1Dto2D(List<List<byte>> a2d, int row, int column, byte[] a1d)
        {
            List<byte> temp = new List<byte>();
            a2d.Add(temp);
            for (int i = 0; i < column; i++)
                a2d[row].Add(a1d[i]);
        }

        /// <summary>
        /// Extracts part of a 1D array into another 1D array
        /// </summary>
        /// <param name="recipiant">The array getting the part of the other array</param>
        /// <param name="donor">Array donating the data</param>
        /// <param name="donorStart">Where to start in the donor array</param>
        public void ArrayPart(byte[] recipiant, byte[] donor, int donorStart)
        {
            for (int i = 0; i < recipiant.Length; i++, donorStart++)
                recipiant[i] = donor[donorStart];
        }

        /// <summary>
        /// Checks if the Pokemon as alresdy been found
        /// </summary>
        /// <param name="pokemon">list of list of Pokemon</param>
        /// <param name="found">How many Pokemon are found</param>
        /// <param name="convert">The found Pokemon being checked</param>
        /// <param name="gen">Selected games gen</param>
        /// <param name="subGen">The targeted game in the gen</param>
        /// <param name="inversion">Is the data in little edian</param>
        public bool UpdateCheck(List<Pokemon_Gen3> pokemon, int found, byte[] convert, int gen, int subGen, bool inversion)
        {
            Offest_data offset_Data = new();
            Pokemon_Value_Check check = new();
            Set_Values sv = new();

            sv.OffsetSetValues(offset_Data, gen, subGen);

            if (found != 0)
            {
                for (int f = 0; f < found; f++)
                {
                    if (check.Duplicate(pokemon, convert, inversion, f, offset_Data))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Adds part of a 1D array to a list of list
        /// </summary>
        /// <param name="pokemon">list of list data is being added to</param>
        /// <param name="row">the index of the list of list the data is being added to</param>
        /// <param name="data">The 1d donor data</param>
        /// <param name="start2">where to start in the donor 1D array</param>
        /// <param name="length">The length of data to donate</param>
        public void AddPart1Dto2D(List<List<byte>> pokemon, int row, byte[] data, int start, int length)
        {
            for (int i = 0; i < length; i++)
                pokemon[row].Add(data[start + i]);
        }

        /// <summary>
        /// Compares 2 1D arrays
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public bool ArrayCompare(byte[] arr1, byte[] arr2)
        {
            return arr1.SequenceEqual(arr2);
        }

        public void PokemonToArray(byte[] arr, Pokemon_Gen3 pokemon, Offest_data od) 
        {
            bool fill = true;
            int count = 0;
            while (fill) 
            {
                fill = false;
                if (count < od.SizePID)
                    arr[od.PID + count] = pokemon.PID[count]; fill = true;
                if (count < od.SizeID)
                    arr[od.ID + count] = pokemon.TrainerID[count]; fill = true;
                if (count < od.NicknameSize)
                    arr[od.Nickname + count] = pokemon.Nickname[count]; fill = true;
                if (count < od.LanguageSize)
                    arr[od.Language + count] = pokemon.Language[count]; fill = true;
                if (count < od.MiscFlagsSize)
                    arr[od.MiscFlags + count] = pokemon.Misc[count]; fill = true;
                if (count < od.OTNameSize)
                    arr[od.OTName + count] = pokemon.OTName[count]; fill = true;
                if (count < od.MarkingsSize)
                    arr[od.Markings + count] = pokemon.Marks[count]; fill = true;
                if (count < od.ChecksumSize)
                    arr[od.Checksum + count] = pokemon.Checksum[count]; fill = true;
                if (count < od.UnknownSize)
                    arr[od.Unknown + count] = pokemon.Unknown[count]; fill = true;
                if (count < od.SpeciesSize)
                    arr[od.Species + count] = pokemon.PokemonID[count]; fill = true;
                if (count < od.SizeItem)
                    arr[od.Item + count] = pokemon.Item[count]; fill = true;
                if (count < od.SizeEXP)
                    arr[od.EXP + count] = pokemon.EXP[count]; fill = true;
                if (count < od.PPUpsSize)
                    arr[od.PPUps + count] = pokemon.PPUps[count]; fill = true;
                if (count < od.SizeFriendship)
                    arr[od.Friendship + count] = pokemon.Friendship[count]; fill = true;
                if (count < od.UnusedSize)
                    arr[od.Unused + count] = pokemon.Unused[count]; fill = true;
                if (count < od.SizeMove1)
                {
                    arr[od.Move1 + count] = pokemon.Move1[count];
                    arr[od.Move2 + count] = pokemon.Move2[count];
                    arr[od.Move3 + count] = pokemon.Move3[count];
                    arr[od.Move4 + count] = pokemon.Move4[count];
                    fill = true;
                }
                if (count < od.PP1Size)
                {
                    arr[od.PP1 + count] = pokemon.PP1[count];
                    arr[od.PP2 + count] = pokemon.PP2[count];
                    arr[od.PP3 + count] = pokemon.PP3[count];
                    arr[od.PP4 + count] = pokemon.PP4[count];
                    fill = true;
                }
                if (count < od.SizeHPEV)
                {
                    arr[od.HPEV + count] = pokemon.HPEV[count];
                    arr[od.AttEV + count] = pokemon.AttackEV[count];
                    arr[od.DefEV + count] = pokemon.DefenceEV[count];
                    arr[od.SpeedEV + count] = pokemon.SpeedEV[count];
                    arr[od.SpAttEV + count] = pokemon.SpAttackEV[count];
                    arr[od.SpDefEV + count] = pokemon.SpDefenceEV[count];
                    arr[od.Cool + count] = pokemon.Cool[count];
                    arr[od.Beauty + count] = pokemon.Beauty[count];
                    arr[od.Cute + count] = pokemon.Cute[count];
                    arr[od.Smart + count] = pokemon.Smart[count];
                    arr[od.Tough + count] = pokemon.Tough[count];
                    arr[od.Sheen + count] = pokemon.Feel[count];
                    fill = true;
                }
                if (count < od.PkrusSize)
                    arr[od.Pkrus + count] = pokemon.PKRus[count]; fill = true;
                if (count < od.MetLocationSize)
                    arr[od.MetLocation + count] = pokemon.MetLocation[count]; fill = true;
                if (count < od.OrginsSize) 
                    arr[od.Orgins + count] = pokemon.Orgins[count]; fill = true;
                if (count < od.SizeIV)
                    arr[od.IV + count] = pokemon.IV[count]; fill = true;
                if (count < od.RibbonsSize)
                    arr[od.Ribbons + count] = pokemon.Ribbion[count]; fill = true;
                count++;
            }
        }
    }
}

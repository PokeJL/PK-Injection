using PKHeX.Core;
using RAM_Injection_Data.Data;
using RAM_Injection_Data.Model;
using System;

namespace RAM_Injection_Data.Controller
{
    public class Data_Ripper
    {
        readonly Data_Conversion hex;
        readonly Array_Manager arr;
        readonly Dex_Conversion dexCon;
        readonly Pokemon_Value_Check checkP;

        public Data_Ripper() 
        {
            hex = new();
            arr = new();
            dexCon = new();
            checkP = new();
        }

        /// <summary>
        /// Starts the linear search to find Pokemon in the RAM
        /// </summary>
        /// <param name="pokemon">List of Pokemon</param>
        /// <param name="val">Basic valuse needed for the application</param>
        /// <param name="offset_Data">The offsets of the Pokemon values</param>
        /// <param name="gv">Contains the target games parameters</param>
        public void SearchPokemon(List<Pokemon_Gen3> pokemon, Applicaton_Values val, Offest_data offset_Data, Game_Values gv, byte[] id, int i)
        {
            byte[] buffer = new byte[gv.PartyDataSize];
            int currentDexNum;

            if (i + gv.PartyDataSize <= val.FileData.Length &&
                val.FileData[i + offset_Data.ID] == id[0] &&
                 val.FileData[i + 1 + offset_Data.ID] == id[1])
            {
                            //loads data into buffer
                for (int n = 0; n < gv.PartyDataSize; n++)
                        buffer[n] = val.FileData[i + n];

                if (gv.IsEncrypted)
                    buffer = PokeCrypto.DecryptArray3(buffer);

                currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.Species, offset_Data.SpeciesSize, gv.Invert));

                        //Checks if the data is a Pokemon
                if (checkP.IsPokemon(buffer, currentDexNum, val, offset_Data, gv))
                {
                    int duplicate = 0;
                            //Checks if the found Pokemon was already found else where in the RAM
                        if (arr.UpdateCheck(pokemon, buffer, val.Gen, val.SubGen, gv.Invert, ref duplicate))
                        {
                            //If the Pokemon is new add to the Pokemon list
                            pokemon.Add(arr.ArrayToPokemon(buffer, offset_Data));
                            pokemon[pokemon.Count - 1].AdressInRAM.Add(i);
                        }
                        else
                            pokemon[duplicate].AdressInRAM.Add(i);
                }
            }

        }

        /// <summary>
        /// Extracts data from the Pokemon list to create a new list so data can be presented better om the data grid view
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public Display_Data AddData(Pokemon_Gen3 list)
        {
            string temp = string.Empty;
            Display_Data data = new();
            Name_Characters name = new();
            Pokemon_Data pData = new();

            //data.SpeciesId = hex.LittleEndianObject(list.PokemonID, true);

            for (int i = 0; i < list.Nickname.Count; i++)
            {
                if (list.Nickname[i] != 255)
                    temp += name.GetLetter(list.Nickname[i]);
                else break;
            }
            data.Name = temp;
            //data.ID = hex.LittleEndianObject(list.TrainerID, true);
            data.Move1 = pData.GetMove(hex.LittleEndianObject(list.Move1, true));
            data.Move2 = pData.GetMove(hex.LittleEndianObject(list.Move2, true));
            data.Move3 = pData.GetMove(hex.LittleEndianObject(list.Move3, true));
            data.Move4 = pData.GetMove(hex.LittleEndianObject(list.Move4, true));

            return data;
        }
    }
}

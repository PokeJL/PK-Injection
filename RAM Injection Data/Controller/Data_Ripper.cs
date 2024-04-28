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
            //byte[] inputFile = val.FileData;
            int currentDexNum;

            //Ensures that the RAM file is larger then a Pokemon in your party
            //for (int i = 0; i < inputFile.Length && inputFile.Length >= gv.PartyDataSize; i++)
            //{

                //Loops to the end of the RAM file
                //if (inputFile.Length >= gv.PartyDataSize)
                //{
                    //Ensures the that the size for the Pokemon stored in the party plus the current
                    //index of the loop isn't past the input length.
                    //Initial check of data to make sure the current data doesn't have a checksum of 0
                    if (i + gv.PartyDataSize <= val.FileData.Length &&
                        val.FileData[i + offset_Data.ID] == id[0] &&
                        val.FileData[i + 1 + offset_Data.ID] == id[1])
                    {
                            //loads data into buffer
                        for (int n = 0; n < gv.PartyDataSize; n++)
                        {
                                buffer[n] = val.FileData[i + n];
                        }
                        //byte[] convert = new byte[1];
                        //if (gv.IsEncrypted)
                        //{
                        //    //byte[] convert = new byte[1];
                        //    convert = PokeCrypto.DecryptArray3(buffer); //might work if does get rid of Poke Crypto start
                        //}

                        currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.Species, offset_Data.SpeciesSize, gv.Invert));

                        //Checks if the data is a Pokemon
                        if (checkP.IsPokemon(buffer, currentDexNum, val, offset_Data, gv))
                        {
                            int duplicate = 0;
                            //Checks if the found Pokemon was already found else where in the RAM
                            if (arr.UpdateCheck(pokemon, val.Found, buffer, val.Gen, val.SubGen, gv.Invert, ref duplicate))
                            {
                                //If the Pokemon is new add to the Pokemon list
                                pokemon.Add(arr.ArrayToPokemon(buffer, offset_Data));
                                pokemon[val.Found].AdressInRAM.Add(i);
                                val.Found += 1;
                            }
                            else
                                pokemon[duplicate].AdressInRAM.Add(i);
                        }
                    }
                //}
            //} 

        }
    }
}

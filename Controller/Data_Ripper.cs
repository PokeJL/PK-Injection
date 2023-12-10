using PK3_RAM_Injection.Data;
using PK3_RAM_Injection.Model;
using System;

namespace PK3_RAM_Injection.Controller
{
    class Data_Ripper
    {
        readonly Data_Conversion hex;
        readonly Array_Manager arr;
        readonly Dex_Conversion dexCon;
        readonly PokeCrypto_Start start;
        readonly Validation check;
        readonly Pokemon_Value_Check checkP;

        public delegate void CurrentProgressMethodInvoker(int amount);
        public delegate bool EndThread();

        public event CurrentProgressMethodInvoker CP;
        public event EndThread End;

        public Data_Ripper() 
        {
            hex = new();
            arr = new();
            dexCon = new();
            start = new();
            check = new();
            checkP = new();
        }

        /// <summary>
        /// Starts the linear search to find Pokemon in the RAM
        /// </summary>
        /// <param name="pokemon">List of Pokemon</param>
        /// <param name="val">Basic valuse needed for the application</param>
        /// <param name="offset_Data">The offsets of the Pokemon values</param>
        /// <param name="gv">Contains the target games parameters</param>
        public void SearchPokemon(List<List<byte>> pokemon, Applicaton_Values val, Offest_data offset_Data, Game_Values gv, byte[] id)
        {
            byte[] buffer = new byte[gv.PartyDataSize];
            int updateTime;
            byte[] inputFile = val.FileData;
            //Ensures that the RAM file is larger then a Pokemon in your party
            if (inputFile.Length >= gv.PartyDataSize)
            {
                updateTime = UpdateBar(inputFile.Length); //Gets update intervals

                //Loops to the end of the RAM file
                for (int i = 0; i < inputFile.Length; i++)
                {
                    //Ends the rip process
                    if (End() == true)
                    {
                        val.Found = 0;
                        break;
                    }
                    //Ensures the that the size for the Pokemon stored in the party plus the current
                    //index of the loop isn't past the input length.
                    //Initial check of data to make sure the current data doesn't have a checksum of 0
                    if (i + gv.PartyDataSize <= inputFile.Length && 
                        //check.ChecksumStart(inputFile, gv.Option, i, val.Gen, val.SubGen, gv.Invert) &&
                        inputFile[i + offset_Data.ID] == id[0] &&
                        inputFile[i + 1 + offset_Data.ID] == id[1])
                    {
                        //loads data into buffer
                        for (int n = 0; n < gv.PartyDataSize; n++)
                        {
                            buffer[n] = inputFile[i + n];
                        }

                        //Encrypted(pokemon, buffer, val, offset_Data, gv);
                        NonEncrypted(pokemon, buffer, val, offset_Data, gv);
                    }
                    //Updates the progress bar
                    ProgressUpdate(i, updateTime, inputFile);
                }
            }
        }

        /// <summary>
        /// Breaks the encryption if the data is encrypted
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="buffer"></param>
        /// <param name="val"></param>
        /// <param name="offset_Data"></param>
        /// <param name="gv"></param>
        private void Encrypted(List<List<byte>> pokemon, byte[] buffer, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            byte[] convert = new byte[1];

            //Breaks the encryption
            convert = start.PK3(buffer);

            //Battle tower shiny fix
            //if (val.Gen == 3)
            //    exceptions.FRLGTrainerTower(ref convert);

            NonEncrypted(pokemon, convert, val, offset_Data, gv);
        }

        /// <summary>
        /// For non encrypted data and where it's determined if the data is a Pokemon
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="buffer"></param>
        /// <param name="val"></param>
        /// <param name="offset_Data"></param>
        /// <param name="gv"></param>
        private void NonEncrypted(List<List<byte>> pokemon, byte[] buffer, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            int currentDexNum;
            //Gets the Pokemon correct dex number to determine if the data is a Pokemon
            currentDexNum = dexCon.Gen3GetDexNum(hex.LittleEndian(buffer, offset_Data.Dex, offset_Data.SizeDex, gv.Invert));        

            //Checks if the data is a Pokemon
            if (checkP.IsPokemon(buffer, currentDexNum, val, offset_Data, gv))
            {
                //Checks if the found Pokemon was already found else where in the RAM
                if (arr.UpdateCheck(pokemon, val.Found, buffer, val.Gen, val.SubGen, gv.Invert))
                {
                    //If the Pokemon is new add to the Pokemon list
                    arr.Array1Dto2D(pokemon, val.Found, gv.StorageDataSize, buffer);
                    val.Found += 1;
                }
            }
        }

        /// <summary>
        /// Updates progress bar
        /// </summary>
        /// <param name="progress">How much the loop has gone</param>
        /// <param name="time">the update time intervals</param>
        /// <param name="data">the data file</param>
        private void ProgressUpdate(int progress, int time, byte[] data)
        {
            if (progress % time == 0) //Update bar if module is 0
                CP(progress);
            else if (progress + 1 == data.Length) //Update bar if the next loop is the last
                CP(progress);
        }

        //163 allows for update intervals that don't slow down the process by delaying the update by a bit
        static private int UpdateBar(int size)
        {
            int timing;
            if (size <= 163)
                timing = size;
            else
                timing = (int)(size / 163);
            return timing;
        }
    }
}

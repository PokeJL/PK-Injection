namespace RAM_Injection_Data.Data
{
    class Game_Values_Data
    {
        public Game_Values_Data()
        {

        }

        /// <summary>
        /// Spacific values for the target game.
        /// </summary>
        /// <param name="storageDataSize"></param>
        /// <param name="partyDataSize"></param>
        /// <param name="effortTotal"></param>
        /// <param name="isEncrypted"></param>
        /// <param name="invert"></param>
        /// <param name="option"></param>
        /// <param name="numOfPokeInGen"></param>
        /// <param name="numOfMovesInGen"></param>
        /// <param name="gen"></param>
        /// <param name="subGen"></param>
        public void GameData(ref int storageDataSize, ref int partyDataSize, ref int effortTotal, ref bool isEncrypted,
                            ref bool invert, ref int option, ref int numOfPokeInGen, ref int numOfMovesInGen, int gen,
                            int subGen)
        {

            if (gen == 3 && subGen == 0) //RSEFRLG Base games
            {
                storageDataSize = 80; //Storage Size
                partyDataSize = 100; //Party Size
                effortTotal = 510;
                isEncrypted = true;
                invert = true;
                option = 0;
                numOfPokeInGen = 65535;
                numOfMovesInGen = 65535;
            }
        }
    }
}

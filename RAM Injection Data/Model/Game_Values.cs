namespace RAM_Injection_Data.Model
{
    /// <summary>
    /// Stores the specific values of the targeted game
    /// </summary>
    public class Game_Values
    {
        public int StorageDataSize { get; set; } = 0; //Size of Pokemon in the PC
        public int PartyDataSize { get; set; } = 0; //Size of Pokemon in the party
        public int EffortTotal { get; set; } = 0; //Max EV total
        public bool IsEncrypted { get; set; } = true; //If the game encryptes data
        public bool PokemonListShuffle { get; set; } = true; //If the game data follow vinila or moded list order
        public bool Invert { get; set; } = true; //Is the data little edian
        public int Option { get; set; } = 0; //Further contols for checksum
        public int NumOfPokeInGen { get; set; } = 0; //Number of Pokemon in gen
        public int NumOfMovesInGen { get; set; } = 0; //Number of moves in the game
    }
}

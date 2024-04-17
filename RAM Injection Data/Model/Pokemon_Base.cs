namespace RAM_Injection_Data.Model
{
    public class Pokemon_Base
    {
        public List<byte>? PokemonID { get; set; }
        public List<byte>? TrainerID { get; set; }
        public List<byte>? OTName { get; set; }
        public List<byte>? Nickname { get; set; }
        public List<byte>? Move1 { get; set; }
        public List<byte>? Move2 { get; set; }
        public List<byte>? Move3 { get; set; }
        public List<byte>? Move4 { get; set; }
        public List<byte>? EXP {  get; set; }
        public List<int>? AdressInRAM { get; set; }
    }
}

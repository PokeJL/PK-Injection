namespace RAM_Injection_Data.Model
{
    /// <summary>
    /// Inherits the the Pokemon Base class model.
    /// Contain refined data specific for gen 3
    /// </summary>
    public class Pokemon_Gen3 : Pokemon_Base
    {
        public List<byte>? SecretID { get; set; } = [];
        public List<byte>? IV { get; set; } = [];
        public List<byte>? HPEV { get; set; } = [];
        public List<byte>? AttackEV { get; set; } = [];
        public List<byte>? DefenceEV { get; set; } = [];
        public List<byte>? SpAttackEV { get; set; } = [];
        public List<byte>? SpDefenceEV { get; set; } = [];
        public List<byte>? SpeedEV { get; set; } = [];
        public List<byte>? Cool {  get; set; } = [];
        public List<byte>? Beauty { get; set; } = [];
        public List<byte>? Cute { get; set; } = [];
        public List<byte>? Smart { get; set; } = [];
        public List<byte>? Tough {  get; set; } = [];
        public List<byte>? Orgins { get; set; } = [];
        public List<byte>? Feel {  get; set; } = [];
        public List<byte>? PID { get; set; } = [];
        public List<byte>? Ribbion { get; set; } = [];
        public List<byte>? Item { get; set; } = [];
        public List<byte>? PKRus { get; set; } = [];
        public List<byte>? Language { get; set; } = [];
        public List<byte>? Misc { get; set; } = [];
        public List<byte>? Friendship { get; set; } = [];
        public List<byte>? Marks {  get; set; } = [];
        public List<byte>? Checksum { get; set; } = [];
        public List<byte>? Unknown { get; set; } = [];
        public List<byte>? PPUps { get; set; } = [];
        public List<byte>? Unused { get; set; } = [];
        public List<byte>? MetLocation {  get; set; } = [];
        public List<byte>? PP1 { get; set; } = [];
        public List<byte>? PP2 { get; set; } = [];
        public List<byte>? PP3 { get; set; } = [];
        public List<byte>? PP4 { get; set; } = [];

        public void ClearData()
        {
            PokemonID.Clear();
            TrainerID.Clear();
            OTName.Clear();
            Nickname.Clear();
            Move1.Clear();
            Move2.Clear();
            Move3.Clear();
            Move4.Clear();
            EXP.Clear();
            AdressInRAM.Clear();
            Edited = false;
            SecretID.Clear();
            IV.Clear();
            HPEV.Clear();
            AttackEV.Clear();
            DefenceEV.Clear();
            SpAttackEV.Clear();
            SpDefenceEV.Clear();
            SpeedEV.Clear();
            Cool.Clear();
            Beauty.Clear();
            Cute.Clear();
            Smart.Clear();
            Tough.Clear();
            Orgins.Clear();
            Feel.Clear();
            PID.Clear();
            Ribbion.Clear();
            Item.Clear();
            PKRus.Clear();
            Language.Clear();
            Misc.Clear();
            Friendship.Clear();
            Marks.Clear();
            Checksum.Clear();
            Unknown.Clear();
            PPUps.Clear();
            Unused.Clear();
            MetLocation.Clear();
            PP1.Clear();
            PP2.Clear();
            PP3.Clear();
            PP4.Clear();

            PokemonID = new();
            TrainerID = new();
            OTName = new();
            Nickname = new();
            Move1 = new();
            Move2 = new();
            Move3 = new();
            Move4 = new();
            EXP = new();
            AdressInRAM = new();
            SecretID = new();
            IV = new();
            HPEV = new();
            AttackEV = new();
            DefenceEV = new();
            SpAttackEV = new();
            SpDefenceEV = new();
            SpeedEV = new();
            Cool = new();
            Beauty = new();
            Cute = new();
            Smart = new();
            Tough = new();
            Orgins = new();
            Feel = new();
            PID = [];
            Ribbion = new();
            Item = new();
            PKRus = new();
            Language = new();
            Misc = new();
            Friendship = new();
            Marks = new();
            Checksum = new();
            Unknown = new();
            PPUps = new();
            Unused = new();
            MetLocation = new();
            PP1 = new();
            PP2 = new();
            PP3 = new();
            PP4 = new();
        }
    }
}

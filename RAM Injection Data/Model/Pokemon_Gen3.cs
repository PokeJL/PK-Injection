using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_Injection_Data.Model
{
    public class Pokemon_Gen3 : Pokemon_Base
    {
        public List<byte>? SecretID { get; set; }
        public List<byte>? IV { get; set; }
        public List<byte>? HPEV { get; set; }
        public List<byte>? AttackEV { get; set; }
        public List<byte>? DefenceEV { get; set; }
        public List<byte>? SpAttackEV { get; set; }
        public List<byte>? SpDefenceEV { get; set; }
        public List<byte>? SpeedEV { get; set; }
        public List<byte>? Cool {  get; set; }
        public List<byte>? Beauty { get; set; }
        public List<byte>? Cute { get; set; }
        public List<byte>? Smart { get; set; }
        public List<byte>? Tough {  get; set; }
        public List<byte>? Orgins { get; set; }
        public List<byte>? Feel {  get; set; }
        public List<byte>? PID { get; set; }
        public List<byte>? Ribbion { get; set; }
        public List<byte>? Item { get; set; }
        public List<byte>? PKRus { get; set; }
        public List<byte>? Language { get; set; }
        public List<byte>? Misc { get; set; }
        public List<byte>? Friendship { get; set; }
        public List<byte>? Marks {  get; set; }
        public List<byte>? Checksum { get; set; }
        public List<byte>? Unknown { get; set; }
        public List<byte>? PPUps { get; set; }
        public List<byte>? Unused { get; set; }
        public List<byte>? MetLocation {  get; set; }
        public List<byte>? PP1 { get; set; }
        public List<byte>? PP2 { get; set; }
        public List<byte>? PP3 { get; set; }
        public List<byte>? PP4 { get; set; }
    }
}

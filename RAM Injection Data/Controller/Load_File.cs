using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class Load_File
    {
        public Load_File() { }

        public Pokemon_Gen3 LoadDefultPK3(Run_Time_Manager rt)
        {
            var defultData = Properties.Resources.Defult;
            return rt.ArrayManager().ArrayToPokemon(defultData, rt.OffestData());
        }
    }
}

using RAM_Injection_Data.Data;
using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class Run_Time_Manager
    {
        readonly Data_Conversion hex;
        readonly Dex_Conversion dex;
        readonly Pokemon_Data data;
        readonly File_Manager fm;
        readonly Data_Ripper rip;
        readonly Applicaton_Values val;
        readonly Offest_data offset;
        readonly Game_Values gv;
        readonly Array_Manager am;
        readonly Load_File lf;
        Set_Values sv;
        List<Pokemon_Gen3> pokemon;
        Pokemon_Gen3 injecting;
        readonly List<string> list;

        public Run_Time_Manager() 
        {
            hex = new();
            dex = new();
            data = new();
            fm = new();
            rip = new();
            val = new();
            offset = new();
            gv = new();
            sv = new();
            am = new();
            lf = new();
            pokemon = new List<Pokemon_Gen3>();
            injecting = new();
            list = new List<string>();
        }

        public Data_Conversion DataConversion()
        {
            return hex;
        }

        public Dex_Conversion DexConversion()
        {
            return dex;
        }

        public Pokemon_Data PokemonData() 
        {
            return data;
        }

        public File_Manager FileManager()
        {
            return fm;
        }

        public Data_Ripper FindData()
        {
            return rip;
        }

        public Applicaton_Values ApplicatonValues()
        {
            return val;
        }

        public Offest_data OffestData()
        {
            return offset;
        }

        public Game_Values GameValues()
        {
            return gv;
        }

        public Array_Manager ArrayManager()
        {
            return am;
        }

        public Load_File LoadFile()
        {
            return lf;
        }

        public Set_Values SetValues()
        {
            return sv;
        }

        public List<Pokemon_Gen3> PokemonGen3s()
        {
            return pokemon;
        }

        public Pokemon_Gen3 InjectPokemon()
        {
            return injecting;
        }

        public List<string> List()
        {
            return list;
        }
    }
}

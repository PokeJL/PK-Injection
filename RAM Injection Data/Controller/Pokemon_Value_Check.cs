﻿using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    /// <summary>
    /// This class breaks down the original hard to read if
    /// statments and breaks them down into easy to read
    /// statments that can be modified easier.
    /// </summary>
    class Pokemon_Value_Check
    {
        readonly Data_Conversion hex;
        readonly Validation_Data_Check vdc;
        readonly Bit_Check bit;
        public Pokemon_Value_Check()
        {
            hex = new();
            vdc = new();
            bit = new();
        }

        /// <summary>
        /// Checks to see if the data in the buffer looks like a valid Pokemon
        /// </summary>
        /// <param name="buffer">The bits that are being checked</param>
        /// <param name="currentDexNum"></param>
        /// <param name="val">Needed to know the gen and sub gen for the checksum might migrate this to
        /// Game_Values in future</param>
        /// <param name="offset_Data">Contains the offset for each value being compared</param>
        /// <param name="gv">Contains basic values of the target game such as party size</param>
        /// <returns></returns>
        public bool IsPokemon(byte[] buffer, int currentDexNum, Applicaton_Values val, Offest_data offset_Data, Game_Values gv)
        {
            int m1 = hex.LittleEndian(buffer, offset_Data.Move1, offset_Data.SizeMove1, gv.Invert);
            //Move 1 has an actual move
            if (!(m1 != 0)) 
                return false;
            if (!vdc.EV(buffer, gv.EffortTotal, gv.Invert, val.Gen, val.SubGen, gv.Option))
                return false;
            if (!vdc.NameCheck(buffer, offset_Data.OTName, offset_Data.OTNameSize))
                return false;
            if (!vdc.NameCheck(buffer, offset_Data.Nickname, offset_Data.NicknameSize))
                return false;
            if (!bit.Orgins(buffer))
                return false;
            int m2 = hex.LittleEndian(buffer, offset_Data.Move2, offset_Data.SizeMove2, gv.Invert);
            //Move 1 != Move 2
            if (!(m1 != m2)) 
                return false;
            int m3 = hex.LittleEndian(buffer, offset_Data.Move3, offset_Data.SizeMove3, gv.Invert);
            //Move 1 != Move 3
            if (!(m1 != m3)) 
                return false;
            int m4 = hex.LittleEndian(buffer, offset_Data.Move4, offset_Data.SizeMove4, gv.Invert);
            //Move 1 != Move 4
            if (!(m1 != m4)) 
                return false;
            //2 != 3 OR 2 AND 3 == 0
            if (!((m2 != m3) || (m2 == 0 && m3 == 0)))
                return false;
            //2 == 0 AND 3 == 0
            if (m2 == 0 && m3 != 0)
                return false;
            //2 != 4 OR 2 AND 4 == 0
            if (!((m2 != m4) || (m2 == 0 && m4 == 0))) 
                return false;
            //2 == 0 AND 4 == 0
            if (m2 == 0 && m4 != 0)
                return false;
            //3 != 4 OR 3 AND 4 == 0
            if (!((m3 != m4) || (m3 == 0 && m4 == 0))) 
                return false;
            //3 == 0 AND 4 == 0
            if (m3 == 0 && m4 != 0)
                return false;
            if (!vdc.Pkrus(buffer, gv.Option)) 
                return false;
            //Check valid IVs
            if (!vdc.IVs(buffer, gv.Option)) 
                return false;
            //langauge
            if (!(buffer[18] < 8 && buffer[18] != 0))
                return false;

            return true;
        }

        /// <summary>
        /// Ensures that the found Pokemon isn't already been found since Pokemon
        /// data can repeat multiple times in the RAM
        /// </summary>
        /// <param name="pokemon">The list of list that contains all fond Pokemon</param>
        /// <param name="convert">The Pokemon in the buffer be checked</param>
        /// <param name="inversion">Is the data little edian </param>
        /// <param name="f">Current index of the loop. Is f and not index since this was 
        /// move out of the loop</param>
        /// <param name="offset_Data">Contains the offest data for the Pokemon</param>
        /// <returns>false if Pokemon is already found OR true if Pokemon is new</returns>
        public bool Duplicate(List<Pokemon_Gen3> pokemon, byte[] convert, bool inversion, int f /*f is the index*/, Offest_data offset_Data)
        {
            //Check if PID of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].PID, inversion) ==
                hex.LittleEndian(convert, offset_Data.PID, offset_Data.SizePID, inversion)))
                return false;
            //Check if Dex # of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].PokemonID, inversion) == 
                hex.LittleEndian(convert, offset_Data.Species, offset_Data.SpeciesSize, inversion)))
                return false;
            //Check if ID of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].TrainerID, inversion) == 
                hex.LittleEndian(convert, offset_Data.ID, offset_Data.SizeID, inversion)))
                return false;
            //Check if SID of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].SecretID, inversion) ==
                hex.LittleEndian(convert, offset_Data.SID, offset_Data.SizeSID, inversion)))
                return false;
            //Check if HP EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].HPEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.HPEV, offset_Data.SizeHPEV, inversion))) 
                return false;
            //Check if Attack EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].AttackEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.AttEV, offset_Data.SizeAttEV, inversion))) 
                return false;
            //Check if Defence EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].DefenceEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.DefEV, offset_Data.SizeDefEV, inversion)))
                return false;
            //Check if Sp.Attack EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].SpAttackEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpAttEV, offset_Data.SizeSpAttEV, inversion)))
                return false;
            //Check if Sp.Defence EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].SpDefenceEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpDefEV, offset_Data.SizeSpDefEV, inversion)))
                return false;
            //Check if Speen EV of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].SpeedEV, inversion) == 
                hex.LittleEndian(convert, offset_Data.SpeedEV, offset_Data.SizeSpeedEV, inversion)))
                return false;
            //Check if Cool of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Cool, inversion) == 
                hex.LittleEndian(convert, offset_Data.Cool, offset_Data.SizeCool, inversion)))
                return false;
            //Check if Beauty of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Beauty, inversion) == 
                hex.LittleEndian(convert, offset_Data.Beauty, offset_Data.SizeBeauty, inversion)))
                return false;
            //Check if Cute of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Cute, inversion) == 
                hex.LittleEndian(convert, offset_Data.Cute, offset_Data.SizeCute, inversion)))
                return false;
            //Check if Smart of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Smart, inversion) == 
                hex.LittleEndian(convert, offset_Data.Smart, offset_Data.SizeSmart, inversion)))
                return false;
            //Check if Tough of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Tough, inversion) == 
                hex.LittleEndian(convert, offset_Data.Tough, offset_Data.SizeTough, inversion)))
                return false;
            //Check if Sheen of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Feel, inversion) == 
                hex.LittleEndian(convert, offset_Data.Sheen, offset_Data.SizeSheen, inversion))) 
                return false;
            //Check if Move 1 of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Move1, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move1, offset_Data.SizeMove1, inversion))) 
                return false;
            //Check if Move 2 of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Move2, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move2, offset_Data.SizeMove2, inversion)))
                return false;
            //Check if Move 3 of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Move3, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move3, offset_Data.SizeMove3, inversion)))
                return false;
            //Check if Move 4 of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].Move4, inversion) == 
                hex.LittleEndian(convert, offset_Data.Move4, offset_Data.SizeMove4, inversion)))
                return false;
            //Check if EXP of found Pokemon matches one already found
            if (!(hex.LittleEndianObject(pokemon[f].EXP, inversion) == 
                hex.LittleEndian(convert, offset_Data.EXP, offset_Data.SizeEXP, inversion)))
                return false;
            if (!(hex.LittleEndianObject(pokemon[f].PKRus, false) == hex.LittleEndian(convert, offset_Data.Pkrus, 1, false))) //error might be here
                return false;
            if (!(hex.LittleEndianObject(pokemon[f].IV, inversion) == hex.LittleEndian(convert, offset_Data.IV, offset_Data.SizeIV, inversion)))
                return false;

            return true;
        }
    }
}

using RAM_Injection_Data.Model;

namespace RAM_Injection_Data.Controller
{
    public class Array_Manager
    {
        public Array_Manager() { }

        /// <summary>
        /// Checks if the Pokemon as alresdy been found
        /// </summary>
        /// <param name="pokemon">list of list of Pokemon</param>
        /// <param name="found">How many Pokemon are found</param>
        /// <param name="convert">The found Pokemon being checked</param>
        /// <param name="gen">Selected games gen</param>
        /// <param name="subGen">The targeted game in the gen</param>
        /// <param name="inversion">Is the data in little edian</param>
        public bool UpdateCheck(List<Pokemon_Gen3> pokemon, byte[] convert, int gen, int subGen, bool inversion, ref int duplicate)
        {
            Offest_data offset_Data = new();
            Pokemon_Value_Check check = new();
            Set_Values sv = new();

            sv.OffsetSetValues(offset_Data, gen, subGen);

            if (pokemon.Count != 0)
            {
                for (int f = 0; f < pokemon.Count; f++)
                {
                    if (check.Duplicate(pokemon, convert, inversion, f, offset_Data))
                    {
                        duplicate = f;
                        return false;
                    }
                }
            }
            return true;
        }

        public void PokemonToArray(byte[] arr, Pokemon_Gen3 pokemon, Offest_data od) 
        {
            for(int i = 0; i < 22; i++) 
            {
                if (i < 1)
                {
                    arr[od.Language + i] = pokemon.Language[i];
                    arr[od.MiscFlags + i] = pokemon.Misc[i];
                    arr[od.Markings + i] = pokemon.Marks[i];
                    arr[od.PPUps + i] = pokemon.PPUps[i];
                    arr[od.Friendship + i] = pokemon.Friendship[i];
                    arr[od.PP1 + i] = pokemon.PP1[i];
                    arr[od.PP2 + i] = pokemon.PP2[i];
                    arr[od.PP3 + i] = pokemon.PP3[i];
                    arr[od.PP4 + i] = pokemon.PP4[i];
                    arr[od.HPEV + i] = pokemon.HPEV[i];
                    arr[od.AttEV + i] = pokemon.AttackEV[i];
                    arr[od.DefEV + i] = pokemon.DefenceEV[i];
                    arr[od.SpeedEV + i] = pokemon.SpeedEV[i];
                    arr[od.SpAttEV + i] = pokemon.SpAttackEV[i];
                    arr[od.SpDefEV + i] = pokemon.SpDefenceEV[i];
                    arr[od.Cool + i] = pokemon.Cool[i];
                    arr[od.Beauty + i] = pokemon.Beauty[i];
                    arr[od.Cute + i] = pokemon.Cute[i];
                    arr[od.Smart + i] = pokemon.Smart[i];
                    arr[od.Tough + i] = pokemon.Tough[i];
                    arr[od.Sheen + i] = pokemon.Feel[i];
                    arr[od.Pkrus + i] = pokemon.PKRus[i];
                    arr[od.MetLocation + i] = pokemon.MetLocation[i];
                }
                if (i < 2)
                {
                    arr[od.Orgins + i] = pokemon.Orgins[i];
                    arr[od.ID + i] = pokemon.TrainerID[i];
                    arr[od.SID + i] = pokemon.SecretID[i];
                    if (pokemon.Checksum.Count() == 2)
                        arr[od.Checksum + i] = pokemon.Checksum[i];
                    arr[od.Unknown + i] = pokemon.Unknown[i];
                    arr[od.Species + i] = pokemon.PokemonID[i];
                    arr[od.Item + i] = pokemon.Item[i];
                    arr[od.Unused + i] = pokemon.Unused[i];
                    arr[od.Move1 + i] = pokemon.Move1[i];
                    arr[od.Move2 + i] = pokemon.Move2[i];
                    arr[od.Move3 + i] = pokemon.Move3[i];
                    arr[od.Move4 + i] = pokemon.Move4[i];

                }
                if (i < 4)
                {
                    arr[od.PID + i] = pokemon.PID[i];
                    arr[od.EXP + i] = pokemon.EXP[i];
                    arr[od.IV + i] = pokemon.IV[i];
                    arr[od.Ribbons + i] = pokemon.Ribbion[i];
                }
                if (i < 7)
                {
                    arr[od.OTName + i] = pokemon.OTName[i];
                }
                if (i < 10)
                {
                    arr[od.Nickname + i] = pokemon.Nickname[i];
                }   
            }
        }

        public Pokemon_Gen3 ArrayToPokemon(byte[] arr, Offest_data od)
        {
            Pokemon_Gen3 pokemon = new();
            for (int i = 0; i < 10; i++)
            {
                if (i < 1)
                {
                    pokemon.Language.Add(arr[od.Language + i]);
                    pokemon.Misc.Add(arr[od.MiscFlags + i]);
                    pokemon.Marks.Add(arr[od.Markings + i]);
                    pokemon.PPUps.Add(arr[od.PPUps + i]);
                    pokemon.Friendship.Add(arr[od.Friendship + i]);
                    pokemon.PP1.Add(arr[od.PP1 + i]);
                    pokemon.PP2.Add(arr[od.PP2 + i]);
                    pokemon.PP3.Add(arr[od.PP3 + i]);
                    pokemon.PP4.Add(arr[od.PP4 + i]);
                    pokemon.HPEV.Add(arr[od.HPEV + i]);
                    pokemon.AttackEV.Add(arr[od.AttEV + i]);
                    pokemon.DefenceEV.Add(arr[od.DefEV + i]);
                    pokemon.SpeedEV.Add(arr[od.SpeedEV + i]);
                    pokemon.SpAttackEV.Add(arr[od.SpAttEV + i]);
                    pokemon.SpDefenceEV.Add(arr[od.SpDefEV + i]);
                    pokemon.Cool.Add(arr[od.Cool + i]);
                    pokemon.Beauty.Add(arr[od.Beauty + i]);
                    pokemon.Cute.Add(arr[od.Cute + i]);
                    pokemon.Smart.Add(arr[od.Smart + i]);
                    pokemon.Tough.Add(arr[od.Tough + i]);
                    pokemon.Feel.Add(arr[od.Sheen + i]);
                    pokemon.PKRus.Add(arr[od.Pkrus + i]);
                    pokemon.MetLocation.Add(arr[od.MetLocation + i]);
                }
                if (i < 2)
                {
                    pokemon.Orgins.Add(arr[od.Orgins + i]);
                    pokemon.TrainerID.Add(arr[od.ID + i]);
                    pokemon.SecretID.Add(arr[od.SID + i]);
                    pokemon.Checksum.Add(arr[od.Checksum + i]);
                    pokemon.Unknown.Add(arr[od.Unknown + i]);
                    pokemon.PokemonID.Add(arr[od.Species + i]);
                    pokemon.Item.Add(arr[od.Item + i]);
                    pokemon.Unused.Add(arr[od.Unused + i]);
                    pokemon.Move1.Add(arr[od.Move1 + i]);
                    pokemon.Move2.Add(arr[od.Move2 + i]);
                    pokemon.Move3.Add(arr[od.Move3 + i]);
                    pokemon.Move4.Add(arr[od.Move4 + i]);
                }
                if (i < 4)
                {
                    pokemon.PID.Add(arr[od.PID + i]);
                    pokemon.EXP.Add(arr[od.EXP + i]);
                    pokemon.IV.Add(arr[od.IV + i]);
                    pokemon.Ribbion.Add(arr[od.Ribbons + i]);
                }
                if (i < 7)
                {
                    pokemon.OTName.Add(arr[od.OTName + i]);
                }
                if (i < 10)
                {
                    pokemon.Nickname.Add(arr[od.Nickname + i]);
                }
            }
            return pokemon;
        }

        public void CopyPokemonObject(Pokemon_Gen3 survive, Pokemon_Gen3 noneSurvive, Offest_data od)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < 1)
                {
                    survive.Language.Add(noneSurvive.Language[i]);
                    survive.Misc.Add(noneSurvive.Misc[i]);
                    survive.Marks.Add(noneSurvive.Marks[i]);
                    survive.PPUps.Add(noneSurvive.PPUps[i]);
                    survive.Friendship.Add(noneSurvive.Friendship[i]);
                    survive.PP1.Add(noneSurvive.PP1[i]);
                    survive.PP2.Add(noneSurvive.PP2[i]);
                    survive.PP3.Add(noneSurvive.PP3[i]);
                    survive.PP4.Add(noneSurvive.PP4[i]);
                    survive.HPEV.Add(noneSurvive.HPEV[i]);
                    survive.AttackEV.Add(noneSurvive.AttackEV[i]);
                    survive.DefenceEV.Add(noneSurvive.DefenceEV[i]);
                    survive.SpeedEV.Add(noneSurvive.SpeedEV[i]);
                    survive.SpAttackEV.Add(noneSurvive.SpAttackEV[i]);
                    survive.SpDefenceEV.Add(noneSurvive.SpDefenceEV[i]);
                    survive.Cool.Add(noneSurvive.Cool[i]);
                    survive.Beauty.Add(noneSurvive.Beauty[i]);
                    survive.Cute.Add(noneSurvive.Cute[i]);
                    survive.Smart.Add(noneSurvive.Smart[i]);
                    survive.Tough.Add(noneSurvive.Tough[i]);
                    survive.Feel.Add(noneSurvive.Feel[i]);
                    survive.PKRus.Add(noneSurvive.PKRus[i]);
                    survive.MetLocation.Add(noneSurvive.MetLocation[i]);
                }
                if (i < 2)
                {
                    survive.Orgins.Add(noneSurvive.Orgins[i]);
                    survive.TrainerID.Add(noneSurvive.TrainerID[i]);
                    survive.SecretID.Add(noneSurvive.SecretID[i]);
                    survive.Checksum.Add(noneSurvive.Checksum[i]);
                    survive.Unknown.Add(noneSurvive.Unknown[i]);
                    survive.PokemonID.Add(noneSurvive.PokemonID[i]);
                    survive.Item.Add(noneSurvive.Item[i]);
                    survive.Unused.Add(noneSurvive.Unused[i]);
                    survive.Move1.Add(noneSurvive.Move1[i]);
                    survive.Move2.Add(noneSurvive.Move2[i]);
                    survive.Move3.Add(noneSurvive.Move3[i]);
                    survive.Move4.Add(noneSurvive.Move4[i]);
                }
                if (i < 4)
                {
                    survive.PID.Add(noneSurvive.PID[i]);
                    survive.EXP.Add(noneSurvive.EXP[i]);
                    survive.IV.Add(noneSurvive.IV[i]);
                    survive.Ribbion.Add(noneSurvive.Ribbion[i]);
                }
                if (i < 7)
                {
                    survive.OTName.Add(noneSurvive.OTName[i]);
                }
                if (i < 10)
                {
                    survive.Nickname.Add(noneSurvive.Nickname[i]);
                }
            }
        }

        public void CommitEditToObject(Pokemon_Gen3 survive, Pokemon_Gen3 noneSurvive)
        {
            //noneSurvive = new();
            for (int i = 0; i < 10; i++)
            {
                if (i < 1)
                {
                    noneSurvive.Language[i] = survive.Language[i];
                    noneSurvive.Misc[i] = survive.Misc[i];
                    noneSurvive.Marks[i] = survive.Marks[i];
                    noneSurvive.PPUps[i] = survive.PPUps[i];
                    noneSurvive.Friendship[i] = survive.Friendship[i];
                    noneSurvive.PP1[i] = survive.PP1[i];
                    noneSurvive.PP2[i] = survive.PP2[i];
                    noneSurvive.PP3[i] = survive.PP3[i];
                    noneSurvive.PP4[i] = survive.PP4[i];
                    noneSurvive.HPEV[i] = survive.HPEV[i];
                    noneSurvive.AttackEV[i] = survive.AttackEV[i];
                    noneSurvive.DefenceEV[i] = survive.DefenceEV[i];
                    noneSurvive.SpeedEV[i] = survive.SpeedEV[i];
                    noneSurvive.SpAttackEV[i] = survive.SpAttackEV[i];
                    noneSurvive.SpDefenceEV[i] = survive.SpDefenceEV[i];
                    noneSurvive.Cool[i] = survive.Cool[i];
                    noneSurvive.Beauty[i] = survive.Beauty[i];
                    noneSurvive.Cute[i] = survive.Cute[i];
                    noneSurvive.Smart[i] = survive.Smart[i];
                    noneSurvive.Tough[i] = survive.Tough[i];
                    noneSurvive.Feel[i] = survive.Feel[i];
                    noneSurvive.PKRus[i] = survive.PKRus[i];
                    noneSurvive.MetLocation[i] = survive.MetLocation[i];
                }
                if (i < 2)
                {
                    noneSurvive.Orgins[i] = survive.Orgins[i];
                    noneSurvive.TrainerID[i] = survive.TrainerID[i];
                    noneSurvive.SecretID[i] = survive.SecretID[i];
                    noneSurvive.Checksum[i] = survive.Checksum[i];
                    noneSurvive.Unknown[i] = survive.Unknown[i];
                    noneSurvive.PokemonID[i] = survive.PokemonID[i];
                    noneSurvive.Item[i] = survive.Item[i];
                    noneSurvive.Unused[i] = survive.Unused[i];
                    noneSurvive.Move1[i] = survive.Move1[i];
                    noneSurvive.Move2[i] = survive.Move2[i];
                    noneSurvive.Move3[i] = survive.Move3[i];
                    noneSurvive.Move4[i] = survive.Move4[i];
                }
                if (i < 4)
                {
                    noneSurvive.PID[i] = survive.PID[i];
                    noneSurvive.EXP[i] = survive.EXP[i];
                    noneSurvive.IV[i] = survive.IV[i];
                    noneSurvive.Ribbion[i] = survive.Ribbion[i];
                }
                if (i < 7)
                {
                    noneSurvive.OTName[i] = survive.OTName[survive.OTName.Count() - 1 -i];
                }
                if (i < 10)
                {
                    noneSurvive.Nickname[i] = survive.Nickname[survive.Nickname.Count() - 1 - i];
                }
            }
            noneSurvive.Edited = true;
        }

        public void PokemonToArrayInject(Applicaton_Values arr, Pokemon_Gen3 pokemon, Offest_data od)
        {
            for (int i = 0; i < pokemon.AdressInRAM.Count; i++)
            {
                for (int m = 0; m < 10; m++)
                {
                    if (m < 1)
                    {
                        arr.FileData[pokemon.AdressInRAM[i] + od.Language + m] = pokemon.Language[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.MiscFlags + m] = pokemon.Misc[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Markings + m] = pokemon.Marks[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.PPUps + m] = pokemon.PPUps[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Friendship + m] = pokemon.Friendship[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.PP1 + m] = pokemon.PP1[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.PP2 + m] = pokemon.PP2[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.PP3 + m] = pokemon.PP3[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.PP4 + m] = pokemon.PP4[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.HPEV + m] = pokemon.HPEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.AttEV + m] = pokemon.AttackEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.DefEV + m] = pokemon.DefenceEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.SpeedEV + m] = pokemon.SpeedEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.SpAttEV + m] = pokemon.SpAttackEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.SpDefEV + m] = pokemon.SpDefenceEV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Cool + m] = pokemon.Cool[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Beauty + m] = pokemon.Beauty[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Cute + m] = pokemon.Cute[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Smart + m] = pokemon.Smart[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Tough + m] = pokemon.Tough[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Sheen + m] = pokemon.Feel[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Pkrus + m] = pokemon.PKRus[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.MetLocation + m] = pokemon.MetLocation[m];
                    }
                    if (m < 2)
                    {
                        arr.FileData[pokemon.AdressInRAM[i] + od.Orgins + m] = pokemon.Orgins[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.ID + m] = pokemon.TrainerID[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.SID + m] = pokemon.SecretID[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Checksum + m] = pokemon.Checksum[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Unknown + m] = pokemon.Unknown[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Species + m] = pokemon.PokemonID[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Item + m] = pokemon.Item[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Unused + m] = pokemon.Unused[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Move1 + m] = pokemon.Move1[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Move2 + m] = pokemon.Move2[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Move3 + m] = pokemon.Move3[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Move4 + m] = pokemon.Move4[m];
                    }
                    if (m < 4)
                    {
                        arr.FileData[pokemon.AdressInRAM[i] + od.PID + m] = pokemon.PID[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.EXP + m] = pokemon.EXP[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.IV + m] = pokemon.IV[m];
                        arr.FileData[pokemon.AdressInRAM[i] + od.Ribbons + m] = pokemon.Ribbion[m];
                    }
                    if (m < 7)
                    {
                        arr.FileData[pokemon.AdressInRAM[i] + od.OTName + m] = pokemon.OTName[m];
                    }
                    if (m < 10)
                    {
                        arr.FileData[pokemon.AdressInRAM[i] + od.Nickname + m] = pokemon.Nickname[m];
                    }
                }
            }
        }
    }
}

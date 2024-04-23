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
        public bool UpdateCheck(List<Pokemon_Gen3> pokemon, int found, byte[] convert, int gen, int subGen, bool inversion, ref int duplicate)
        {
            Offest_data offset_Data = new();
            Pokemon_Value_Check check = new();
            Set_Values sv = new();

            sv.OffsetSetValues(offset_Data, gen, subGen);

            if (found != 0)
            {
                for (int f = 0; f < found; f++)
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
            bool fill = true;
            int count = 0;
            while (fill) 
            {
                fill = false;
                if (count < 1)
                {
                    arr[od.Language + count] = pokemon.Language[count];
                    arr[od.MiscFlags + count] = pokemon.Misc[count];
                    arr[od.Markings + count] = pokemon.Marks[count];
                    arr[od.PPUps + count] = pokemon.PPUps[count];
                    arr[od.Friendship + count] = pokemon.Friendship[count];
                    arr[od.PP1 + count] = pokemon.PP1[count];
                    arr[od.PP2 + count] = pokemon.PP2[count];
                    arr[od.PP3 + count] = pokemon.PP3[count];
                    arr[od.PP4 + count] = pokemon.PP4[count];
                    arr[od.HPEV + count] = pokemon.HPEV[count];
                    arr[od.AttEV + count] = pokemon.AttackEV[count];
                    arr[od.DefEV + count] = pokemon.DefenceEV[count];
                    arr[od.SpeedEV + count] = pokemon.SpeedEV[count];
                    arr[od.SpAttEV + count] = pokemon.SpAttackEV[count];
                    arr[od.SpDefEV + count] = pokemon.SpDefenceEV[count];
                    arr[od.Cool + count] = pokemon.Cool[count];
                    arr[od.Beauty + count] = pokemon.Beauty[count];
                    arr[od.Cute + count] = pokemon.Cute[count];
                    arr[od.Smart + count] = pokemon.Smart[count];
                    arr[od.Tough + count] = pokemon.Tough[count];
                    arr[od.Sheen + count] = pokemon.Feel[count];
                    arr[od.Pkrus + count] = pokemon.PKRus[count];
                    arr[od.MetLocation + count] = pokemon.MetLocation[count];

                }
                if (count < 2)
                {
                    arr[od.ID + count] = pokemon.TrainerID[count];
                    arr[od.SID + count] = pokemon.SecretID[count];
                    arr[od.Checksum + count] = pokemon.Checksum[count];
                    arr[od.Unknown + count] = pokemon.Unknown[count];
                    arr[od.Species + count] = pokemon.PokemonID[count];
                    arr[od.Item + count] = pokemon.Item[count];
                    arr[od.Unused + count] = pokemon.Unused[count];
                    arr[od.Move1 + count] = pokemon.Move1[count];
                    arr[od.Move2 + count] = pokemon.Move2[count];
                    arr[od.Move3 + count] = pokemon.Move3[count];
                    arr[od.Move4 + count] = pokemon.Move4[count];
                    arr[od.Orgins + count] = pokemon.Orgins[count];

                }
                if (count < 4)
                {
                    arr[od.PID + count] = pokemon.PID[count];
                    arr[od.EXP + count] = pokemon.EXP[count];
                    arr[od.IV + count] = pokemon.IV[count];
                    arr[od.Ribbons + count] = pokemon.Ribbion[count];
                }
                if (count < 16)
                {
                    arr[od.OTName + count] = pokemon.OTName[count];
                }
                if (count < 22)
                {
                    arr[od.Nickname + count] = pokemon.Nickname[count];
                    fill = true;
                }   
                count++;
            }
        }

        public Pokemon_Gen3 ArrayToPokemon(byte[] arr, Offest_data od)
        {
            Pokemon_Gen3 pokemon = new();
            bool fill = true;
            int count = 0;
            while (fill)
            {
                fill = false;
                if (count < 1)
                {
                    pokemon.Language.Add(arr[od.Language + count]);
                    pokemon.Misc.Add(arr[od.MiscFlags + count]);
                    pokemon.Marks.Add(arr[od.Markings + count]);
                    pokemon.PPUps.Add(arr[od.PPUps + count]);
                    pokemon.Friendship.Add(arr[od.Friendship + count]);
                    pokemon.PP1.Add(arr[od.PP1 + count]);
                    pokemon.PP2.Add(arr[od.PP2 + count]);
                    pokemon.PP3.Add(arr[od.PP3 + count]);
                    pokemon.PP4.Add(arr[od.PP4 + count]);
                    pokemon.HPEV.Add(arr[od.HPEV + count]);
                    pokemon.AttackEV.Add(arr[od.AttEV + count]);
                    pokemon.DefenceEV.Add(arr[od.DefEV + count]);
                    pokemon.SpeedEV.Add(arr[od.SpeedEV + count]);
                    pokemon.SpAttackEV.Add(arr[od.SpAttEV + count]);
                    pokemon.SpDefenceEV.Add(arr[od.SpDefEV + count]);
                    pokemon.Cool.Add(arr[od.Cool + count]);
                    pokemon.Beauty.Add(arr[od.Beauty + count]);
                    pokemon.Cute.Add(arr[od.Cute + count]);
                    pokemon.Smart.Add(arr[od.Smart + count]);
                    pokemon.Tough.Add(arr[od.Tough + count]);
                    pokemon.Feel.Add(arr[od.Sheen + count]);
                    pokemon.PKRus.Add(arr[od.Pkrus + count]);
                    pokemon.MetLocation.Add(arr[od.MetLocation + count]);

                }
                if (count < 2)
                {
                    pokemon.TrainerID.Add(arr[od.ID + count]);
                    pokemon.SecretID.Add(arr[od.SID + count]);
                    pokemon.Checksum.Add(arr[od.Checksum + count]);
                    pokemon.Unknown.Add(arr[od.Unknown + count]);
                    pokemon.PokemonID.Add(arr[od.Species + count]);
                    pokemon.Item.Add(arr[od.Item + count]);
                    pokemon.Unused.Add(arr[od.Unused + count]);
                    pokemon.Move1.Add(arr[od.Move1 + count]);
                    pokemon.Move2.Add(arr[od.Move2 + count]);
                    pokemon.Move3.Add(arr[od.Move3 + count]);
                    pokemon.Move4.Add(arr[od.Move4 + count]);
                    pokemon.Orgins.Add(arr[od.Orgins + count]);

                }
                if (count < 4)
                {
                    pokemon.PID.Add(arr[od.PID + count]);
                    pokemon.EXP.Add(arr[od.EXP + count]);
                    pokemon.IV.Add(arr[od.IV + count]);
                    pokemon.Ribbion.Add(arr[od.Ribbons + count]);
                }
                if (count < 16)
                {
                    pokemon.OTName.Add(arr[od.OTName + count]);
                }
                if (count < 22)
                {
                    pokemon.Nickname.Add(arr[od.Nickname + count]);
                    fill = true;
                }
                count++;
            }
            return pokemon;
        }

        public void CopyPokemonObject(Pokemon_Gen3 survive, Pokemon_Gen3 noneSurvive, Offest_data od)
        {
            bool fill = true;
            int count = 0;
            while (fill)
            {
                fill = false;
                if (count < 1)
                {
                    survive.Language.Add(noneSurvive.Language[od.Language + count]);
                    survive.Misc.Add(noneSurvive.Misc[od.MiscFlags + count]);
                    survive.Marks.Add(noneSurvive.Marks[od.Markings + count]);
                    survive.PPUps.Add(noneSurvive.PPUps[od.PPUps + count]);
                    survive.Friendship.Add(noneSurvive.Friendship[od.Friendship + count]);
                    survive.PP1.Add(noneSurvive.PP1[od.PP1 + count]);
                    survive.PP2.Add(noneSurvive.PP2[od.PP2 + count]);
                    survive.PP3.Add(noneSurvive.PP3[od.PP3 + count]);
                    survive.PP4.Add(noneSurvive.PP4[od.PP4 + count]);
                    survive.HPEV.Add(noneSurvive.HPEV[od.HPEV + count]);
                    survive.AttackEV.Add(noneSurvive.AttackEV[od.AttEV + count]);
                    survive.DefenceEV.Add(noneSurvive.DefenceEV[od.DefEV + count]);
                    survive.SpeedEV.Add(noneSurvive.SpeedEV[od.SpeedEV + count]);
                    survive.SpAttackEV.Add(noneSurvive.SpAttackEV[od.SpAttEV + count]);
                    survive.SpDefenceEV.Add(noneSurvive.SpDefenceEV[od.SpDefEV + count]);
                    survive.Cool.Add(noneSurvive.Cool[od.Cool + count]);
                    survive.Beauty.Add(noneSurvive.Beauty[od.Beauty + count]);
                    survive.Cute.Add(noneSurvive.Cute[od.Cute + count]);
                    survive.Smart.Add(noneSurvive.Smart[od.Smart + count]);
                    survive.Tough.Add(noneSurvive.Tough[od.Tough + count]);
                    survive.Feel.Add(noneSurvive.Feel[od.Sheen + count]);
                    survive.PKRus.Add(noneSurvive.PKRus[od.Pkrus + count]);
                    survive.MetLocation.Add(noneSurvive.MetLocation[od.MetLocation + count]);

                }
                if (count < 2)
                {
                    survive.TrainerID.Add(noneSurvive.TrainerID[od.ID + count]);
                    survive.SecretID.Add(noneSurvive.SecretID[od.SID + count]);
                    survive.Checksum.Add(noneSurvive.Checksum[od.Checksum + count]);
                    survive.Unknown.Add(noneSurvive.Unknown[od.Unknown + count]);
                    survive.PokemonID.Add(noneSurvive.PokemonID[od.Species + count]);
                    survive.Item.Add(noneSurvive.Item[od.Item + count]);
                    survive.Unused.Add(noneSurvive.Unused[od.Unused + count]);
                    survive.Move1.Add(noneSurvive.Move1[od.Move1 + count]);
                    survive.Move2.Add(noneSurvive.Move2[od.Move2 + count]);
                    survive.Move3.Add(noneSurvive.Move3[od.Move3 + count]);
                    survive.Move4.Add(noneSurvive.Move4[od.Move4 + count]);
                    survive.Orgins.Add(noneSurvive.Orgins[od.Orgins + count]);

                }
                if (count < 4)
                {
                    survive.PID.Add(noneSurvive.PID[od.PID + count]);
                    survive.EXP.Add(noneSurvive.EXP[od.EXP + count]);
                    survive.IV.Add(noneSurvive.IV[od.IV + count]);
                    survive.Ribbion.Add(noneSurvive.Ribbion[od.Ribbons + count]);
                }
                if (count < 16)
                {
                    survive.OTName.Add(noneSurvive.OTName[od.OTName + count]);
                }
                if (count < 22)
                {
                    survive.Nickname.Add(noneSurvive.Nickname[od.Nickname + count]);
                    fill = true;
                }
                count++;
            }
        }

        public void CommitEditToObject(Pokemon_Gen3 survive, Pokemon_Gen3 noneSurvive)
        {
            bool fill = true;
            int count = 0;
            while (fill)
            {
                fill = false;
                if (count < 1)
                {
                    noneSurvive.Language[count] = survive.Language[count];
                    noneSurvive.Misc[count] = survive.Misc[count];
                    noneSurvive.Marks[count] = survive.Marks[count];
                    noneSurvive.PPUps[count] = survive.PPUps[count];
                    noneSurvive.Friendship[count] = survive.Friendship[count];
                    noneSurvive.PP1[count] = survive.PP1[count];
                    noneSurvive.PP2[count] = survive.PP2[count];
                    noneSurvive.PP3[count] = survive.PP3[count];
                    noneSurvive.PP4[count] = survive.PP4[count];
                    noneSurvive.HPEV[count] = survive.HPEV[count];
                    noneSurvive.AttackEV[count] = survive.AttackEV[count];
                    noneSurvive.DefenceEV[count] = survive.DefenceEV[count];
                    noneSurvive.SpeedEV[count] = survive.SpeedEV[count];
                    noneSurvive.SpAttackEV[count] = survive.SpAttackEV[count];
                    noneSurvive.SpDefenceEV[count] = survive.SpDefenceEV[count];
                    noneSurvive.Cool[count] = survive.Cool[count];
                    noneSurvive.Beauty[count] = survive.Beauty[count];
                    noneSurvive.Cute[count] = survive.Cute[count];
                    noneSurvive.Smart[count] = survive.Smart[count];
                    noneSurvive.Tough[count] = survive.Tough[count];
                    noneSurvive.Feel[count] = survive.Feel[count];
                    noneSurvive.PKRus[count] = survive.PKRus[count];
                    noneSurvive.MetLocation[count] = survive.MetLocation[count];

                }
                if (count < 2)
                {
                    noneSurvive.TrainerID[count] = survive.TrainerID[count];
                    noneSurvive.SecretID[count] = survive.SecretID[count];
                    noneSurvive.Checksum[count] = survive.Checksum[count];
                    noneSurvive.Unknown[count] = survive.Unknown[count];
                    noneSurvive.PokemonID[count] = survive.PokemonID[count];
                    noneSurvive.Item[count] = survive.Item[count];
                    noneSurvive.Unused[count] = survive.Unused[count];
                    noneSurvive.Move1[count] = survive.Move1[count];
                    noneSurvive.Move2[count] = survive.Move2[count];
                    noneSurvive.Move3[count] = survive.Move3[count];
                    noneSurvive.Move4[count] = survive.Move4[count];
                    noneSurvive.Orgins[count] = survive.Orgins[count];

                }
                if (count < 4)
                {
                    noneSurvive.PID[count] = survive.PID[count];
                    noneSurvive.EXP[count] = survive.EXP[count];
                    noneSurvive.IV[count] = survive.IV[count];
                    noneSurvive.Ribbion[count] = survive.Ribbion[count];
                }
                if (count < 16)
                {
                    noneSurvive.OTName[count] = survive.OTName[count];
                }
                if (count < 22)
                {
                    noneSurvive.Nickname[count] = survive.Nickname[count];
                    fill = true;
                }
                count++;
            }
            noneSurvive.Edited = true;
        }

        public void PokemonToArrayInject(byte[] arr, Pokemon_Gen3 pokemon, Offest_data od)
        {
            bool fill = true;
            int count = 0;
            for (int i = 0; i < pokemon.AdressInRAM.Count; i++)
            {
                while (fill)
                {
                    fill = false;
                    if (count < 1)
                    {
                        arr[pokemon.AdressInRAM[i] + od.Language + count] = pokemon.Language[count];
                        arr[pokemon.AdressInRAM[i] + od.MiscFlags + count] = pokemon.Misc[count];
                        arr[pokemon.AdressInRAM[i] + od.Markings + count] = pokemon.Marks[count];
                        arr[pokemon.AdressInRAM[i] + od.PPUps + count] = pokemon.PPUps[count];
                        arr[pokemon.AdressInRAM[i] + od.Friendship + count] = pokemon.Friendship[count];
                        arr[pokemon.AdressInRAM[i] + od.PP1 + count] = pokemon.PP1[count];
                        arr[pokemon.AdressInRAM[i] + od.PP2 + count] = pokemon.PP2[count];
                        arr[pokemon.AdressInRAM[i] + od.PP3 + count] = pokemon.PP3[count];
                        arr[pokemon.AdressInRAM[i] + od.PP4 + count] = pokemon.PP4[count];
                        arr[pokemon.AdressInRAM[i] + od.HPEV + count] = pokemon.HPEV[count];
                        arr[pokemon.AdressInRAM[i] + od.AttEV + count] = pokemon.AttackEV[count];
                        arr[pokemon.AdressInRAM[i] + od.DefEV + count] = pokemon.DefenceEV[count];
                        arr[pokemon.AdressInRAM[i] + od.SpeedEV + count] = pokemon.SpeedEV[count];
                        arr[pokemon.AdressInRAM[i] + od.SpAttEV + count] = pokemon.SpAttackEV[count];
                        arr[pokemon.AdressInRAM[i] + od.SpDefEV + count] = pokemon.SpDefenceEV[count];
                        arr[pokemon.AdressInRAM[i] + od.Cool + count] = pokemon.Cool[count];
                        arr[pokemon.AdressInRAM[i] + od.Beauty + count] = pokemon.Beauty[count];
                        arr[pokemon.AdressInRAM[i] + od.Cute + count] = pokemon.Cute[count];
                        arr[pokemon.AdressInRAM[i] + od.Smart + count] = pokemon.Smart[count];
                        arr[pokemon.AdressInRAM[i] + od.Tough + count] = pokemon.Tough[count];
                        arr[pokemon.AdressInRAM[i] + od.Sheen + count] = pokemon.Feel[count];
                        arr[pokemon.AdressInRAM[i] + od.Pkrus + count] = pokemon.PKRus[count];
                        arr[pokemon.AdressInRAM[i] + od.MetLocation + count] = pokemon.MetLocation[count];

                    }
                    if (count < 2)
                    {
                        arr[pokemon.AdressInRAM[i] + od.ID + count] = pokemon.TrainerID[count];
                        arr[pokemon.AdressInRAM[i] + od.SID + count] = pokemon.SecretID[count];
                        arr[pokemon.AdressInRAM[i] + od.Checksum + count] = pokemon.Checksum[count];
                        arr[pokemon.AdressInRAM[i] + od.Unknown + count] = pokemon.Unknown[count];
                        arr[pokemon.AdressInRAM[i] + od.Species + count] = pokemon.PokemonID[count];
                        arr[pokemon.AdressInRAM[i] + od.Item + count] = pokemon.Item[count];
                        arr[pokemon.AdressInRAM[i] + od.Unused + count] = pokemon.Unused[count];
                        arr[pokemon.AdressInRAM[i] + od.Move1 + count] = pokemon.Move1[count];
                        arr[pokemon.AdressInRAM[i] + od.Move2 + count] = pokemon.Move2[count];
                        arr[pokemon.AdressInRAM[i] + od.Move3 + count] = pokemon.Move3[count];
                        arr[pokemon.AdressInRAM[i] + od.Move4 + count] = pokemon.Move4[count];
                        arr[pokemon.AdressInRAM[i] + od.Orgins + count] = pokemon.Orgins[count];

                    }
                    if (count < 4)
                    {
                        arr[pokemon.AdressInRAM[i] + od.PID + count] = pokemon.PID[count];
                        arr[pokemon.AdressInRAM[i] + od.EXP + count] = pokemon.EXP[count];
                        arr[pokemon.AdressInRAM[i] + od.IV + count] = pokemon.IV[count];
                        arr[pokemon.AdressInRAM[i] + od.Ribbons + count] = pokemon.Ribbion[count];
                    }
                    if (count < 16)
                    {
                        arr[pokemon.AdressInRAM[i] + od.OTName + count] = pokemon.OTName[count];
                    }
                    if (count < 22)
                    {
                        arr[pokemon.AdressInRAM[i] + od.Nickname + count] = pokemon.Nickname[count];
                        fill = true;
                    }
                    count++;
                }
            }
        }
    }
}

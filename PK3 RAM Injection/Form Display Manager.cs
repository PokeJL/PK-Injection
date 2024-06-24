using RAM_Injection_Data.Controller;
using RAM_Injection_Data.Model;

namespace PK3_RAM_Injection
{
    public class Form_Display_Manager
    {
        public Form_Display_Manager() { }

        /// <summary>
        /// Initializes the hex editor for Pokemon
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="sendersList"></param>
        public void InitializeHex(Run_Time_Manager rt, List<List<NumericUpDown>> sendersList) 
        {
            SetHexToEdit(rt.LoadFile().LoadDefultPK3(rt), sendersList);
        }

        /// <summary>
        /// Loads a Pokemon found in RAM to the hex editor
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sendersList"></param>
        public void SetHexToEdit(Pokemon_Gen3 p, List<List<NumericUpDown>>sendersList)
        {
            //Sets all numeric up down objects to 1 inorder for edits to properly reflect
            for (int i = 0; i < sendersList.Count; i++) 
            {
                for (int j = 0; j < sendersList[i].Count; j++)
                {
                    sendersList[i][j].Value = 1;
                }
            }

            //Loads the Pokemon into the editor
            for (int i = 0; i < sendersList.Count; i++)
            {
                if (sendersList[i][0].Tag == "pid")
                {
                    for(int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PID[j];
                    }
                }
                else if(sendersList[i][0].Tag == "species")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PokemonID[j];
                    }
                }
                else if (sendersList[i][0].Tag == "language")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Language[j];
                    }
                }
                else if (sendersList[i][0].Tag == "pkrus")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PKRus[j];
                    }
                }
                else if (sendersList[i][0].Tag == "item")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Item[j];
                    }
                }
                else if (sendersList[i][0].Tag == "version")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Orgins[j];
                    }
                }
                else if (sendersList[i][0].Tag == "met")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.MetLocation[j];
                    }
                }
                else if (sendersList[i][0].Tag == "m1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Move1[j];
                    }
                }
                else if (sendersList[i][0].Tag == "m2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Move2[j];
                    }
                }
                else if (sendersList[i][0].Tag == "m3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Move3[j];
                    }
                }
                else if (sendersList[i][0].Tag == "m4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Move4[j];
                    }
                }
                else if (sendersList[i][0].Tag == "mpp1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PP1[j];
                    }
                }
                else if (sendersList[i][0].Tag == "mpp2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PP2[j];
                    }
                }
                else if (sendersList[i][0].Tag == "mpp3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PP3[j];
                    }
                }
                else if (sendersList[i][0].Tag == "mpp4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PP4[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ppup")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.PPUps[j];
                    }
                }
                else if (sendersList[i][0].Tag == "exp")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.EXP[j];
                    }
                }
                else if (sendersList[i][0].Tag == "iv")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.IV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.HPEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.AttackEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.DefenceEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.SpAttackEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev5")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.SpDefenceEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ev6")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.SpeedEV[j];
                    }
                }
                else if (sendersList[i][0].Tag == "friend")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Friendship[j];
                    }
                }
                else if (sendersList[i][0].Tag == "id")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.TrainerID[j];
                    }
                }
                else if (sendersList[i][0].Tag == "sid")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.SecretID[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ot")
                {
                    for (int j = 0, n = sendersList[i].Count - 1; j < sendersList[i].Count; j++, n--)
                    {
                        sendersList[i][j].Value = p.OTName[n];
                    }
                }
                else if (sendersList[i][0].Tag == "nickname")
                {
                    for (int j = 0, n = sendersList[i].Count - 1; j < sendersList[i].Count; j++, n--)
                    {
                        sendersList[i][j].Value = p.Nickname[n];
                    }
                }
                else if (sendersList[i][0].Tag == "contest1")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Cool[j];
                    }
                }
                else if (sendersList[i][0].Tag == "contest2")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Cute[j];
                    }
                }
                else if (sendersList[i][0].Tag == "contest3")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Beauty[j];
                    }
                }
                else if (sendersList[i][0].Tag == "contest4")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Tough[j];
                    }
                }
                else if (sendersList[i][0].Tag == "contest5")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Smart[j];
                    }
                }
                else if (sendersList[i][0].Tag == "contest6")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Feel[j];
                    }
                }
                else if (sendersList[i][0].Tag == "ribbon")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Ribbion[j];
                    }
                }
                else if (sendersList[i][0].Tag == "unknown")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Unknown[j];
                    }
                }
                else if (sendersList[i][0].Tag == "unused")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Unused[j];
                    }
                }
                else if (sendersList[i][0].Tag == "misc")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Misc[j];
                    }
                }
                else if (sendersList[i][0].Tag == "mark")
                {
                    for (int j = 0; j < sendersList[i].Count; j++)
                    {
                        sendersList[i][j].Value = p.Marks[j];
                    }
                }
            }
        }
    }
}

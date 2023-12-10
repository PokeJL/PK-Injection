using PK3_RAM_Injection.Data;
using PK3_RAM_Injection.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PK3_RAM_Injection.Controller
{
    internal class Set_Values
    {

        public Set_Values() { }
        Offset offset = new();
        //Resets some of the application values
        public void ApplicationPartReset(Applicaton_Values val)
        {
            val.FileData = new byte[1];
            val.Found = 0;
            val.SelectIndex = 0;
            val.DexNum = 0;
            val.Gen = 0;
            val.SubGen = 0;
        }

        public void OffsetSetValues(Offest_data od, int gen, int subGen)
        {
            int pid = 0, dex = 0, item = 0, id = 0, sid = 0, exp = 0, friendship = 0,
                ability = 0, hpEV = 0, attEV = 0, defEV = 0, speedEV = 0, spAttEV = 0, spDefEV = 0,
                cool = 0, beauty = 0, cute = 0, smart = 0, tough = 0, sheen = 0, move1 = 0, move2 = 0,
                move3 = 0, move4 = 0, iv = 0, nature = 0, sizePID = 0, sizeDex = 0, sizeItem = 0,
                sizeID = 0, sizeSID = 0, sizeEXP = 0, sizeFriendship = 0, sizeAbility = 0,
                sizeHPEV = 0, sizeAttEV = 0, sizeDefEV = 0, sizeSpeedEV = 0, sizeSpAttEV = 0,
                sizeSpDefEV = 0, sizeCool = 0, sizeBeauty = 0, sizeCute = 0, sizeSmart = 0,
                sizeTough = 0, sizeSheen = 0, sizeMove1 = 0, sizeMove2 = 0, sizeMove3 = 0, sizeMove4 = 0,
            sizeIV = 0, sizeNature = 0, encryption = 0, sizeEncryption = 0,
                pkrus = 0, checksum = 0, checksumCalcDataStart = 0, version = 0,
                nickname = 0, nicknameSize = 0, otName = 0, otNameSize = 0, language = 0;

            offset.Offsets3Later(ref pid, ref dex, ref item, ref id, ref sid, ref exp, ref friendship,
                                ref ability, ref hpEV, ref attEV, ref defEV, ref speedEV, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref move1, ref move2,
                                ref move3, ref move4, ref iv, ref nature, ref sizePID, ref sizeDex, ref sizeItem,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeedEV, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeMove1, ref sizeMove2, ref sizeMove3, ref sizeMove4,
                                ref sizeIV, ref sizeNature, ref encryption, ref sizeEncryption,
                                ref pkrus, ref checksum, ref checksumCalcDataStart, ref version,
                                ref nickname, ref nicknameSize, ref otName, ref otNameSize, ref language, gen, subGen);

            od.PID = pid;
            od.Dex = dex;
            od.Item = item;
            od.ID = id;
            od.SID = sid;
            od.EXP = exp;
            od.Friendship = friendship;
            od.Ability = ability;
            od.HPEV = hpEV;
            od.AttEV = attEV;
            od.DefEV = defEV;
            od.SpeedEV = speedEV;
            od.SpAttEV = spAttEV;
            od.SpDefEV = spDefEV;
            od.Cool = cool;
            od.Beauty = beauty;
            od.Cute = cute;
            od.Smart = smart;
            od.Tough = tough;
            od.Sheen = sheen;
            od.Move1 = move1;
            od.Move2 = move2;
            od.Move3 = move3;
            od.Move4 = move4;
            od.IV = iv;
            od.Nature = nature;
            od.SizePID = sizePID;
            od.SizeDex = sizeDex;
            od.SizeItem = sizeItem;
            od.SizeID = sizeID;
            od.SizeSID = sizeSID;
            od.SizeEXP = sizeEXP;
            od.SizeFriendship = sizeFriendship;
            od.SizeAbility = sizeAbility;
            od.SizeHPEV = sizeHPEV;
            od.SizeAttEV = sizeAttEV;
            od.SizeDefEV = sizeDefEV;
            od.SizeSpeedEV = sizeSpeedEV;
            od.SizeSpAttEV = sizeSpAttEV;
            od.SizeSpDefEV = sizeSpDefEV;
            od.SizeCool = sizeCool;
            od.SizeBeauty = sizeBeauty;
            od.SizeCute = sizeCute;
            od.SizeSmart = sizeSmart;
            od.SizeTough = sizeTough;
            od.SizeSheen = sizeSheen;
            od.SizeMove1 = sizeMove1;
            od.SizeMove2 = sizeMove2;
            od.SizeMove3 = sizeMove3;
            od.SizeMove4 = sizeMove4;
            od.SizeIV = sizeIV;
            od.SizeNature = sizeNature;
            od.Encryption = encryption;
            od.SizeEncryption = sizeEncryption;
            od.Pkrus = pkrus;
            od.Checksum = checksum;
            od.ChecksumCalcDataStart = checksumCalcDataStart;
            od.Version = version;
            od.Nickname = nickname;
            od.NicknameSize = nicknameSize;
            od.OTName = otName;
            od.OTNameSize = otNameSize;
            od.Language = language;
        }

        /// <summary>
        /// Fills targeted game data
        /// </summary>
        /// <param name="gen">Targeted gen</param>
        /// <param name="subGen">Used if games in same gen store data diffrently</param>
        public void GameSetValues(Game_Values gv, int gen, int subGen)
        {
            Game_Values_Data data = new();
            int sds = 0, pds = 0, et = 0, o = 0, np = 0, nm = 0;
            bool ie = true, i = true;

            data.GameData(ref sds, ref pds, ref et, ref ie,
                        ref i, ref o, ref np, ref nm, gen, subGen);

            gv.StorageDataSize = sds;
            gv.PartyDataSize = pds;
            gv.EffortTotal = et;
            gv.IsEncrypted = ie;
            gv.Invert = i;
            gv.Option = o;
            gv.NumOfPokeInGen = np;
            gv.NumOfMovesInGen = nm;
        }
    }
}

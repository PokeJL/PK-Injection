using RAM_Injection_Data.Model;
using RAM_Injection_Data.Data;

namespace RAM_Injection_Data.Controller
{
    public class Set_Values
    {

        public Set_Values() { }
        Offset offset = new();

        public void OffsetSetValues(Offest_data od, int gen, int subGen)
        {
            int pid = 0, dex = 0, item = 0, ppups = 0, id = 0, sid = 0, exp = 0, friendship = 0,
                hpEV = 0, attEV = 0, defEV = 0, speedEV = 0, spAttEV = 0, spDefEV = 0,
                cool = 0, beauty = 0, cute = 0, smart = 0, tough = 0, sheen = 0, move1 = 0, move2 = 0,
                move3 = 0, move4 = 0, iv = 0, sizePID = 0, sizeDex = 0, sizeItem = 0, ppupsSize = 0,
                sizeID = 0, sizeSID = 0, sizeEXP = 0, sizeFriendship = 0, sizeAbility = 0,
                sizeHPEV = 0, sizeAttEV = 0, sizeDefEV = 0, sizeSpeedEV = 0, sizeSpAttEV = 0,
                sizeSpDefEV = 0, sizeCool = 0, sizeBeauty = 0, sizeCute = 0, sizeSmart = 0,
                sizeTough = 0, sizeSheen = 0, sizeMove1 = 0, sizeMove2 = 0, sizeMove3 = 0, sizeMove4 = 0,
                sizeIV = 0, pkrus = 0, pkrusSize = 0, checksum = 0, checksumSize = 0, checksumCalcDataStart = 0, 
                orgins = 0, orginsSize = 0, nickname = 0, nicknameSize = 0, otName = 0, otNameSize = 0, language = 0, 
                languageSize = 0, miscFlags = 0, miscFlagSize = 0, markings = 0, markingsSize = 0, unknown = 0, 
                unknownSize = 0, unused = 0, unusedSize = 0, pp1 = 0, pp1Size = 0, pp2 = 0, pp2Size = 0, pp3 = 0, 
                pp3Size = 0, pp4 = 0, pp4Size = 0, ribbons = 0, ribbonsSize = 0, metLocation = 0, metLocationSize = 0;

            offset.Offsets3Later(ref pid, ref dex, ref item, ref ppups, ref id, ref sid, ref exp, ref friendship,
                                ref hpEV, ref attEV, ref defEV, ref speedEV, ref spAttEV, ref spDefEV,
                                ref cool, ref beauty, ref cute, ref smart, ref tough, ref sheen, ref move1, ref move2,
                                ref move3, ref move4, ref iv, ref sizePID, ref sizeDex, ref sizeItem, ref ppupsSize,
                                ref sizeID, ref sizeSID, ref sizeEXP, ref sizeFriendship, ref sizeAbility,
                                ref sizeHPEV, ref sizeAttEV, ref sizeDefEV, ref sizeSpeedEV, ref sizeSpAttEV,
                                ref sizeSpDefEV, ref sizeCool, ref sizeBeauty, ref sizeCute, ref sizeSmart,
                                ref sizeTough, ref sizeSheen, ref sizeMove1, ref sizeMove2, ref sizeMove3, ref sizeMove4,
                                ref sizeIV, ref pkrus, ref pkrusSize, ref checksum, ref checksumSize, ref checksumCalcDataStart, 
                                ref orgins, ref orginsSize, ref nickname, ref nicknameSize, ref otName, ref otNameSize, ref language, 
                                ref languageSize, ref miscFlags, ref miscFlagSize, ref markings, ref markingsSize, ref unknown, 
                                ref unknownSize, ref unused, ref unusedSize, ref pp1, ref pp1Size, ref pp2, ref pp2Size, ref pp3, 
                                ref pp3Size, ref pp4, ref pp4Size, ref ribbons, ref ribbonsSize, ref metLocation, ref metLocationSize, gen, subGen);

            od.PID = pid;
            od.Species = dex;
            od.Item = item;
            od.PPUps = ppups;
            od.ID = id;
            od.SID = sid;
            od.EXP = exp;
            od.Friendship = friendship;
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
            od.SizePID = sizePID;
            od.SpeciesSize = sizeDex;
            od.SizeItem = sizeItem;
            od.PPUpsSize = ppupsSize;
            od.SizeID = sizeID;
            od.SizeSID = sizeSID;
            od.SizeEXP = sizeEXP;
            od.SizeFriendship = sizeFriendship;
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
            od.Pkrus = pkrus;
            od.PkrusSize = pkrusSize;
            od.Checksum = checksum;
            od.ChecksumSize = checksumSize;
            od.ChecksumCalcDataStart = checksumCalcDataStart;
            od.Orgins = orgins;
            od.OrginsSize = orginsSize;
            od.Nickname = nickname;
            od.NicknameSize = nicknameSize;
            od.OTName = otName;
            od.OTNameSize = otNameSize;
            od.Language = language;
            od.LanguageSize = languageSize;
            od.MiscFlags = miscFlags;
            od.MarkingsSize = miscFlagSize;
            od.Markings = markings;
            od.MarkingsSize = markingsSize;
            od.Unknown = unknown;
            od.UnknownSize = unknownSize;
            od.Unused = unused;
            od.UnusedSize = unusedSize;
            od.PP1 = pp1;
            od.PP1Size = pp1Size;
            od.PP2 = pp2;
            od.PP2Size = pp2Size;
            od.PP3 = pp3;
            od.PP3Size = pp3Size;
            od.PP4 = pp4;
            od.PP4Size = pp4Size;
            od.Ribbons = ribbons;
            od.RibbonsSize = ribbonsSize;
            od.MetLocation = metLocation;
            od.MetLocationSize = metLocationSize;
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
            //gv.IsEncrypted = ie;
            gv.Invert = i;
            gv.Option = o;
            gv.NumOfPokeInGen = np;
            gv.NumOfMovesInGen = nm;
        }
    }
}

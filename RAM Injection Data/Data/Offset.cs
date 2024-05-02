namespace RAM_Injection_Data.Data
{
    class Offset
    {
        public Offset() { }

        /// <summary>
        /// Returns the data stucture for a Pokemon in a given gen
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dex"></param>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <param name="sid"></param>
        /// <param name="exp"></param>
        /// <param name="friendship"></param>
        /// <param name="ability"></param>
        /// <param name="hpEV"></param>
        /// <param name="attEV"></param>
        /// <param name="defEV"></param>
        /// <param name="speedEV"></param>
        /// <param name="spAttEV"></param>
        /// <param name="spDefEV"></param>
        /// <param name="cool"></param>
        /// <param name="beauty"></param>
        /// <param name="cute"></param>
        /// <param name="smart"></param>
        /// <param name="tough"></param>
        /// <param name="sheen"></param>
        /// <param name="move1"></param>
        /// <param name="move2"></param>
        /// <param name="move3"></param>
        /// <param name="move4"></param>
        /// <param name="iv"></param>
        /// <param name="nature"></param>
        /// <param name="sizePID"></param>
        /// <param name="sizeDex"></param>
        /// <param name="sizeItem"></param>
        /// <param name="sizeID"></param>
        /// <param name="sizeSID"></param>
        /// <param name="sizeEXP"></param>
        /// <param name="sizeFriendship"></param>
        /// <param name="sizeAbility"></param>
        /// <param name="sizeHPEV"></param>
        /// <param name="sizeAttEV"></param>
        /// <param name="sizeDefEV"></param>
        /// <param name="sizeSpeedEV"></param>
        /// <param name="sizeSpAttEV"></param>
        /// <param name="sizeSpDefEV"></param>
        /// <param name="sizeCool"></param>
        /// <param name="sizeBeauty"></param>
        /// <param name="sizeCute"></param>
        /// <param name="sizeSmart"></param>
        /// <param name="sizeTough"></param>
        /// <param name="sizeSheen"></param>
        /// <param name="sizeMove1"></param>
        /// <param name="sizeMove2"></param>
        /// <param name="sizeMove3"></param>
        /// <param name="sizeMove4"></param>
        /// <param name="sizeIV"></param>
        /// <param name="sizeNature"></param>
        /// <param name="encryption"></param>
        /// <param name="sizeEncryption"></param>
        /// <param name="pkrus"></param>
        /// <param name="checksum"></param>
        /// <param name="checksumCalcDataStart"></param>
        /// <param name="version"></param>
        /// <param name="nickname"></param>
        /// <param name="sizeNickname"></param>
        /// <param name="otName"></param>
        /// <param name="sizeOTName"></param>
        /// <param name="language"></param>
        /// <param name="gen"></param>
        /// <param name="subGen"></param>
        public void Offsets3Later(ref int pid, ref int dex, ref int item, ref int ppups, ref int id, ref int sid, ref int exp, ref int friendship,
                                ref int hpEV, ref int attEV, ref int defEV, ref int speedEV, ref int spAttEV, ref int spDefEV,
                                ref int cool, ref int beauty, ref int cute, ref int smart, ref int tough, ref int sheen, ref int move1, ref int move2,
                                ref int move3, ref int move4, ref int iv, ref int sizePID, ref int sizeDex, ref int sizeItem, ref int ppupsSize,
                                ref int sizeID, ref int sizeSID, ref int sizeEXP, ref int sizeFriendship, ref int sizeAbility,
                                ref int sizeHPEV, ref int sizeAttEV, ref int sizeDefEV, ref int sizeSpeedEV, ref int sizeSpAttEV,
                                ref int sizeSpDefEV, ref int sizeCool, ref int sizeBeauty, ref int sizeCute, ref int sizeSmart,
                                ref int sizeTough, ref int sizeSheen, ref int sizeMove1, ref int sizeMove2, ref int sizeMove3, ref int sizeMove4,
                                ref int sizeIV, ref int pkrus, ref int pkrusSize, ref int checksum, ref int checksumSize, ref int checksumCalcDataStart,
                                ref int orgins, ref int orginsSize, ref int nickname, ref int nicknameSize, ref int otName, ref int otNameSize, ref int language,
                                ref int languageSize, ref int miscFlags, ref int miscFlagSize, ref int markings, ref int markingsSize, ref int unknown,
                                ref int unknownSize, ref int unused, ref int unusedSize, ref int pp1, ref int pp1Size, ref int pp2, ref int pp2Size, ref int pp3,
                                ref int pp3Size, ref int pp4, ref int pp4Size, ref int ribbons, ref int ribbonsSize, 
                                ref int metLocation, ref int metLocationSize, int gen, int subGen)
        {
            //RSEFRLG Base Game
            if (gen == 3 && subGen == 0)
            {
                pid = 0;
                sizePID = 4;
                dex = 32;
                sizeDex = 2;
                item = 34;
                sizeItem = 2;
                ppups = 40;
                ppupsSize = 1;
                id = 4;
                sizeID = 2;
                sid = 6;
                sizeSID = 2;
                exp = 36;
                sizeEXP = 4;
                friendship = 41;
                sizeFriendship = 1;
                sizeAbility = 1;
                hpEV = 56;
                sizeHPEV = 1;
                attEV = 57;
                sizeAttEV = 1;
                defEV = 58;
                sizeDefEV = 1;
                speedEV = 59;
                sizeSpeedEV = 1;
                spAttEV = 60;
                sizeSpAttEV = 1;
                spDefEV = 61;
                sizeSpDefEV = 1;
                cool = 62;
                sizeCool = 1;
                beauty = 63;
                sizeBeauty = 1;
                cute = 64;
                sizeCute = 1;
                smart = 65;
                sizeSmart = 1;
                tough = 66;
                sizeTough = 1;
                sheen = 67;
                sizeSheen = 1;
                move1 = 44;
                sizeMove1 = 2;
                move2 = 46;
                sizeMove2 = 2;
                move3 = 48;
                sizeMove3 = 2;
                move4 = 50;
                sizeMove4 = 2;
                iv = 72;
                sizeIV = 4;
                pkrus = 68;
                pkrusSize = 1;
                checksum = 28;
                checksumSize = 2;
                checksumCalcDataStart = 32;
                orgins = 0x46;
                orginsSize = 2;
                nickname = 0x08;
                nicknameSize = 10;
                otName = 0x14;
                otNameSize = 7;
                language = 0x12;
                languageSize = 1;
                miscFlags = 0X13;
                miscFlagSize = 1;
                markings = 0x1B;
                markingsSize = 1;
                unknown = 0x1E;
                unknownSize = 2;
                unused = 42;
                unusedSize = 2;
                pp1 = 52;
                pp1Size = 1;
                pp2 = 53;
                pp2Size = 1;
                pp3 = 54;
                pp3Size = 1;
                pp4 = 55;
                pp4Size = 1;
                ribbons = 76;
                ribbonsSize = 4;
                metLocation = 69;
                metLocationSize = 1;
            }
        }
    }
}
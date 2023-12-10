namespace PK3_RAM_Injection.Data
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
        public void Offsets3Later(ref int pid, ref int dex, ref int item, ref int id, ref int sid, ref int exp, ref int friendship,
                                ref int ability, ref int hpEV, ref int attEV, ref int defEV, ref int speedEV, ref int spAttEV, ref int spDefEV,
                                ref int cool, ref int beauty, ref int cute, ref int smart, ref int tough, ref int sheen, ref int move1, ref int move2,
                                ref int move3, ref int move4, ref int iv, ref int nature, ref int sizePID, ref int sizeDex, ref int sizeItem,
                                ref int sizeID, ref int sizeSID, ref int sizeEXP, ref int sizeFriendship, ref int sizeAbility,
                                ref int sizeHPEV, ref int sizeAttEV, ref int sizeDefEV, ref int sizeSpeedEV, ref int sizeSpAttEV,
                                ref int sizeSpDefEV, ref int sizeCool, ref int sizeBeauty, ref int sizeCute, ref int sizeSmart,
                                ref int sizeTough, ref int sizeSheen, ref int sizeMove1, ref int sizeMove2, ref int sizeMove3, ref int sizeMove4,
                                ref int sizeIV, ref int sizeNature, ref int encryption, ref int sizeEncryption, ref int pkrus, ref int checksum, ref int checksumCalcDataStart, ref int version,
                                ref int nickname, ref int sizeNickname, ref int otName, ref int sizeOTName, ref int language, int gen, int subGen)
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
                id = 4;
                sizeID = 2;
                sid = 6;
                sizeSID = 2;
                exp = 36;
                sizeEXP = 4;
                friendship = 41;
                sizeFriendship = 1;
                ability = 0; //not clear in the structure
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
                nature = 0; //not clear in structure
                sizeNature = 1;
                encryption = 0; //Value not used in generation but set here so I can reuse code
                sizeEncryption = 1;
                pkrus = 68;
                checksum = 28;
                checksumCalcDataStart = 32;
                version = 0x46; //Origin index
                nickname = 0x08;
                sizeNickname = 22;
                otName = 0x14;
                sizeOTName = 16;
                language = 0x12;
            }
        }
    }
}
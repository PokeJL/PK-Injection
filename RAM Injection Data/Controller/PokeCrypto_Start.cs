namespace RAM_Injection_Data.Controller
{
    class PokeCrypto_Start
    {
        public PokeCrypto_Start() { }

        //From PKHeX and modified to meet needs of this application needed to get decryption started
        public byte[] PK3(byte[] data)
        {
            PKHeX.Core.PokeCrypto.DecryptIfEncrypted3(ref data);
            if (data.Length != 100) //SIZE_3PARTY = 100;
                Array.Resize(ref data, 100); //SIZE_3PARTY = 100;
            return data;
        }
    }
}

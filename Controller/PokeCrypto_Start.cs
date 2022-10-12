namespace PK3_RAM_Injection.Controller
{
    class PokeCrypto_Start
    {
        public PokeCrypto_Start() { }

        //From PKHeX and modified to meet needs of this application needed to get decryption started
        public byte[] PK3(byte[] data)
        {
            PokeCrypto.DecryptIfEncrypted3(ref data);
            if (data.Length != PokeCrypto.SIZE_3PARTY)
                Array.Resize(ref data, PokeCrypto.SIZE_3PARTY);
            return data;
        }
    }
}

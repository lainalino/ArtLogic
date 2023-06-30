namespace ArtLogic.Infra.Services.Interfaces
{
    public interface IDecodeEncodeService
    {
        public Task<string> EncodeText(string textToEncode);
        public Task<byte[]> WriteEncondedTexFile(List<string> listEncodeText);
    }
}

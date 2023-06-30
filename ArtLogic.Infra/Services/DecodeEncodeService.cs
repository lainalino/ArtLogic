using ArtLogic.Infra.Services.Interfaces;
using TheWeirdTextFormatLibrary;

namespace ArtLogic.Infra.Services
{
    public class DecodeEncodeService : IDecodeEncodeService
    {
        /// <summary> 
        /// Encoded the text by method Encoded 
        /// <example>For example: tacocat
        /// </example>
        /// <returns>267487694,125043731</returns>
        /// </summary>  
        public async Task<string> EncodeText(string textToEncode)
        {
            var arrayEncoded = await ATextDecodeEncode.Encode(textToEncode, Global.sCharacterSize, Global.sBinarySize);
            return await Task.FromResult(arrayEncoded);
        }

        /// <summary> 
        /// Write the encoded text in a file
        /// </summary> 
        /// 
        public async Task<byte[]> WriteEncondedTexFile(List<string> listEncodeText)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    foreach (var item in listEncodeText)
                    {
                        //write the encoded text to file 
                        writer.WriteLine(item);
                    }
                }

                // converting to array
                byte[] bytesInStream = stream.ToArray();
                stream.Close();

                return await Task.FromResult(bytesInStream);
            }

        }

    }
}

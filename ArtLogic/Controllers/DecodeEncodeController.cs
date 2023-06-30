using ArtLogic.Infra.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using System.IO;
using System.Text;
using TheWeirdTextFormatLibrary;

namespace ArtLogic.Controllers
{
    public class DecodeEncodeController : Controller
    {
        private readonly IDecodeEncodeService _decodeEncodeService;
        private readonly IWebHostEnvironment env;
        public DecodeEncodeController(IDecodeEncodeService decodeEncodeService, IWebHostEnvironment env)
        {
            _decodeEncodeService = decodeEncodeService;
            this.env = env;
        }

        [Route("")]
        [Route("[controller]/Index")]
        public IActionResult Index() => View();

        public async Task<IActionResult> WriteEncodedText(IFormFile originFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = new StringBuilder();
                    List<string> listArrayEncode = new List<string>();

                    string textEncoded = string.Empty;
                    string pathFile = Path.GetFileName(originFile.FileName);

                    //create a file 
                    using (var stream = System.IO.File.Create(pathFile))
                    {
                        //copy the contents to manipulate
                        await originFile.CopyToAsync(stream);

                        //read the stream
                        using (var reader = new StreamReader(originFile.OpenReadStream()))
                        {
                            //read until the last character
                            while (reader.Peek() >= 0)
                            {
                                string line = reader.ReadLine();

                                if (!string.IsNullOrEmpty(line))
                                {
                                    //encoded the text
                                    textEncoded = await _decodeEncodeService.EncodeText(line);

                                    //add a list. Format: [encoded1, encoded2, encoded3]
                                    listArrayEncode.Add($"[{textEncoded}]");
                                }
                            }
                        }                       
                    }

                    //delete the file
                    System.IO.File.Delete(pathFile);
                    
                    //write the list in a file and return this file in bytes
                    var byteTextEncoded = await _decodeEncodeService.WriteEncondedTexFile(listArrayEncode);

                    //named the file "TheWeirdFormatText" to download
                    return File(byteTextEncoded, "text/plain", "TheWeirdFormatText.txt");
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View("Index");
            }
        }
    }
}

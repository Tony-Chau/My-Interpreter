using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Translator;
using static Translator.LanguageList;

namespace MyInterpreterApi.Controllers
{
    public class LanguageController : ApiController
    {
        List<Language> LanguageList = GetLanguageList();
        
        /// <summary>
        /// Gets a list of languages with name and code
        /// </summary>
        /// <returns>A list of languages</returns>
        public List<Language> Get()
        {
            return LanguageList;
        }

        // GET: api/Language/GetNames/{code}
        /// <summary>
        /// Gets the name of the language base on the given code
        /// </summary>
        /// <param name="code">The input code to get the name of the language of which it belongs to</param>
        /// <returns>The name of the language that links with the code</returns>
        [HttpGet]
        [Route("api/Language/GetNames/{code}")]
        public string GetName(string code)
        {
            return GetLanguageName(code);
        }

        // GET: api/Language/GetCodes/{name}
        /// <summary>
        /// Gets the code of the language base on the given language
        /// </summary>
        /// <param name="name">The input name to get the code of the language of which it belongs to</param>
        /// <returns>The name of the code that links with the name</returns>
        [HttpGet]
        [Route("api/Language/GetCodes/{name}")]
        public string GetCode(string name)
        {
            return GetLanguageCode(name);
        }


        // GET: api/Language/GetNames
        /// <summary>
        /// Gets the list of language names 
        /// </summary>
        /// <returns>List of language names</returns>
        [HttpGet]
        [Route("api/Language/GetNames")]
        public IList GetNames()
        {
            return GetLanguageNameList();
        }

        // GET: api/Language/GetCodes
        /// <summary>
        /// Gets the list of language codes
        /// </summary>
        /// <returns>List of Language codes</returns>
        [HttpGet]
        [Route("api/Language/GetCodes")]
        public IList GetCodes()
        {
            return GetLanguageCodeList();
        }

        /// <summary>
        /// Translate the text
        /// </summary>
        /// <param name="apikey">The Yandex Api Key</param>
        /// <param name="text">The text that is being translated</param>
        /// <param name="to">Requires code of the language. Translate the text base on the code</param>
        /// <returns>The translated text</returns>
        [HttpGet]
        [Route("api/Translate")]
        public async Task<string> Translate(string apikey, string text, string to)
        {
            return await Yandex.Translate(apikey, text, to);
        }

        /// <summary>
        /// Identify the language
        /// </summary>
        /// <param name="apikey">The apikey of Rapidsystran</param>
        /// <param name="host">the host of Rapidsystran</param>
        /// <param name="text">The text being identified</param>
        /// <returns>A list of language code that the program identified</returns>
        [HttpGet]
        [Route("api/Identify")]
        public List<string> Identify(string apikey, string host, string text)
        {
            apikey = HttpUtility.UrlDecode(apikey);
            host = HttpUtility.UrlEncode(host);
            return RapidSystran.IdentifyLanguage(apikey, host, text);
        }
    }
}

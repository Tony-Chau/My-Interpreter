using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using Newtonsoft.Json;
using Nito.AsyncEx;

namespace Translator
{
    public class Yandex
    {
        public string key { get; }

        public Yandex(string apikey)
        {
            key = apikey;
        }

        /// <summary>
        /// Using Yandex Translate to translate the text to your specific language
        /// Only Translate works. Detect language is no longer functional. 
        /// Go to: https://tech.yandex.com/translate/
        /// </summary>
        /// <param name="text">The message getting translated</param>
        /// <param name="lang">Your targeted language (must be in language code)</param>
        /// <returns>The translated text</returns>
        public async Task<string> Translate(string text, string lang)
        {
            string message = "";
            try
            {
                string uri = "https://translate.yandex.net/api/v1.5/tr.json/translate?" +
                    "key=" + key +
                    "&text=" + HttpUtility.UrlEncode(text)+
                    "&lang=" + lang;
                using (HttpClient client = new HttpClient())
                {
                    string res = await client.GetStringAsync(uri);
                    YandexTranslated json = JsonConvert.DeserializeObject<YandexTranslated>(res);
                    message = json.text.First();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return message;
        }
        public static async Task<string> Translate(string apikey, string text, string lang)
        {
            string message = "";
            try
            {
                string uri = "https://translate.yandex.net/api/v1.5/tr.json/translate?" +
                    "key=" + apikey +
                    "&text=" + HttpUtility.UrlEncode(text) +
                    "&lang=" + lang;
                using (HttpClient client = new HttpClient())
                {
                    string res = await client.GetStringAsync(uri);
                    YandexTranslated json = JsonConvert.DeserializeObject<YandexTranslated>(res);
                    message = json.text.First();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return message;
        }
    }



    //I understand Yandex also includes this function, but its a bit messy and decided to manually do this cause it will look cleaner
    public static class LanguageList
    {
        //I did not want to do this, but this leaves me no choice.
        private static List<Language> _LanguageList = new List<Language>
        {
            {new Language("Azerbaijan", "az") },
            {new Language("Albanian", "sq") },
            {new Language("Amharic", "am") },
            {new Language("English", "en") },
            {new Language("Arabic", "ar") },
            {new Language("Armenian", "hy") },
            {new Language("Afrikaans", "af") },
            {new Language("Basque", "eu") },
            {new Language("Bashkir", "ba") },
            {new Language("Belarusian", "be") },
            {new Language("Bengali", "bn") },
            {new Language("Burmese", "my") },
            {new Language("Bulgarian", "bg") },
            {new Language("Bosnian", "bs") },
            {new Language("Welsh", "cy") },
            {new Language("Hungarian", "hu") },
            {new Language("Vietnamese", "vi") },
            {new Language("Haitian (Creole)", "ht") },
            {new Language("Galician", "gl") },
            {new Language("Dutch", "nl") },
            {new Language("Hill Mari", "mrj") },
            {new Language("Greek", "el") },
            {new Language("Georgian", "ka") },
            {new Language("Gujarati", "gu") },
            {new Language("Danish", "da") },
            {new Language("Hebrew", "he") },
            {new Language("Yiddish", "yi") },
            {new Language("Indonesian", "id") },
            {new Language("Irish", "ga") },
            {new Language("Italian", "it") },
            {new Language("Icelandic", "is") },
            {new Language("Spanish", "es") },
            {new Language("Kazakh", "kk") },
            {new Language("Kannada", "kn") },
            {new Language("Catalan", "ca") },
            {new Language("Kyrgyz", "ky") },
            {new Language("Chinese", "zh") },
            {new Language("Korean", "ko") },
            {new Language("Xhosa", "xh") },
            {new Language("Khmer", "km") },
            {new Language("Laotian", "lo") },
            {new Language("Latin", "la") },
            {new Language("Latvian", "lv") },
            {new Language("Lithuanian", "lt") },
            {new Language("Luxembourgish", "lb") },
            {new Language("Malagasy", "mg") },
            {new Language("Malay", "ms") },
            {new Language("Malayalam", "ml") },
            {new Language("Maltese", "mt") },
            {new Language("Macedonian", "mk") },
            {new Language("Maori", "mi") },
            {new Language("Marathi", "mr") },
            {new Language("Mari", "mhr") },
            {new Language("Mongolian", "mn") },
            {new Language("German", "de") },
            {new Language("Nepali", "ne") },
            {new Language("Norwegian", "no") },
            {new Language("Punjabi", "pa") },
            {new Language("Papiamento", "pap") },
            {new Language("Persian", "fa") },
            {new Language("Polish", "pl") },
            {new Language("Portuguese", "pt") },
            {new Language("Romanian", "ro") },
            {new Language("Russian", "ru") },
            {new Language("Cebuano", "ceb") },
            {new Language("Serbian", "sr") },
            {new Language("Sinhala", "si") },
            {new Language("Slovakian", "sk") },
            {new Language("Slovenian", "sl") },
            {new Language("Swahili", "sw") },
            {new Language("Sundanese", "su") },
            {new Language("Tajik", "tg") },
            {new Language("Thai", "th") },
            {new Language("Tagalog", "tl") },
            {new Language("Tamil", "ta") },
            {new Language("Tatar", "tt") },
            {new Language("Telugu", "te") },
            {new Language("Turkish", "tr") },
            {new Language("Udmurt", "udm") },
            {new Language("Uzbek", "uz") },
            {new Language("Ukrainian", "uk") },
            {new Language("Urdu", "ur") },
            {new Language("Finnish", "fi") },
            {new Language("French", "fr") },
            {new Language("Hindi", "hi") },
            {new Language("Croatian", "hr") },
            {new Language("Czech", "cs") },
            {new Language("Swedish", "sv") },
            {new Language("Scottish", "gd") },
            {new Language("Estonian", "et") },
            {new Language("Esperanto", "eo") },
            {new Language("Javanese", "jv") },
            {new Language("Japanese", "ja") }
        };

        /// <summary>
        /// Get a list of available Language Codes
        /// </summary>
        /// <returns>List of available Language Code</returns>
        public static IList GetLanguageCodeList()
        {
            var list = new List<string>();
            foreach (Language lan in _LanguageList)
            {
                list.Add(lan.Code);
            }
            return list;
        }

        /// <summary>
        /// Gets a list of available language names
        /// </summary>
        /// <returns>List of available language names</returns>
        public static IList GetLanguageNameList()
        {
            var list = new List<string>();
            foreach (Language lan in _LanguageList)
            {
                list.Add(lan.Name);
            }
            return list;
        }

        /// <summary>
        /// The language list
        /// </summary>
        /// <returns>The language list</returns>
        public static List<Language> GetLanguageList()
        {
            return _LanguageList;
        }

        /// <summary>
        /// Gets a specific Language name using code
        /// </summary>
        /// <param name="code">The language code</param>
        /// <returns>The name of the language that shares that links with the code</returns>
        public static string GetLanguageName(string code)
        {
            return _LanguageList.FirstOrDefault(x => x.Code == code.ToLower())
                .Name;    
    }

        /// <summary>
        /// Gets a specific code using name
        /// </summary>
        /// <param name="name">Name of the language</param>
        /// <returns>The language code that links with the name</returns>
        public static string GetLanguageCode(string name)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException("Input name is too short and not acceptable. Must be at least 3 characters.");
            }
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return _LanguageList.FirstOrDefault(x => x.Name == name)
                .Code;
        }

    }

    public class Language
    {
        public string Name { get; }
        public string Code { get; }
        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }


}

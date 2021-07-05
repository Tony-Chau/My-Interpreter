using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace Translator
{
    public class RapidSystran
    {
        public string host { get; }
        public string apikey { get; }

        /// <summary>
        /// Sets up the Systran Api via RapidApi. 
        /// Go to: https://rapidapi.com/systran/api/systran-io-translation-and-nlp?endpoint=568bf57ce4b04bcce8ec3e75
        /// </summary>
        /// <param name="host">Link to the site</param>
        /// <param name="apikey">The api key</param>
        public RapidSystran(string host, string apikey)
        {
            this.host = host;
            this.apikey = apikey;
        }

        /// <summary>
        /// Identify the language format
        /// </summary>
        /// <param name="text">The text that will be examine</param>
        public List<string> IdentifyLanguage(string text)
        {
            List<string> list = new List<String>();
            try
            {
                string uri = string.Format("https://systran-systran-platform-for-language-processing-v1.p.rapidapi.com/nlp/lid/detectLanguage/document?" +
                    "input=" + HttpUtility.UrlEncode(text));
                var json = GetResponse(uri, Method.GET);
                //return some language
                DetectedList res = JsonConvert.DeserializeObject<DetectedList>(json.Content);
                foreach (DetectedLanguage _det in res.detectedlanguages) {
                    list.Add(_det.lang);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public static List<string> IdentifyLanguage(string apikey, string host, string text)
        {
            List<string> list = new List<String>();
            try
            {
                string uri = string.Format("https://systran-systran-platform-for-language-processing-v1.p.rapidapi.com/nlp/lid/detectLanguage/document?" +
                    "input=" + HttpUtility.UrlEncode(text));
                var json = GetResponse(uri, Method.GET, apikey, host);
                //return some language
                DetectedList res = JsonConvert.DeserializeObject<DetectedList>(json.Content);
                foreach (DetectedLanguage _det in res.detectedlanguages)
                {
                    list.Add(_det.lang);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        /// <summary>
        /// To get the response from the server
        /// </summary>
        /// <param name="url">The url path</param>
        /// <param name="method">The HTTP protocol type</param>
        /// <returns>The response from the Api page</returns>
        private IRestResponse GetResponse(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("x-rapidapi-host", host);
            request.AddHeader("x-rapidapi-key", apikey);
            return client.Execute(request);
        }

        private static IRestResponse GetResponse(string url, Method method, string apikey, string host)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("x-rapidapi-host", host);
            request.AddHeader("x-rapidapi-key", apikey);
            return client.Execute(request);
        }
    }
}

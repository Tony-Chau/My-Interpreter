using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class YandexTranslated
    {
        public int code { get; set; }
        public string lang { get; set; }
        public List<string> text { get; set; }
    }


    public class DetectedLanguage
    {
        public double confidence { get; set; }

        public string lang { get; set; }
    }

    class DetectedList
    {
        public List<DetectedLanguage> detectedlanguages { get; set; }
    }
}

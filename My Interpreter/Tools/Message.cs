using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tools.Interface;
using Translator;

namespace Tools
{
    public class Audio : IMessage
    {
        public int Id { get; }

        public string User { get; }

        public string Text { get; }

        public DateTime DateReceived { get; }

        public Language From { get; set; }
        public Language To { get; set; }

        public Audio(int id, string user, string text, DateTime datereceived, Language from, Language to)
        {
            Id = id;
            User = user;
            Text = text;
            DateReceived = datereceived;
            From = from;
            To = to;

        }

    }
    public class Message : IMessage
    {
        public int Id { get; }

        public string User { get; }

        public string Text { get; }

        public DateTime DateReceived { get; }

        public Language From { get; set; }
        public Language To { get; set; }

        public Message(int id, string user, string text, DateTime datereceived, Language from, Language to) 
        {
            Id = id;
            User = user;
            Text = text;
            DateReceived = datereceived;
            From = from;
            To = to;

        }
        public async Task<string> Translate(Yandex yandex)
        {
            string translated = "";
            try
            {
                translated = await yandex.Translate(Text, To.Code);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return translated;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator;

namespace Tools.Interface
{
    public interface IMessage
    {
        int Id { get; }
        string User { get; }
        string Text { get; }
        DateTime DateReceived { get; }
        Language From { get; set; }
        Language To { get; set; }

        

    }
}

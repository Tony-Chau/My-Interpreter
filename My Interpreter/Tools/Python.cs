using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython;

namespace Tools
{
    public static class Python
    {
        public static string filename;

        public static void load(string filename)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = filename;

        }
        public static void Recordvoice()
        {

        }
    }
}

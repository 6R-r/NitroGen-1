using System;
using System.Collections.Generic;
using System.Text;
using Leaf.xNet;
using Console = Colorful.Console;

namespace NitroGen
{
    class Checker
    {
        static void Connect()
        {
            using (var request = new HttpRequest())
            {
                // Randomize User-agent for better anonymity
                request.UserAgent = Http.RandomUserAgent();
            }
        }
    }
}

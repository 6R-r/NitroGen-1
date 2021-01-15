using Colorful;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading;
using System;

namespace NitroGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Nitro Gen";
            Console.WriteLine(Title.asciiTitle, ColorTranslator.FromHtml("#7289da"));
            Console.WriteLine("Note : Any code generated, are not verified\n codes may have already been used or invalid", Color.OrangeRed);
            Generator.Init();

        }
    }
}

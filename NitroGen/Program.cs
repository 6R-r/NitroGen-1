using Colorful;
using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace NitroGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Nitro Gen";
            Console.WriteLine(Title.asciiTitle, ColorTranslator.FromHtml("#7289da"));
            Console.WriteLine("By: Kwalix\n", ColorTranslator.FromHtml("#ed8409"));
            Generator.Init();
            Generator.Start();
        }
    }
}

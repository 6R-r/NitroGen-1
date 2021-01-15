using System;
using System.Collections.Generic;
using System.Text;
using Console = Colorful.Console;
using System.Drawing;
using System.IO;
using System.Threading;

namespace NitroGen
{
    class Generator
    {
        static int amount;
        static List<string> codeSave = new List<string> { };
        static string generatorDate;
        public static void Init()
        {
            Console.Write("How much code do you want to generate : ", Color.Yellow);
            try
            {
                string tmp = Console.ReadLine();
                amount = Int32.Parse(tmp);
            } catch (Exception ex)
            {
                Console.WriteLine($"[ERR] {ex.Message}", Color.Red);
                Console.WriteLine("[INF] Please retry", ColorTranslator.FromHtml("#0972ec"));
                Init();
            }
            if(amount <= 0)
            {
                throw new Exception("Please enter a valid number!");
            }
        }
        private static void Save()
        {
        }
        public static void Start()
        {
            
            char[] alpha = "AfnOmhIFoWUb73dauQpLg6XwqJxiNY5T1r4SlkvztH2yeBsGE8DRPCVMcKZ9".ToCharArray();
            // 16 char gift url
            generatorDate = DateTime.Now.ToString();
            Console.WriteLine($"[INF] Starting generator at : {generatorDate}", ColorTranslator.FromHtml("#0972ec"));
            Thread.Sleep(2000);
            for (int i = 0; i < amount; i++)
            {
                List<char> tmpCode = new List<char> { };
                for(int j = 0; j < 16; j++)
                {
                    Random rand = new Random();
                    int itemNum = rand.Next(0, alpha.Length - 1);
                    char tmpChar = alpha[itemNum];
                    tmpCode.Add(tmpChar);
                }
                string completeCode = String.Join("", tmpCode);
                Console.WriteLine($"[-] https://discord.com/gifts/{completeCode}", ColorTranslator.FromHtml("#08d91a"));
                codeSave.Add(completeCode);
                Save();
            }
        }
    }
}

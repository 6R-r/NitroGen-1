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
        static public List<string> codeSave = new List<string> { };
        static string generatorDate;
        public static void Init()
        {
            Console.Write("How much code do you want to generate : ", Color.Yellow);
            try
            {
                string tmp = Console.ReadLine();
                amount = Int32.Parse(tmp);
                if (amount <= 0)
                {
                    throw new Exception("Please enter a valid number!");

                }
            } catch (Exception ex)
            {
                Console.WriteLine($"[ERR] {ex.Message}", Color.Red);
                Console.WriteLine("[INF] Please retry", ColorTranslator.FromHtml("#0972ec"));
                
                Init();
            }
            
            Start();
        }
        private static void Save()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory().ToString(), "Nitro.txt");
            string codeToString = String.Join("\n", codeSave);
            Console.WriteLine("\n[INF] Save generated code", ColorTranslator.FromHtml("#0972ec"));

            Thread.Sleep(2000);
            if(File.Exists(filePath))
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"\n###### {generatorDate} ######\n");
                    codeSave.ForEach(s => sw.WriteLine("https://discord.gift/" + s));
                }
            } else
            {
                Console.WriteLine("\n[INF] Nitro.txt not exist, creating it...", ColorTranslator.FromHtml("#0972ec"));
                using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"\n###### {generatorDate} ######\n");
                    codeSave.ForEach(s => sw.WriteLine("https://discord.gift/" + s));
                }
            }

            Console.Write("\nwhat do you want to do [Gen| Exit] : ", Color.Yellow);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "generate":
                case "gen":
                case "Gen":
                case "g":
                case "G":
                    Init();
                    break;
                case "exit":
                case "Exit":
                case "e":
                case "E":
                    Console.WriteLine("\nThx for using this tool :)", Color.Gold);
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nThx for using this tool :)", Color.Gold);
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
            }
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
                Console.WriteLine($"[-] {completeCode}", ColorTranslator.FromHtml("#08d91a"));
                codeSave.Add(completeCode);
            }
            Checker.Checking();
            Save();
        }
    }
}

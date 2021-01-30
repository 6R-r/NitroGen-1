using System;
using System.Collections.Generic;
using System.Text;
using Leaf.xNet;
using Console = Colorful.Console;
using System.IO;
using System.Drawing;

namespace NitroGen
{
    class Checker
    {
        static List<string> proxies = new List<string> { };
        static ushort proxiesCounter = 0;
        static public void FetchProxies()
        {
            string pwd = Directory.GetCurrentDirectory();
            string proxyPath = Path.Join(pwd + @"\http_proxies.txt");
            
            foreach (string proxy in File.ReadLines(proxyPath))
            {
                proxies.Add(proxy);
            }
        }

        static bool ParseProxy(string parsedProx)
        {
           if (parsedProx.Contains("8080"))
            {
                Console.WriteLine(parsedProx);
                return true;
            } else
            {
                return false;
            }

        }

        static public void Checking()
        {
            FetchProxies();
            using (var request = new HttpRequest())
            {
                request.KeepTemporaryHeadersOnRedirect = true;
                Console.WriteLine("Start checking code...", ColorTranslator.FromHtml("#0972ec"));
                request.UserAgent = Http.RandomUserAgent();
                foreach (string code in Generator.codeSave)
                {
                    Random randomProxy = new Random();
                    try
                    {
                        while (!ParseProxy(proxies[proxiesCounter]))
                        {
                            proxiesCounter++;
                        }
                        request.Proxy = HttpProxyClient.Parse(proxies[proxiesCounter]);
                        Console.WriteLine($"https://discord.com/gifts/{code}");
                        request.Get($"https://discord.com/gifts/{code}");
                        Console.WriteLine(request.Response);
                    } 
                    catch (Exception ex)
                    {
                        proxiesCounter++;
                        Console.WriteLine("[ERR] Cannot connect to proxy", Color.Red);
                    }
                } 
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Leaf.xNet;
using Console = Colorful.Console;
using System.IO;

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

        static public void Checking()
        {
            FetchProxies();
            Random randomProxy = new Random();
            Console.WriteLine(proxies[5]);
            using (var request = new HttpRequest())
            {
                // Randomize User-agent for better anonymity
                request.UserAgent = Http.RandomUserAgent();
                request.Proxy = HttpProxyClient.Parse(proxies[randomProxy.Next(0, proxies.Count)]);
                request.Get("https://discord.com/api/v8/entitlements/gift-codes/");
                Console.WriteLine(request.Response);
            }
        }
    }
}

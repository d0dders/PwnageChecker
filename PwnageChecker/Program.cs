using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PwnageChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter and address to check if it has been PWNED!");
            


            var results = GetPwnage(Console.ReadLine());
            foreach (PwnResult result in results)
            {
                Console.WriteLine(result.ToString() + Environment.NewLine);
                
            }

            Console.ReadKey();
        }

        public static List<PwnResult> GetPwnage(string account)
        {
            //TODO: handle if account was not PWNED: System.Net.WebException: 'The remote server returned an error: (404) Not Found.' 
            var results = new List<PwnResult>();
            WebClient webClient = new WebClient();
            webClient.Headers.Add("api-version", "2");
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "PwnageChecker via Command Line");
            Byte[] pwnageData = webClient.DownloadData("https://haveibeenpwned.com/api/v2/breachedaccount/" + account);

            using (var stream = new MemoryStream(pwnageData))
            using (var reader = new StreamReader(stream))
            {
                results = JsonConvert.DeserializeObject<List<PwnResult>>(reader.ReadToEnd());
            }
            return results;
        }

    }
}

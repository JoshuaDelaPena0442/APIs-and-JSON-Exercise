using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void KanyeQuote()
        {
            var client = new HttpClient();
            var kanyeUrl = "https://api.kanye.rest";
            var kanyeResponse = client.GetAsync(kanyeUrl).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse.Content.ReadAsStringAsync().Result).GetValue("quote").ToString();
            Console.WriteLine($"Kanye says: {kanyeQuote}");
            Console.WriteLine();
        }

        public static void RonQuote()
        {
            var client = new HttpClient();
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetAsync(ronUrl).Result;
            var ronQuote = JArray.Parse(ronResponse.Content.ReadAsStringAsync().Result)[0].ToString();
            Console.WriteLine($"Ron says: {ronQuote}");
            Console.ReadLine();
        }
    }
}

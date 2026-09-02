using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class OpenWeatherMapAPI
    {
        public static void WeatherInfo()
        {
            var client = new HttpClient();
            var key = "938d76cb32727cc7c3e0417e2e842f15";
            
            
            while (true) 
            { 
                Console.WriteLine("Please enter a city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

            
                var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={key}&units=imperial";
            
            
                try
                {
                    var response = client.GetStringAsync(weatherUrl).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    var temp = JObject.Parse(formattedResponse).GetValue("temp");
                    Console.WriteLine($"The current Temperature is {temp} degrees Fahrenheit");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Would you like to check another city? (Yes/No)");
                var answer = Console.ReadLine();
                if (answer.ToLower().Trim() == "no")
                {
                    break;
                }
            }              
        }
    }
}
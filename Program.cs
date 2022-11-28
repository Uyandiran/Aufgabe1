using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace Aufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}
            // c2b238d710aa8593924a3d04ba80ca97
            string openWeatherKey = "c2b238d710aa8593924a3d04ba80ca97";

            Console.WriteLine("Bitte geben Sie den Namen einer Stadt ein:");
            string stadt = Console.ReadLine();



            HttpClient httpClient = new HttpClient();
            string requestUri = "https://api.openweathermap.org/data/2.5/weather?q="+stadt+"&appid=c2b238d710aa8593924a3d04ba80ca97&units=metric";
            HttpResponseMessage httpResponse = httpClient.GetAsync(requestUri).Result;

            string response = httpResponse.Content.ReadAsStringAsync().Result;
            OpenWeatherMapData openWeatherMapData = JsonConvert.DeserializeObject<OpenWeatherMapData>(response);

            Console.WriteLine(openWeatherMapData.main.temp);
            Console.ReadKey();


        }
    }
}

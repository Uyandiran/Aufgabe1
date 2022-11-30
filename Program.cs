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
            //string openWeatherKey = "c2b238d710aa8593924a3d04ba80ca97"; // füge den Key über die App config ein

            Console.WriteLine("Bitte geben Sie den Namen einer Stadt ein:");
            string stadt = null;
            stadt = Console.ReadLine();
            OpenWeatherMap openweathermap = new OpenWeatherMap();
            openweathermap.openWeatherMapRequest(stadt);
            Console.WriteLine(openweathermap.toString());
            Console.ReadKey();
        }
    }
}

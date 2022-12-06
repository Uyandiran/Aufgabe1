using System;
using System.Net.Http;
using Newtonsoft.Json;


namespace Aufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie den Namen einer Stadt ein:");
            string stadt = Console.ReadLine();
            OpenWeatherMap openweathermap = new OpenWeatherMap();
            openweathermap.openWeatherMapRequest(stadt);
            Console.WriteLine(openweathermap.toString());
        }
    }
}

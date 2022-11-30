using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace Aufgabe1
{
    class OpenWeatherMap
    {
        public OpenWeatherMap()
        {
            requestUri = "https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}&units=metric";
            key = "c2b238d710aa8593924a3d04ba80ca97";

            requestUri = requestUri.Replace("{API key}", key);
            httpResponse = null;
            response = null;
            httpClient  = new HttpClient();
        }

        private string generateURI(string stadt)
        {
            return requestUri.Replace("{city name}", stadt);
        }

        public void openWeatherMapRequest(string stadt)
        {
            //Füge den Namen der Stadt in den String hinzu.
            string str = generateURI(stadt);
            httpClient = new HttpClient();
            httpResponse = httpClient.GetAsync(str).Result;
            string response = httpResponse.Content.ReadAsStringAsync().Result;
            currentWeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(response);            
        }

        public string toString()
        {
            str = "Die aktuelle Temperatur beträgt: " + currentWeatherData.main.temp + " grad Celsius, die tiefst Temperatur liegt heute bei : " + 
                currentWeatherData.main.temp_min + " grad Celsius, die höchst Temperatur bei: "+ currentWeatherData.main.temp_max+" grad Celsius";
            return str;
        }
        
        private string str;
        private HttpClient httpClient;
        private HttpResponseMessage httpResponse;
        private string key;
        private string requestUri;
        private string response;
        public CurrentWeatherData currentWeatherData;
    }
}

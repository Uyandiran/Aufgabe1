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
            requestUri = System.Configuration.ConfigurationManager.AppSettings["requestUri"].ToString()+"&units=metric";
            key = System.Configuration.ConfigurationManager.AppSettings["OpenWeatherMapKey"].ToString();
                        
            requestUri = requestUri.Replace("{API key}", key);
            httpResponse = null;
            response = null;
            httpClient  = null;
        }

        private string generateURI(string stadt)
        {
            return requestUri.Replace("{city name}", stadt);
        }

        public void openWeatherMapRequest(string stadt)
        {
            string str = generateURI(stadt);
            httpClient = new HttpClient();
            httpResponse = httpClient.GetAsync(str).Result;
            string response = httpResponse.Content.ReadAsStringAsync().Result;
            currentWeatherData = JsonConvert.DeserializeObject<CurrentWeatherData>(response);            
        }

        public string toString()
        {
            str = "Die aktuelle Temperatur beträgt: " + currentWeatherData.main.temp + " grad Celsius, die tiefst Temperatur liegt heute bei : " + 
                currentWeatherData.main.temp_min + " grad Celsius und die höchst Temperatur bei: "+ currentWeatherData.main.temp_max+" grad Celsius";
            return str;
        }

        private void SaveToFile()
        {

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

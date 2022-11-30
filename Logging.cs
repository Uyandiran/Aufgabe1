using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Aufgabe1
{
    static class Logging
    {
        public static void WriteLog(string message)
        {
            string logPath = System.Configuration.ConfigurationManager.AppSettings["LogPath"];
            StreamWriter writer = new StreamWriter(logPath, true);
            writer.WriteLine($"{DateTime.Now}:" + message);        
        }
    }    
}


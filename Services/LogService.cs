using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderWebApi.Services
{
    public class LogService
    {
        public int Counter { get; set; }

        public void SetError(string errMessenge)
        {
            var path = $"{Directory.GetCurrentDirectory()}\\Logs\\OrderLog{Counter}.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(errMessenge);
            sw.Close();
            Thread.Sleep(1 * 1000);
        }
    }
}

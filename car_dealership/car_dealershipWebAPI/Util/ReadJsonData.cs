using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using car_dealershipWebAPI.Models;

namespace car_dealershipWebAPI.Util
{

    public class ReadJsonData
    {
        private static ReadJsonData instance;
        public RootObject Config { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
        private static string PathToBin
        {
            get
            {
                return $"{HttpRuntime.AppDomainAppPath}bin";
            }
        }
        private static string PathToConfig
        {
            get
            {
                var configPath = ConfigurationManager.AppSettings["PathToJsonData"];
                return configPath;
            }
        }

        private ReadJsonData() { }

        public static ReadJsonData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReadJsonData();
                    using (StreamReader r = new StreamReader(PathToConfig))
                    {
                        string json = r.ReadToEnd();
                        RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
                        instance.Config = ro;
                        instance.Vehicles = ro.Vehicles;
                    }
                }
                return instance;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace car_dealershipWebAPI.Models
{
    /// <summary>
    /// Vehicle
    /// </summary>
    public class Vehicle
    {
        public string _id { get; set; }
        public string make { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public bool hasSunroof { get; set; }
        public bool isFourWheelDrive { get; set; }
        public bool hasLowMiles { get; set; }
        public bool hasPowerWindows { get; set; }
        public bool hasNavigation { get; set; }
        public bool hasHeatedSeats { get; set; }
        public bool hasAutomaticTransmission { get; set; }
    }

    public class RootObject
    {
        public  IEnumerable<Vehicle> Vehicles { get; set; }        
    }
}
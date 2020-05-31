using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSBO_01_18LebedISPraktika2
{
    public class WiFiLocation
    {
        public long global_id { get; set; }
        public int Number { get; set; }
        public Cells Cells { get; set; }
    }

    public class Cells
    {
        public long global_id { get; set; }
        public string Name { get; set; }
        public string AdmArea { get; set; }
        public string District { get; set; }
        public string Location { get; set; }
        public int NumberOfAccessPoints { get; set; }
        public string WiFiName { get; set; }
        public int CoverageArea { get; set; }
        public string FunctionFlag { get; set; }
        public string AccessFlag { get; set; }
        public string Password { get; set; }
        public GeoData geoData { get; set; }
    }

    public class GeoData
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }

        public double Latitude => coordinates[1];
        public double Longitude => coordinates[0];
    }

    /*

    {
        "global_id": 276298117,
        "Number": 1,
        "Cells": {
            "global_id": 276298117,
            "Name": "Городской Wi-Fi",
            "AdmArea": "Центральный административный округ",
            "District": "район Якиманка",
            "Location": "город Москва, Болотная улица, дом 10",
            "NumberOfAccessPoints": 2,
            "WiFiName": "Moscow_WiFi_Free",
            "CoverageArea": 50,
            "FunctionFlag": "действует",
            "AccessFlag": "открытая сеть",
            "Password": null,
            "geoData": {
                "type": "Point",
                "coordinates": [
                    37.618727711,
                    55.746452779
                ]
            }
        }
    },*/

}



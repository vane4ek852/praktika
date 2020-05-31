using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BSBO_01_18LebedISPraktika2
{
    public class MosApi
    {
        const string ApiKey = "3a75454a30bce27b890b3216189bcebd";
        const string Dataset = "2756";
        public string ApiAddress = $"https://apidata.mos.ru/v1/datasets/{Dataset}/rows?$top=5000&api_key={ApiKey}";
        //string versionAddress = @"https://apidata.mos.ru/v1/datasets/{Dataset}/version";

        public async Task<WiFiLocation[]> GetLocationData()
        { 
            var client = new HttpClient();            
            var str = await client.GetStringAsync(ApiAddress);
            return JsonConvert.DeserializeObject<WiFiLocation[]>(str);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Baidu.AI.Common.Extend
{
    public class VehicleOcrApi
    {
        public string GetVinCode(byte[] image, string token, Dictionary<string, object> options = null)
        {
            var result = HttpExtend.KongPatchResponse<JObject>("https://aip.baidubce.com/rest/2.0/ocr/v1/vin_code?access_token=" + token, null, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("image", Convert.ToBase64String(image)) });
            return result;
        }
    }
}

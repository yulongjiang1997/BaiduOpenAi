using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Baidu.AI.Common.Extend
{
    public static class HttpExtend
    {
        /// <summary>
        /// 实体转成get参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public static async Task<K> Get<T, K>(string url, T param = null) where T : class
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.GetAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// 实体转成Delete参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public static async Task<K> Delete<T, K>(string url, T param = null) where T : class
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.DeleteAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public static async Task<K> PostJson<T, K>(string url, T param = null) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var paramStr = ModelToHttpParam<T>.ToPostJsonParam(param);
            var strContent = new StringContent(paramStr);
            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");// ("content-type", "application/json");
            var requstResult = await httpClient.PostAsync(url, strContent);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public static async Task<K> PostFromBody<T, K>(string url, T param = null, IEnumerable<KeyValuePair<string, string>> keyValues = null, string contentType = null) where T : class
        {
            HttpClient httpClient = new HttpClient();
            var paramStr = ModelToHttpParam<T>.ToPostFromBodyParam(param);
            if (keyValues != null)
            {
                paramStr = paramStr.Union(keyValues);
            }
            var strContent = new FormUrlEncodedContent(paramStr);
            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var requstResult = await httpClient.PostAsync(url, strContent);
            var result = string.Empty;
            using (requstResult)

            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// 修改API
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string KongPatchResponse<T>(string url, T param = null, IEnumerable<KeyValuePair<string, string>> keyValues = null) where T:class
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
            var paramStr = ModelToHttpParam<T>.ToPostFromBodyParam(param);
            if (keyValues != null)
            {
                paramStr = paramStr.Union(keyValues);
            }
            string s3 = (from pair in paramStr
                         select pair.Key + "=" + System.Web.HttpUtility.UrlEncode(pair.Value.ToString())).DefaultIfEmpty("").Aggregate((string a, string b) => a + "&" + b);
            byte[] btBodys = Encoding.UTF8.GetBytes(s3);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();

            return responseContent;
        }
    }

    /// <summary>
    /// 实体转Http请求参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ModelToHttpParam<T>
    {
        /// <summary>
        /// 当前实体属性列表
        /// </summary>
        public static PropertyInfo[] PropertyInfos { get; set; }

        /// <summary>
        /// 转成get请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToGetParam(T model)
        {
            if (model == null) return "";
            if (PropertyInfos == null || PropertyInfos.Count() == 0)
            {
                PropertyInfos = typeof(T).GetProperties();
            }
            var paramList = PropertyInfos.Select(i =>
            {
                var name = i.Name;
                var value = i.GetValue(model);
                return value == null ? "" : $"{name}={value}";
            }).Where(i => !string.IsNullOrEmpty(i)).ToList();
            return "?" + string.Join("&", paramList);
        }

        /// <summary>
        /// 转成POST请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToPostJsonParam(T model)
        {
            if (model == null) return "{}";
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 转成POST请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string, string>> ToPostFromBodyParam(T model)
        {
            var result = new List<KeyValuePair<string, string>>();
            if (model == null) return result;
            if (PropertyInfos == null || PropertyInfos.Count() == 0)
            {
                PropertyInfos = typeof(T).GetProperties();
            }
            var paramList = PropertyInfos.Select(i =>
            {
                var r = new KeyValuePair<string, string>(i.Name, i.GetValue(model).ToString());
                return r;
            }).ToList();
            return paramList;
        }
    }
}

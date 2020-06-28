using Baidu.Aip.Ocr;
using BaiduOcr.Common.Dto;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Baidu.AI.Ocr
{
    public class BaiduOcr
    {
        private Baidu.Aip.Ocr.Ocr client = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey">apiKey</param>
        /// <param name="secretKey">secretKey</param>
        /// <param name="requestTimeout">识别请求超时时间</param>
        public BaiduOcr(string apiKey, string secretKey, int requestTimeout = 60000)
        {
            client = new Baidu.Aip.Ocr.Ocr(apiKey, secretKey);
            client.Timeout = requestTimeout;  // 修改超时时间
        }

        /// <summary>
        /// 本地图片分析
        /// </summary>
        /// <param name="imagePath">本地图片路径</param>
        /// <param name="options">参数列表</param>
        public ResultBase<JObject> LocalImageAnalysis(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = LocalImageAnalysis(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片分析
        /// </summary>
        /// <param name="image">图片数据</param>
        /// <param name="options">参数列表</param>
        public ResultBase<JObject> LocalImageAnalysis(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 调用通用文字识别, 图片参数为本地图片
                result.Data = client.GeneralBasic(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 远程图片识别
        /// </summary>
        /// <param name="imageUrl">远程图片URL</param>
        /// <param name="options">参数列表</param>
        public ResultBase<JObject> RemoteImageAnalysis(string imageUrl, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 调用通用文字识别, 图片参数为本地图片
                result.Data = client.GeneralBasicUrl(imageUrl, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片分析 高精度版
        /// </summary>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAccurateAnalysis(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 调用通用文字识别（高精度版）
                result = LocalImageAccurateAnalysis(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片分析 高精度版
        /// </summary>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAccurateAnalysis(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 调用通用文字识别（高精度版）
                result.Data = client.AccurateBasic(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 识别本地图中文字 含位置信息版
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAnalysisLocationInfo(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 带参数调用通用文字识别（含位置信息版）, 图片参数为本地图片
                result.Data = client.General(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 识别远程图片中的文字 含位置信息版
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        public ResultBase<JObject> RemoteImageAnalysisLocationInfo(string imageUrl, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用通用文字识别（含位置信息版）, 图片参数为本地图片
                result.Data = client.GeneralUrl(imageUrl, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片分析 含位置信息 高精度版 
        /// </summary>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAccurateAnalysisLocationInfo(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 调用通用文字识别（高精度版）
                result = LocalImageAccurateAnalysisLocationInfo(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片分析 含位置信息 高精度版 
        /// </summary>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAccurateAnalysisLocationInfo(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 调用通用文字识别（高精度版）
                result.Data = client.Accurate(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片识别 生僻字版本
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAnalysisEnhanced(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 调用通用文字识别（含生僻字版）, 图片参数为本地图片，    
                // 带参数调用通用文字识别（含生僻字版）, 图片参数为本地图片
                result = LocalImageAnalysisEnhanced(image, options);
             }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 本地图片识别 生僻字版本
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> LocalImageAnalysisEnhanced(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 调用通用文字识别（含生僻字版）, 图片参数为本地图片，    
                // 带参数调用通用文字识别（含生僻字版）, 图片参数为本地图片
                result.Data = client.GeneralEnhanced(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
             }
            return result;
        }

        /// <summary>
        /// 远程图片识别 生僻字版本
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> RemoteImageAnalysisEnhanced(string imageUrl, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用通用文字识别（含生僻字版）, 图片参数为远程url图片
                result.Data = client.GeneralEnhancedUrl(imageUrl, options); 
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            } 
            return result;
        }  
    }
}

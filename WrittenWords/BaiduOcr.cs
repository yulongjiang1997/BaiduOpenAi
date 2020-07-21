using Baidu.AI.Common.Dto.Ocr;
using Baidu.AI.Common.Dto.Ocr.BankCard;
using Baidu.AI.Common.Dto.Ocr.IdCrad;
using Baidu.AI.Common.Dto.Ocr.ImageAccurateAnalysis;
using Baidu.AI.Common.Dto.Ocr.ImageAnalysis;
using Baidu.AI.Common.Extend;
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
        public ResultBase<ImageAnalysisReturn> LocalImageAnalysis(string imagePath, ImageAnalysisInput parmeter = null)
        {
            var result = new ResultBase<ImageAnalysisReturn>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = LocalImageAnalysis(image, parmeter);
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
        public ResultBase<ImageAnalysisReturn> LocalImageAnalysis(byte[] image, ImageAnalysisInput parmeter = null)
        {
            var result = new ResultBase<ImageAnalysisReturn>();
            try
            {
                // 调用通用文字识别, 图片参数为本地图片
                var options = parmeter == null ? null : ClassToDictionary<ImageAnalysisInput>.GetDictionary(parmeter);
                result.Data = client.GeneralBasic(image, options).ToModel<ImageAnalysisReturn>();
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
        public ResultBase<ImageAnalysisReturn> RemoteImageAnalysis(string imageUrl, ImageAnalysisInput parmeter = null)
        {
            var result = new ResultBase<ImageAnalysisReturn>();
            try
            {
                // 调用通用文字识别, 图片参数为远程图片
                var options = parmeter == null ? null : ClassToDictionary<ImageAnalysisInput>.GetDictionary(parmeter);
                // 调用通用文字识别, 图片参数为远程图片
                result.Data = client.GeneralBasicUrl(imageUrl, options).ToModel<ImageAnalysisReturn>();
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
        public ResultBase<ImageAccurateAnalysisReturn> LocalImageAccurateAnalysis(string imagePath, ImageAccurateAnalysisInput parmeter = null)
        {
            var result = new ResultBase<ImageAccurateAnalysisReturn>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 调用通用文字识别（高精度版）
                result = LocalImageAccurateAnalysis(image, parmeter);
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
        public ResultBase<ImageAccurateAnalysisReturn> LocalImageAccurateAnalysis(byte[] image, ImageAccurateAnalysisInput parmeter = null)
        {
            var result = new ResultBase<ImageAccurateAnalysisReturn>();
            try
            {
                var options = parmeter == null ? null : ClassToDictionary<ImageAccurateAnalysisInput>.GetDictionary(parmeter);
                // 调用通用文字识别（高精度版）
                result.Data = client.AccurateBasic(image, options).ToModel<ImageAccurateAnalysisReturn>();
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

        /// <summary>
        /// 网络图片文字识别  没理解和本地 图片 有什么区别。。
        /// </summary>
        /// <param name="imagePath">本地图片</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> WebImage(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 带参数调用网络图片文字识别, 图片参数为本地图片
                result = WebImage(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 网络图片文字识别  没理解和本地 图片 有什么区别。。
        /// </summary>
        /// <param name="imagePath">本地图片</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> WebImage(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用网络图片文字识别, 图片参数为本地图片
                result.Data = client.WebImage(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 网络图片文字识别
        /// </summary>
        /// <param name="imageUrl">远程URL</param>
        /// <param name="options">参数</param>
        /// <returns></returns>
        public ResultBase<JObject> WebImageUrl(string imageUrl, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用网络图片文字识别, 图片参数为远程url图片
                result.Data = client.WebImageUrl(imageUrl, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 身份证识别
        /// </summary>
        /// <param name="imagePath">身份证路径</param>
        /// <param name="isFront">是否正面 true 正面  false 反面</param>
        /// <param name="options">参数</param>
        /// <returns></returns>
        private ResultBase<T> IdCard<T>(string imagePath, bool isFront, IdcardInput parmeter = null)
        {
            var result = new ResultBase<T>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 带参数调用身份证识别
                result = IdCard<T>(image, isFront, parmeter);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 身份证识别
        /// </summary>
        /// <param name="image">身份证图片byte数组</param>
        /// <param name="isFront">是否正面 true 正面  false 反面</param>
        /// <param name="options">参数</param>
        /// <returns></returns>
        private ResultBase<T> IdCard<T>(byte[] image, bool isFront, IdcardInput parmeter = null)
        {
            var result = new ResultBase<T>();
            try
            {
                var idCardSide = isFront ? "front" : "back";
                var options = parmeter == null ? null : ClassToDictionary<IdcardInput>.GetDictionary(parmeter);
                // 带参数调用身份证识别
                result.Data = client.Idcard(image, idCardSide, options).ToModel<T>();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 身份证正面识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="parmeter"></param>
        /// <returns></returns>
        public ResultBase<IdCardFrontReturn> IdCardFront(string imagePath, IdcardInput parmeter = null)
        {
            return IdCard<IdCardFrontReturn>(imagePath, true, parmeter);
        }

        /// <summary>
        /// 身份证正面识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="parmeter"></param>
        /// <returns></returns>
        public ResultBase<IdCardFrontReturn> IdCardFront(byte[] image, IdcardInput parmeter = null)
        {
            return IdCard<IdCardFrontReturn>(image, true, parmeter);
        }

        /// <summary>
        /// 身份证反面识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="parmeter"></param>
        /// <returns></returns>
        public ResultBase<IdCardBackReturn> IdCardBack(string imagePath, IdcardInput parmeter = null)
        {
            return IdCard<IdCardBackReturn>(imagePath, false, parmeter);
        }

        /// <summary>
        /// 身份证反面识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="parmeter"></param>
        /// <returns></returns>
        public ResultBase<IdCardBackReturn> IdCardBack(byte[] image, IdcardInput parmeter = null)
        {
            return IdCard<IdCardBackReturn>(image, false, parmeter);
        }

        /// <summary>
        /// 银行卡识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public ResultBase<BankCardReturn> Bankcard(string imagePath)
        {
            var result = new ResultBase<BankCardReturn>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 调用银行卡识别，可能会抛出网络等异常，请使用try/catch捕获
                result = Bankcard(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 银行卡识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public ResultBase<BankCardReturn> Bankcard(byte[] image)
        {
            var result = new ResultBase<BankCardReturn>();
            try
            {
                // 调用银行卡识别，可能会抛出网络等异常，请使用try/catch捕获
                result.Data = client.Bankcard(image).ToModel<BankCardReturn>();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 驾驶证识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> DrivingLicense(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 带参数调用驾驶证识别
                result = DrivingLicense(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 驾驶证识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> DrivingLicense(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用驾驶证识别
                result.Data = client.DrivingLicense(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 行驶证识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> VehicleLicense(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = VehicleLicense(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 行驶证识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> VehicleLicense(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                result.Data = client.VehicleLicense(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 车牌识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> LicensePlate(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = LicensePlate(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 车牌识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> LicensePlate(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                result.Data = client.LicensePlate(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 营业执照识别
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> BusinessLicense(string imagePath)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = BusinessLicense(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 营业执照识别
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> BusinessLicense(byte[] image)
        {
            var result = new ResultBase<JObject>();
            try
            {
                result.Data = client.BusinessLicense(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 通用票据识别
        /// 用户向服务请求识别医疗票据、发票、的士票、保险保单等票据类图片中的所有文字，并返回文字在图中的位置信息。
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> Receipt(string imagePath, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = Receipt(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 通用票据识别
        /// 用户向服务请求识别医疗票据、发票、的士票、保险保单等票据类图片中的所有文字，并返回文字在图中的位置信息。
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> Receipt(byte[] image, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                result.Data = client.Receipt(image, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格文字识别同步接口
        /// 自动识别表格线及表格内容，结构化输出表头、表尾及每个单元格的文字内容。
        /// </summary>
        /// <param name="imagePath"></param> 
        /// <returns></returns>
        public ResultBase<JObject> Form(string imagePath)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result.Data = client.Form(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格文字识别提交接口
        /// 自动识别表格线及表格内容，结构化输出表头、表尾及每个单元格的文字内容。表格文字识别接口为异步接口，分为两个API：提交请求接口、获取结果接口。
        /// </summary>
        /// <param name="imagePath"></param> 
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionRequest(string imagePath)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                result = TableRecognitionRequest(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格文字识别提交接口
        /// 自动识别表格线及表格内容，结构化输出表头、表尾及每个单元格的文字内容。表格文字识别接口为异步接口，分为两个API：提交请求接口、获取结果接口。
        /// </summary>
        /// <param name="imagePath"></param> 
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionRequest(byte[] image)
        {
            var result = new ResultBase<JObject>();
            try
            {
                result.Data = client.TableRecognitionRequest(image);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格识别结果获取
        /// 获取表格文字识别结果
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionGetResultDemo(string requestId, Dictionary<string, object> options = null)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 带参数调用表格识别结果
                result.Data = client.TableRecognitionGetResult(requestId, options);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格图片转换成excel
        /// </summary>
        /// <param name="imagePath">本地图片路径</param>
        /// <param name="timeout">处理超时时间</param>
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionToExcel(string imagePath, int timeout = 30000)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 识别为excel文件
                result = TableRecognitionToExcel(image, timeout);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格图片转换成excel
        /// </summary>
        /// <param name="image">图片byte[]</param>
        /// <param name="timeout">处理超时时间</param>
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionToExcel(byte[] image, int timeout = 30000)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 识别为excel文件
                result.Data = client.TableRecognitionToExcel(image, timeout);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格图片转换成Json
        /// </summary>
        /// <param name="imagePath">本地图片路径</param>
        /// <param name="timeout">处理超时时间</param>
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionToJson(string imagePath, int timeout = 30000)
        {
            var result = new ResultBase<JObject>();
            try
            {
                var image = File.ReadAllBytes(imagePath);
                // 识别为excel文件
                result = TableRecognitionToJson(image, timeout);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 表格图片转换成Json
        /// </summary>
        /// <param name="image">图片byte[]</param>
        /// <param name="timeout">处理超时时间</param>
        /// <returns></returns>
        public ResultBase<JObject> TableRecognitionToJson(byte[] image, int timeout = 30000)
        {
            var result = new ResultBase<JObject>();
            try
            {
                // 识别为excel文件
                result.Data = client.TableRecognitionToJson(image, timeout);
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

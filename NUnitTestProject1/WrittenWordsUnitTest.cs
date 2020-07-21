
using Baidu.AI.Common.Dto.Ocr.ImageAccurateAnalysis;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {
            try
            {
                // …Ë÷√APPID/AK/SK
                var APP_ID = "20625372";
                var API_KEY = "RU2AG3F9H8SdIiT1o72E8GcV";
                var SECRET_KEY = "9lMQykOsWQtYa3z1LnbUhb2UAgQX8XSE";

                var writtenWords = new Baidu.AI.Ocr.BaiduOcr(API_KEY, SECRET_KEY);
                // var zm = @"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\1.jpg";
                // var fm = @"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\2.jpg";
                // var cp = @"C:\Users\Administrator\Desktop\1.jpg";
                var result = writtenWords.IdCardFront(@"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\1.jpg", new Baidu.AI.Common.Dto.Ocr.IdCrad.IdcardInput { DetectDirection = true,  DetectRisk = true, });
                var result1 = writtenWords.IdCardBack(@"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\2.jpg", new Baidu.AI.Common.Dto.Ocr.IdCrad.IdcardInput { DetectDirection = true,  DetectRisk = true, });
                var ss = result.Data.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
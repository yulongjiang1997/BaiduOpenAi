
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

                var result3 = writtenWords.VehicleLicense(@"C:\Users\Administrator\Desktop\vin\lALPDiCpsTJ8LnXNCSTNBDg_1080_2340.png");

                var result = writtenWords.GetVinCode(@"C:\Users\Administrator\Desktop\vin\47dac3de23ff80e2.jpg");
                Console.WriteLine("47dac3de23ff80e2----" + result.words_result[0].words);
                var result1 = writtenWords.GetVinCode(@"C:\Users\Administrator\Desktop\vin\9198e874f0bf777d.jpg");
                Console.WriteLine("9198e874f0bf777d----" + result1.words_result[0].words);
                var result2 = writtenWords.GetVinCode(@"C:\Users\Administrator\Desktop\vin\3072998c66a61a7.jpg");
                Console.WriteLine("3072998c66a61a7----" + result2.words_result[0].words);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
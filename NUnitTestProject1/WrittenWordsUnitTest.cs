 
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
                var zm = @"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\1.jpg";
                var fm = @"C:\Users\Administrator\Documents\Tencent Files\1209026461\FileRecv\MobileFile\2.jpg";
                var cp = @"C:\Users\Administrator\Desktop\1.jpg";
                var result = writtenWords.LocalImageAccurateAnalysis(cp);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
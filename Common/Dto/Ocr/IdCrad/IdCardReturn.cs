using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.IdCrad
{

    public class 住址
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 南京市江宁区弘景大道3889号
        /// </summary>
        public string words { get; set; }
    }

    public class Location
    {
        /// <summary>
        /// 
        /// </summary>
        public int left { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int top { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
    }

    public class 公民身份号码
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string words { get; set; }
    }


    public class 出生
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string words { get; set; }
    }


    public class 姓名
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 伍云龙
        /// </summary>
        public string words { get; set; }
    }



    public class 性别
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 男
        /// </summary>
        public string words { get; set; }
    }


    public class 民族
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 汉
        /// </summary>
        public string words { get; set; }
    }

    public class 签发日期
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 汉
        /// </summary>
        public string words { get; set; }
    }

    public class 签发机关
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 汉
        /// </summary>
        public string words { get; set; }
    }

    public class 失效日期
    {
        /// <summary>
        /// 
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 汉
        /// </summary>
        public string words { get; set; }
    }

    public class FrontResult
    {
        /// <summary>
        /// 
        /// </summary>
        public 住址 住址 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public 公民身份号码 公民身份号码 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public 出生 出生 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public 姓名 姓名 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public 性别 性别 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public 民族 民族 { get; set; }
    }

    public class BackResult
    {

        public 签发日期 签发日期 { get; set; }

        public 签发机关 签发机关 { get; set; }

        public 失效日期 失效日期 { get; set; }
    }

    public class IdCardReturn
    {
        /// <summary>
        /// 
        /// </summary>
        public long log_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int direction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string idcard_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string edit_tool { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int words_result_num { get; set; }
    }

    public class IdCardFrontReturn : IdCardReturn
    {
        /// <summary>
        /// 
        /// </summary>
        public FrontResult words_result { get; set; }
    }

    public class IdCardBackReturn : IdCardReturn
    {
        /// <summary>
        /// 
        /// </summary>
        public BackResult words_result { get; set; }
    }

}

using Baidu.AI.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.IdCrad
{
    public class IdcardInput
    {
        /// <summary>
        /// 是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:
        /// - true：检测朝向；- false：不检测朝向。
        /// </summary>
        [Description("detect_direction")]
        public bool? DetectDirection { get; set; }

        /// <summary>
        /// 是否开启身份证风险类型(身份证复印件、临时身份证、身份证翻拍、修改过的身份证)功能，默认不开启，即：false。可选值:true-开启；false-不开启
        /// </summary>
        [Description("detect_risk")]
        public bool? DetectRisk { get; set; }
    }
}

using Baidu.AI.Common.Attributes;
using Baidu.AI.Common.Enum.Orc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr
{
    public class ImageAnalysisInput
    {
        /// <summary>
        /// 识别语言类型
        /// </summary>
        [Description("language_type")]
        public LanguageType? LanguageType { get; set; }

        /// <summary>
        /// 是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:
        /// - true：检测朝向；- false：不检测朝向。
        /// </summary>
        [Description("detect_direction")]
        public bool? DetectDirection { get; set; }

        /// <summary>
        /// 是否检测语言，默认不检测。当前支持（中文、英语、日语、韩语）
        /// </summary>
        [Description("detect_language")]
        public bool? DetectLanguage { get; set; }

        /// <summary>
        /// 是否返回识别结果中每一行的置信度
        /// </summary>
        [Description("probability")]
        public bool? Probability { get; set; }
    }
}

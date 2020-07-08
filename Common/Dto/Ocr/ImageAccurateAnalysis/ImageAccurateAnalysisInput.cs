using Baidu.AI.Common.Attributes;
using Baidu.AI.Common.Enum.Orc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.ImageAccurateAnalysis
{
    public class ImageAccurateAnalysisInput
    { 

        /// <summary>
        /// 是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:
        /// - true：检测朝向；- false：不检测朝向。
        /// </summary>
        [Description("detect_direction")]
        public bool? DetectDirection { get; set; } 

        /// <summary>
        /// 是否返回识别结果中每一行的置信度
        /// </summary>
        [Description("probability")]
        public bool? Probability { get; set; }
    }
}

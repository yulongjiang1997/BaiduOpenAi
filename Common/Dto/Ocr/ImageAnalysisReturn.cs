using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr
{
    public class ImageAnalysisReturn
    {
        /// <summary>
        /// 唯一的log id，用于问题定位
        /// </summary>
        public string log_id { get; set; }

        /// <summary>
        /// 图像方向，当detect_direction=true时存在。
        ///- -1:未定义，
        ///- 0:正向，
        ///- 1: 逆时针90度，
        ///- 2:逆时针180度，
        ///- 3:逆时针270度
        /// </summary>
        public int direction { get; set; }

        /// <summary>
        /// 识别结果数，表示words_result的元素个数
        /// </summary>
        public int words_result_num { get; set; }

        /// <summary>
        /// 定位和识别结果数组
        /// </summary>
        public List<WordsResult> words_result { get; set; }
    }

    public class WordsResult
    {
        /// <summary>
        /// 识别结果字符串
        /// </summary>
        public string words { get; set; }

        /// <summary>
        /// 行置信度信息；如果输入参数 probability = true 则输出
        /// </summary>
        public Probability probability { get; set; }
    }

    public class Probability
    {
        /// <summary>
        /// 行置信度方差
        /// </summary>
        public decimal variance { get; set; }

        /// <summary>
        /// 行置信度平均值
        /// </summary>
        public decimal average { get; set; }

        /// <summary>
        /// 行置信度最小值
        /// </summary>
        public decimal min { get; set; }
    }
}

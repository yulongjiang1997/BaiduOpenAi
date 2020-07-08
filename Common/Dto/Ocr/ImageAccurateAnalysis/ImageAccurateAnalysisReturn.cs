using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.ImageAccurateAnalysis
{
    public class Probability
    {
        /// <summary>
        /// 
        /// </summary>
        public double variance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double average { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double min { get; set; }
    }

    public class Words_resultItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string words { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Probability probability { get; set; }
    }

    public class ImageAccurateAnalysisReturn
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
        public int words_result_num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Words_resultItem> words_result { get; set; }
    }
}

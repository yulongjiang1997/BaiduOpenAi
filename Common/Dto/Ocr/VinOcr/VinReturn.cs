using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.VinOcr
{
    public class VinReturn
    {
        public long log_id { get; set; }
        public List<result> words_result { get; set; }
        public int words_result_num { get; set; }
    }

    public class result
    {

        public location location { get; set; }

        public string words { get; set; }

    }

    public class location
    {
        public int width { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public int height { get; set; }
    } 
}

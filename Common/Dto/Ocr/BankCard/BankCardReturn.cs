using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Dto.Ocr.BankCard
{
    public class Result
    {
        /// <summary>
        /// 银行卡卡号
        /// </summary>
        public string bank_card_number { get; set; }
        /// <summary>
        /// 银行名，不能识别时为空
        /// </summary>
        public string bank_name { get; set; }
        /// <summary>
        /// 银行卡类型，0:不能识别; 1: 借记卡; 2: 信用卡
        /// </summary>
        public int bank_card_type { get; set; }
    }

    public class BankCardReturn
    {
        /// <summary>
        /// 请求标识码，随机数，唯一。
        /// </summary>
        public long log_id { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public Result result { get; set; }
    }

}

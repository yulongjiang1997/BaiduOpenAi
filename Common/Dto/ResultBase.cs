using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduOcr.Common.Dto
{
    public class ResultBase<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public ResultBase()
        {
            IsSuccess = true;
        }
    }
}

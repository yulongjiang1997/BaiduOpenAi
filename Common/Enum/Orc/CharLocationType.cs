using Baidu.AI.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Enum.Orc
{
    public enum CharLocationType
    {
        [Description("不定位单字符位置")]
        big,
        [Description("定位单字符位置")]
        small
    }
}

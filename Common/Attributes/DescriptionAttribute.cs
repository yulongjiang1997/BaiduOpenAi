using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Attributes
{ 
    public class DescriptionAttribute : Attribute
    {
        private string Desc { get; set; }

        public DescriptionAttribute(string desc)
        {
            Desc = desc;
        }

        public string GetDesc()
        {
            return Desc;
        }
    }
}

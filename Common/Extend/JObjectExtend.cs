﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baidu.AI.Common.Extend
{
    public static class JObjectExtend
    {
        public static T ToModel<T>(this JObject input)
        {
            return JsonConvert.DeserializeObject<T>(input.ToString());
        }

        public static T ToModel<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}

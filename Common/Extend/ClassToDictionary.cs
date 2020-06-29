using Baidu.AI.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Baidu.AI.Common.Extend
{
    public static class ClassToDictionary<T>
    {
        private static PropertyInfo[] PropertyInfos = null;
        private static Type ThisClassType = null;
        private static Dictionary<PropertyInfo, DescriptionAttribute> TypeIsDescription = new Dictionary<PropertyInfo, DescriptionAttribute>();

        public static Dictionary<string, object> GetDictionary(T @class)
        {
            var result = new Dictionary<string, object>();
            if (ThisClassType == null) ThisClassType = @class.GetType();
            if (PropertyInfos == null) PropertyInfos = ThisClassType.GetProperties();
            if (TypeIsDescription.Count == 0)
            {
                foreach (var item in PropertyInfos)
                {
                    var isExist = item.GetCustomAttributes(true).FirstOrDefault(t => (t as DescriptionAttribute) != null);
                    TypeIsDescription.Add(item, (DescriptionAttribute)isExist);
                }
            }
            foreach (var item in PropertyInfos)
            {
                var value = item.GetValue(@class);
                if (value == null) continue;
                var keyValue = TypeIsDescription.FirstOrDefault(i => i.Key == item);
                var fieldDesc = keyValue.Value == null ? item.Name : (keyValue.Value).GetDesc();
                if (value is bool) result.Add(fieldDesc, value.ToString().ToLower());
                else result.Add(fieldDesc, value.ToString());
            }
            return result;
        }

    }

}

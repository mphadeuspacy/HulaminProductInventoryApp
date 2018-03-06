using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace Gijima.Hulamin.Core.Extensions
{
    public static class SerializerExtensions
    {
        public static string SerializeToJsonObject(this object objectToJsonSerialize)
        {
            return JsonConvert.SerializeObject(objectToJsonSerialize);
        }

        public static T DeserializeObject<T>(this string jsonToObjectDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(jsonToObjectDeserialize);
        }

        // This method is borrowed off Phoenix SearchControllerHelper
        public static Dictionary<string, string> SerializeObjectToDictionary(this object objectToDictionarySerialize)
        {
            var queryString = new Dictionary<string, string>();

            foreach (PropertyInfo propertyInfo in objectToDictionarySerialize.GetType().GetProperties())
            {
                var val = propertyInfo.GetValue(objectToDictionarySerialize);

                if (val != null) queryString.Add(propertyInfo.Name, val.ToString());
            }

            return queryString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Comum.Helpers
{
    public class JsonHelper
    {
        public static T Deserialize<T>(string jsonData)
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);

            return result;
        }

        public static string Serialize<T>(T instance)
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(instance);

            return result;
        }
    }
}

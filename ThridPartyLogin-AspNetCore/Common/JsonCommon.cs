using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ThridPartyLogin_AspNetCore.Common
{
    public static class JsonCommon
    {
        public static JObject Deserialize(string objStr)
        {
            return JsonConvert.DeserializeObject<JObject>(objStr);
        }
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
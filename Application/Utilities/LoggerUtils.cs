using Newtonsoft.Json;

namespace Application.Utilities
{
    public class LoggerUtils
    {
        public static string DeserializeObjectToString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
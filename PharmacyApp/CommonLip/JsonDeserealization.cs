using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.CommonLip
{
    public static class JsonDeserealization
    {
        public static TOutput GetJsonResult<TOutput>(string path) where TOutput : class, new()
        {
            string strResult = GetStringResult(path);
            TOutput result = new TOutput();
            result = JsonConvert.DeserializeObject<TOutput>(strResult);
            return result;
        }

        private static string GetStringResult(string content)
        {
            using (StreamReader reader = new StreamReader(content))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }
    }
}

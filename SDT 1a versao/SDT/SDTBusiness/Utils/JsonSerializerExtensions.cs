using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace SDTBusiness.Registers
{
    public static class JsonSerializerExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            MemoryStream stream;

            using (stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);
            }

            return Encoding.Default.GetString(stream.ToArray());
        }

        public static T FromJson<T>(this string json)
        {
            T obj;

            using (MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

                obj = (T)serializer.ReadObject(stream);

            }

            return obj;

        }
    }
}

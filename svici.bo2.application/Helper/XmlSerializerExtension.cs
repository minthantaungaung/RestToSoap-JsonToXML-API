using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace svici.bo2.application.Helper
{
    public static class XmlSerializerExtension
    {
        public static T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T response = default;
            using (StringReader reader = new StringReader(xml))
            {
                response = (T)serializer.Deserialize(reader);
                return response;
            }
        }

        public static string SerializeToXml<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlDocument xmlDoc = new XmlDocument();

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                xmlDoc.Load(stream);
            }
            return xmlDoc.OuterXml;
        }
    }
}

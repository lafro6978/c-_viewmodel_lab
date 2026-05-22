using System.IO;
using System.Xml.Serialization;
using mmmmmmmm.Data;

namespace mmmmmmmm.Parsers
{
    public class CoolingParser : ParserBase
    {
        public CoolingParser(string path) : base(path) { }

        public override InputData? Parse() // Добавлен ?
        {
            using (var reader = new StreamReader(_fileStream))
            {
                string? name = reader.ReadLine()?.Trim(); // Добавлен ?
                string xmlContent = reader.ReadToEnd();

                var serializer = new XmlSerializer(typeof(CoolingInput), new XmlRootAttribute("CoolingData"));

                using (var stringReader = new StringReader(xmlContent))
                {
                    var result = (CoolingInput?)serializer.Deserialize(stringReader); // Добавлен ?
                    if (result != null)
                    {
                        result.Name = string.IsNullOrEmpty(name) ? "Cooling Process" : name;
                    }
                    return result;
                }
            }
        }
    }
}
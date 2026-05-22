using System.IO;
using System.Text.Json;
using mmmmmmmm.Data;

namespace mmmmmmmm.Parsers
{
    public class RcParser : ParserBase
    {
        public RcParser(string path) : base(path) { }

        public override InputData? Parse() // Добавлен ?
        {
            using (var reader = new StreamReader(_fileStream))
            {
                string? name = reader.ReadLine()?.Trim(); // Добавлен ?
                string jsonContent = reader.ReadToEnd();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<RCInput>(jsonContent, options);

                if (result != null)
                {
                    result.Name = string.IsNullOrEmpty(name) ? "RC Circuit" : name;
                }
                return result;
            }
        }
    }
}
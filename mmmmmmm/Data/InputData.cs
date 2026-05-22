using System.Text.Json.Serialization;
using System.Xml.Serialization;
using mmmmmmmm.Solvers;

namespace mmmmmmmm.Data
{
    public abstract class InputData
    {
        public string? Name { get; set; } // Добавлен ?

        [JsonPropertyName("TimeMax")]
        [XmlElement("TimeMax")]
        public double MaxTime { get; set; }

        [JsonPropertyName("TimeStep")]
        [XmlElement("TimeStep")]
        public double DeltaT { get; set; }

        public abstract IEquationSolver GetSolver();
    }
}
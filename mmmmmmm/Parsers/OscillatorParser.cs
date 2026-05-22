using System.IO;
using mmmmmmmm.Data;

namespace mmmmmmmm.Parsers
{
    public class OscillatorParser : ParserBase
    {
        public OscillatorParser(string path) : base(path) { }

        public override InputData? Parse() // Добавлен ?
        {
            InputData? result = null; // Добавлен ?
            using (var reader = new StreamReader(_fileStream))
            {
                var oscillatorResult = new OscillatorInput { Name = reader.ReadLine()?.Trim() };
                string? line; // Добавлен ?
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && double.TryParse(parts[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                    {
                        switch (parts[0].Trim())
                        {
                            case "Mass": oscillatorResult.Mass = value; break;
                            case "Stiffness": oscillatorResult.Stiffness = value; break;
                            case "Damping": oscillatorResult.Damping = value; break;
                            case "X0": oscillatorResult.X0 = value; break;
                            case "V0": oscillatorResult.V0 = value; break;
                            case "TimeMax": oscillatorResult.MaxTime = value; break;
                            case "TimeStep": oscillatorResult.DeltaT = value; break;
                        }
                    }
                }
                result = oscillatorResult;
            }
            return result;
        }
    }
}
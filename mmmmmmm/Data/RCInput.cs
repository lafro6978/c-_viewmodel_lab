using mmmmmmmm.Solvers;
using mmmmmmmm.Solvers.Implementation;

namespace mmmmmmmm.Data
{
    public class RCInput : InputData
    {
        public double Resistance { get; set; }
        public double Capacitance { get; set; }
        public double VoltageSource { get; set; }
        public double U0 { get; set; }

        public override IEquationSolver GetSolver()
        {
            return new RcSolver();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nMaxTime: {MaxTime}\nDeltaT: {DeltaT}\nResistance: {Resistance}\nCapacitance: {Capacitance}\nVoltageSource: {VoltageSource}\nU0: {U0}\n";
        }
    }
}
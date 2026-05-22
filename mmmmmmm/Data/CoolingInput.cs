using mmmmmmmm.Solvers;
using mmmmmmmm.Solvers.Implementation;

namespace mmmmmmmm.Data
{
    public class CoolingInput : InputData
    {
        public double T0 { get; set; }
        public double Tenv { get; set; }
        public double Coeff { get; set; }

        public override IEquationSolver GetSolver()
        {
            return new CoolingSolver();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nMaxTime: {MaxTime}\nDeltaT: {DeltaT}\nT0: {T0}\nTenv: {Tenv}\nCoeff: {Coeff}\n";
        }
    }
}
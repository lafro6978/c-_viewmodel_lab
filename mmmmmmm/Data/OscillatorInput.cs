using mmmmmmmm.Solvers;
using mmmmmmmm.Solvers.Implementation;

namespace mmmmmmmm.Data
{
    public class OscillatorInput : InputData
    {
        public double Mass { get; set; }
        public double Stiffness { get; set; }
        public double Damping { get; set; }
        public double X0 { get; set; }
        public double V0 { get; set; }

        public override IEquationSolver GetSolver()
        {
            return new OscillatorSolver();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nMaxTime: {MaxTime}\nDeltaT: {DeltaT}\nMass: {Mass}\nStiffness: {Stiffness}\nDamping: {Damping}\nX0: {X0}\nV0: {V0}\n";
        }
    }
}
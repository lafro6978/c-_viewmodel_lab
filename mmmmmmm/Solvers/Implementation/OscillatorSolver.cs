using System;
using mmmmmmmm.Data;

namespace mmmmmmmm.Solvers.Implementation
{
    public class OscillatorSolver : IEquationSolver
    {
        public SolverResult Solve(InputData input)
        {
            if (!(input is OscillatorInput data))
                throw new ArgumentException("Ожидаются данные типа OscillatorInput");

            var result = SolverMethods.OscillatorSolve(
                data.Mass, data.Stiffness, data.Damping,
                data.X0, data.V0, data.MaxTime, data.DeltaT);

            return new SolverResult { XValues = result[0], YValues = result[1] };
        }
    }
}
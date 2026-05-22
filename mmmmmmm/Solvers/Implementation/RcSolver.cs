using System;
using mmmmmmmm.Data;

namespace mmmmmmmm.Solvers.Implementation
{
    public class RcSolver : IEquationSolver
    {
        public SolverResult Solve(InputData input)
        {
            if (!(input is RCInput data))
                throw new ArgumentException("Ожидаются данные типа RCInput");

            var result = SolverMethods.RcSolve(
                data.Resistance, data.Capacitance,
                data.VoltageSource, data.U0, data.MaxTime, data.DeltaT);

            return new SolverResult { XValues = result[0], YValues = result[1] };
        }
    }
}
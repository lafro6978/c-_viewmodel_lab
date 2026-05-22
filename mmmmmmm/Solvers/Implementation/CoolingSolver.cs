using System;
using mmmmmmmm.Data;

namespace mmmmmmmm.Solvers.Implementation
{
    public class CoolingSolver : IEquationSolver
    {
        public SolverResult Solve(InputData input)
        {
            if (!(input is CoolingInput data))
                throw new ArgumentException("Ожидаются данные типа CoolingInput");

            var result = SolverMethods.CoolingSolve(
                data.Coeff, data.Tenv, data.T0, data.MaxTime, data.DeltaT);

            return new SolverResult { XValues = result[0], YValues = result[1] };
        }
    }
}
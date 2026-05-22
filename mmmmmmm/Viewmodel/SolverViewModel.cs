using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;
using mmmmmmmm.Data;
using mmmmmmmm.Common;
using mmmmmmmm.Solvers;

namespace mmmmmmmm.ViewModel
{
    public class SolverViewModel : ViewModelBase
    {
        private readonly UndoRedoManager _undoRedoManager;
        private readonly InputViewModel _inputViewModel;

        private PlotModel? _plotModel; // Добавлен ?
        private SolverResult? _solverResult; // Добавлен ?
        private bool _isUpdating = false;

        public SolverViewModel(UndoRedoManager undoRedoManager, InputViewModel inputViewModel)
        {
            _undoRedoManager = undoRedoManager;
            _inputViewModel = inputViewModel;
        }

        public PlotModel? PlotModel // Добавлен ?
        {
            get => _plotModel;
            set
            {
                if (_plotModel == value) return;
                var oldVal = _plotModel;
                _plotModel = value;
                OnPropertyChanged();

                if (!_isUpdating)
                {
                    _undoRedoManager.AddUndoRedo(
                        () => { _isUpdating = true; PlotModel = oldVal; _isUpdating = false; },
                        () => { _isUpdating = true; PlotModel = value; _isUpdating = false; }
                    );
                }
            }
        }

        public SolverResult? SolverResult // Добавлен ?
        {
            get => _solverResult;
            set
            {
                if (_solverResult == value) return;
                var oldVal = _solverResult;
                _solverResult = value;
                OnPropertyChanged();

                if (!_isUpdating)
                {
                    _undoRedoManager.AddUndoRedo(
                        () => { _isUpdating = true; SolverResult = oldVal; _isUpdating = false; },
                        () => { _isUpdating = true; SolverResult = value; _isUpdating = false; }
                    );
                }
            }
        }

        public void Solve()
        {
            var data = _inputViewModel.CurrentImportedData;
            if (data == null) return;

            var solver = data.GetSolver();
            SolverResult = solver.Solve(data);

            var points = new List<DataPoint>();
            if (SolverResult != null && SolverResult.XValues != null && SolverResult.YValues != null)
            {
                for (int i = 0; i < SolverResult.XValues.Length; i++)
                    points.Add(new DataPoint(SolverResult.XValues[i], SolverResult.YValues[i]));
            }

            var series = new LineSeries { Title = data.Name };
            series.Points.AddRange(points);

            var newPlotModel = new PlotModel();
            newPlotModel.Series.Add(series);

            PlotModel = newPlotModel;
        }
    }
}
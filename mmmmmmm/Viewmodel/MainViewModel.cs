using mmmmmmmm.Common;

namespace mmmmmmmm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly UndoRedoManager _undoRedoManager;

        public InputViewModel InputViewModel { get; }
        public SolverViewModel SolverViewModel { get; }

        public MainViewModel()
        {
            _undoRedoManager = new UndoRedoManager();
            InputViewModel = new InputViewModel(_undoRedoManager);
            SolverViewModel = new SolverViewModel(_undoRedoManager, InputViewModel);
        }

        public void Undo()
        {
            _undoRedoManager.Undo();
        }

        public void Redo()
        {
            _undoRedoManager.Redo();
        }
    }
}
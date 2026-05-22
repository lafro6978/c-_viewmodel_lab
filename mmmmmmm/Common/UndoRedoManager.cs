using System;
using System.Collections.Generic;

namespace mmmmmmmm.Common
{
    public class UndoRedoManager
    {
        private Stack<UndoRedoCommand> _undoStack = new Stack<UndoRedoCommand>();
        private Stack<UndoRedoCommand> _redoStack = new Stack<UndoRedoCommand>();

        public void AddUndoRedo(Action undoAction, Action redoAction)
        {
            var command = new UndoRedoCommand(undoAction, redoAction);
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.UndoAction?.Invoke();
                _redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var command = _redoStack.Pop();
                command.RedoAction?.Invoke();
                _undoStack.Push(command);
            }
        }
    }
}
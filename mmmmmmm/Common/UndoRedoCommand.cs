using System;

namespace mmmmmmmm.Common
{
    public class UndoRedoCommand
    {
        public Action UndoAction { get; }
        public Action RedoAction { get; }

        public UndoRedoCommand(Action undoAction, Action redoAction)
        {
            UndoAction = undoAction;
            RedoAction = redoAction;
        }
    }
}
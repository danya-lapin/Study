using System.Collections.Generic;

namespace GraphicEditor
{
    public class UndoRedoStack
    {
        private readonly LinkedList<ICommand> _undoRedoStack;
        private LinkedListNode<ICommand> _currentCommand;
        
        public UndoRedoStack()
        {
            _undoRedoStack = new LinkedList<ICommand>();
            _currentCommand = null;
        }

        public ICommand Add(ICommand command)
        {
            _currentCommand = _undoRedoStack.AddLast(command);
            return _currentCommand.Value;
        }

        public ICommand Peek() => _undoRedoStack.Last.Value;

        public void Clear() => _undoRedoStack.Clear();

        public void ExecuteAll()
        {
            foreach (var command in _undoRedoStack)
            {
                if (command.Equals(_currentCommand.Value))
                {
                    command.Execute();
                    break;
                }
                
                command.Execute();
            }
        }

        public void Undo()
        {
            if (_currentCommand == null)
            {
                return;
            }

            _currentCommand = _currentCommand.Previous;
        }

        public void Redo()
        {
            if (_currentCommand == null)
            {
                return;
            }

            _currentCommand = _currentCommand.Next;
        }

        public LinkedListNode<ICommand> GetCurrentCommand() => _currentCommand;
    }
}
using System;
using GraphicEditor;
using Xunit;

namespace UndoRedoStackTest
{
    public class UndoRedoStackTest
    {
        [Fact]
        public void AddTest()
        {
            var undoRedoStack = new UndoRedoStack();
            undoRedoStack.Add(new TestCommand());
            Assert.NotNull(undoRedoStack.Peek());
        }

        [Fact]
        public void PeekTest()
        {
            var undoRedoStack = new UndoRedoStack();
            Assert.Equal(undoRedoStack.Add(new TestCommand()), undoRedoStack.Peek());
        }

        [Fact]
        public void ExecuteAllTest()
        {
            var undoRedoStack = new UndoRedoStack();
            undoRedoStack.Add(new TestCommand());
            undoRedoStack.Add(new TestCommand());
            undoRedoStack.Add(new TestCommand());
            Assert.Throws<NotImplementedException>(() => undoRedoStack.ExecuteAll());
        }

        [Fact]
        public void GetCurrentCommandTest()
        {
            var undoRedoStack = new UndoRedoStack();
            undoRedoStack.Add(new TestCommand());
            Assert.Equal(undoRedoStack.Add(new TestCommand()), undoRedoStack.GetCurrentCommand().Value);
        }

        [Fact]
        public void UndoTest()
        {
            var undoRedoStack = new UndoRedoStack();
            undoRedoStack.Add(new TestCommand());
            var currentCommand = undoRedoStack.GetCurrentCommand();
            undoRedoStack.Undo();
            Assert.NotEqual(undoRedoStack.GetCurrentCommand(), currentCommand);
        }
    }
}
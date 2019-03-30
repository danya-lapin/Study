using Stack1;
using Xunit;

namespace StackTest
{
    public class UnitTest1
    {
        [Fact]
        public void PushTest()
        {
            var head = new Stack<int>(9);
            head.Push(10);
            Assert.Equal(10, head.Pick());
        }

        [Fact]
        public void PopTest_DeleteHead()
        {
            var head = new Stack<int>(9);
            head.Pop();
            Assert.Null(head);
        }

        [Fact]
        public void PopTest()
        {
            var head = new Stack<int>(9);
            head.Push(10);
            head.Push(11);
            head.Pop();
            Assert.Equal(10, head.Pick());
        }

        [Fact]
        public void FindTest_NonExistent()
        {
            var head = new Stack<string>("cat");
            head.Push("dog");
            head.Push("mouse");
            Assert.False(head.Find("fish"));
        }

        [Fact]
        public void FindTest()
        {
            var head = new Stack<string>("table");

            head.Push("chair");
            head.Push("pencil");
            Assert.True(head.Find("chair"));
        }
    }
}
using System;

namespace Stack1
{
    public class Stack<T> where T : IComparable
    {
        private static Node _head;


        public Stack(T value)
        {
            _head = new Node(value);
        }

        public void Push(T value)
        {
            if (_head == null)
            {
                _head = new Node(value);
            }
            else
            {
                var node = new Node(value);
                node.Next = _head;
                _head = node;
            }
        }

        public T Pop()
        {
            if (_head == null)
            {
                throw new Exception("pop from empty stack");
            }

            var value = _head.Value;
            _head = _head.Next;
            return value;
        }

        public T Pick()
        {
            return _head.Value;
        }

        public bool Find(T value)
        {
            return Find_Value(_head, value);
        }

        private bool Find_Value(Node _head, T value)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else
            {
                return Find_Value(_head.Next, value);
            }
        }

        private class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = _head;
            }
            

            public Node(Node next, T value)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
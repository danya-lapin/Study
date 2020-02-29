using System;
using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
    public class AvlTree: ICollection
    {
        
        private Node Root { get; set; }

        public int Count { get; private set; }

        public bool IsSynchronized { get; }

        public object SyncRoot { get; }

        private bool IsReadOnly { get; }

        public AvlTree(bool isReadOnly)
        {
            Root = null;
            Count = 0;
            IsReadOnly = isReadOnly;
            IsSynchronized = true;
            SyncRoot = new object();
        }

        public class Node
        {
            public Node RightChild { get; set; }
            public Node LeftChild { get; set; }

            public int Value { get; }
            public int Depth { get; set; }

            public Node(int value, int depth = 1)
            {
                RightChild = null;
                LeftChild = null;
                Value = value;
                Depth = depth;
            }
        }

        private void RightFlip()
        {
            var tempLeftSub = Root.LeftChild;
            var tempRightChild = Root.LeftChild.RightChild.RightChild;
            var tempLeftChild = Root.LeftChild.RightChild.LeftChild;
            var tempRoot = Root;
            Root = Root.LeftChild.RightChild;
            Root.LeftChild = tempLeftSub;
            Root.RightChild = tempRoot;
            Add(tempLeftChild, tempLeftChild.Value, tempLeftChild.Depth);
            Add(tempRightChild, tempRightChild.Value, tempRightChild.Depth);
        }
        
        private void LeftFlip()
        {
            var tempRoot = Root;
            var tempRightSub = Root.RightChild;
            var tempLeftChild = Root.RightChild.LeftChild.LeftChild;
            var tempRightChild = Root.RightChild.LeftChild.RightChild;
            Root = Root.RightChild.LeftChild;
            Root.LeftChild = tempRoot;
            Root.RightChild = tempRightSub;
            Add(tempLeftChild, tempLeftChild.Value, tempLeftChild.Depth);
            Add(tempRightChild, tempRightChild.Value, tempRightChild.Depth);
        }

        private void Balance()
        {
            if (Root.RightChild.Depth - Root.LeftChild.Depth >= 2 &&
                Root.RightChild.LeftChild.Depth > Root.RightChild.RightChild.Depth)
            {
                LeftFlip();
            }

            if (Root.LeftChild.Depth - Root.RightChild.Depth >= 2 &&
                Root.LeftChild.RightChild.Depth > Root.LeftChild.LeftChild.Depth)
            {
                RightFlip();
            }
        }

        public void Add(int item)
        {
            Add(Root, item);
        }

        private void Add(Node root, int item, int depth = 1)
        {
            while (true)
            {
                if (IsReadOnly)
                {
                    throw new Exception("Collection is readonly");
                }

                if (root == null)
                {
                    // ReSharper disable once RedundantAssignment
                    root = new Node(item, depth);
                    return;
                }

                if (Contains(item))
                {
                    throw new ArgumentException("Specified value already exists");
                }

                if (item > root.Value)
                {
                    if (root.RightChild == null)
                    {
                        root.RightChild = new Node(item, depth);
                        Count++;
                        Balance();
                        return;
                    }

                    root = root.RightChild;
                    depth = ++depth;
                    continue;
                }

                if (item < root.Value)
                {
                    if (root.LeftChild == null)
                    {
                        root.LeftChild = new Node(item, depth);
                        Count++;
                        Balance();
                        return;
                    }

                    root = root.LeftChild;
                    depth = ++depth;
                    continue;
                }

                break;
            }
        }

        public void Add(Node item, Node root, int depth = 1)
        {
            while (true)
            {
                if (IsReadOnly)
                {
                    throw new Exception("Collection is readonly");
                }

                if (root == null)
                {
                    root = new Node(item.Value, depth);
                }

                if (Contains(item.Value))
                {
                    throw new ArgumentException("Specified value already exists");
                }

                if (item.Value > root.Value)
                {
                    if (root.RightChild == null)
                    {
                        root.RightChild = item;
                        root.RightChild.Depth = depth;
                        Count++;
                        Balance();
                        return;
                    }

                    root = root.RightChild;
                    continue;
                }

                if (item.Value < root.Value)
                {
                    if (root.LeftChild == null)
                    {
                        root.LeftChild = item;
                        root.LeftChild.Depth = depth;
                        Count++;
                        Balance();
                        return;
                    }

                    depth++;
                    root = root.LeftChild;
                    continue;
                }

                break;
            }
        }

        public bool Remove(int item)
        {
            return Remove(Root, item);
        }
        private bool Remove(Node root, int item)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value.Equals(item))
            {
                var tempLeftChild = root.LeftChild;
                root = root.RightChild;
                Add(tempLeftChild, root);
                Count--;
                root.Depth--;
            }

            if (item > root.Value)
            {
                return Remove(root.RightChild, item);
            }
            return true;
        }

        private List<Node> ConvertToList(Node root)
        {
            var treeArray = new List<Node>();
            while (true)
            {
                if (root.LeftChild != null)
                {
                    root = root.LeftChild;
                    continue;
                }

                if (root.RightChild != null)
                {
                    root = root.RightChild;
                    continue;
                }

                treeArray.Add(root);
                break;
            }

            return treeArray;
        }

        public IEnumerator GetEnumerator()
        {
            // ReSharper disable once RedundantAssignment
            var treeArray = new List<Node>();
            treeArray = ConvertToList(Root);
            return treeArray.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            Root = null;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public bool Contains(int item)
        {
            return Contains(item, Root);
        }

        private bool Contains(int item, Node root)
        {
            while (true)
            {
                if (root.Value.Equals(item))
                {
                    return true;
                }

                if (root.Value > item)
                {
                    root = root.LeftChild;
                    continue;
                }

                if (root.Value < item)
                {
                    root = root.RightChild;
                    continue;
                }

                return false;
            }
        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void CopyTo(Array array, int index, Node root, int i = 0)
        {
            while (true)
            {
                if (root == null)
                {
                    return;
                }

                if (root.LeftChild != null)
                {
                    root = root.LeftChild;
                    continue;
                }

                if (root.RightChild != null)
                {
                    root = root.RightChild;
                    continue;
                }

                // ReSharper disable once RedundantAssignment
                array.SetValue(root, i++ + index);
                break;
            }
        }

        public void CopyTo(Array array, int index)
        {
            CopyTo(array, index, Root);
        }
    }
}
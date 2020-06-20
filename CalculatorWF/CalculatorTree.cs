using System;
using System.Collections;
using System.Collections.Generic;

namespace CalculatorWF
{
    public class CalculatorTree
    {
        private Node _root;

        public CalculatorTree()
        {
            
        }

        public CalculatorTree(IOperation value)
        {
            _root = new Node(value);
        }

        public void Add(IOperation value)
        {
            Add(_root, value);
        }
        //TODO: Build a tree inside this class
        private Node Add(Node root, IOperation value)
        {
            if (root.Value == null)
            {
                root.Value = value;
                return root;
            }
            if (root.Left == null)
            {
                root.Left = new Node(value);
                return root.Left;
            }

            if (root.Right == null)
            {
                root.Right = new Node(value);
                return root.Right;
            }
            throw new ArgumentException("Input string is incorrect");
        }

        public double BypassCalculate()
        {
            return BypassCalculate(_root);
        }

        private double BypassCalculate(Node root)
        {
            if (root == null)
            {
                throw new ArgumentException("Input string is incorrect");
            }

            return root.Value.CalculateResult();
        }

        public void CreateTree(string input)
        {
            _root = new Node();
            HandleString(input, _root);
        }

        private void HandleString(string input, Node root)
        {
            input.Replace(" ", string.Empty);
            var flag = true;
            while (flag)
            {
                flag = TrimSafelyRemovableScopes(input);
                if (flag)
                {
                    input = input.Substring(1, input.Length - 2);
                }
            }
            
            if (IsOperand(input))
            {
                Add(root, new Operand(Convert.ToDouble(input)));
                return;
            }
            var operands = new string[2];
            if (input.Contains("+") && !OperationIsScoped(input, '+'))
            {
                operands = input.Split(new []{'+'}, 2);
                var addOperation = new AddOperation();
                var operationNode = Add(root, addOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);
                
                addOperation.LeftOperand = operationNode.Left.Value;
                addOperation.RightOperand = operationNode.Right.Value;
                return;
            }

            if (input.Contains("-") && !OperationIsScoped(input, '-'))
            {
                operands = input.Split(new []{'-'}, 2);
                var subtractOperation = new SubtractOperation();
                var operationNode = Add(root, subtractOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);
                
                subtractOperation.LeftOperand = operationNode.Left.Value;
                subtractOperation.RightOperand = operationNode.Right.Value;
                return;
            }
            
            if (input.Contains("*") && !OperationIsScoped(input, '*'))
            {
                operands = input.Split(new []{'*'}, 2);
                var multiplyOperation = new MultiplyOperation();
                var operationNode = Add(root, multiplyOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);

                multiplyOperation.LeftOperand = operationNode.Left.Value;
                multiplyOperation.RightOperand = operationNode.Right.Value;
                return;
            }

            if (input.Contains("/") && !OperationIsScoped(input, '/'))
            {
                operands = input.Split(new []{'/'}, 2);
                var divisionOperation = new DivisionOperation();
                var operationNode = Add(root, divisionOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);

                divisionOperation.LeftOperand = operationNode.Left.Value;
                divisionOperation.RightOperand = operationNode.Right.Value;
                return;
            }
            if (input.Contains("+") && OperationIsScoped(input, '+'))
            {
                operands = input.Split(new []{'+'}, 2);
                var addOperation = new AddOperation();
                var operationNode = Add(root, addOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);
                
                addOperation.LeftOperand = operationNode.Left.Value;
                addOperation.RightOperand = operationNode.Right.Value;
                return;
                
            }

            if (input.Contains("-") && OperationIsScoped(input, '-'))
            {
                operands = input.Split(new []{'-'}, 2);
                var subtractOperation = new SubtractOperation();
                var operationNode = Add(root, subtractOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);
                
                subtractOperation.LeftOperand = operationNode.Left.Value;
                subtractOperation.RightOperand = operationNode.Right.Value;
                return;
            }
            
            if (input.Contains("*") && OperationIsScoped(input, '*'))
            {
                operands = input.Split(new []{'*'}, 2);
                var multiplyOperation = new MultiplyOperation();
                var operationNode = Add(root, multiplyOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);

                multiplyOperation.LeftOperand = operationNode.Left.Value;
                multiplyOperation.RightOperand = operationNode.Right.Value;
                return;
            }

            if (input.Contains("/") && OperationIsScoped(input, '/'))
            {
                operands = input.Split(new []{'/'}, 2);
                var divisionOperation = new DivisionOperation();
                var operationNode = Add(root, divisionOperation);
                HandleString(operands[0], operationNode);
                HandleString(operands[1], operationNode);

                divisionOperation.LeftOperand = operationNode.Left.Value;
                divisionOperation.RightOperand = operationNode.Right.Value;
            }
        }

        private bool TrimSafelyRemovableScopes(string input)
        {
            if (input[0].Equals('(') && input[input.Length - 1].Equals(')'))
            {
                var temporaryString = input;
                temporaryString = temporaryString.Substring(1, temporaryString.Length - 2);
                try
                {
                    CheckForIncorrectScoping(temporaryString);
                }
                catch (ArgumentException)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        private void CheckForIncorrectScoping(string input)
        {
            var stack = new Stack<char>();
            try
            {
                foreach (var symbol in input)
                {
                    if (symbol.Equals('('))
                    {
                        stack.Push('(');
                    }

                    if (symbol.Equals(')'))
                    {
                        stack.Pop();
                    }
                }
            }
            
            catch(Exception)
            {
                throw new ArgumentException("Input string is incorrect");
            }
            
            if (stack.Count != 0)
            {
                throw new ArgumentException("Input string is incorrect");
            }
        }
        
        private char LastOperationInCurrentExpression(string input)
        {
            if (input.Contains("+"))
            {
                return '+';
            }

            if (input.Contains("-"))
            {
                return '-';
            }

            if (input.Contains("*"))
            {
                return '*';
            }

            if (input.Contains("/"))
            {
                return '*';
            }

            return '\0';
        }

        public bool IsOperand(string substring)
        {
            if (ContainsOperations(substring))
            {
                return false;
            }

            return true;
        }

        public bool ContainsOperations(string input)
        {
            if (input.Contains("+") || input.Contains("-") ||
                input.Contains("*") || input.Contains("/"))
            {
                return true;
            }

            return false;
        }

        private bool OperationIsScoped(string input, char operation)
        {
            var openingScopesAmount = 0;
            var closingScopesAmount = 0;
            var substrings = input.Split(new char[]{operation}, 2);
            foreach (var symbol in substrings[0])
            {
                if (symbol.Equals('('))
                {
                    openingScopesAmount++;
                }

                if (symbol.Equals(')'))
                {
                    closingScopesAmount++;
                }
            }

            if (!(openingScopesAmount - closingScopesAmount >= 1))
            {
                return false;
            }

            openingScopesAmount = 0;
            closingScopesAmount = 0;
            
            foreach (var symbol in substrings[1])
            {
                if (symbol.Equals('('))
                {
                    openingScopesAmount++;
                }

                if (symbol.Equals(')'))
                {
                    closingScopesAmount++;
                }
            }

            if (!(closingScopesAmount - openingScopesAmount >= 1))
            {
                return false;
            }

            return true;
        }

        private class Node
        {
            public IOperation Value { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node()
            {
                
            }

            public Node(IOperation value)
            {
                Value = value;
            }
        }
    }
}
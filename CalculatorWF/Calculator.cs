using System;
using System.Collections.Generic;

namespace CalculatorWF
{
    public class Calculator
    {
        private readonly string _inputString;

        private CalculatorTree _calculatorTree;

        public Calculator(string inputString)
        {
            _inputString = inputString;
            _calculatorTree = new CalculatorTree();
        }

        public double Calculate()
        {
            _calculatorTree.CreateTree(_inputString);
            return _calculatorTree.BypassCalculate();
        }

        // public double Calculate()
        // {
        //     HandleString(_inputString);
        //     return _calculatorTree.BypassCalculate();
        // }
        //
        // private void HandleString(string substring, IOperation firstOperand = null, IOperation secondOperand = null)
        // {
        //     var substringArray = new string[2];
        //     char operationCharacter = '\0';
        //     substring.Replace(" ", string.Empty);
        //     if (substring.Contains("+"))
        //     {
        //         substringArray = substring.Split(new char[]{'+'}, 2);
        //         operationCharacter = '+';
        //     }
        //     else if(substring.Contains("-"))
        //     {
        //         substringArray = substring.Split(new char[]{'-'}, 2);
        //         operationCharacter = '-';
        //     }
        //     else if(substring.Contains("*"))
        //     {
        //         substringArray = substring.Split(new char[]{'*'}, 2);
        //         operationCharacter = '*';
        //     }
        //     else if(substring.Contains("/"))
        //     {
        //         substringArray = substring.Split(new char[]{'/'}, 2);
        //         operationCharacter = '/';
        //     }
        //
        //     if (IsOperand(substringArray[0]))
        //     {
        //         firstOperand = new Operand(Convert.ToDouble(substringArray[0])) {IsDeclared = true};
        //     }
        //     else
        //     {
        //         switch (LastOperationInCurrentExpression(substringArray[0]))
        //         {
        //             case '+':
        //             {
        //                 firstOperand = new AddOperation();
        //                 break;
        //             }
        //             case '-':
        //             {
        //                 firstOperand = new SubtractOperation();
        //                 break;
        //             }
        //             case '*':
        //             {
        //                 firstOperand = new MultiplyOperation();
        //                 break;
        //             }
        //             case '/':
        //             {
        //                 firstOperand = new DivisionOperation();
        //                 break;
        //             }
        //         }
        //         HandleString(substringArray[0], firstOperand, secondOperand);
        //     }
        //
        //     if (IsOperand(substringArray[1]))
        //     {
        //         secondOperand = new Operand(Convert.ToDouble(substringArray[1])) {IsDeclared = true};
        //     }
        //     else
        //     {
        //         switch (LastOperationInCurrentExpression(substringArray[1]))
        //         {
        //             case '+':
        //             {
        //                 firstOperand = new AddOperation();
        //                 break;
        //             }
        //             case '-':
        //             {
        //                 firstOperand = new SubtractOperation();
        //                 break;
        //             }
        //             case '*':
        //             {
        //                 firstOperand = new MultiplyOperation();
        //                 break;
        //             }
        //             case '/':
        //             {
        //                 firstOperand = new DivisionOperation();
        //                 break;
        //             }
        //         }
        //         HandleString(substringArray[1], firstOperand, secondOperand);
        //     }
        //     
        //     switch (operationCharacter)
        //     {
        //         case '\0':
        //         {
        //             return;
        //         }
        //         case '+':
        //         {
        //             _calculatorTree.Add(new AddOperation());
        //             _calculatorTree.Add(firstOperand);
        //             _calculatorTree.Add(secondOperand);
        //             break;
        //         }
        //     }
        // }

        
    }
}
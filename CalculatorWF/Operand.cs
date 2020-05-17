namespace CalculatorWF
{
    public class Operand: IOperation
    {
        public double Value { get; set; }
        public bool IsDeclared { get; set; }
        public bool IsOperation { get; }
        public IOperation LeftOperand { get; set; }
        public IOperation RightOperand { get; set; }

        public double CalculateResult()
        {
            return Value;
        }

        public Operand()
        {
            IsOperation = false;
        }

        public Operand(double value)
        {
            Value = value;
            IsOperation = false;
        }
    }
}
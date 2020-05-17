namespace CalculatorWF
{
    public class SubtractOperation: IOperation
    {
        public IOperation LeftOperand { get; set; }
        public IOperation RightOperand { get; set; }
        public bool IsOperation { get; }

        public double CalculateResult()
        {
            return LeftOperand.CalculateResult() - RightOperand.CalculateResult();
        }

        public SubtractOperation()
        {
            IsOperation = true;
        }
    }
}
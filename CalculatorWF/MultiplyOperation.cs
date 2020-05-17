namespace CalculatorWF
{
    public class MultiplyOperation: IOperation
    {
        public IOperation LeftOperand { get; set; }
        public IOperation RightOperand { get; set; }
        public bool IsOperation { get; }


        public double CalculateResult()
        {
            return LeftOperand.CalculateResult() * RightOperand.CalculateResult();
        }

        public MultiplyOperation()
        {
            IsOperation = true;
        }
    }
}
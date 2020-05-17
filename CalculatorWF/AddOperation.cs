namespace CalculatorWF
{
    public class AddOperation: IOperation
    {
        public IOperation LeftOperand { get; set; }
        public IOperation RightOperand { get; set; }
        public bool IsOperation { get; }

        public double CalculateResult()
        {
            return LeftOperand.CalculateResult() + RightOperand.CalculateResult();
        }

        public AddOperation()
        {
            IsOperation = true;
        }
    }
}
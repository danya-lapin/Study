namespace CalculatorWF
{
    public class DivisionOperation: IOperation
    {
        public IOperation LeftOperand { get; set; }
        public IOperation RightOperand { get; set; }
        
        
        public double CalculateResult()
        {
            return LeftOperand.CalculateResult() / RightOperand.CalculateResult();
        }
    }
}
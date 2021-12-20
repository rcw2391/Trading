using TechnicalAnalysisCalculations.Calculators;

namespace TechnicalAnalysisCalculations
{
    public class Calculator : ICalculator
    {
        public Calculator()
        {
            Trends = new Trends();
        }
        
        public ITrends Trends { get; set; }
    }
}

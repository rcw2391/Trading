using TechnicalAnalysisCalculations.Calculators;

namespace TechnicalAnalysisCalculations
{
    public interface ICalculator
    {
        public ITrends Trends { get; }
    }
}

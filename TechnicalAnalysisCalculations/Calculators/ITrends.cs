using System.Runtime.CompilerServices;
using TechnicalAnalysisCalculations.Models;

namespace TechnicalAnalysisCalculations.Calculators
{

    public interface ITrends
    {
        public double AverageTrueRange(IEnumerable<IHistory> history, int period, int start = 0);
        public double EMA(IEnumerable<IHistory> history, int period, int start = 0, double smoothing = 2);
        public double SMA(IEnumerable<IHistory> history, int period, int start = 0, bool checkHistoryIntegrity = false);
        public double RSI(IEnumerable<IHistory> history, int period, int start = 0);
        public double WilliamsPercentRange(IEnumerable<IHistory> history, int period, int start = 0);
        public double TrueRange(IHistory current, IHistory previous);
    }
}

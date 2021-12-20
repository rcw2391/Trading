using TechnicalAnalysisCalculations.Models;

namespace TechnicalAnalysisCalculations
{
    public static class Helpers
    {
        /// <summary>
        /// Checks IHistory collection to ensure it can be used for analysis.
        /// Throws an exception if collection cannot be used.
        /// </summary>
        /// <param name="history">Collection of histories</param>
        /// <param name="periods">Number of periods being examined</param>
        /// <param name="start">Index to start</param>
        /// <param name="buffer">Required number of extra histories</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EmptyHistoryException"></exception>
        /// <exception cref="HistoryIntervalMismatchException"></exception>
        /// <exception cref="InsufficentHistoryException"></exception>"
        /// <exception cref="InvalidPeriodException"></exception>
        /// <exception cref="InvalidStartException"></exception>
        /// <exception cref="InconsistentStockIdException"></exception>"
        public static void CheckHistoryIntegrity(IEnumerable<IHistory> history, int periods = 0, int start = 0, int buffer = 0)
        {
            if (history == null) throw new ArgumentNullException(nameof(history));

            if (periods <= 0) throw new InvalidPeriodException(nameof(periods));

            List<IHistory> historyList = new(history);

            if (historyList.Count == 0) throw new EmptyHistoryException(nameof(history));

            Interval i = historyList[0].Interval;
            int id = historyList[0].StockId;

            foreach (IHistory h in historyList)
            {
                if (h.Interval != i)
                    throw new HistoryIntervalMismatchException(nameof(history));

                if (h.Volume <= 0 || h.Open <= 0 || h.Close <= 0 || h.High <= 0 || h.Low <= 0)
                    throw new InvalidHistoryException(nameof(history));

                if (h.StockId != id)
                    throw new InconsistentStockIdException(nameof(history));
            }

            if (periods > 0 && periods + buffer > historyList.Count)
                throw new InsufficentHistoryException(nameof(history));

            if (start > 0 && historyList.Count - periods - buffer < start - 1)
                throw new InvalidStartException(nameof(history));
        }
    }
}

using TechnicalAnalysisCalculations.Models;

namespace TechnicalAnalysisCalculations.Calculators
{
    public class Trends : ITrends
    {
        /// <summary>
        /// Calculates average true range across a given period
        /// </summary>
        /// <param name="history">Collection of history</param>
        /// <param name="period">Periods to average</param>
        /// <param name="start">Index to start</param>
        /// <returns></returns>
        public double AverageTrueRange(IEnumerable<IHistory> history, int period, int start = 0)
        {
            // Verify entered parameters are valid to perform calculation
            Helpers.CheckHistoryIntegrity(history, period, start, 1);
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));

            List<IHistory> calcList = new();

            for (int i = start; i <= period; i++)
            {
                calcList.Add(historyList[i]);
            }

            historyList = new();

            List<double> tr = new();

            for (int i = 0; i < period; i++)
            {
                double calc = TrueRange(calcList[i], calcList[i + 1]);

                tr.Add(calc);
            }

            return Math.Round(tr.Average(), 4);
        }

        /// <summary>
        /// Calculates True Range
        /// </summary>
        /// <param name="current">Current period</param>
        /// <param name="previous">Previous period</param>
        /// <returns></returns>
        public double TrueRange(IHistory current, IHistory previous)
        {
            List<double> ranges = new();

            double rangeDiff = Math.Abs(current.High - current.Low);
            double highCPDiff = Math.Abs(current.High - previous.Close);
            double lowCPDiff = Math.Abs(current.Low - previous.Close);

            ranges.Add(rangeDiff);
            ranges.Add(highCPDiff);
            ranges.Add(lowCPDiff);

            return Math.Round(ranges.Max(), 4);
        }

        /// <summary>
        /// Returns Exponential Moving Average with a given smoothing, default is 2.
        /// </summary>
        /// <param name="history">Collection of history</param>
        /// <param name="period">Periods to perform average</param>
        /// <param name="start">Index to start</param>
        /// <param name="smoothing">Default is 2</param>
        /// <returns></returns>
        public double EMA(IEnumerable<IHistory> history, int period, int start = 0, double smoothing = 2)
        {
            Helpers.CheckHistoryIntegrity(history, period, start, period);
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));

            return EMAInternal(historyList, smoothing, start, period, start);
        }

        /// <summary>
        /// Recursively calculates EMA
        /// </summary>
        protected double EMAInternal(IEnumerable<IHistory> history, double smoothing, int index, int period, int start)
        {
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));


            if (index == period + start)
            {
                return SMA(historyList, period, period);
            }
            else
            {
                double today = historyList[index].Close * (smoothing / (period + 1));

                double yesterday = EMAInternal(history, smoothing, index + 1, period, start) * (1 - (smoothing / (period + 1)));

                double total = today + yesterday;

                return Math.Round(total, 4);
            }
        }

        /// <summary>
        /// Calculates Simple Moving Average across a given period
        /// </summary>
        /// <param name="history">Collection of history</param>
        /// <param name="period">Periods to get average</param>
        /// <param name="start">Index to start</param>
        /// <param name="checkHistoryIntegrity">Flag to execute CheckHistoryIntegrity</param>
        /// <returns></returns>
        public double SMA(IEnumerable<IHistory> history, int period, int start = 0, bool checkHistoryIntegrity = false)
        {
            if (checkHistoryIntegrity) Helpers.CheckHistoryIntegrity(history, period, start);
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));

            double sum = 0;

            for (int i = start; i < period + start; i++)
            {
                sum += historyList[i].Close;
            }

            return Math.Round(sum / period, 4);
        }

        public double RSI(IEnumerable<IHistory> history, int period, int start = 0)
        {
            Helpers.CheckHistoryIntegrity(history, period, start, period); 
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));

            return Math.Round(100 - (100 / (1 + (AverageGain(history, period, start, start) / AverageLoss(history, period, start, start)))), 2);
        }

        private double AverageGain(IEnumerable<IHistory> history, int period, int start, int index)
        {
            List<IHistory> h = new(history);
            
            if (index == period + start)
            {
                double sum = 0;
                
                for (int i = index; i < period + index; i++)
                {
                    if (h[i].Close > h[i].Open)
                        sum += (h[i].Close - h[i].Open) / h[i].Open;
                }

                return sum / period;
            }
            else
            {
                double previous = AverageGain(history, period, start, index + 1);
                double current = Math.Max((h[index].Close - h[index].Open) / h[index].Open, 0);

                return (previous * (period - 1) + current) / period;
            }
        }

        private double AverageLoss(IEnumerable<IHistory> history, int period, int start, int index)
        {
            List<IHistory> h = new(history);

            if (index == period + start)
            {
                double sum = 0;

                for (int i = index; i < period + index; i++)
                {
                    if (h[i].Open > h[i].Close)
                        sum += (h[i].Open - h[i].Close) / h[i].Open;
                }

                return sum / period;
            }
            else
            {
                double previous = AverageLoss(history, period, start, index + 1);
                double current = Math.Max((h[index].Open - h[index].Close) / h[index].Open, 0);

                return (previous * (period - 1) + current) / period;
            }
        }

        /// <summary>
        /// Calculates Williams Percent Range over the given period across the given history.
        /// -20 to 0 is overbought, -80 to -100 is oversold
        /// </summary>
        /// <param name="history">List of histories</param>
        /// <param name="period"># of periods</param>
        /// <param name="start">Index to start</param>
        /// <returns></returns>
        public double WilliamsPercentRange(IEnumerable<IHistory> history, int period, int start = 0)
        {
            Helpers.CheckHistoryIntegrity(history, period, start);
            List<IHistory> historyList = new List<IHistory>(history);

            historyList = new(historyList.OrderByDescending(x => x.Date));

            List<IHistory> calcList = new();

            for (int i = start; i < start + period; i++)
            {
                calcList.Add(historyList[i]);
            }

            historyList = new();

            // Most recent closing price
            double close = calcList[0].Close;
            // Highest high in set
            double high = calcList.Max(x => x.High);
            // Lowest low in set
            double low = calcList.Min(x => x.Low);

            double wpr = (high - close) / (high - low);

            return Math.Round(wpr * -100, 2);
        }
    }
}

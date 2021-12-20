using System.Collections.Generic;
using TechnicalAnalysisCalculations.Calculators;
using TechnicalAnalysisCalculations.Models;
using Xunit;

namespace TA_UnitTests
{
    public class TrendsTests
    {
        public TrendsTests()
        {
            _trends = new Trends();
            _history = new(HistoryMock.GetHistory());
        }

        private ITrends _trends;

        private List<IHistory> _history;


        [Fact]
        public void SMA_Returns_Correct()
        {
            double sma = _trends.SMA(_history, 5);

            Assert.True(sma == 389.852);
        }

        [Fact]
        public void EMA_Returns_Correct()
        {
            double ema = _trends.EMA(_history, 5);

            Assert.True(ema == 389.285);
        }

        [Fact]
        public void AverageTrueRange_Returns_Correct()
        {
            double atr = _trends.AverageTrueRange(_history, 14);

            Assert.True(atr == 9.2264);
        }

        [Fact]
        public void TrueRange_Returns_Correct()
        {
            double tr = _trends.TrueRange(_history[0], _history[1]);

            Assert.True(tr == 7.4200);
        }

        [Fact]
        public void WilliamsPercentRange_Returns_Correct()
        {
            double wpr = _trends.WilliamsPercentRange(_history, 14);

            Assert.True(wpr == -73.04);
        }

        [Fact]
        public void RSI_Returns_Correct()
        {
            double rsi = _trends.RSI(_history, 14);

            Assert.True(rsi == 45.01);
        }
    }
}
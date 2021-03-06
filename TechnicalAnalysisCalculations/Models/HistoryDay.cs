namespace TechnicalAnalysisCalculations.Models
{
    public class HistoryDay : IHistory
    {
        public DateTime Date { get; set; }
        public int Volume { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public int StockId { get; set; }
        public Interval Interval => Interval.Days;

        public Stock Stock { get; set; }
    }
}

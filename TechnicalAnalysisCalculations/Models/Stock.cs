namespace TechnicalAnalysisCalculations.Models
{
    public class Stock
    {
        public string Ticker { get; set; }
        public ICollection<IHistory> Histories { get; set; }
    }
}

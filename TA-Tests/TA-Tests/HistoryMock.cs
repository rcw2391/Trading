using System;
using System.Collections.Generic;
using System.IO;
using TechnicalAnalysisCalculations.Models;

namespace TA_UnitTests
{
    public static class HistoryMock
    {
        public static IEnumerable<IHistory> GetHistory()
        {
            List<IHistory> h = new();

            using (var reader = new StreamReader("test-history.csv"))
            {

                while (!reader.EndOfStream)
                {
                    List<string> line = new();

                    var l = reader.ReadLine();
                    line = new(l.Split(','));

                    h.Add(new HistoryDay()
                    {
                        Date = DateTime.Parse(line[0]),
                        Close = double.Parse(line[1]),
                        Volume = int.Parse(line[2]),
                        Open = double.Parse(line[3]),
                        High = double.Parse(line[4]),
                        Low = double.Parse(line[5]),
                        StockId = 1
                    });
                }
            }

            return h;
        }
    }
}

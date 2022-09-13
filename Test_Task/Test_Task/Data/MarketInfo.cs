using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task.Data
{
    public class MarketInfo
    {
        public string ExchangeId { get; set; }
        public string BaseId { get; set; }
        public string QuoteId { get; set; }
        public string BaseSymbol { get; set; }
        public string QuoteSymbol { get; set; }
        public double VolumeUsd24Hr { get; set; }
        public double PriceUsd { get; set; }
    }
}

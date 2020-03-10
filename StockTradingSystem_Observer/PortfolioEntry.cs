using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    // klasse hvis eneste formål er at definere hvad hver plads i et portfolio består af (tillader os at have både stock og amount)
    class PortfolioEntry
    {
        public Stock stock;
        public int amount;
    }
}

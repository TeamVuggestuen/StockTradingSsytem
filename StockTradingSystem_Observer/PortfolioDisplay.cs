using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    //PortfolioDisplay=Observer
    class PortfolioDisplay : IObserver<Portfolio>
    {
        public void Update(Portfolio subject)    //Når et portfolio(subject) kalder update på PortfolioDisplay(observer)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Stock portfolio:");
            ReadOnlyCollection<PortfolioEntry> entries = subject.GetPortfolioEntries();
            foreach (PortfolioEntry entry in entries)
            {
                Console.WriteLine("Stock: {0} - amount: {1} - price: {2} - held value: {3}", entry.stock.Name_, entry.amount, entry.stock.Value_, entry.stock.Value_ * entry.amount);
            }
            Console.WriteLine("Total holdings: {0}", subject.GetTotalStockValue());
        }
    }
}

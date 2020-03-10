using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    public interface IObserver<T>
    {
        void Update(T subjectType);    //funktion til at en aktie kan underrette alle lyttene observers (uanset om det er Portfolio eller PortfolioDisplay; og derfor <T>)
    }
}

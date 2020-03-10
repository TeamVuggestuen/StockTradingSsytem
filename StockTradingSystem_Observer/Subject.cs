using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    public abstract class Subject<T>
    {
        //observer-liste
        protected readonly List<IObserver<T>> Observers = new List<IObserver<T>>();

        //attach-funktion
        public void attach(IObserver<T> Observer)
        {
            Observers.Add(Observer);
        }

        //detach-funktion
        public void detach(IObserver<T> Observer)
        {
            Observers.Remove(Observer);
        }
    }
}

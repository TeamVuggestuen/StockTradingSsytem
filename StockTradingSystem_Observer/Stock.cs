using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    class Stock : Subject<Stock>
    {
        //constructor
        public Stock(int value, string name)
        {
            value_ = value;
            name_ = name;
        }

        //Properties
        private int value_;

        public int Value_
        {
            get => value_;

            set
            {
                value_ = value; 
                Notify();      // Hvis en aktie ændre kaldes notify så alle observers (portfolio der lytter)
            }
        }

        private string name_;
        public string Name_
        {
            get => name_;
            private set => this.name_ = value;
        }

        //notify (stock er et Concrete subject der notify'er alle observer's )
        void Notify()
        {
            foreach (var Observer in Observers)
            {
                Observer.Update(this);
            }
        }

        // funktion til at opdatere/ændre aktien (så der er noget at notify om)
        public void UpdateValue()
        {
            Random rand = new Random();
            int newPercentage = rand.Next(95, 106);
            int newValue = (Value_ * newPercentage) / 100;
            Value_ = newValue;
        }

    }
}

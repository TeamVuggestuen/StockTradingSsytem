using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTradingSystem_Observer
{
    // Portofolio er en concrete observer og bruger derfor IObserver interface til at observere <stocks>
    // MEN portfolio er OGSÅ et concrete subject der notifyer et PortfolioDisplay og arver derfor også fra Subject (nu bare med <Portfolio> i stedet for <stocks>)
    class Portfolio : Subject<Portfolio>, IObserver<Stock>
    {
        
        //først skal vi bruge en liste så et portfolio kan lytte til mere end én aktie
        private readonly List<PortfolioEntry> portfolio = new List<PortfolioEntry>();    //Vi bruger liste med <PortfolioEntry> så vi kan have to ting på hver plads i listen

        
        // Attach
        // Da portfolio først er observer skal vi bruge en attach funktion så den kan "lytte til" en given aktie)
        // attach wrappes i en add-funktion med den specifikke aktie som parameter (+ antal)
        public void Add(Stock stock, int amount)
        {
            portfolio.Add(new PortfolioEntry() {stock = stock, amount = amount});   //den aktie vi vil lytte gemmes i listen sammen med antal af aktien
            stock.attach(this);     // herefter hæfter vi os på aktien
            NotifyPortfolioChanged();       // Når der er sket en opdatering af portfolio skal PortfolioDisplay informeres (Portfolio går fra at være observer til at være subject)
        }

        //Implementering af Update fra IObserver
        //Det er den funktion aktien kalder når den skal informere alle der lytter
        // det er også her at portfolio går fra oberver -> subject
        public void Update(Stock subject)
        {
            NotifyPortfolioChanged();  // Hvis aktien kalder en update på os(Portfolio=Observer) sender vi beskeden videre til PortfolioDisplay (Portfolio=subject)
        }

        //Notify (nu er portfolio=subject)
        //Implementering af hvordan PortfolioDisplay underettes når funktionen kaldes i de to eksempler/funktioner ovenfor
        //svarer til Notify i Stocks klassen.
        void NotifyPortfolioChanged()  
        {
            foreach (IObserver<Portfolio> observer in Observers)        //Portfolio gør her brug af Listen fra den abstrakte subjectklasse
            {
                observer.Update(this);
            }
        }

        // ekstra funktioner som PortfolioDisplay gør brug af for info om portfolio
        public int GetTotalStockValue()
        {
            int totalValue = 0;
            foreach (PortfolioEntry entry in portfolio)
            {
                int stockValue = entry.amount * entry.stock.Value_;
                totalValue += stockValue;
            }
            return totalValue;
        }

        public ReadOnlyCollection<PortfolioEntry> GetPortfolioEntries()
        {
            return portfolio.AsReadOnly();
        }
    }
}

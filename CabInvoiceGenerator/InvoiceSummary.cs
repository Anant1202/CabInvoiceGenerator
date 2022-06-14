using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        private string userId;

        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[TotalFare/NumOfRides -> ] Avg fair : " + this.averageFare);
        }

        public InvoiceSummary(int numberOfRides, double totalFare, double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[NumOfRides,fare,avgFare ->] Avg fair : " + this.averageFare);
        }

        public InvoiceSummary(int numberOfRides, double totalFare, string userId)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.userId = userId;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine("[using userId] : {0}  |  Avg fair : {1}", this.userId, this.averageFare);
        }
    }
}






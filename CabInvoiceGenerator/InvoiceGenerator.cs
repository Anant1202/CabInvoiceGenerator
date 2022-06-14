 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //Delcaring an Enum 
        public enum RideType { NORMAL }
        public const double MINIMUM_FARE = 5;
        public const double MIN_COST_PERKM = 10;
        public const int COST_PER_TIME = 1;

        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MIN_COST_PERKM + time * COST_PER_TIME;
            if (totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            else
            {
                return totalFare;
            }
        }
    }
}

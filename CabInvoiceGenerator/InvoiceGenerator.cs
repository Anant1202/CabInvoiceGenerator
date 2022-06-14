 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int numberOfRides;
        public double totalFare;
        public double averageFare;
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine(" avg fair : " + this.averageFare);
        }
        public InvoiceSummary(int numberOfRides, double totalFare,double averageFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
            Console.WriteLine(" avg fair : " + this.averageFare);
        }

    }
    public class Ride
    {
        // variables used
        public double distance;
        public int time;

        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
    public class InvoiceGenerator
    {
        public enum RideType
        {
            NORMAL
        }
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;

        RideType rideType;
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }

        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
                Console.WriteLine(" Distance : " + distance + " Time : " + time);
            }
            catch (CustomException)
            {
                if (rideType.Equals(null))
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new CustomException(CustomException.ExceptionType.INVALID_TIME, "Invalid time");

                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }


        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);

                }
            }
            catch (CustomException)
            {
                if (rides == null)
                {
                    throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "Rides are null");
                }

            }
            Console.WriteLine(" no of rides : " + rides.Length);
            return new InvoiceSummary(rides.Length, totalFare);
        }

    }
}

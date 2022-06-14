using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (rideList == false)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CustomException)
            {
                throw new CustomException(CustomException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        public Ride[] GetRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                var userRidesArray = this.userRides[userId].ToArray();
                Console.WriteLine(" User rides [distance,time] : ");
                foreach (var ur in userRidesArray)
                {
                    Console.Write("[" + ur.time + " , " + ur.distance + "] ");
                }
                return userRidesArray;
            }
            catch (Exception)
            {
                throw new CustomException(CustomException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }
    }
}

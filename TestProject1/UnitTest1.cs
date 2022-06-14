using CabInvoiceGenerator;
using static CabInvoiceGenerator.InvoiceGenerator;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void givenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 15.0;
            int time = 17;
            InvoiceGenerator obj= new InvoiceGenerator(RideType.NORMAL);
            double fare = obj.CalculateFare(distance, time);
            System.Console.WriteLine("Fare is : " + fare);
            Assert.AreEqual(167, fare);
        }
        [TestMethod]
        public void GivenMultipleRide_ShouldReturn_InvoiceSummary()
        {
            InvoiceGenerator obj = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = 
                { 
                new Ride(2.0, 5),
                new Ride(0.1, 5)
                };
            InvoiceSummary actual = obj.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }
    }
}

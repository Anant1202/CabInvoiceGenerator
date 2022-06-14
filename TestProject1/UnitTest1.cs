using CabInvoiceGenerator;
using static CabInvoiceGenerator.InvoiceGenerator;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            double distance = 15.0;
            int time = 17;
            InvoiceGenerator obj= new InvoiceGenerator(RideType.NORMAL);
            double fare = obj.CalculateFare(distance, time);
            System.Console.WriteLine("Fare is : " + fare);
            Assert.AreEqual(167, fare);
        }
        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
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
        [TestMethod]
        public void EnhancedInvoice()
        {
            InvoiceGenerator obj= new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.2, 2) };
            InvoiceSummary actual= obj.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void GivenUserId_UsingInvoiceSummaryShouldReturnsInvoice()
        {
            InvoiceGenerator obj = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 10), new Ride(0.2, 2) };
            obj.AddRides("user1", rides);
            InvoiceSummary actual = obj.GetInvoiceSummary("user1");
            InvoiceSummary expected = new InvoiceSummary(2, 35.0, "user1");   //no of rides, total, userid
            Assert.AreEqual(expected, actual);
        }

    }
}

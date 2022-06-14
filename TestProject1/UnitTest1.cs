using CabInvoiceGenerator;

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
            InvoiceGenerator obj= new InvoiceGenerator();
            double fare = obj.CalculateFare(distance, time);
            System.Console.WriteLine("Fare is : " + fare);
            Assert.AreEqual(167, fare);
        }
    }
}

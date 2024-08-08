using BidSaas.Core.Enums;
using BidSaas.Core.Models;
using BidSaas.Core.Services;

namespace BidSaas.Core.Tests
{
    public class AuctionCalculatorTests
    {
        List<Vehicle> Vehicles;
        List<VehicleAuctionCost> ExpectedResults;

       [SetUp]
        public void Setup()
        {
            Vehicles = new List<Vehicle> {
            new Vehicle(398, VehicleType.Common),
            new Vehicle(501, VehicleType.Common),
            new Vehicle(57, VehicleType.Common),
            new Vehicle(1800, VehicleType.Luxury),
            new Vehicle(1100, VehicleType.Common),
            new Vehicle(1000000, VehicleType.Luxury)};

            ExpectedResults = new List<VehicleAuctionCost>
            {
                new VehicleAuctionCost(398, 39.80f, 7.96f, 5, 100 ),
                new VehicleAuctionCost(501, 50, 10.02f, 10, 100),
                new VehicleAuctionCost(57, 10, 1.14f, 5, 100),
                new VehicleAuctionCost(1800, 180, 72, 15, 100),
                new VehicleAuctionCost(1100, 50, 22, 15, 100),
                new VehicleAuctionCost(1000000, 200, 40000, 20, 100),
            };
        }

        [Test]
        public void CalculateTotalPrice()
        {
            // Arrange
            AuctionCalculator ac = new AuctionCalculator();

            // Act & Assert
            for (int i=0; i< Vehicles.Count;i++)
            {
                var auctionCost = ac.CalculateTotalPrice(Vehicles[i]);

                // Assert
                Assert.IsTrue(auctionCost.Equals(ExpectedResults[i]));
            }
        }
    }
}
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
            Vehicles = new List<Vehicle>();
            ExpectedResults = new List<VehicleAuctionCost>();
        }

        [Test]
        public void CalculateTotalPrice_VehiclesWithVariousFees_ExpectedCostsAreEquals()
        {
            // Arrange
            AuctionCalculator ac = new AuctionCalculator();

            Vehicles.AddRange(new List<Vehicle> {
            new Vehicle(398, VehicleType.Common),
            new Vehicle(501, VehicleType.Common),
            new Vehicle(57, VehicleType.Common),
            new Vehicle(1800, VehicleType.Luxury),
            new Vehicle(1100, VehicleType.Common),
            new Vehicle(1000000, VehicleType.Luxury)});

            ExpectedResults.AddRange(new List<VehicleAuctionCost>
            {
                new VehicleAuctionCost(398, 39.80f, 7.96f, 5, 100 ),
                new VehicleAuctionCost(501, 50, 10.02f, 10, 100),
                new VehicleAuctionCost(57, 10, 1.14f, 5, 100),
                new VehicleAuctionCost(1800, 180, 72, 15, 100),
                new VehicleAuctionCost(1100, 50, 22, 15, 100),
                new VehicleAuctionCost(1000000, 200, 40000, 20, 100),
            });

            //Comparing fees and the vehicle price doesn't require a separate total calculation,
            //as the totals will be equal if all conditions are identical.

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
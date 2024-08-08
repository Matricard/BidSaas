using BidSaas.Core.Enums;

namespace BidSaas.Core.Models
{
    public class Vehicle
    {
        public Vehicle(float basePrice, VehicleType type) { 
            BasePrice = basePrice;
            Type = type;
        }
        public float BasePrice { get; private set; }
        public VehicleType Type { get; private set; }
    }
}

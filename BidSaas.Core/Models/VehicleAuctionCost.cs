namespace BidSaas.Core.Models
{
    public class VehicleAuctionCost: IEquatable<VehicleAuctionCost>
    {
        public float BasePrice { get; private set; }
        public float BuyerFee { get; private set; }
        public float SellerFee { get; private set; }
        public float AssociationFee { get; private set; }
        public float StorageFee { get; private set; }

        public VehicleAuctionCost(float basePrice, float buyerFee, float sellerFee, float associationFee, float storageFee)
        {
            BasePrice = basePrice;
            BuyerFee = buyerFee;
            SellerFee = sellerFee;
            AssociationFee = associationFee;
            StorageFee = storageFee;
        }

        public float AuctionFee => BuyerFee + SellerFee + AssociationFee + StorageFee;
        public float Total => BasePrice + AuctionFee;

        public bool Equals(VehicleAuctionCost? vehicle)
        {
            if (vehicle != null)
            {

                return AreFloatsEqual(vehicle.BasePrice, BasePrice) &&
                       AreFloatsEqual(vehicle.BuyerFee, BuyerFee) &&
                       AreFloatsEqual(vehicle.SellerFee, SellerFee) &&
                       AreFloatsEqual(vehicle.AssociationFee, AssociationFee) &&
                       AreFloatsEqual(vehicle.StorageFee, StorageFee);
            }

            return false;
        }
        private static bool AreFloatsEqual(float a, float b, float epsilon = 0.0001f)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}
using System.Collections.ObjectModel;

namespace BidSaas.Core.Constants
{
    public static class FeeConstants
    {
        public const float BasicBuyerFeePercentage = 0.10f;

        public const float CommonBuyerFeeMin = 10.0f;
        public const float CommonBuyerFeeMax = 50.0f;

        public const float LuxuryBuyerFeeMin = 25.0f;
        public const float LuxuryBuyerFeeMax = 200.0f;

        public const float CommonSellerFeePercentage = 0.02f;
        public const float LuxurySellerFeePercentage = 0.04f;

        public const float FixedStorageFee = 100.0f;

        public static readonly ReadOnlyDictionary<float, float> AssociationCostTiers = new ReadOnlyDictionary<float, float>(
            new Dictionary<float, float>
        {
            { 500, 5 },
            { 1000, 10 },
            { 3000, 15 },
            { float.MaxValue, 20 }
        });
    }
}
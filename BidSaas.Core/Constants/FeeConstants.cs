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


        /// <summary>
        /// Association based fee based on the price of the vehicle <br />
        /// $5 for an amount up to $500 <br />
        /// $10 for an amount up to $1000 <br />
        /// $15 for an amount up to $3000 <br />
        /// $20 for an amount over $3000 
        /// </summary>
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
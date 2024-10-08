﻿using BidSaas.Core.Enums;
using BidSaas.Core.Constants;
using BidSaas.Core.Models;

namespace BidSaas.Core.Services
{
    public class AuctionCalculator
    {
        public VehicleAuctionCost CalculateTotalPrice(Vehicle vehicle)
        {
            float buyerFee = CalculateBuyerFee(vehicle.BasePrice, vehicle.Type);
            float sellerFee = CalculateSellerFee(vehicle.BasePrice, vehicle.Type);
            float associationFee = CalculateAssociationFee(vehicle.BasePrice);

            return new VehicleAuctionCost(vehicle.BasePrice, buyerFee, sellerFee, associationFee, FeeConstants.FixedStorageFee);
        }

        private float CalculateBuyerFee(float basePrice, VehicleType type)
        {
            float feePercentage = FeeConstants.BasicBuyerFeePercentage;
            float fee = basePrice * feePercentage;

            switch (type) {
                case VehicleType.Common:
                    return Math.Clamp(fee, FeeConstants.CommonBuyerFeeMin, FeeConstants.CommonBuyerFeeMax);
                case VehicleType.Luxury:
                    return Math.Clamp(fee, FeeConstants.LuxuryBuyerFeeMin, FeeConstants.LuxuryBuyerFeeMax);
                default:
                    throw new NotImplementedException();
            }
            //TODO change NotImplementedException
        }

        private float CalculateSellerFee(float basePrice, VehicleType type)
        {
            float feePercentage = (type == VehicleType.Common) ? 
                FeeConstants.CommonSellerFeePercentage : FeeConstants.LuxurySellerFeePercentage;

            return basePrice * feePercentage;
        }

        private float CalculateAssociationFee(float amount)
        {
            foreach (var tier in FeeConstants.AssociationCostTiers)
            {
                if (amount <= tier.Key)
                    return tier.Value;
            }

            return FeeConstants.AssociationCostTiers[float.MaxValue];
        }
    }
}
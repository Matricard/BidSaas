﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSaas.Core.Models
{
    public class VehicleAuctionCost
    {
        // Propriétés publiques avec getters publics et setters privés
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
        public float Total =>  BasePrice + AuctionFee;
    }

}

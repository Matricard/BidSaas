export default class CostModel {
    constructor(basePrice, buyerFee, sellerFee, associationFee, storageFee, auctionFee, total) {
        this.basePrice = basePrice;
        this.buyerFee = buyerFee;
        this.sellerFee = sellerFee;
        this.associationFee = associationFee;
        this.storageFee = storageFee;
        this.auctionFee = auctionFee;
        this.total = total;
    }
}
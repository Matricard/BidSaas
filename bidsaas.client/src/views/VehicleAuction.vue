<template>
    <div>
        <select v-model="selectedType">
            <option disabled value="">Please select one</option>
            <option value="0">Common</option>
            <option value="1">Luxury</option>
        </select>
    </div>
    <div>
        <input v-model.number="basePriceInput" type="number" placeholder="Enter vehicle price here">
    </div>
    <div v-if="costDetails">
        <h2>Cost Details</h2>
        <ul>
            <li>Base Price: {{ costDetails.basePrice.toFixed(2) }}</li>
            <li>Buyer Fee: {{ costDetails.buyerFee.toFixed(2) }}</li>
            <li>Seller Fee: {{ costDetails.sellerFee.toFixed(2) }}</li>
            <li>Association Fee: {{ costDetails.associationFee.toFixed(2) }}</li>
            <li>Storage Fee: {{ costDetails.storageFee.toFixed(2) }}</li>
            <li>Auction Fee: {{ costDetails.auctionFee.toFixed(2) }}</li>
            <li>Total: {{ costDetails.total.toFixed(2) }}</li>
        </ul>
    </div>
</template>

<script>
import CostModel from '../models/CostModel.js';

export default {
    data() {
        return {
            selectedType: '',
            basePriceInput: '',
            costDetails: null,
            typingTimeout: null
        };
    },
    watch: {
        basePriceInput(newValue) {
            clearTimeout(this.typingTimeout);
            this.typingTimeout = setTimeout(() => {
                this.fetchCostDetails();
            }, 500);
        },
        selectedType(newValue) {
            this.fetchCostDetails();
        }
    },
    methods: {
        async fetchCostDetails() {
            try {
                const response = await fetch('https://localhost:7039/Auction', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        basePrice: parseFloat(this.basePriceInput),
                        type: parseInt(this.selectedType)
                    })
                });

                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const responseData = await response.json();

                console.log('Received data:', responseData);

                this.costDetails = new CostModel(
                    responseData.cost.basePrice,
                    responseData.cost.buyerFee,
                    responseData.cost.sellerFee,
                    responseData.cost.associationFee,
                    responseData.cost.storageFee,
                    responseData.cost.auctionFee,
                    responseData.cost.total
                );

                console.log('Server response:', this.costDetails);
            } catch (error) {
                console.error('Error sending request:', error);
            }
        }
    }
};
</script>
<style scoped>
</style>
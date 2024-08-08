<template>
    <div class="d-flex flex-column justify-content-center align-items-center mt-5" >
      <div class="mb-4" style="width: 20rem;">
        <div class="mb-3">
          <select v-model="selectedType" class="form-select">
            <option disabled value="">Please select one</option>
            <option value="0">Common</option>
            <option value="1">Luxury</option>
          </select>
        </div>
  
        <div>
          <input 
            v-model.number="basePriceInput" 
            type="number" 
            step="0.01"
            class="form-control" 
            placeholder="Enter vehicle price here"/>
        </div>
      </div>
  
      <div v-if="costDetails" class="card p-4" style="width: 20rem;">
        <h2>Cost Details</h2>
        <ul class="list-unstyled">
          <li>Base Price: {{ costDetails.basePrice.toFixed(2) }} $</li>
          <li>Buyer Fee: {{ costDetails.buyerFee.toFixed(2) }} $</li>
          <li>Seller Fee: {{ costDetails.sellerFee.toFixed(2) }} $</li>
          <li>Association Fee: {{ costDetails.associationFee.toFixed(2) }} $</li>
          <li>Storage Fee: {{ costDetails.storageFee.toFixed(2) }} $</li>
          <li>Total: {{ costDetails.total.toFixed(2) }} $</li>
        </ul>
      </div>
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
                }, 200);
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

<style>
    .list-unstyled li {
        margin-bottom: 0.5rem;
    }
</style>
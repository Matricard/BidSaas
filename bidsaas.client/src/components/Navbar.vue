<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container">
        <a class="navbar-brand" href="#">
            {{pageTitle}}
        </a>
  
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
  
        <div class="collapse navbar-collapse" id="navbarNav">
        
        </div>
      </div>
    </nav>
  </template>
  
  <script>
  export default {
    data() {
      return {
        pageTitle: 'The Bid Calculation Tool'
      };
    },
    mounted() {
      document.title = this.pageTitle;
    }
  };
  </script>

  
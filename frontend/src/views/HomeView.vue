<template>
  <link rel="stylesheet" href="~/css/home.css" asp-append-version="true" />
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <link rel="stylesheet" href="https://www.w3schools.com/lib/w3-theme-black.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css">
  <WebHeader current-page="home" />
  <HomeComponent />
</template>

<script>
import WebHeader from '../components/tools/HeaderComponent.vue';
import HomeComponent from '../components/HomeComponent.vue';

export default {
  components:{WebHeader, HomeComponent},
}
</script>

<style>
#home-container {
  padding: 0px;
}
</style>

<template>
    <WebHeader current-page="home" />
    <Social />
  </template>
  
  <script>
  import WebHeader from '@/components/tools/HeaderComponent.vue';
  import Social from '@/components/Profile/SocialComponent.vue';
  
  export default {
    components:{WebHeader, Social},
  }
  </script>
  
  <style>
  @import '@/assets/css/identity.css';
  </style>
  
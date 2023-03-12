<template>
    <WebHeader current-page="home" />
    <FriendsRequest />
  </template>
  
  <script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import FriendsRequest from '../../components/Profile/FriendsRequestComponent.vue';
  
  export default {
    components:{WebHeader, FriendsRequest},
  }
  </script>
  
  <style>
  @import '@/assets/css/identity.css';
  </style>
  
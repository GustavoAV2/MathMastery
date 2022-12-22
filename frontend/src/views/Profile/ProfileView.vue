<template>
    <WebHeader current-page="home" />
    <Profile />
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import Profile from '../../components/Profile/IdentityComponent.vue';
  
  export default {
    components:{WebHeader, Profile},
  }
</script>

<style>
@import '@/assets/css/identity.css';
</style>
  
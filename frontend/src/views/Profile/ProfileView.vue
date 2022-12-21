<template>
    <link rel="stylesheet" href="~/css/identity.css" asp-append-version="true" />
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
</style>
  
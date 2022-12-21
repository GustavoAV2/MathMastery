<template>
    <link rel="stylesheet" href="~/css/identity.css" asp-append-version="true" />
    <WebHeader current-page="home" />
    <Friends />
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import Friends from '../../components/Profile/FriendsComponent.vue';
  
  export default {
    components:{WebHeader, Friends},
  }
</script>

<style>
</style>
  
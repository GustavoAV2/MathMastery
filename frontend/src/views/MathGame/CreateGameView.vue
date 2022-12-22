<template>
    <WebHeader current-page="home" />
    <CreateGame />
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import CreateGame from '../../components/MathGame/CreateGameComponent.vue';
  
  export default {
    components:{WebHeader, CreateGame},
  }
</script>

<style>
@import '@/assets/css/create_game.css';
</style>
  
<template>
    <WebHeader current-page="home" />
    <Game />
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import Game from '../../components/MathGame/GameComponent.vue';
  
  export default {
    components:{WebHeader, Game},
  }
</script>

<style>
</style>
  
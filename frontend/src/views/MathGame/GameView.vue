<template>
    <WebHeader current-page="home" />
    <template v-if="difficulty != ''">
      <Game :difficulty="difficulty"/>
    </template>
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import Game from '../../components/MathGame/GameComponent.vue';
  
  export default {
    components:{WebHeader, Game},
    data(){
      return {
        difficulty: ""
      }
    },
    mounted() {
      this.difficulty = this.$route.params.difficulty;
    }
  }
</script>

<style>
  @import '@/assets/css/create_game.css';
  @import '@/assets/css/game.css';
</style>

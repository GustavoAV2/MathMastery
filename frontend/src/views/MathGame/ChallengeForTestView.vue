<template>
    <WebHeader current-page="home" />
    <ChallengeForTest />
</template>
  
<script>
  import WebHeader from '../../components/tools/HeaderComponent.vue';
  import ChallengeForTest from '../../components/MathGame/ChallengeForTestComponent.vue';
  
  export default {
    components:{WebHeader, ChallengeForTest},
  }
</script>

<style>
</style>
  
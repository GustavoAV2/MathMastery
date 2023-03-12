<template>
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
@import '@/assets/css/identity.css';
</style>

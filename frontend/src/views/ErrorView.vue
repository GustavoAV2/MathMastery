<template>
    <WebHeader current-page="home" />
    <h1>Lamentamos pelo erro...</h1>
    <hr/>
    <router-link to="/">
      <a>Voltar ao menu principal</a>
    </router-link> 
    <FooterComponent />
</template>

<script>
import WebHeader from '@/components/tools/HeaderComponent.vue';
import FooterComponent from '@/components/tools/FooterComponent.vue';

export default {
  components:{WebHeader, FooterComponent},
  created(){
    clearInterval();
  }
}
</script>

<style>
@import '@/assets/css/site.css';
@import '@/assets/css/home.css';
@import 'https://www.w3schools.com/w3css/4/w3.css';
@import 'https://www.w3schools.com/lib/w3-theme-black.css';
@import 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css';
</style>

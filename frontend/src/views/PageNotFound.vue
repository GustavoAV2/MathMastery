<script setup>
import WebHeader from '../components/tools/HeaderComponent.vue';
</script>

<template>
  <WebHeader current-page="home" />
  <br>
  <div class="container">
      <h1>Pagina nao encontrada!</h1>
      <h4 class="col-6 fs-7">Verifique a URL</h4>
      <hr>
      <router-link to="/" class="navbar-link" id="sign-nav-link">Voltar para o inicio...</router-link>
  </div>
</template>

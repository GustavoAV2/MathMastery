<template>
    <WebHeader />
    <div class="container">
        <h2>Resultado:</h2>
        <p>Acertos em problemas matematicos: {{ data.numberResolvedAccounts }}</p>
        <p>Erros em problemas matematicos: {{ data.numberUnresolvedAccounts }}</p>
        <p>Win Rate: {{ data.winRate }}</p>
        <hr>
        <a class="nav-link text-blue">Voltar ao inicio...</a>
    </div>
</template>

<script>
import WebHeader from '../../components/tools/HeaderComponent.vue';

export default {
  components:{WebHeader},
}
</script>

<style>
#home-container {
  padding: 0px;
}
</style>

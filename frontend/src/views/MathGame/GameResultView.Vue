<template>
    <WebHeader />
    <div class="container">
      <div class="card border-success mb-3 fade-in" id="normal-info">
        <div class="card-body text-success">
          <div class="row">
            <div class="col">
              <h5 class="card-title solvedProblems">Acertos em problemas matematicos:</h5>
              <p class="card-text solvedProblems">{{ resolvedAccounts }}</p>

              <h5 class="card-title unsolvedProblems">Erros em problemas matematicos:</h5>
              <p class="card-text unsolvedProblems">{{ unresolvedAccounts }}</p>
            </div>
            <div class="col winRate-container">
              <h5 class="card-title winRate">Win Rate: </h5>
              <p class="card-text winRate"> {{ winRate }} %</p>
            </div>
          </div>
        </div>
      </div>
      <router-link to="/mathgame/create" class="link-mathgame">Voltar...</router-link>
    </div>
</template>

<script>
import User from '@/services/users'
import WebHeader from '../../components/tools/HeaderComponent.vue';

export default {
  components:{WebHeader},
  data(){
    return {
      resolvedAccounts: 0,
      unresolvedAccounts: 0,
      winRate: 0
    }
  },
  methods:{
    async setWinRate(winRate){
      while(this.winRate != winRate){
        await new Promise(r => setTimeout(r, 10));
        this.winRate += 1;
      }
    },
    updateUserResults(){
      User.getByToken().then(response => {
        if (response.data.id){
          var payload = {
            NumberResolvedAccounts: this.resolvedAccounts,
            NumberUnresolvedAccounts: this.unresolvedAccounts
          }
          User.updateGameUserStatus(payload, response.data.id).then(response => {
            console.log(response.data);
          }).catch(er => {
            this.$router.push("/error");
          })
        }
      }).catch(er => {
        this.$router.push("/error");
      })
      
    }
  },
  created(){
    this.updateUserResults();

    this.resolvedAccounts = parseInt(localStorage.getItem('challengesSolve'));
    this.unresolvedAccounts = parseInt(localStorage.getItem('challengesUnsolved'));

    var correctAcc = this.resolvedAccounts * 100;
    var winRate = correctAcc / 5;
    this.setWinRate(winRate);
  }
}
</script>

<style scoped>
@import '@/assets/css/game.css';
#home-container {
  padding: 0px;
}
.card{
  margin-top:20px;
}
.card-title{
  font-size: 35px;
}
.card-text{
  font-size: 45px;
}
.solvedProblems{
  color: green;
}
.unsolvedProblems{
  color: red;
}
.winRate{
  font-size: 50px;
  color: black;
}
.winRate-container{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
</style>

<template>
  <WebHeader current-page="sign" />
  <div class="container">
    <h1 class="text-center mt-5">Entrar</h1>
    <div class="form-fields">
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="user.email" class="form-control" id="email">
      </div>
      <div class="form-group">
        <label for="senha">Senha:</label>
        <input type="password" v-model="user.password" class="form-control" id="senha">
      </div>
      <hr>
      <button class="btn register-btn" @click="loginUser()">Entrar</button>
    </div>
    <div class="text-center mt-3">
      <p>Não tem uma conta? <router-link to="/register">Registre-se</router-link>.</p>
    </div>
  </div>
  <FooterComponent />
</template>

<script>
import User from '@/services/users'
import alertMixin from '@/mixins/alertMixin'
import WebHeader from '../../components/tools/HeaderComponent.vue';
import FooterComponent from '../../components/tools/FooterComponent.vue';

export default {
  components:{WebHeader, FooterComponent},
  mixins:[alertMixin],
  data(){
    return{
      loading: false,
      user:{
        email:null,
        password:null
      }
    }
  },
  methods: {
      loginUser(){
          this.loading = true
          User.login(this.user).then(response => {
            console.log(response);
            if (response.data){
              localStorage.setItem('token', response.data)
              this.$router.push('/')
            }
            else{
              this.generateMessage("Credenciais incorretas!")
            }
          }).
          catch(() => {
            this.generateMessage("Credenciais incorretas!")
          }).
          finally(() => this.loading = false)
      }
  }
}
</script>

<style scoped>
.form-fields {
  margin: 0 auto;
  max-width: 600px;
  background-color: #FFFFFF;
  border-radius: 10px;
  padding: 20px;
  box-shadow: 0px 0px 10px #1ABC9C;
}
.form-fields input{
  font-size: 20px;
  padding: 10px;
}
label {
  color: #34495E;
  font-weight: bold;
}
button {
  background-color: #1ABC9C;
  color: #FFFFFF;
  border: none;
  border-radius: 5px;
  padding: 10px;
  font-size: 16px;
  margin-top: 20px;
}
.register-btn:hover {
  color: #1ABC9C;
  border: 1px solid #1ABC9C;
}
.register-btn{
  border: 1px solid #1ABC9C;
  background-color: white;
  color: black;
  padding: 14px 28px;
  font-size: 16px;
  cursor: pointer;
}
</style>
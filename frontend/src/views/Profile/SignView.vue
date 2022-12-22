<template>
  <WebHeader current-page="sign" />
  <div class="container-fluid text-center mt-5" id="sign-container">
    <div class="row">
      <div class="col-12 h5">Entrar</div>
    </div>
    <div class="row mt-2">
      <div class="col-12">
        <div class="container">
          <div class="row mb-3">
            <div class="col-12">
              <input class="form-inputs" type="email" v-model="user.email" id="user-email-input" placeholder="Email ou nome de usuário">
            </div>
          </div>
          <div class="row mb-3">
            <div class="col-12"> 
              <input class="form-inputs" type="password" v-model="user.password" id="user-password-input" placeholder="Senha">
            </div>
          </div>

          <div class="row mb-3">
            <div class="col-12"> 
              <button id="submit-button" class="btn btn-dark" @click="loginUser()">Entrar</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        Não possui cadastro? <router-link to="/register" id="register-link">Registrar</router-link>
      </div>
    </div>
    <div>
        <transition v-if="message.content" name="slide" mode="out-in" appear>
          <div :class="message.type" role="alert">
            {{ message.content }}
          </div>
        </transition>
    </div>
  </div>
</template>

<script>
import User from '@/services/users'
import alertMixin from '@/mixins/alertMixin'
import WebHeader from '../../components/tools/HeaderComponent.vue';

export default {
  components:{WebHeader},
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
              if (response.data.access_token){
                localStorage.setItem('token', response.data.access_token)
                this.$router.push('/')
              }
              else{
                this.generateMessage("Credenciais incorretas!", "alert alert-danger")
              }
          }).
          catch(() => {
              this.generateMessage("Credenciais incorretas!", "alert alert-danger")
          }).
          finally(() => this.loading = false)
      }
  }
}
</script>

<style>
#sign-container {
  color: black;
}

.form-inputs{
  width: 30%;
  text-align: center;
}
input {
  background-color: var(--color-background);
  border: none;
  border-bottom: 2px solid black;
  text-decoration: none;
  outline: none;
  color: black;
}

#register-link {
  text-decoration: underline;
  color: black;
  font-weight: 600;
}

@keyframes slide-in {
  from {
    transform: translateY(40px);
  }

  to {
    transform: translateY(0);
  }
}

@keyframes slide-out {
  from {
    transform: translateY(0);
  }

  to {
    transform: translateY(40px);
  }
}
.alert{
  margin-left: 50%;
  margin-right: 500px;
}
.slide-enter-active {
  animation: slide-in 2s ease;
  transition: opacity 2s;
}

.slide-leave-active {
  animation: slide-out 2s ease;
  transition: opacity 2s;
}

.slide-enter,
.slide-leave-to {
  opacity: 0;
  transition: 2s;
}
</style>

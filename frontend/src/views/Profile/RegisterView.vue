<template>
  <WebHeader current-page="sign" />
  <div class="container-fluid text-center mt-5" id="sign-container">
    <div class="row">
      <div class="col-12 h5">Registrar</div>
    </div>
    <div class="row mt-2 form-container">
      <div class="col-12">
        <div class="container">

          <div class="row mb-3">
            <div class="col-12">
              <input class="form-inputs" type="text" v-model="user.first_name" placeholder="Primeiro nome">
            </div>
          </div>

          <div class="row mb-3">
            <div class="col-12">
              <input class="form-inputs" type="text" v-model="user.last_name" placeholder="Último nome">
            </div>
          </div>

          <div class="row mb-3">
            <div class="col-12">
              <input class="form-inputs" type="email" v-model="user.email" id="user-email-input" placeholder="Email">
            </div>
          </div>

          <div class="row mb-3">
            <div class="col-12">
              <input type="text" class="form-inputs" v-model="user.username" id="user-username-input"
                placeholder="Nome de usuário">
            </div>
          </div>
          
          <template v-if="hidden">
            <div class="row mb-3">
              <div class="col-12">
                <input type="password" class="form-inputs" v-model="user.password" id="user-password-input"
                  placeholder="Senha">
              </div>
            </div>
          </template>

          <div class="row mb-3">
            <div class="col-12">
              <label for="user-birthdate">Data de nascimento</label><br />
              <input class="form-inputs" type="date" v-model="user.birthdate" id="user-birthdate">
            </div>
          </div>
          <div class="row mb-3">
            <div class="col-12"> <button class="btn btn-dark" @click="save()">Registrar</button>
            </div>
          </div>
          <div class="row">
            <div class="col-12">
              Já possui uma conta? <router-link to="/sign" id="sign-link">Entrar</router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <transition v-if="message.content" name="slide" mode="out-in" appear>
    <div :class="message.type" role="alert">
      {{ message.content }}
    </div>
  </transition>
</template>

<script>
import WebHeader from '../../components/tools/HeaderComponent.vue';
import alertMixin from '@/mixins/alertMixin'
import User from '@/services/users'

export default {
  mixins: [alertMixin],
  components: { WebHeader },

  data() {
    return {
      hidden: true,
      confirm_password: null,
      user: {
        email: null,
        password: null,
        birthdate: null,
        username: null,
        first_name: null,
        last_name: null,
      }
    }
  },
  methods: {
    save() {
      if (this.confirm_password == this.user.password) {
        User.create(this.user).then(() => {
          this.generateMessage("Cadastro efetuado! Redirecionando para login.", "alert alert-success");
          const timeout = setTimeout(() => {
            this.$router.push("/sign");

          }, 2000);
          console.log(timeout);
        }).
          catch(() => {
            this.generateMessage("Erro de servidor, registro não efetuado.", "alert alert-danger")
          })
      }
      else {
        this.generateMessage("Senhas não são idênticas.", "alert alert-danger")
      }
    }
  }
}
</script>

<style>
#sign-container {
  color: black;
}

#first-name {
  margin-right: 10px;
}

#last-name {
  margin-left: 10px;
}

.form-inputs {
  width: 30%;
}

@media only screen and (max-device-width: 900px) {
  .form-inputs {
    width: 60%;
  }
}

input {
  background-color: var(--color-background);
  border: none;
  border-bottom: 2px solid black;
  text-decoration: none;
  outline: none;
  color: black;
}

#sign-link {
  text-decoration: underline;
  color: black;
  font-weight: 600;
}

input:focus {
  transition: 0.3s;
  box-shadow: 0 0 0 0;
  border: 0 none;
  outline: 0;
  color: black;
  border-bottom: 2px solid #5fa8d3;
  background-color: white;
}

/* Transition */
.alert-danger {
  margin-right: 150px;
  margin-left: 150px;
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
}
</style>

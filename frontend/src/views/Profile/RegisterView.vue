<template>
  <WebHeader current-page="sign" />
  <div class="container">
    <h1 class="text-center mt-5">Registro de usuário</h1>
    <div class="form-fields">
      <div class="form-group">
        <label for="primeiro-nome">Primeiro nome:</label>
        <input type="text" v-model="user.firstName" class="form-control" id="primeiro-nome">
      </div>
      <div class="form-group">
        <label for="ultimo-nome">Último nome:</label>
        <input type="text" v-model="user.lastName" class="form-control" id="ultimo-nome">
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="user.email" class="form-control" id="email">
      </div>
      <div class="form-group">
        <label for="nome-usuario">Nome de usuário:</label>
        <input type="text" v-model="user.username" class="form-control" id="nome-usuario">
      </div>
      <div class="form-group">
        <label for="senha">Senha:</label>
        <input type="password" v-model="user.password" class="form-control" id="senha">
      </div>
      <div class="form-group">
        <label for="confirmar-senha">Confirmar senha:</label>
        <input type="password" v-model="confirm_password" class="form-control" id="confirmar-senha">
      </div>
      <hr>
      <button class="btn register-btn" @click="save()">Registrar</button>
    </div>
    <div class="text-center mt-3">
      <p>Já tem uma conta? <router-link to="/sign">Faça login</router-link>.</p>
    </div>
  </div>
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
        firstName: null,
        lastName: null,
      }
    }
  },
  methods: {
    save() {
      console.log(this.user)
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
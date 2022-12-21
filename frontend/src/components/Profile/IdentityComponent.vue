<template>
<div class="container">
    <template v-if="token != null">
        <div style=" width: 100%;">
            <div class="card" style="width: 100%; border-radius: 8px 0px 0px 8px;">
                <div class="card-body text-center">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                        class="rounded-circle img-fluid" style="width: 150px;">
                    <h5 class="my-3">{{ user.lastName }}</h5>
                    <p class="text-muted mb-1">{{ user.userName }}</p>
                    <p class="text-muted mb-4">{{ user.winRate }}</p>
                </div>
            </div>

            <div class="card" style="width: 100%; border-radius: 0px 8px 8px 0px;">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-9">
                            <p class="mb-0">Acertos em problemas matematicos:</p>
                        </div>
                        <div class="col-sm-3">
                            <p class="text-muted mb-0">
                                {{ user.numberResolvedAccounts }}
                            </p>
                        </div>
                    </div>
                    <hr>

                    <div class="row">
                        <div class="col-sm-9">
                            <p class="mb-0">Erros em problemas matematicos:</p>
                        </div>
                        <div class="col-sm-3">
                            <p class="text-muted mb-0">{{ user.NumberUnresolvedAccounts }}</p>
                        </div>
                    </div>
                    <hr>

                    <div class="row">
                        <div class="col-sm-9">
                            <p class="mb-0">Win Rate:</p>
                        </div>
                        <div class="col-sm-3">
                            <p class="text-muted mb-0">{{ user.winRate }}</p>
                        </div>
                    </div>
                    <hr>

                    <div class="row">
                        <div class="col-sm-9">
                            <p class="mb-0">E-mail verificado:</p>
                        </div>
                        <div class="col-sm-3">
                            <p class="text-muted mb-0">{{ user.email }}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <a class="nav-link text-blue" asp-area="Identity" asp-controller="Home" asp-action="Index">Voltar para o Inicio...</a>
    </template>

    <template v-else>
        <h3>Você ainda não está logado!</h3>
        <br />
        <a class="nav-link text-blue" asp-area="Identity" asp-page="/Account/Login">Faca o login para visualizar esta pagina...</a>
    </template>
</div>
</template>

<script>
import User from '@/services/users'

export default {
    data(){
        return{
            token: null,
            user: null
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
        if (this.token != null){
            User.getByToken(this.token).then(response => {
                console.log(response.data)
                this.user = response.data;
            }).catch(()=>{})
        }
    }
}
</script>
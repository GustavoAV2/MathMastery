<template>
<div class="container">
    <template v-if="token != null">
        <template v-if="this.loading == false">
            <div>
                <div>
                    <div class="card-body text-center">
                        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                            class="rounded-circle img-fluid" style="width: 150px;">
                        <h5 class="my-3">{{ user.firstName }} {{ user.lastName }}</h5>
                        <p class="text-muted mb-1">{{ user.userName }}</p>
                        <p class="text-muted mb-1">{{ user.winRate }}</p>
                        <router-link to="/friends" class="btn btn-success mb-1">Friends</router-link>
                        <button class="btn btn-warning mb-1">Editar</button>
                    </div>
                </div>
    
                <div class="card" style="border-radius: 8px 8px 8px 8px;">
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
                                <p class="text-muted mb-0">{{ user.numberUnresolvedAccounts }}</p>
                            </div>
                        </div>
                        <hr>
    
                        <div class="row">
                            <div class="col-sm-9">
                                <p class="mb-0">Taxa de acertos:</p>
                            </div>
                            <div class="col-sm-3">
                                <p class="text-muted mb-0">{{ winRate }}%</p>
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
        </template>
        <template v-else>
            <div class="loading-container" >
                <div class="spinner-border" role="status">
                    <span class="sr-only"></span>
                </div>
            </div>
        </template>
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
            loading: true,
            token: null,
            user: null,
            winRate: null
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
        User.getByToken().then(response =>{
            this.user = response.data;
            var played = this.user.numberUnresolvedAccounts + this.user.numberResolvedAccounts;
            this.winRate = this.user.numberResolvedAccounts * 100 / played;
            console.log(this.user);
            this.loading = false;
        })
    }
}
</script>

<style>
.loading-container{
    margin-top: 10%;
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
.btn-space{
    margin: 1px;
}
</style>
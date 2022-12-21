<template>
    <template v-if="token != null">
        <div style="display: flex;">
            <div class="added-friends-container">
                <div class="preview-friend-container" v-for="user in users">
                    <img src="/test">
                    <p>{{user.firstName}} {{user.lastName}}</p>
                </div>
                <div class="preview-friend-container">
                    <img src="/test">
                    <p>Nenhum usuario</p>
                </div>
            </div>
    
            <div class="search-user">
                <div style="display: flex; width: 100%;">
                    <form id="friend-form" asp-controller="Home" asp-action="IdentityFriend" style="display:flex; flex-direction: row; width: 100%;">
                        <input id="friend-input" style="width: 80%;" name="email" placeholder="Find your friend by Username...">
                        <button type="submit" style="margin:0px; width: 20%; border-radius: 0px 0px 0px 0px;" class="btn btn-outline-success">Buscar</button>
                    </form>
                </div>
                <template v-if="userFound != null">
                    <div class="user-card">
                        <div class="card" style="width: 100%; border-radius: 0px 0px 0px 8px;">
                            <div class="card-body text-center">
                                <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                                    class="rounded-circle img-fluid" style="width: 150px;">
                                    <h5 class="my-3">{{userFound.firstName}} {{userFound.lastName}}</h5>
                                    <p class="text-muted mb-1">@{{userFound.userName}}</p>
                                <p class="text-muted mb-4">{{userFound.winRate}}</p>
                                <div class="d-flex justify-content-center mb-2">
                                    <form method="post" asp-controller="Home" asp-action="AddFriend" style="display:flex; flex-direction: row; width: 100%;">
                                        <input name="friendId" type="hidden" value="@userFound.Id">
                                        <button type="submit" class="btn btn-outline-success ms-1">Solicitar amizade</button>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div class="card" style="width: 100%; border-radius: 0px 0px 8px 0px;">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-9">
                                        <p class="mb-0">Acertos em problemas matematicos:</p>
                                    </div>
                                    <div class="col-sm-3">
                                        <p class="text-muted mb-0">
                                            {{userFound.NumberResolvedAccounts}}
                                        </p>
                                    </div>
                                </div>
                                <hr>
        
                                <div class="row">
                                    <div class="col-sm-9">
                                        <p class="mb-0">Erros em problemas matematicos:</p>
                                    </div>
                                    <div class="col-sm-3">
                                            {{userFound.numberUnresolvedAccounts}}
                                    </div>
                                </div>
                                <hr>
        
                                <div class="row">
                                    <div class="col-sm-9">
                                        <p class="mb-0">Win Rate:</p>
                                    </div>
                                    <div class="col-sm-3">
                                        <p class="text-muted mb-0">@ViewData["WinRate"]%</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </template>

                <template v-else>
                    <h1>Nenhum usuario encontrado!</h1>
                </template>
            </div>
        </div>
    </template>

    <template v-else>
        <h3>Você ainda não está logado!</h3>
        <br />
        <a class="nav-link text-blue" asp-area="Identity" asp-page="/Account/Login">Faca o login para visualizar esta pagina...</a>
    </template>
</template>

<script >
import User from '@/services/users'

export default {
    data(){
        return{
            token: null,
            user: null,
            users: [],
            userFound: null
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

<template>
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
                <input id="friend-input" v-model="usernameOrEmail" style="width: 80%;" name="email" placeholder="Insira um Email ou nome de Usuario...">
                <button @click="findUser()" style="margin:0px; width: 20%; border-radius: 0px 0px 0px 0px;" class="btn btn-outline-success">Buscar</button>
            </div>
            <template v-if="userFound != null">
                <div class="user-card">
                    <div class="card" style="width: 100%; border-radius: 0px 0px 0px 8px;">
                        <div class="card-body text-center">
                                <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar"
                                class="rounded-circle img-fluid" style="width: 150px;">
                                <h5 class="my-3">{{userFound.firstName}} {{userFound.lastName}}</h5>
                                <p class="text-muted mb-1">{{userFound.userName}}</p>
                                <button @click="sendFriendRequest()" class="btn btn-outline-success ms-1">Solicitar amizade</button>
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
                                        {{userFound.numberResolvedAccounts}}
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
                                    <p class="text-muted mb-0">{{ userFound.winRate }} %</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </template>

            <template v-else>
                <div class="loading-container" >
                    <h2 class="text-muted mb-1">Nenhum usuario encontrado!</h2>
                </div>
            </template>
        </div>
    </div>
</template>

<script >
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return{
            friendRequestDto: {
                requesterId: "",
                receiverId: "",
                status: "P"
            },
            usernameOrEmail: "",
            friendUsers: [],
            userFound: null
        }
    },
    methods:{
        findUser(){
            console.log("buscou");
            User.getByUsernameOrEmail(this.usernameOrEmail).then(response =>{
                this.userFound = response.data;
                var winRate = (this.userFound.numberResolvedAccounts * 100) / (this.userFound.numberResolvedAccounts + this.userFound.numberUnresolvedAccounts);
                this.userFound.winRate = parseInt(winRate.toString());
            }).catch(er => {
                this.userFound = null;
            })
        },
        sendFriendRequest(){
            this.friendRequestDto.receiverId = this.userFound.id;
            Friend.sendFriendRequest(this.friendRequestDto).then(response => {
                console.log(response.data);
                alert("Solicitação de amizade enviada!");
            })
            .catch();
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
        User.getByToken().then(response =>{
            this.friendRequestDto.requesterId = response.data.id;
        }).catch(er => {
            this.$router.push('/error');
        })
    }
}
</script>

<template>
    <!-- v-for="user in users" -->
    <template v-if="loading">
        <div class="container">
            <br>
                <div class="spinner-border text-dark" role="status">
            </div>
        </div>
    </template>
    
    <template v-else>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12 col-sm-4">
                    <div class="user-container left-space">
                        <div class="user-name">{{ current_user.firstName }} {{ current_user.lastName }}</div>
                        <button class="profile-button"  @click="selectCurrentUser()">Ver seu perfil</button>
                    </div>
                    <hr style="border-color:black; margin: 0px; margin-bottom: 10px; padding: 0px;">
                    <div class="flex-line left-space">
                        <p style="font-size:20px;">Amigos:</p> 
                        <router-link to="/friends/request">
                            <button class="btn btn-success btn-sm">Adicionar amigo</button>
                        </router-link>
                    </div>
                    <ul class="list-group">
                        <li class="list-group-item" v-for="user in friends" @click="selectUser(user)">{{ user.firstName }} {{user.lastName}}</li>
                    </ul>
                </div>
                <template v-if="selected_user != null">
                    <div class="col-12 col-sm-8">
                        <br>
                        <div class="friend-info">
                            <h2>{{selected_user.firstName}} {{selected_user.lastName}}</h2>
                            <p>Email: {{selected_user.email}}</p>
                            <p>Taxa de acertos: {{ selected_user.winRate }}%</p>
                            <p>Acertos: {{selected_user.numberResolvedAccounts}} </p>
                            <p>Erros: {{selected_user.numberUnresolvedAccounts}}</p>
                        </div>
                    </div>
                </template>
                <template v-else>
                    <div class="col-12 col-sm-8">
                        <br>
                        <div class="friend-info">
                            <div class="flex-line">
                                <h2>{{current_user.firstName}} {{current_user.lastName}}</h2>
                                <button class="btn btn-warning mb-1">Editar</button>
                            </div>
                            <p>Email: {{current_user.email}}</p>
                            <p>Taxa de acertos: {{ current_user.winRate }}%</p>
                            <p>Acertos: {{current_user.numberResolvedAccounts}} </p>
                            <p>Erros: {{current_user.numberUnresolvedAccounts}}</p>
                        </div>
                    </div>
                </template>
            </div>
        </div>

    </template>
</template>

<script>
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return{
            loading: true,
            current_user: null,
            selected_user: null,
            friends: []
        }
    },
    methods:{
        selectUser(user){
            this.selected_user = user;
        },
        selectCurrentUser(){
            this.selected_user = null;
        }
    },
    mounted() {
        User.getByToken().then(response => {
            var userId = response.data.id;
            this.current_user = response.data;
            var played = this.current_user.numberUnresolvedAccounts + this.current_user.numberResolvedAccounts;
            this.current_user.winRate = this.current_user.numberResolvedAccounts * 100 / played;
            return Promise.all([
                Friend.getFriendsByUserId(userId),
            ]);
        })
        .then(([friendsResponse]) => {
            this.friends = friendsResponse.data;
            this.loading = false;
        })
        .catch(error => {
            console.log(error);
            this.$router.push('/error');
        });
    }
}
</script>

<style scoped>
.btn-success{
    border-color: #1ABC9C;
    background-color: #1ABC9C;
}
.btn-success:hover{
    border-color: #198754;
    background-color: #198754;
}
.btn-primary{
    border-color: #8E44AD;
    background-color: #8E44AD;
    height: 40px;
    margin-top: 10px;
}
.friend-info {
    padding: 20px;
    background-color: #eee;
    border-radius: 5px;
    height: 100%;
}
.list-group-item{
    cursor: pointer;
}
.list-group-item:hover {     
    background-color: #0d6efa;  
}
.list-group-item:focus {     
    background-color:#0d6efd;  
    color: white;
}
.left-space{
    padding-left: 10px;
}
.flex-line{
    display: flex;
    justify-content: space-between;
}

.user-container {
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 10px;
    font-family: Arial, sans-serif;
}

.user-name {
    font-size: 25px;
    font-weight: bold;
    margin-right: 10px;
}

.profile-button {
    background-color: #4CAF50;
    color: white;
    border: none;
    padding: 8px 10px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 14px;
    border-radius: 4px;
    cursor: pointer;
}
</style>
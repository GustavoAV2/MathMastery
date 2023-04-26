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
                    <div class="row">
                        <div class="col">
                            <h2>Amigos:</h2>
                        </div>
                    </div>
                    <router-link to="/friends/request">
                        <button class="btn btn-success btn-sm">Enviar convite de amizade</button>
                    </router-link>
                    <hr>
                    <ul class="list-group">
                        <li class="list-group-item" v-for="user in friends" @click="selectUser(user)">{{ user.firstName }} {{user.lastName}}</li>
                    </ul>
                </div>
                <template v-if="selected_friend != null">
                    <div class="col-12 col-sm-8">
                        <br>
                        <div class="friend-info">
                            <h2>{{selected_friend.firstName}} {{selected_friend.lastName}}</h2>
                            <p>Email: {{selected_friend.email}}</p>
                            <p>Taxa de acertos: {{ selected_friend.winRate }}%</p>
                            <p>Acertos: {{selected_friend.numberResolvedAccounts}} </p>
                            <p>Erros: {{selected_friend.numberUnresolvedAccounts}}</p>
                        </div>
                    </div>
                </template>
                <template v-else>
                    <div class="col-12 col-sm-8">
                        <br>
                        <div class="friend-info">
                            <h2>Nenhum amigo selecionado</h2>
                        </div>
                    </div>
                </template>
            </div>
        </div>

    </template>
</template>

<script >
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return{
            loading: true,
            selected_friend: null,
            friends: []
        }
    },
    methods:{
        selectUser(user){
            this.selected_friend = user;
        }
    },
    mounted() {
        User.getByToken().then(response => {
            var userId = response.data.id;
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
</style>
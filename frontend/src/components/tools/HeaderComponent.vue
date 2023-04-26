<template>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm border-bottom">
            <div class="container-fluid">
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <router-link to="/" class="nav-link">Inicio</router-link>
                        </li>
                        
                        <template v-if="token != null">
                            <li class="nav-item">
                                <router-link to="/profile" class="nav-link">Perfil</router-link>
                            </li>

                            <li class="nav-item">
                                <router-link to="/friends" class="nav-link">Amigos</router-link>
                            </li>
                        </template> 
                    </ul>
                    
                    <ul class="navbar-nav">
                        <template v-if="token != null">
                            <template v-if="notifications">
                                <div class="dropdown">
                                    <span><span class="n-notification">{{ notifications.length }}</span> notificações</span>
                                    <div class="dropdown-content">
                                        <p v-for="(notification, index) in notifications" :key="index">
                                            {{ notification.username }} solicitou amizade
                                            <button @click="accept(notification)" class="btn btn-success btn-sm">Aceitar</button>
                                            <button @click="decline(notification)" class="btn btn-danger btn-sm">Negar</button>
                                        </p>
                                    </div>
                                </div>
                            </template>
                            <li class="nav-item">
                                <form class="form-inline" >
                                    <button type="submit" class="btn btn-danger" @click="logout()">Logout</button>
                                </form>
                            </li>
                        </template> 

                        <template v-else>
                            <li class="nav-item">
                                <router-link to="/register" class="nav-link text-dark">Register</router-link>
                            </li>
                            <li class="nav-item">
                                <router-link to="/sign" class="nav-link text-dark">Login</router-link>
                            </li>
                        </template> 
                    </ul>

                </div>
            </div>
        </nav>
    </header>
</template>

<script>
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return{
            token: null,
            notifications: [
                {username: 'Joao'},{username: 'Junior'}
            ],
        }
    },
    methods:{
        logout(){
            localStorage.clear();
            var token = localStorage.getItem('token');
            User.logout(token).then(response => {
                console.log(response.data)
            }).catch(()=>{});
        },

        accept(notification) {
        console.log(`Aceitando solicitação de amizade de ${notificacao.user}...`)
        },
        decline(notification) {
        console.log(`Negando solicitação de amizade de ${notificacao.user}...`)
        }
    },
    mounted() {
        User.getByToken().then(response => {
            this.token = localStorage.getItem('token')
            var userId = response.data.id;
            return Promise.all([
                Friend.getFriendsNotifications(userId),
            ]);
        })
        .then(([notificationsResponse]) => {
            console.log(notificationsResponse.data);
            this.notifications = notificationsResponse.data;
        })
        .catch(error => {
            console.log(error);
        });
    }
}
</script>

<style>
.username{
    margin:0px;
    padding:0px;
}
.nav-link {
    cursor: pointer;
    text-decoration: none;
    color: #FFFFFF;
}
.navbar-brand{
    color: #E67E22;
}
.nav-link:hover {
    color: #1ABC9C;
}
header{
    background-color: black;
}
.n-notification{
    color: #E67E22;
}
.dropdown {
    cursor: pointer;
    color: #f9f9f9;
    position: relative;
    display: inline-block;
    margin-right: 20px;
    margin-top: 5px;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  padding: 12px 16px;
  z-index: 1;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>

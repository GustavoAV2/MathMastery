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
                            <li class="nav-item" style="cursor:pointer;">
                                <a class="nav-link text-dark">
                                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar" class="rounded-circle img-fluid" style="width: 30px;">
                                    <!-- {{ user.name }} -->
                                </a>
                            </li>
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

export default {
    data(){
        return{
            token: null,
            user: {"username": ""}
        }
    },
    methods:{
        logout(){
            localStorage.clear();
            User.logout(this.token).then(response => {
                console.log(response.data)
            }).catch(()=>{});
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
        // if (this.token != null){
        //     User.getByToken(this.token).then(response => {
        //         console.log(response.data)
        //         this.user = response.data;
        //     }).catch(()=>{})
        // }
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
</style>
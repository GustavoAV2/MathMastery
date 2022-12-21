<template>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow">
            <div class="container-fluid">
                <a class="navbar-brand">Math WebSite</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link">Home</a>
                        </li>
                        
                        <template v-if="token != null">
                            <li class="nav-item">
                                <a class="nav-link">Profile</a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link">Friends</a>
                            </li>
                        </template> 

                        <li class="nav-item">
                            <a class="nav-link">Challenges</a>
                        </li>
                    </ul>
                    
                    <ul class="navbar-nav">
                        <template v-if="token != null">
                            <li class="nav-item" style="cursor:pointer;">
                                <a class="nav-link text-dark">
                                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-chat/ava3.webp" alt="avatar" class="rounded-circle img-fluid" style="width: 30px;">
                                    {{ user.name }}
                                </a>
                            </li>
                            <li class="nav-item">
                                <form class="form-inline" >
                                    <button type="submit" class="btn btn-danger">Logout</button>
                                </form>
                            </li>
                        </template> 

                        <template v-else>
                            <li class="nav-item">
                                <router-link to="/register" class="nav-link text-dark">Register</router-link>
                            </li>
                            <li class="nav-item">
                                <router-link to="/sing" class="nav-link text-dark">Login</router-link>
                            </li>
                        </template> 
                    </ul>

                </div>
            </div>
        </nav>
    </header>
    
    <!-- <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="/">Echo</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link to="/" class="nav-link" id="home-nav-link" @click="clearForTest()">Home</router-link>
                    </li>
                    <template v-if="token != null">
                        <li class="nav-item">
                            <router-link to="/" class="nav-link" id="sign-nav-link">{{user.username}}</router-link>
                        </li>
                    </template>
                    <template v-else>
                        <li class="nav-item">
                            <router-link to="/sign" class="nav-link" id="sign-nav-link">Entrar</router-link>
                        </li>
                    </template>
                </ul>
            </div>
        </div>
    </nav> -->

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

<style>
.username{
    margin:0px;
    padding:0px;
}
.nav-link {
    text-decoration: none;
    color: black;
}

.nav-link:hover {
    color: gray;
}
</style>
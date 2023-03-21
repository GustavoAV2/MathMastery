<template>
    <!-- v-for="user in users" -->
    <div class="container-fluid">
		<div class="row">
			<div class="col-12 col-sm-4">
                <h2>Friends List</h2>
                <router-link to="/friends/request">
                    <button class="btn btn-success btn-sm">Enviar convite de amizade</button>
                </router-link>
                <hr>
				<ul class="list-group">
					<li class="list-group-item">Friend 1</li>
					<li class="list-group-item">Friend 2</li>
					<li class="list-group-item">Friend 3</li>
					<li v-for="user in users" class="list-group-item" @click="selectUser()">{{ user.firstName }} {{user.lastName}}</li>
				</ul>
			</div>
			<div class="col-12 col-sm-8">
                <br>
				<div class="friend-info">
					<h2>{{actual_friend.firstName}} {{actual_friend.lastName}}</h2>
					<p>Email: {{actual_friend.email}}</p>
					<p>Taxa de acertos: {{ actual_friend.winRate }}%</p>
					<p>Acertos: {{actual_friend.numberResolvedAccounts}} </p>
					<p>Erros: {{actual_friend.numberUnresolvedAccounts}}</p>
				</div>
			</div>
		</div>
    </div>

</template>

<script >
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return{
            userId: "",
            actual_friend: {
                firstName: "Gustavo",
                lastName: "Voltolini",
                email: "guga@gmail.com",
                winRate: 0,
                numberResolvedAccounts: "1",
                numberUnresolvedAccounts: "12"
            },
            friendUsers: [],
        }
    },
    methods:{
        selectUser(){

        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
        User.getByToken().then(response =>{
            this.userId = response.data.id;
        }).catch(er => {
            console.log(er);
            this.$router.push('/error');
        })
        
        if (this.userId){
            Friend.getFriendsByUserId().then(response => {
                this.friendUsers = response.data;
            }).catch(er => {
                console.log(er);
                this.friendUsers = [];
            })
        }
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
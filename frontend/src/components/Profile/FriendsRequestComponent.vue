<template>
    <div class="container mt-5">
		<h1 class="mb-4">Solicitação de amizade</h1>
        <div class="form-group">
            <label for="friend-email">Nome de usuário:</label>
            <input type="text" v-model="friendRequestDto.username" class="form-control" id="friend-email" name="friend-email" required>
        </div>
        <br>
        <button type="submit" @click="sendFriendRequest()" class="btn btn-success">Enviar solicitação</button>
	</div>
</template>

<script>
import User from '@/services/users'
import Friend from '@/services/friends'

export default {
    data(){
        return {
            friendRequestDto: {
                username: ""
            },
        }
    },

    methods:{
        sendFriendRequest(){
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
            this.token = localStorage.getItem("token");
        }).catch(er => {
            this.$router.push('/error');
        })
    }
}
</script>

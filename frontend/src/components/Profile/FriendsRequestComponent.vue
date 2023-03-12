<template>
    <div class="container mt-5">
		<h1 class="mb-4">Solicitação de amizade</h1>
        <div class="form-group">
            <label for="friend-email">Email do usuário:</label>
            <input type="email" v-model="usernameOrEmail" class="form-control" id="friend-email" name="friend-email" required>
        </div>
        <button type="submit" @click="sendFriendRequest()" class="btn btn-primary">Enviar solicitação</button>
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
            }
        }
    },
    methods:{
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

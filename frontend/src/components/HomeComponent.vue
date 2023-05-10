<template>
	<div class="jumbotron jumbotron-fluid">
		<div class="container">
			<h1 class="home-message">Teste suas habilidades matemáticas!</h1>
			<p class="lead home-message">Desafie-se com problemas matemáticos de diferentes níveis de dificuldade e expanda seu conhecimento.</p>
		</div>
	</div>
    <div class="container">
        <div class="row">
            <div class="col-sm" @click="moveToGame('1')">
                <h3>Normal</h3>
                <img src="@/assets/img/ICONS/black-hole-1.png"/>
                <hr class="my-4 cards-divisor"/>
                <h4>Adição e subtração</h4>
                <h4>Sem tempo para resolver</h4>
                <h4>Multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>
            <div class="col-sm" @click="moveToGame('2')">
                <h3>Dificil</h3>
                <img src="@/assets/img/ICONS/black-hole-2.png"/>
                <hr class="my-4 cards-divisor"/>
                <h4>Adição, subtração e divisão</h4>
                <h4>Tempo para resolver</h4>
                <h4>Multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>
            <div class="col-sm" @click="moveToGame('3')">
                <h3>Genial</h3>
                <img src="@/assets/img/ICONS/black-hole-3.png"/>
                <hr />
                <h4>Adição, subtração, divisão e multiplicação</h4>
                <h4>Tempo para resolver</h4>
                <h4>Sem multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>  
        </div>
        <br>
        <template v-if="!token">
            <router-link to="/register">
                <button type="button" class="btn btn-primary btn-lg btn-block" @click="moveToRegister()">Registrar</button>
            </router-link>
            <button class="btn btn-game btn-lg btn-block" @click="moveToGame('1')">Iniciar desafio</button>
            <p class="home-message">Registre-se para rankear seu perfil, adicionar amigos e evoluir com eles.</p>
        </template>
        <template v-else>
            <button class="btn btn-game full-with btn-lg btn-block" @click="moveToGame('1')">Iniciar desafio</button>
            <p class="home-message">(Este botão te levara para o modo normal)</p>
        </template>
    </div>
</template>

<script >
export default {
    data(){
        return{
            token: null,
        }
    },
    methods:{
        moveToRegister(){
            this.$router.push('/register');
        },
        moveToGame(difficultyParam){
            this.$router.push('/mathgame/' + difficultyParam);
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
    }
}
</script>

<style scoped>  
body{
    color: black;
}
.container{
    color: black;
}
.btn-primary {
    color: #1ABC9C;
    width: 30%;
    height: 100px;
    border-width:3px;
    border-radius: 0px;
    border-style:solid;
    border-color:#1ABC9C;
    background-color: white;
}
.btn-primary:hover {
    box-shadow: 0px 8px 15px #1ABC9C;
    color: black;
    background-color: #17A589;
}
.btn-game{
    color: #8E44AD;
    height: 100px;
    width: 70%;
    border-width:3px;
    border-radius: 0px;
    border-style:solid;
    border-color:#8E44AD;
    background-color: white;
    
}
.full-with{
    width: 100%;
}
.btn-game:hover{
    box-shadow: 0px 8px 15px #8E44AD;
    color: black;
    background-color: #8E44AD;
}
.home-message{
    color: black;
}
.button-36{
    width: 50%;
}
.col-sm{
    margin:5px;
    border-width:2px;
    border-style:solid;
    border-color:black;
    border-radius: 5px;
    cursor: pointer;
}
.col-sm:hover{
    margin:5px;
    border-width:2px;
    border-style:solid;
    border-color:#1ABC9C;
    border-radius: 5px;
    transition: 0.2s;
}
.col-sm img{
    width: 120px;
}
.card {
    background-color: #FFFFFF;
    color: #34495E;
}

.cards-divisor{
    border-color: black;
}
</style>

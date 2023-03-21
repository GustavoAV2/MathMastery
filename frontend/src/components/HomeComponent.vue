<template>
	<div class="jumbotron jumbotron-fluid">
		<div class="container">
			<h1 class="home-message">Teste suas habilidades matemáticas!</h1>
			<p class="lead home-message">Desafie-se com problemas matemáticos de diferentes níveis de dificuldade e expanda seu conhecimento.</p>
			<hr class="my-4">
			<p class="home-message">Registre-se para começar a resolver problemas.</p>
		</div>
	</div>
    <div class="container">
        <hr class="my-4 cards-divisor">
        <div class="row">
            <div class="col-sm">
                <h3>Normal</h3>
                <img src="@/assets/img/ICONS/black-hole-1.png"/>
                <hr class="my-4 cards-divisor"/>
                <h4>Adição e subtração</h4>
                <h4>Sem tempo para resolver</h4>
                <h4>Multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>
            <div class="col-sm">
                <h3>Dificil</h3>
                <img src="@/assets/img/ICONS/black-hole-2.png"/>
                <hr class="my-4 cards-divisor"/>
                <h4>Adição, subtração e divisão</h4>
                <h4>Tempo para resolver</h4>
                <h4>Multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>
            <div class="col-sm">
                <h3>Genial</h3>
                <img src="@/assets/img/ICONS/black-hole-3.png"/>
                <hr />
                <h4>Adição, subtração, divisão e multiplicação</h4>
                <h4>Tempo para resolver</h4>
                <h4>Sem multiplas escolhas</h4>
                <h4>Cinco desafios</h4>
            </div>  
        </div>
        <hr class="my-4 cards-divisor">
        <router-link to="/register">
            <button type="button" class="btn btn-primary btn-lg btn-block">Registrar</button>
        </router-link>
        <button class="btn btn-game btn-lg btn-block" @click="createGame(info)">Iniciar desafio</button>
    </div>
</template>

<script >
export default {
    data(){
        return{
            token: null,
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
    border-width:1px;
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
    border-width:1px;
    border-radius: 0px;
    border-style:solid;
    border-color:#8E44AD;
    background-color: white;
    
}
.btn-game:hover{
    box-shadow: 0px 8px 15px #8E44AD;
    color: black;
    background-color: #8E44AD;
}
.home-message{
    color: black;
}
</style>

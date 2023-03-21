<template>
<div class="container">
    <h2>Dificuldade:</h2>
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
    </div>
    <hr class="my-4 cards-divisor">
    <button class="" @click="createGame(info)">Iniciar desafio</button>
</div>
</template>

<script>    
export default {
    data(){
        return{
            token: null,
            user: null,
            info: "normal"
        }
    },
    mounted() {
        this.token = localStorage.getItem("token");
    },
    methods:{
        setInfo(infoNum){
            if (infoNum == 1){
                console.log("Easy Checked");
                this.info = "easy";
            }
            if (infoNum == 2) {
                console.log("Normal Checked")
                this.info = "normal";
            }
            if (infoNum == 3) {
                console.log("Hard Checked")
                this.info = "hard";
            }
            if (infoNum == 4) {
                console.log("Genius Checked")
                this.info = "genius";
            }
        },
        createGame(info){
            this.$router.push('/mathgame/' + info)
        }
    }
}
</script>
<style>
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
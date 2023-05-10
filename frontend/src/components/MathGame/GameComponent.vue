<template>
<div class="container">
<template v-if="!loading == true">
    <section class="jumbotron text-center">
        <p style="font-size: 20px;">{{game.challengesPlayed + 1}} / 5</p>

        <div style="margin-top:8%" class="container">
            <h1 class="jumbotron-heading">
                {{game.challenge.firstNumber}} {{operation}} {{game.challenge.lastNumber}}
            </h1>
            <p class="lead text-muted">Solve this challenge if you can!</p>
        </div>
    </section>

    <div class="container" style="width: 50%;">
        <div class="control-cont">
            <div id="loading" class="loading centralize">
                <h4 style="padding: 0px; font-size: 5px; color:white;"><strong id="seconds">{{seconds}}s</strong></h4>
            </div>
        </div>
    </div>

    <template v-if="difficulty == '2' || difficulty == '3'">
        <div class="container-numbers">
            <label class="form-label" for="typeNumber">Reposta do cálculo</label>
            <input v-model="inputResult" type="number" class="form-control shadow-none" />
            <button class="btn btn-dark" @click="generateNewGame()">Enviar</button>
        </div>
    </template>
    
    <template v-else>
        <div id="options">
                <div v-for="result in game.randomResults">
                    <button class="btn-alternative btn-dark" @click="sendValueAndRequestGame(result)">{{result}}</button>
                </div>
        </div>
    </template>
    
    <div style="padding-right: 20%; padding-left: 20%;">
        <div style="display: flex; flex-direction: row; align-content: space-around; justify-content: space-evenly;">
            <div>
                <img id="dumb" src="../../assets/img/dumb.png" alt="Dumb" /> 
                <strong id="dumb-label" style="font-size: 45px;">{{game.challengesUnsolved}}</strong>
            </div>
            <div>
                <img id="nerd" src="../../assets/img/right.png" alt="Right" />
                <strong id="nerd-label" style="font-size: 45px;">{{game.challengesSolve}}</strong>
            </div>
        </div>
    </div>
</template>

<template v-else>
    <div class="loading-container">
        <div class="spinner-border" role="status">
            <span class="sr-only"></span>
        </div>
    </div>
</template>
</div>
</template>

<script >
import Game from '@/services/game'
export default{
    props:{
        difficulty: String,
    },
    data(){
        return{
            loading: true,
            seconds: 30,
            width: 100,
            game: {
                challenge: {
                    operation: "",
                    firstNumber: "",
                    lastNumber: "",
                    actualResult: "",
                },
                randomResults: [],    
                challengesSolve: "",
                challengesUnsolved: "",
                challengesPlayed: ""
            },
            inputResult: ""
        }
    },
    computed:{
        operation(){
            if (this.game.challenge.operation == 'Sum'){
                return "+";
            }
            if (this.game.challenge.operation == 'Subtract'){
                return "-";
            }
            if (this.game.challenge.operation == 'Multiply'){
                return "x";
            }
            return "÷";
        },
        lenOfResult(){
            return this.game.challenge.actualResult.toString().length;
        }
    },
    methods:{
        setNewProgressBar(){
            console.log("Reestruturando tempo e elementos;")
            this.seconds = 30;
            this.width = 100;
            var div = document.getElementById("loading");
            div.style.width = "100%";
            div.style.backgroundColor = "#673FD7";
            div.style.border = "solid #673FD7";   
        },
        requestNextGame(){
            console.log("Requisitando próximo game")
            this.game.result = parseInt(this.inputResult);
            var game = { ...this.game, ...this.game.challenge}
            game.difficulty = this.difficulty;
            console.log(this.game)
            Game.nextGame(game).then(response => {
                this.game = response.data
                if (this.game.challengesPlayed >= 5){
                    localStorage.setItem('challengesSolve', this.game.challengesSolve);
                    localStorage.setItem('challengesUnsolved', this.game.challengesUnsolved);
                    this.$router.push("/mathgame/result");
                }
            }).
            catch(() => {
                this.$router.push("/error");
            })
        },
        runProgressBar(){
            const div = document.getElementById("loading");
            if (this.seconds > 1) {
                this.seconds = this.seconds - 1;
                this.width = this.width - 3;
                div.style.width = this.width + "%";
            }
            else {
                this.seconds = "";
                div.style.width = "0%";
                div.style.backgroundColor = "white";
                div.style.border = "none";   
            }
        },
        sendValueAndRequestGame(value){
            this.inputResult = value;
            this.generateNewGame();
        },
        async runGame(){
            while (this.seconds != 0){
                await new Promise(r => setTimeout(r, 1000));
                this.runProgressBar();
            }
            if (this.seconds == 0){
                this.generateNewGame();
            }
        },
        generateNewGame(){
            this.requestNextGame();
            this.setNewProgressBar();
        }
    },
    async created(){
        while(this.game.challengesPlayed < 5){
            this.loading = false;
            await this.runGame();
        }
    },
    mounted() {
        Game.createGame(this.difficulty).then(response => {
            this.game = response.data;
            console.log(this.game);
        }).
        catch(() => {
            this.$router.push("/error");
        });
    }
}
</script>

<style scoped>
#typeNumber{
    width: 50%;
}
.container-numbers{
    display: flex;
    flex-direction: column;
    justify-content: center;
    margin-right: 30%;
    margin-left: 30%;
}

.form-control{
    text-align: center;
    margin-bottom: 5px;
}

input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}

#options{
    display: flex;
    flex-direction: row;
}

.btn-alternative:hover {
    transition: 0.5s;
    background-color: #673FD7;
}

.btn-alternative:focus {
    background-color: #673FD7;
    color: black;
}
</style>
<template>
<div class="container">
    <form asp-action="Index" asp-controller="MathGame" method="post">
        <div style="display: flex; flex-direction: column; justify-content: center;">
           <h2>Dificuldade:</h2>

            <label class="form-control" style="padding: 15px; display: flex; justify-content: space-evenly; flex-direction: row;">
                <div class="btn-group btn-group-toggle" style="width: 100%; height: 100%;" data-toggle="buttons">
                    <label class="btn btn-secondary active">
                        <input type="radio" v-on:focus="setInfo(1)" name="difficulty" id="option1" autocomplete="off" value="easy">
                        <p>Facil</p>
                    </label>
                    <label class="btn btn-success">
                        <input type="radio" checked v-on:focus="setInfo(2)" name="difficulty" id="option2" autocomplete="off" value="normal">
                        <p>Normal</p> 
                    </label>
                    <label class="btn btn-danger">
                        <input type="radio" v-on:focus="setInfo(3)" name="difficulty" id="option3" autocomplete="off" value="hard">
                        <p>Dificil</p>
                    </label>
                    <label class="btn btn-dark">
                        <input type="radio" v-on:focus="setInfo(4)" name="difficulty" id="option4" autocomplete="off" value="genius">
                        <p>Genial</p>
                    </label>
                </div>
            </label>

            <br />
            <template v-if="info == 'easy'">
                <div class="card border-primary mb-3 fade-in" id="easy-info">
                    <div class="card-header">Como funciona essa dificuldade?</div>
                    <div class="card-body text-primary">
                        <h5 class="card-title">Facil</h5>
                        <p class="card-text">Addition and subtraction, no time to resolve, multiple choice, five challenges.</p>
                    </div>
                </div>
            </template>
            
            <template v-if="info == 'normal'">
                <div class="card border-success mb-3 fade-in" id="normal-info">
                    <div class="card-header">Como funciona essa dificuldade?</div>
                    <div class="card-body text-success">
                        <h5 class="card-title">Normal</h5>
                        <p class="card-text">Addition and subtraction, no time to resolve, multiple choice, five challenges.</p>
                    </div>
                </div>
            </template>

            <template v-if="info == 'hard'">
                <div class="card border-danger mb-3 fade-in" id="hard-info">
                    <div class="card-header">Como funciona essa dificuldade?</div>
                    <div class="card-body text-danger">
                        <h5 class="card-title">Dificil</h5>
                        <p class="card-text">Addition, subtraction and division, <strong>time to resolve</strong>, multiple choice, five challenges.</p>
                    </div>
                </div>
            </template>

            <template v-if="info == 'genius'">
                <div class="card border-dark mb-3 fade-in" id="genius-info">
                    <div class="card-header">Como funciona essa dificuldade?</div>
                    <div class="card-body text-dark">
                        <h5 class="card-title">Genial</h5>
                        <p class="card-text">Addition, subtraction, division and multiplication, <strong>time to resolve, no multiple choice</strong>, five challenges.</p>
                    </div>
                </div>
            </template>

            <br />
            <button type="submit" class="button-36" role="button">Iniciar desafio</button>
        </div>
    </form>
</div>
</template>

<script>    
import User from '@/services/users'

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
        if (this.token != null){
            User.getByToken(this.token).then(response => {
                console.log(response.data)
                this.user = response.data;
            }).catch(()=>{})
        }
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
        }
    }
}
</script>

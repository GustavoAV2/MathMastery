<template>
<link rel="stylesheet" href="~/css/create_game.css" asp-append-version="true" />
<div class="container">
    <section class="jumbotron text-center">
        <p style="font-size: 20px;">{{game.resolvedProblems}} / {{game.maxChallenges}}</p>

        <div style="margin-top:8%" class="container">
            <h1 class="jumbotron-heading">
                {{game.firstNumber}} {{operation}} {{game.lastNumber}}
            </h1>
            <p class="lead text-muted">Solve this challenge if you can!</p>
            <div style="display: flex; flex-direction: row-reverse; align-items: center; justify-content: center;">
                <p>
                    <form v-for="result in results" method="post">
                        <input type="hidden" name="FirstNumber" value={{game.FirstNumber}}>
                        <input type="hidden" name="LastNumber" value={{game.LastNumber}}>
                        <input type="hidden" name="Operation" value={{game.Operation}}>
                        <input type="hidden" name="ChallengesSolve" value={{game.ChallengesSolve}}>
                        <input type="hidden" name="ChallengesUnsolved" value={{game.ChallengesUnsolved}}>
                        <input type="hidden" name="result" value={{result}}>
                        <button class="btn-alternative btn-dark">{{result}}</button>
                    </form>
                </p>
            </div>
        </div>
    </section>

    <div style="padding-right: 20%; padding-left: 20%;">
        <div style="display: flex; flex-direction: row; align-content: space-around; justify-content: space-evenly;">
            <div>
                <img style="margin: 20px;" height="100px" width="100px" src="/img/dumb.png" alt="Dumb" /> 
                <strong style="font-size: 45px;">{{game.challengesUnsolved}}</strong>
            </div>
            <div>
                <img style="margin: 20px;" height="100px" width="100px" src="/img/right.png" alt="Right" /> 
                <strong style="font-size: 45px;">{{game.challengesSolve}}</strong>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import User from '@/services/users'

export default {
    data(){
        return{
            token: null,
            user: null,
            game: {}
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
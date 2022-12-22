<template>

<div class="container">
    <section class="jumbotron text-center">
        <p style="font-size: 20px;">{{resolvedProblems}} / {{game.maxChallenges}}</p>

        <div style="margin-top:8%" class="container">
            <h1 class="jumbotron-heading">
                {{game.firstNumber}} {{operation}} {{game.lastNumber}}
            </h1>
            <p class="lead text-muted">Solve this challenge if you can!</p>
        </div>
    </section>

    <div class="container" style="width: 50%;">
        <div class="control-cont">
            <div id="loading" class="loading centralize">
                <h4 style="padding: 0px; font-size: 5px; color:white;"><strong id="seconds">30s</strong></h4>
            </div>
        </div>
    </div>

    <template v-if="difficulty == GameDifficulty.Hard || difficulty == GameDifficulty.Genius">
        <section class ="jumbotron text-center">
            <div id="options">
                <form id="form-high-level">
                    <input v-for="ex in result_examples" type="text" class="number" placeholder="0" onkeydown="limit(this);" onkeyup="limit(this);">

                    <input type="hidden" name="FirstNumber" value=@game.FirstNumber>
                    <input type="hidden" name="LastNumber" value=@game.LastNumber>
                    <input type="hidden" name="Operation" value=@game.Operation>
                    <input type="hidden" name="ChallengesSolve" value=@game.ChallengesSolve>
                    <input type="hidden" name="ChallengesUnsolved" value=@game.ChallengesUnsolved>
                    <input type="hidden" name="result" id="result" value="0">
                </form>
            </div>
        </section>
    </template>
    
    <template v-else>
        <section class ="jumbotron text-center">
            <div id="options">
                <p>
                    <form v-for="result in results">
                        <input type="hidden" name="firstNumber" value={{game.firstNumber}}>
                        <input type="hidden" name="lastNumber" value={{game.lastNumber}}>
                        <input type="hidden" name="operation" value={{game.operation}}>
                        <input type="hidden" name="challengesSolve" value={{game.challengesSolve}}>
                        <input type="hidden" name="challengesUnsolved" value={{game.challengesUnsolved}}>
                        <input type="hidden" name="result" id="result" value={{result}}>
                        <button class="btn-alternative btn-dark" >@result</button>
                    </form>
                </p>
            </div>
        </section>
    </template>
    <div style="padding-right: 20%; padding-left: 20%;">
        <div style="display: flex; flex-direction: row; align-content: space-around; justify-content: space-evenly;">
            <div>
                <img id="dumb" src="/img/dumb.png" alt="Dumb" /> 
                <strong id="dumb-label" style="font-size: 45px;">{{game.challengesUnsolved}}</strong>
            </div>
            <div>
                <img id="nerd" src="/img/right.png" alt="Right" />
                <strong id="nerd-label" style="font-size: 45px;">{{game.ChallengesSolve}}</strong>
            </div>
        </div>
    </div>
</div>
</template>

<script >
import User from '@/services/users'

export default {
    data(){
        return{
            token: null,
            user: {"username": ""},
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
<!-- 
<script>
    function limit(element, id) {
        var max_chars = 1;
        if (element.value.length > max_chars) {
            element.value = element.value.substr(1, 2);
        }
    }

    function setResult() {
        var value = "";
        var inputs = document.getElementsByClassName("number");
        for (var i = 0; i < inputs.length; i++) {
            value += inputs[i].value;
        }
        document.getElementById("result").value = value;
    }

    function setAutoSubmitInInput() {
        var inputs = document.getElementsByClassName("number");
        inputs[inputs.length - 1].addEventListener("input", () => {
            setResult();
            document.getElementById("form-high-level").submit();
        })
    }

    function intervalSeconds() {
        const second_label = document.getElementById("seconds");
        if (seconds > 1) {
            seconds = seconds - 1;
            second_label.innerHTML = seconds + "s";
        }
        else {
            second_label.innerHTML = "";
            clearInterval(intervalSeconds);
        }
    }

    function intervalFunction() {
        const div = document.getElementById("loading");

        if (width > 1) {
            width = width - 1;
            div.style.width = width + "%";
            console.log(width);
        }
        else {
            div.style.width = "0%";
            div.style.backgroundColor = "white";
            div.style.border = "none";
            setResult();
            document.getElementById("form-high-level").submit();
            clearInterval(intervalFunction);
        }
    }

    if (document.getElementById("form-high-level")) {
        setAutoSubmitInInput();
    }

    var seconds = 30;
    var width = 100;

    setInterval(intervalFunction, 300);
    setInterval(intervalSeconds, 1000);
</script> -->

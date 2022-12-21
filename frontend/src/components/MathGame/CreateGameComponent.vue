<template>
<link rel="stylesheet" href="~/css/create_game.css" asp-append-version="true" />

<div class="container">
    <form asp-action="Index" asp-controller="MathGame" method="post">
        <div style="display: flex; flex-direction: column; justify-content: center;">
           <h2>Dificuldade:</h2>

            <label class="form-control" style="padding: 15px; display: flex; justify-content: space-evenly; flex-direction: row;">
                <div class="btn-group btn-group-toggle" style="width: 100%; height: 100%;" data-toggle="buttons">
                    <label class="btn btn-secondary active">
                        <input type="radio" name="Difficulty" id="option1" autocomplete="off" value="@GameDifficulty.Easy" onfocus="setInfo(1)">
                        <p>Facil</p>
                    </label>
                    <label class="btn btn-success">
                        <input type="radio" name="Difficulty" id="option2" autocomplete="off" value="@GameDifficulty.Normal" onfocus="setInfo(2)">
                        <p>Normal</p> 
                    </label>
                    <label class="btn btn-danger">
                        <input type="radio" name="Difficulty" id="option3" autocomplete="off" value="@GameDifficulty.Hard" onfocus="setInfo(3)">
                        <p>Dificil</p>
                    </label>
                    <label class="btn btn-dark">
                        <input type="radio" name="Difficulty" id="option4" autocomplete="off" value="@GameDifficulty.Genius" onfocus="setInfo(4)">
                        <p>Genial</p>
                    </label>
                </div>
            </label>

            <br />
            <div class="card border-primary mb-3 fade-in" id="easy-info">
                <div class="card-header">Como funciona essa dificuldade?</div>
                <div class="card-body text-primary">
                    <h5 class="card-title">Facil</h5>
                    <p class="card-text">Addition and subtraction, no time to resolve, multiple choice, five challenges.</p>
                </div>
            </div>

            <div class="card border-success mb-3" id="normal-info">
                <div class="card-header">Como funciona essa dificuldade?</div>
                <div class="card-body text-success">
                    <h5 class="card-title">Normal</h5>
                    <p class="card-text">Addition and subtraction, no time to resolve, multiple choice, five challenges.</p>
                </div>
            </div>

            <div class="card border-danger mb-3" id="hard-info">
                <div class="card-header">Como funciona essa dificuldade?</div>
                <div class="card-body text-danger">
                    <h5 class="card-title">Dificil</h5>
                    <p class="card-text">Addition, subtraction and division, <strong>time to resolve</strong>, multiple choice, five challenges.</p>
                </div>
            </div>

            <div class="card border-dark mb-3" id="genius-info">
                <div class="card-header">Como funciona essa dificuldade?</div>
                <div class="card-body text-dark">
                    <h5 class="card-title">Genial</h5>
                    <p class="card-text">Addition, subtraction, division and multiplication, <strong>time to resolve, no multiple choice</strong>, five challenges.</p>
                </div>
            </div>

            <br />
            <button type="submit" class="button-36" role="button">Iniciar desafio</button>
        </div>
    </form>
</div>
</template>
<!-- 
<script>    
    function startFunc(){
        if (document.getElementById("option1").checked){
            document.getElementById("easy-info").style.display = "flex";
        }
        if (document.getElementById("option2").checked) {
            document.getElementById("normal-info").style.display = "flex";
        }
        if (document.getElementById("option3").checked) {
            document.getElementById("hard-info").style.display = "flex";
        }
        if (document.getElementById("option4").checked) {
            document.getElementById("genius-info").style.display = "flex";
        }
    }

    function disableAllInfo(){
        document.getElementById("easy-info").style.display = "none";
        document.getElementById("normal-info").style.display = "none";
        document.getElementById("hard-info").style.display = "none";
        document.getElementById("genius-info").style.display = "none";
    }

    function setInfo(infoNum){
        if (infoNum == 1){
            console.log("Easy Checked")
            disableAllInfo();
            document.getElementById("easy-info").style.display = "flex";
        }
        if (infoNum == 2) {
            console.log("Normal Checked")
            disableAllInfo();
            document.getElementById("normal-info").style.display = "flex";
        }
        if (infoNum == 3) {
            console.log("Hard Checked")
            disableAllInfo();
            document.getElementById("hard-info").style.display = "flex";
        }
        if (infoNum == 4) {
            console.log("Genius Checked")
            disableAllInfo();
            document.getElementById("genius-info").style.display = "flex";
        }
    }

    disableAllInfo();
    startFunc();
</script> -->
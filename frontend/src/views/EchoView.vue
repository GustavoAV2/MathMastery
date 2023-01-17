<template>
    <EchoHeader current-page="sign" />
    <div class="container-fluid echo-container">
        <div class="row text-center mt-3">
            <div class="col-12">
                <span class="h2">Primeiras compras da casa nova</span><br>
                <span class="h5">22/04/2023</span>
            </div>
        </div>
        <div class="row mt-2 text-center echo-image">
            <div class="col-12">
                img
            </div>
        </div>
        <div class="row mt-2 text-center echo-description">
            <div class="col-12">
                Comecei a morar com meu amigo Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur quasi facilis excepturi nostrum veniam, voluptates architecto. Quas corrupti quod ducimus dolore illo vero repudiandae sed accusamus, nisi enim eveniet odio!
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                Impressões: 82
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                Quem está neste echo?
            </div>
            <div class="col-12">
                @volto
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                [ Mudança ] [ Amigos ] [ Verão ]
            </div>
        </div>
        <div class="row mt-2 text-center echo-data">
            <div class="col-12 py-4">
                <svg width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd"><path d="M11 21.883l-6.235-7.527-.765.644 7.521 9 7.479-9-.764-.645-6.236 7.529v-21.884h-1v21.883z"/></svg>

            </div>
        </div>
    </div>
    <div class="container-fluid echo-container">
        <div class="row text-center mt-3">
            <div class="col-12">
                <span class="h2">Aniversário na praia</span><br>
                <span class="h5">19/06/2023</span>
            </div>
        </div>
        <div class="row mt-2 text-center echo-image">
            <div class="col-12">
                img
            </div>
        </div>
        <div class="row mt-2 text-center echo-description">
            <div class="col-12">
                Aniversário de 21 anos na praia em Itapema Lorem ipsum dolor sit amet consectetur adipisicing elit. Quibusdam veniam dolores nulla reprehenderit similique amet exercitationem! Vero veniam a, architecto repellendus deserunt quas sequi iste quos nulla, assumenda saepe impedit.
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                Impressões: 23
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                Quem está neste echo?
            </div>
            <div class="col-12">
                @volto, @rafa
            </div>
        </div>
        <div class="row mt-2 text-start echo-data">
            <div class="col-12">
                [ Festa ] [ Praia ] [ Summer ]
            </div>
        </div>
    </div>
</template>
<script>
import EchoHeader from '../components/EchoHeader.vue';

export default {
    components: { EchoHeader }
}
</script>
<style>
.echo-image {
    height: 200px;
    align-items: center;
}

.echo-description {
    border: 1px solid black;
    padding: 20px;
    background-color: gray;
    font-size: 15px;
}
</style>
<template lang="">
    <WebHeader current-page="home" />
    <div class="container">
        <h1>Como jogar?</h1>
        <p>
            Aqui está uma descrição de como funcionam os desafios e o formato das partidas:
        </p>
    
        <h2>
            Desafios Disponíveis:
        </h2>
        <ul>
            <li>
                <strong>Normal:</strong> 
                Este é o nível de dificuldade mais básico, adequado para iniciantes. 
                Os desafios neste nível envolvem apenas operações de soma e subtração.
            </li>
            <li>
                <strong>Difícil:</strong>
                Neste nível, os desafios são um pouco mais complexos. 
                Além das operações de soma e subtração, também incluímos operações de multiplicação.
            </li>
            <li>
                <strong>Genial:</strong> 
                O nível mais avançado, onde os desafios são projetados para desafiar até mesmo os jogadores mais 
                experientes. Aqui, você encontrará desafios com soma, subtração, multiplicação e divisão.
            </li>
            <li>
                <strong>Dificuldade Crescente:</strong> 
                Cada nível de dificuldade apresenta um aumento gradual na complexidade dos números utilizados nos desafios.
                Isso significa que, à medida que você avança para níveis mais difíceis, 
                os números nas operações matemáticas se tornam mais desafiadores.
            </li>
        </ul>
    
        <h2>
            Estrutura da Partida:
        </h2>
        <p>
            Ao iniciar uma partida, você será submetido a uma série de 5 desafios. Em cada desafio, 
            você enfrentará um problema matemático diferente, selecionado aleatoriamente com base na dificuldade escolhida. 
            O objetivo é resolver cada desafio no menor tempo possível, garantindo a resposta correta.
        </p>
    
        <h2>
            Resultados e Classificação:
        </h2>
        <p>
            Ao final de cada partida, o seu resultado será computado e poderá ser visto publicamente. 
            Isso permite que você compare seu desempenho com o de seus colegas e acompanhe seu progresso ao longo do tempo.
            A classificação mostrará a pontuação obtida em cada partida e o posicionamento em relação aos outros jogadores.
        </p>
    
        <hr style="border-color: black;">
        <p>
            Lembramos que o objetivo principal dos desafios é o desenvolvimento do raciocínio rápido, lógico e matemático.
            Portanto, mesmo que você não obtenha a pontuação máxima, cada partida é uma oportunidade de 
            aprendizado e melhoria contínua.
        </p>
        <p>
            A aba "Como Jogar" fornecerá informações mais detalhadas sobre cada nível de dificuldade, 
            exemplos de desafios matemáticos encontrados em cada um deles e dicas úteis para melhorar o desempenho.
            Estamos comprometidos em oferecer uma experiência envolvente e desafiadora que contribua para o
            aprimoramento das habilidades matemáticas dos nossos usuários.
        </p>
        <p>
            Divirta-se jogando e desafiando seus amigos para ver quem se sai melhor nos desafios matemáticos!
        </p>
    </div>
    
  <FooterComponent />
</template>

<script>
import WebHeader from '@/components/tools/HeaderComponent.vue';
import FooterComponent from '@/components/tools/FooterComponent.vue';

export default {
  components:{WebHeader, FooterComponent},
}
</script>

<style>
@import '@/assets/css/site.css';
@import '@/assets/css/home.css';
@import 'https://www.w3schools.com/w3css/4/w3.css';
@import 'https://www.w3schools.com/lib/w3-theme-black.css';
@import 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css';

.container{
    /* margin-left: 50px;
    margin-right: 50px; */
    padding-left: 80px;
    padding-right: 80px;
}
</style>
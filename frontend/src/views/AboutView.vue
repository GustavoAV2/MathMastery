<template lang="">
  <WebHeader current-page="home" />
  <div class="container">
    <h1>Sobre</h1>
    <p>
      Bem-vindo ao Math Mastery, nosso de desafios matemáticos! Aqui, 
      os usuários têm acesso a uma plataforma interativa que visa desenvolver 
      o raciocínio rápido, lógico e matemático. Nossa missão é proporcionar 
      um ambiente desafiador e divertido, onde você pode aprimorar suas habilidades 
      mentais e se conectar com outros entusiastas da matemática.
    </p>
    
    <h2>Desafios Matemáticos</h2>
    <p>
      Ao se cadastrar, você terá a oportunidade de participar de uma 
      variedade de desafios matemáticos. Cada desafio apresenta uma pergunta ou problema matemático, 
      e seu objetivo é resolvê-lo da maneira mais rápida e precisa possível.
    </p>
    
    <h2>Adicionar Amigos</h2>
    <p>
      Além disso, você também pode adicionar amigos à sua lista de contatos no site. 
      Isso permitirá que você acompanhe o desempenho dos seus amigos nos desafios e 
      compare seus resultados. Essa funcionalidade promove a competição amigável e 
      incentiva a melhoria contínua.
    </p>
    
    <h2>Importância do Raciocínio Rápido, Lógico e Matemático</h2>
    <p>
      Desenvolver raciocínio rápido, lógico e matemático é importante por diversos motivos. 
      Em primeiro lugar, essas habilidades são fundamentais em muitas áreas da vida, desde a 
      resolução de problemas cotidianos até o sucesso acadêmico e profissional. Ao aprimorar 
      seu raciocínio rápido, você se torna mais eficiente em tomar decisões 
      rápidas e lidar com situações desafiadoras.
    </p>
    <p>
      Além disso, o raciocínio lógico e matemático é essencial para a compreensão de conceitos
      complexos, a formulação de argumentos sólidos e a resolução de problemas abstratos. 
      Essas habilidades ajudam a desenvolver a capacidade de pensar de forma crítica, analítica e criativa.
    </p>
    
    <h2>Diferentes Níveis de Dificuldade</h2>
    <p>
      Esse site oferece diferentes níveis de dificuldade para os desafios matemáticos, 
      permitindo que você escolha aqueles que se adequam ao seu nível de habilidade. 
      Isso significa que iniciantes e especialistas em matemática 
      podem encontrar desafios adequados às suas necessidades e continuar progredindo em suas habilidades.
    </p>

    <h2>Sobre o criador</h2>
    <p>
        Olá, meu nome é Gustavo Voltolini, criei esse site para fins de estudos e com a intenção de
        proporcionar um ambiente de aprendizado interativo e estimulante.
        Estou animado para tê-lo aqui e espero que você aproveite a 
        jornada de aprimorar suas habilidades matemáticas enquanto se diverte com os desafios. 
        Boa sorte e divirta-se!
    </p>
    <h4>Meu perfil:</h4>
    <a href="https://github.com/GustavoAV2">GitHub</a><br>
    <a href="https://www.linkedin.com/in/gustavo-voltolini/">Linkedin</a>

  </div>

</template>

<script>
import WebHeader from '../components/tools/HeaderComponent.vue';

export default {
  components:{WebHeader},
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

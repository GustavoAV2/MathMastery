<template>
    <div style="width: 100%; height: 100%;">
        <header class="w3-container w3-theme w3-padding" id="myHeader">
          <div class="w3-center">
          <h1 class="w3-xxxlarge w3-animate-bottom">Voce esta pronto?</h1>
            <div class="w3-padding-32">
                <template  v-if="token != null">
                    <a>
                        <router-link to="/sign">
                            <button class="w3-btn w3-xlarge w3-dark-grey w3-hover-light-grey" style="font-weight:900;">
                                Iniciar!
                            </button>
                        </router-link>
                    </a>
                </template>

                <template v-else>
                    <a>
                        <router-link to="/sign">
                            <button class="w3-btn w3-xlarge w3-dark-grey w3-hover-light-grey" style="font-weight:900;">
                                Iniciar!
                            </button>
                        </router-link>
                    </a>
                    <a>
                        <router-link to="/sign">
                            <button class="w3-btn w3-xlarge w3-dark-grey w3-hover-light-grey" style="font-weight:900;">
                                Login
                            </button>
                        </router-link>
                    </a>
                </template>
            </div>
          </div>
        </header>
    
        <!-- Modal -->
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content w3-card-4 w3-animate-top">
              <header class="w3-container w3-theme-l1"> 
                <span onclick="document.getElementById('id01').style.display='none'"
                class="w3-button w3-display-topright">×</span>
                <h4>Oh snap! We just showed you a modal..</h4>
                <h5>Because we can <i class="fa fa-smile-o"></i></h5>
              </header>
              <div class="w3-padding">
                <p>Cool huh? Ok, enough teasing around..</p>
                <p>Go to our <a class="w3-btn" href="/w3css/default.asp">W3.CSS Tutorial</a> to learn more!</p>
              </div>
              <footer class="w3-container w3-theme-l1">
                <p>Modal footer</p>
              </footer>
            </div>
        </div>
    
        <div class="w3-row-padding w3-center w3-margin-top">
            <template v-if="token != null">
                <a>
                    <div class="w3-third" id="normal-submit">
                        <div class="w3-card w3-container" style="min-height:460px">
                            <h3>Normal</h3>
                            <img src="@/assets/img/ICONS/black-hole-1.png"/>
                            <hr />
                            <h4>Addition and subtraction</h4>
                            <h4>No time to resolve</h4>
                            <h4>Multiple choice</h4>
                            <h4>Five challenges</h4>
                        </div>
                    </div>
                </a>
                <a>
                    <div class="w3-third">
                        <div class="w3-card w3-container" id="hard-submit" style="min-height:460px">
                            <h3>Hard</h3>
                            <img src="@/assets/img/ICONS/black-hole-2.png"/>
                            <hr />
                            <h4>Subtraction, addition and division</h4>
                            <h4>Time to resolve</h4>
                            <h4>Multiple choice</h4>
                            <h4>Five challenges</h4>
                        </div>
                    </div>
                </a>
                <a>
                    <div class="w3-third" id="genius-submit">
                        <div class="w3-card w3-container" style="min-height:460px">
                            <h3>Genius</h3>
                            <img src="@/assets/img/ICONS/black-hole-3.png"/>
                            <hr />
                            <h4>Subtraction, addition, division and multiplication</h4>
                            <h4>Time to resolve</h4>
                            <h4>No multiple choice</h4>
                            <h4>Five challenges</h4>
                        </div>
                    </div>
                </a>
            </template>
            <template v-else>
                <a>
                    <div class="w3-third">
                        <div class="w3-card w3-container" style="min-height:460px">
                            <h3>Normal</h3>
                            <img src="@/assets/img/ICONS/black-hole-1.png"/>
                            <hr />
                            <h4>Addition and subtraction</h4>
                            <h4>No time to resolve</h4>
                            <h4>Multiple choice</h4>
                            <h4>Five challenges</h4>
                        </div>
                    </div>
    
                    <div class="w3-third">
                        <div class="w3-card w3-container" style="min-height:460px;">
                            <h3>Hard</h3>
                            <img src="@/assets/img/ICONS/black-hole-2.png"/>
                            <hr />
                            <h4>Subtraction, addition and division</h4>
                            <h4>Time to resolve</h4>
                            <h4>Multiple choice</h4>
                            <h4>Five challenges</h4>
                        </div>
                    </div>
    
                    <div class="w3-third">
                      <div class="w3-card w3-container" style="min-height:460px">
                          <h3>Genius</h3>
                          <img src="@/assets/img/ICONS/black-hole-3.png"/>
                          <hr />
                          <h4>Subtraction, addition, division and multiplication</h4>
                          <h4>Time to resolve</h4>
                          <h4>No multiple choice</h4>
                          <h4>Five challenges</h4>
                      </div>
                    </div>
                </a>
            </template>
        </div>
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
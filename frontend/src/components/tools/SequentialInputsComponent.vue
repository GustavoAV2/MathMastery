<template lang="">
    <div>
        <!-- section class ="jumbotron text-center">
            <div id="options">
                <div id="form-high-level">
                    <input v-for="index in lenOfResult" :id="index" v-on:input="limit(index)" type="text" class="number" placeholder="0">
                </div>
            </div>
        </section>< -->
    </div>
</template>
<script>
// export default {
//     methods:{
//         limit(index){
//             var inputs = document.getElementsByClassName("number");

//             for (var i = 0; i < inputs.length; i++) {
//                 var input = inputs[i];
//                 if (input.id == index.toString()){
//                     if (input.value.length > 1){
//                         input.value = input.value.substr(1,2);
//                     }
//                 }
//                 if (input.id > index){
//                     inputs[i].focus();
//                     break;
//                 }
//                 else if (input.id == inputs.length){
//                     this.generateNewGame();
//                     var firstInput = document.getElementsByClassName("number")[0];
//                     firstInput.focus();
//                 }
//             }
//     }
// }
</script>
<style lang="">
    
</style>
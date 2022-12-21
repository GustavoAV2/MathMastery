export default{
    data(){
        return {
            message:{
                content: null,
                type: null
            }
        }    
    },

    methods:{
        generateMessage(msg, type){
            this.message.content = msg
            this.message.type = type
            setTimeout(()=>{
                this.message.content = null
                this.message.type = null
            }, 2500)
        }
    }
}
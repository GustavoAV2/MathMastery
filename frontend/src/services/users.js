import {http} from '../services/config'

export default{
    login(user){
        return http.post('/user/login', user)
    },
    create(user){
        return http.post('/user', user)
    },
    getByToken(){
        return http.get('/user/me')
    },
    getByUsernameOrEmail(username){
        return http.get('/user/friend/' + username)
    },
    update(user, id){
        return http.put('/user/' + id, user)
    },
    updateGameUserStatus(payload, id){
        return http.put('/user/game/' + id, payload)
    },
    desactive(id){
        return http.delete('/user/desactive/' + id)
    }
}
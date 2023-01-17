import {http} from '../services/config'

export default{
    login(user){
        return http.post('/user/login', user)
    },
    create(user){
        return http.post('/user', user)
    },
    getById(id){
        return http.get('/user/' + id)
    },
    getByToken(token){
        return http.get('/user/me/' + token)
    },
    getByUsername(username){
        return http.get('/user/' + username)
    },
    update(user, id){
        return http.put('/user/' + id, user)
    },
    desactive(id){
        return http.delete('/user/desactive/' + id)
    }
}
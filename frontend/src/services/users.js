import {http} from '../services/config'

export default{
    login(user){
        return http.post('/users/login', user)
    },
    create(user){
        return http.post('/users', user)
    },
    getById(id){
        return http.get('/users/' + id)
    },
    getByToken(token){
        return http.get('/users/me/' + token)
    },
    getByUsername(username){
        return http.get('/users/' + username)
    },
    update(user, id){
        return http.put('/users/' + id, user)
    },
    desactive(id){
        return http.delete('/users/desactive/' + id)
    }
}
import {http} from '../services/config'

export default{
    sendFriendRequest(friendRequest){
        return http.post('/friend', friendRequest)
    },
    putFriendRequest(friendRequest){
        return http.put('/friend' + friendRequest)
    }
}
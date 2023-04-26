import {http} from '../services/config'

export default{
    sendFriendRequest(friendRequest){
        return http.post('/friend', friendRequest)
    },
    getFriendsNotifications(userId){
        return http.get('/friend/notifications/' + userId);
    },
    putFriendRequest(friendRequest){
        return http.put('/friend' + friendRequest)
    },
    getFriendsByUserId(userId){
        return http.get('/friend/' + userId)
    }
}
import {http} from '../services/client'

export default{
    sendFriendRequest(friendRequest){
        return http.post('/friend', friendRequest)
    },
    getFriendsNotifications(userId){
        return http.get('/friend/notifications/' + userId);
    },
    getFriendsByUserId(userId){
        return http.get('/friend/' + userId)
    },
    acceptFriendRequest(friendRequestId){
        return http.put('/friend/accept/' + friendRequestId)
    },
    declineFriendRequest(friendRequestId){
        return http.put('/friend/decline/' + friendRequestId)
    }
}
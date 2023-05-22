import axios from 'axios'

export const http = axios.create({
    baseURL: "http://18.231.69.144:8000/",
    headers: {
        'Authorization': {
            toString() {
                return `Bearer ${localStorage.getItem("token")}`
            }
        }
    }
})

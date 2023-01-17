import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://localhost:7224/',
    headers: {
        'Authorization': {
            toString() {
                return `Bearer ${localStorage.getItem("token")}`
            }
        }
    }
})

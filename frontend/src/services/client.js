import axios from 'axios'

export const http = axios.create({
    baseURL: import.meta.env.BACKEND_URL,
    headers: {
        'Authorization': {
            toString() {
                return `Bearer ${localStorage.getItem("token")}`
            }
        }
    }
})

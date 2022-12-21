import axios from 'axios'

export const http = axios.create({
    baseURL: 'https://c092-2804-d57-4e1e-d500-88e1-ebb0-9705-8cca.sa.ngrok.io/',
    headers: {
        'Authorization': {
            toString() {
                return `Bearer ${localStorage.getItem('token')}`
            }
        }
    }
})

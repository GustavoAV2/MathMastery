import axios from 'axios'

export const http = axios.create({
    // baseURL: "https://localhost:7224/",
    baseURL: "https://gustavovolt-001-site1.ctempurl.com/",
    headers: {
        'Authorization': {
            toString() {
                return `Bearer ${localStorage.getItem("token")}`
            }
        }
    }
})

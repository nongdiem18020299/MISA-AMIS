var ApiConfig = {
    development: 'https://localhost:44391/'
}

export default ApiConfig[process.env.NODE_ENV];
import ApiConfig from "../config/ApiConfig.js";
import axios from "axios";

var BaseApiConfig = axios.create({
    baseURL: ApiConfig,
    headers: {
        'Content-type': 'application/json'
    }
})

export default BaseApiConfig;
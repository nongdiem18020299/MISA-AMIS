import BaseApiConfig from "./BaseApiConfig.js";

export default class BaseApi{
    constructor(){
        this.controller = null;
    }

    /**
     * Lấy toàn bộ dữ liệu
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    getAll(){
        return BaseApiConfig.get(`${this.controller}`, {header:{ "Access-Control-Allow-Origin": "*"}});
    }

    /**
     * Lấy dữ liệu theo trường
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    getField(field){
        return BaseApiConfig.get(`${this.controller}/${field}`);
    }

    /**
     * Lấy dữ liệu lọc
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    getFilter(filter, param){
        return BaseApiConfig.get(`${this.controller}/${filter}`, {params: param});
    }

    /**
     * Lấy dữ liệu theo Id
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    getId(id){
        return BaseApiConfig.get(`${this.controller}/${id}`);
    }

    /**
     * Post dữ liệu
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    post(data){
        return BaseApiConfig.post(`${this.controller}`, data);
    }

    /**
     * Sửa dũa liệu
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    put(id, data){
        return BaseApiConfig.put(`${this.controller}/${id}`, data)
    }

    /**
     * Xóa dữ liệu
     * Author: NTDIEM(21/07/2021)
     * @returns 
     */
    delete(id){
        return BaseApiConfig.delete(`${this.controller}/${id}`);
    }

}
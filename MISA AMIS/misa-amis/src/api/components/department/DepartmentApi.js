import BaseApi from "../../base/BaseApi.js";

class DepartmentApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/Department";
    }
}

export default new DepartmentApi();
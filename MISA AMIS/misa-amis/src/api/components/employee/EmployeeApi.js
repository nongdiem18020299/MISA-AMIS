import BaseApi from "../../base/BaseApi.js";

class EmployeeApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/employees";
    }
}

export default new EmployeeApi();
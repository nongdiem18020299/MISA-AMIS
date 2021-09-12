import BaseApi from "../../base/BaseApi.js";

class PositionApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/Positions";
    }
}

export default new PositionApi();
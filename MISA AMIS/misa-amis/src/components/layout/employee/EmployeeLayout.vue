<template>
  <div id="Employee-layout">
    <Header> </Header>
    <div class="employee-container">
      <employee-body-header
        @open-form="openForm('post')"
      ></employee-body-header>
      <employee-body
        :Employees="employees"
        :TotalPage="totalPage"
        :TotalRecord="totalRecord"
        :PageNumber="pageNumber"
        @load-data="getData"
        @paging="getData"
        @openForm="openForm"
        @openPopup="openPopup"
      ></employee-body>
    </div>
    <employee-dialog
      :key="formKey"
      v-if="isShowForm"
      @close-form="closeForm"
      @getNewForm="getNewForm"
      @loading="loadData"
      :EmployeeInf="employeeInf"
      :Departments="departments"
      :FormState="formState"
      @openPopup="openPopup"
      @openToast="openToast"
    ></employee-dialog>
    <popup-content
      v-if="isOpenPopup"
      :EmployeeId="employeeId"
      :Content="popupContent"
      :PopupType="popupType"
      @closePopup="closePopup"
      @loading="loadData"
      @closePopupAndForm="
        isOpenPopup = false;
        isShowForm = false;
      "
      @closePopupAndSave="
        isOpenPopup = false;
        isShowForm = false;
      "
      @openToast="openToast"
    ></popup-content>
    <loading-effect v-if="loading"></loading-effect>
    <toast-message
      :key="toastKey"
      v-if="isOpenToast"
      :toastMessage="toastMessage"
      :toastType="toastType"
    ></toast-message>
  </div>
</template>
<style scoped>
@import "../../../css/layout/EmployeeLayout.css";
@import "../../../css/common/Common.css";
</style>
<script>
import EmployeeBody from "../employee/EmployeeBody.vue";
import EmployeeBodyHeader from "../employee/EmployeeBodyHeader.vue";
import Header from "../Header.vue";
import EmployeeApi from "../../../api/components/employee/EmployeeApi.js";
import DepartmentApi from "../../../api/components/department/DepartmentApi.js";
import EmployeeDialog from "../../dialog/EmployeeDialog.vue";
import PopupContent from "../../popup/PopupContent.vue";
import LoadingEffect from "../../effect/LoadingEffect.vue";
import Enumeration from "../../../js/enum/Enumeration.js";
import EnumResources from "../../../js/enum/EnumResources.js";
import moment from "moment";
import ToastMessage from "../../toastMessage/toastMessage.vue";
// import Sidebar from './Sidebar.vue'
export default {
  name: "EmployeeLayout",
  components: {
    Header,
    EmployeeBodyHeader,
    EmployeeBody,
    EmployeeDialog,
    PopupContent,
    LoadingEffect,
    ToastMessage,
  },
  data() {
    return {
      employees: [],
      departments: [],
      isShowForm: false,
      totalPage: 0,
      totalRecord: 0,
      pageNumber: 0,
      pageSize: 0,
      inputSearch: "",
      employeeInf: {},
      isOpenPopup: false,
      employeeId: "",
      employeeCode: "",
      popupContent: "",
      popupType: "",
      loading: false,
      newEmployeeCode: "",
      formState: "",
      tableIndex: 0,
      formKey: 0,
      isOpenToast: false,
      toastType: "",
      toastMessage: "",
      toastKey:0,
    };
  },
  created() {
    //  this.getData();
    this.getNewEmployeeCode();
    this.getDepartment();
  },
  methods: {
    /**
     * Hàm lưu Form
     * CreateBy: NTDIEM(23/08/2021)
     */
    saveForm() {
      if (!this.isSave) {
        this.isSave = true;
      }
    },
    /**
     * Hàm lấythông tin nhân viên
     * CreateBy: NTDIEM(17/08/2021)
     */
    getData(pageNum, pageSize, inputSearch) {
      this.pageNumber = pageNum;
      this.pageSize = pageSize;
      this.inputSearch = inputSearch;
      this.loading = true;
      let param = {
        pageIndex: pageNum,
        pageSize: pageSize,
        employeeFilter: inputSearch,
      };
      EmployeeApi.getFilter("employeeFilter", param)
        .then((res) => {
          this.totalPage = res.data.totalPage;
          this.totalRecord = res.data.totalRecord;
          this.fomatData(res.data.data);
          this.loading = false;
        })
        .catch((res) => {
          this.loading = false;
          console.log(res);
        });
    },
    /**
     * Hàm fomat Data lấy từ API
     * CreateBy: NTDIEM(20/08/2021)
     */
    fomatData(employees) {
      for (var employee of employees) {
        for (var field in employee) {
          switch (field) {
            case "departmentId":
              employee[field] = this.formatDepartment(employee[field]);
              break;
            case "dateOfBirth":
              employee[field] = this.formatDate(employee[field]);
              break;
            case "identityDate":
              employee[field] = this.formatDate(employee[field]);
              break;
            case "gender":
              employee[field] = this.formatGender(employee[field]);
              break;
            default:
              break;
          }
        }
      }
      this.employees = employees;
    },
    /**
     * Hàm format phòng ban
     * CreateBy: NTDIEM(20/08/2021)
     */
    formatDepartment(data) {
      for (var department of this.departments) {
        // console.log(department['departmentId'] +" "+ data);
        if (department["departmentId"] == data) {
          return department["departmentName"];
        }
      }
    },
    /**
     * Hàm format ngày tháng
     * CreateBy: NTDIEM(20/08/2021)
     */
    formatDate(data) {
      if (data) {
        return moment(String(data)).format("DD/MM/YYYY");
      }
    },
    /**
     * Hàm format giới tình từ enum sang text
     * CreateBy: NTDIEM(20/08/2021)
     */
    formatGender(data) {
      var enumGender = Enumeration.Gender;
      // console.log(enumGender);
      for (var value in enumGender) {
        // console.log(data+" "+ value);
        if (data == enumGender[value]) {
          return EnumResources.Gender[value];
        }
      }
    },
    /**
     * Hàm mở Form thông tin nhân viên
     * CreateBy: NTDIEM(17/08/2021)
     */
    openForm(formState, employee, message) {
      this.formState = formState;
      if (message == "reply") {
        this.employeeInf = employee;
        this.employeeInf["employeeCode"] = this.newEmployeeCode;
      } else {
        if (employee) {
          this.employeeInf = employee;
        } else {
          this.employeeInf.employeeCode = this.newEmployeeCode;
        }
      }
      this.isShowForm = true;
    },
    /**
     * Hàm đóng Form thông tin nhân viên
     * CreateBy: NTDIEM(19/08/2021)
     */
    closeForm(isChange) {
      if (isChange) {
        this.openPopup("Notify", "", "");
      } else {
        this.loadData(true);
        this.isShowForm = false;
        this.getNewForm();
      }
    },
    /**
     * Hàm mở popup thông báo xóa
     * CreateBy: NTDIEM(19/08/2021)
     */
    openPopup(popupType, employeeId, employeeCode) {
      this.popupType = popupType;
      this.employeeId = employeeId;
      this.popupContent = employeeCode;
      // console.log(employeeId, employeeCode);
      this.isOpenPopup = true;
    },
    /**
     * Hàm đóng poppup
     * CreateBy: NTDIEM(19/08/2021)
     */
    closePopup() {
      this.isOpenPopup = false;
      // this.onLoading = false;
    },
    /**
     * Hàm lấy mã nhân viên mới
     * CreateBy: NTDIEM(20/08/2021)
     */
    async getNewEmployeeCode() {
      this.loading = true;
      await EmployeeApi.getField("NewEmployeeCode")
        .then((res) => {
          console.log(res);
          this.newEmployeeCode = res.data;
          this.loading = false;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm lấy thông tin phòng ban
     * CreateBy: NTDIEM(20/08/2021)
     */
    getDepartment() {
      console.log("?/");
      DepartmentApi.getAll()
        .then((res) => {
          console.log(res);
          this.departments = res.data;
        })
        .catch((res) => {
          console.log(res);
        });
    },
    /**
     * Hàm lấy dữ liệu cho form cất và thêm
     * CreateBy: NTDIEM(20/08/2021)
     */
    getNewForm() {
      console.log("lấy form mới");
      this.getNewEmployeeCode();
      this.formKey++;
      this.employeeInf = {};
      this.formState = "post";
      this.employeeInf['employeeCode'] = this.newEmployeeCode;
      console.log(this.employeeInf);
    },
    /**
     * Hàm loading dữ liệu
     * CreateBy: NTDIEM(20/08/2021)
     */
    loadData(state) {
      if (state) {
        this.getData(this.pageNumber, this.pageSize, this.inputSearch);
      }
    },
    /**
     * Hàm mở toast Message
     * CreateBy: NTDIEM(23/08/2021)
     */
    openToast(toastType, toastMessage){
      this.toastType = toastType;
      this.toastMessage = toastMessage;
      this.isOpenToast = true;
      this.toastKey++;
    }
  },
};
</script>
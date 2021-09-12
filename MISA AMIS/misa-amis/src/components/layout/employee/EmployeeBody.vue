<template>
  <div id="employee-body" class="">
    <div class="body-toolbar d-flex">
      <div class="search-input">
        <input
          class="search-tool"
          type="text"
          placeholder="Tìm theo mã, tên nhân viên"
          v-model="inputSearch"
          @keypress.enter="searchData"
        />
        <div class="search-icon"></div>
      </div>
      <div
        class="refresh-btn pointer"
        v-tooltip.top-center="'Lấy lại dữ liệu'"
        @click="reloadTable"
      ></div>
    </div>
    <div class="body-table">
      <table>
        <thead>
          <tr>
            <th class="check-box checkbox-header">
              <base-check-box :inputName="'checkbox'"></base-check-box>
            </th>
            <th>MÃ NHÂN VIÊN</th>
            <th>TÊN NHÂN VIÊN</th>
            <th>GIỚI TÍNH</th>
            <th>NGÀY SINH</th>
            <th>SỐ CMND</th>
            <th>CHỨC DANH</th>
            <th>TÊN ĐƠN VỊ</th>
            <th>SỐ TÀI KHOẢN</th>
            <th>TÊN NGÂN HÀNG</th>
            <th>CHI NHÁNH TK NGÂN HÀNG</th>
            <th>TỈNH/TP NGÂN HÀNG</th>
            <th>ĐỊA CHỈ</th>
            <th>ĐT DI ĐỘNG</th>
            <th>ĐT CỐ ĐỊNH</th>
            <th class="last-col-1">EMAIL</th>
            <th class="last-coll">CHỨC NĂNG</th>
          </tr>
        </thead>
        <tbody v-for="(employee, i) in Employees" :key="i">
          <tr>
            <td class="check-box-body">
              <base-check-box :inputName="'checkbox'"></base-check-box>
            </td>
            <td>{{ employee.employeeCode }}</td>
            <td>{{ employee.employeeName }}</td>
            <td>{{ employee.gender }}</td>
            <td>{{ employee.dateOfBirth }}</td>
            <td>{{ employee.identityNumber }}</td>
            <td>{{ employee.employeePosition }}</td>
            <td>{{ employee.departmentId }}</td>
            <td>{{ employee.bankAccountNumber }}</td>
            <td>{{ employee.bankName }}</td>
            <td>{{ employee.bankBranchName }}</td>
            <td>{{ employee.bankProvinceName }}</td>
            <td>{{ employee.address }}</td>
            <td>{{ employee.phoneNumber }}</td>
            <td>{{ employee.telephoneNumber }}</td>
            <td class="last-col-1">{{ employee.email }}</td>
            <td class="function">
              <function-box
                @openDrop="openDrop"
                @getInFo="getInfo(employee)"
                @closeDrop="isDrop = false"
                @openForm="openForm('default', 'put')"
                :isDrop="isDrop"
              ></function-box>
            </td>
          </tr>
        </tbody>
      </table>
      <dropdown-list
        v-if="isDrop"
        v-bind:style="{
          top: dropPosTop + 'px',
        }"
        @openPopup="openPopup"
        @openForm="openForm('reply', 'post')"
        @CloseDrop="closeDrop"
      ></dropdown-list>
    </div>
    <employee-footer
      :TotalPage="TotalPage"
      :TotalRecord="TotalRecord"
      :PageNumber="PageNumber"
      @footer-paging="paging"
    ></employee-footer>
  </div>
</template>

<script>
import BaseCheckBox from "../../base/BaseCheckBox.vue";
import DropdownList from "../../base/BaseFunctionList.vue";
import FunctionBox from "../../base/BaseFunctionBox.vue";
import EmployeeFooter from "./EmployeeFooter.vue";
// import EmployeeApi from "../../api/components/employee/EmployeeApi.js";
export default {
  name: "EmployeeBody",
  components: { EmployeeFooter, BaseCheckBox, FunctionBox, DropdownList },
  data() {
    return {
      isDrop: false,
      dropPosTop: 0,
      employee: {},
      pageNum: 0,
      pageSize: 0,
      inputSearch: "",
    };
  },
  props: {
    Employees: [],
    TotalPage: Number,
    TotalRecord: Number,
    PageNumber: Number,
  },
  created() {},
  methods: {
    /**
     * Phân trang
     * CreateBy: NTDIEM(16/08/2021)
     */
    paging(pageNum, pageSize) {
      this.pageNum = pageNum;
      this.pageSize = pageSize;
      this.searchData();
    },
    /**
     * Hàm tìm kiếm dữ liệu khi ngời dùng ấn enter
     * CreateBy: NTDIEM(23/08/2021)
     */
    searchData() {
      if (!this.inputSearch) {
        this.$emit("paging", this.pageNum, this.pageSize, "NV");
      } else {
        this.$emit("paging", this.pageNum, this.pageSize, this.inputSearch);
      }
    },
    /**
     * Hàm mở phần danh sách chức năng
     * CreateBy: NTDIEM(17/08/2021)
     */
    openDrop(dropPosTop) {
      this.isDrop = true;
      this.dropPosTop = dropPosTop - 100;
      console.log(dropPosTop);
    },
    /**
     * Hàm mở Form thông tin nhân viên
     * CreateBy: NTDIEM(16/08/2021)
     */
    openForm(message, formState) {
      this.$emit("openForm", formState, this.employee, message);
    },
    /**
     * Hàm mở popup thông báo xóa
     * CreateBy: NTDIEM(18/08/2021)
     */
    openPopup(popupType) {
      this.isDrop = false;
      // this.popupType=popupType;
      this.$emit(
        "openPopup",
        popupType,
        this.employee["employeeId"],
        this.employee["employeeCode"]
      );

      // console.log(this.employeeCode);
    },
    /**
     * Hàm lấy Id và mã nhân viên để mở popup
     * CreateBy: NTDIEM(16/08/2021)
     */
    getInfo(employee) {
      this.employee = employee;
    },
    /**
     * Hàm reload bảng nhân viên
     * CreateBy: NTDIEM(20/08/2021)
     */
    reloadTable() {
      this.paging(this.pageNum, this.pageSize);
    },
    /**
     * Hàm đóng danh sách chức năng
     * CreateBy: NTDIEM(20/08/2021)
     */
    closeDrop() {
      this.isDrop = false;
    },
  },
  watch: {},
};
</script>

<style>
@import "../../../css/layout/EmployeeBody.css";
</style>
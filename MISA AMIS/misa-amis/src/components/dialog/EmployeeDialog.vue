<template>
  <div class="dialog-container d-flex" :key="formIndex">
    <Draggable class="dialog-employee">
      <div class="dialog-header d-flex">
        <div class="dialog-header-title">Thông tin nhân viên</div>
        <div class="dialog-header-select d-flex">
          <div class="select-item d-flex">
            <base-check-box></base-check-box>
            <div class="item-label">Là khách hàng</div>
          </div>
          <div class="select-item d-flex">
            <base-check-box></base-check-box>
            <div class="item-label">Là nhà cung cấp</div>
          </div>
        </div>
        <div class="dialog-header-icon d-flex">
          <div class="icon-info" v-tooltip.bottom-center="'Giúp'"></div>
          <div class="icon-close" v-tooltip.bottom-center="'Đóng'" @click="closeForm"></div>
        </div>
      </div>
      <form action="" id="employee-form">
        <div class="group-top d-flex">
          <div class="group-top-left dflex">
            <div class="form-row d-flex">
              <div class="form-item input-code form-2-5 pr6">
                <div class="form-item-label">Mã <b>*</b></div>
                <base-input
                  :inputName="'Mã nhân viên'"
                  :isRequired="true"
                  :inputValue.sync="EmployeeInf.employeeCode"
                  ref="employeeCode"
                  @keyup.native="validateForm('employeeCode')"
                  @change.native="setIsChange"
                  tabindex="1"
                  v-tooltip.top-center="employeeCodeTooltip"
                ></base-input>
              </div>
              <div class="form-item form-3-5">
                <div class="form-item-label">Tên <b>*</b></div>
                <base-input
                  :inputName="'Tên'"
                  :isRequired="true"
                  :inputValue.sync="EmployeeInf.employeeName"
                  ref="employeeName"
                  @keyup.native="validateForm('employeeName')"
                  @change.native="setIsChange"
                  tabindex="2"
                  v-tooltip.top-center="employeeNameTooltip"
                ></base-input>
              </div>
            </div>
            <div class="form-row">
              <div class="form-item">
                <div class="form-item-label">Đơn vị <b>*</b></div>
                <base-dropdown
                  :inputName="'Đơn vị'"
                  :isRequired="true"
                  :valueArray="Departments"
                  :value.sync="EmployeeInf.departmentId"
                  ref="departmentId"
                  @keyup.native="validateForm('departmentId')"
                  @change.native="setIsChange"
                  tabindex="3"
                  v-tooltip.top-center="departmentIdTooltip"
                ></base-dropdown>
              </div>
            </div>
            <div class="form-row">
              <div class="form-item">
                <div class="form-item-label">Chức danh</div>
                <base-input
                  :inputValue.sync="EmployeeInf.employeePosition"
                  ref="employeePosition"
                  @change.native="setIsChange"
                  tabindex="4"
                ></base-input>
              </div>
            </div>
          </div>

          <div class="group-top-right dflex">
            <div class="form-row d-flex">
              <div class="form-item form-2-5 pr6">
                <div class="form-item-label">Ngày sinh</div>
                <date-picker
                  :format="'DD-MM-YYYY'"
                  :placeholder="'DD-MM-YYYY'"
                  v-model="EmployeeInf.dateOfBirth"
                  ref="dateOfBirth"
                  @change.native="setIsChange"
                  @focus.native="focusInput('dateOfBirth', 5)"
                  tabindex="5"
                ></date-picker>
              </div>
              <div class="form-item form-3-5 input-gender pl6">
                <div class="form-item-label">Giới tính</div>
                <div class="form-item-checkbox d-flex">
                  <base-check-box
                    :isRadioCheckbox="true"
                    :Checked="EmployeeInf.gender == 'Nam'"
                    :inputName="'radio'"
                    @click.native="setGender('Nam')"
                    @change.native="setIsChange"
                    :tabindex="6"
                  ></base-check-box>
                  <div class="item-label">Nam</div>
                  <base-check-box
                    :isRadioCheckbox="true"
                    :Checked="EmployeeInf.gender == 'Nữ'"
                    :inputName="'radio'"
                    @click.native="setGender('Nữ')"
                    @change.native="setIsChange"
                    :tabindex="7"
                  ></base-check-box>
                  <div class="item-label">Nữ</div>
                  <base-check-box
                    :isRadioCheckbox="true"
                    :Checked="EmployeeInf.gender == 'Khác'"
                    :inputName="'radio'"
                    @click.native="setGender('Khác')"
                    @change.native="setIsChange"
                    :tabindex="8"
                  ></base-check-box>
                  <div class="item-label">Khác</div>
                </div>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item input-code form-3-5 pr6">
                <div class="form-item-label">Số CMND</div>
                <base-input
                  :inputValue.sync="EmployeeInf.identityNumber"
                  ref="identityNumber"
                  @change.native="setIsChange"
                  tabindex="8"
                ></base-input>
              </div>
              <div class="form-item form-2-5">
                <div class="form-item-label">Ngày cấp</div>
                <date-picker
                  :format="'DD-MM-YYYY'"
                  :placeholder="'DD-MM-YYYY'"
                  v-model="EmployeeInf.identityDate"
                  ref="identityDate"
                  @change.native="setIsChange"
                  @focus.native="focusInput('identityDate', 9)"
                  tabindex="9"
                ></date-picker>
              </div>
            </div>
            <div class="form-row">
              <div class="form-item">
                <div class="form-item-label">Nơi cấp</div>
                <base-input
                  :inputValue.sync="EmployeeInf.identityPlace"
                  ref="identityPlace"
                  @change.native="setIsChange"
                  tabindex="10"
                ></base-input>
              </div>
            </div>
          </div>
        </div>
        <div class="group-bottom">
          <div class="form-row">
            <div class="form-item">
              <div class="form-item-label">Địa chỉ</div>
              <base-input
                :inputValue.sync="EmployeeInf.address"
                ref="address"
                @change.native="setIsChange"
                tabindex="11"
              ></base-input>
            </div>
          </div>
          <div class="form-row d-flex">
            <div class="form-item pr6">
              <div
                class="form-item-label"
                v-tooltip.top-center="'Số điện thoại di động'"
              >
                ĐT di động
              </div>
              <base-input
                :isPhoneNumber="true"
                :inputValue.sync="EmployeeInf.phoneNumber"
                ref="phoneNumber"
                @keyup.native="validateForm('phoneNumber')"
                @change.native="setIsChange"
                tabindex="12"
              ></base-input>
            </div>
            <div class="form-item pr6">
              <div
                class="form-item-label"
                v-tooltip.top-center="'Số điện thoại cố định'"
              >
                ĐT cố định
              </div>
              <base-input
                :inputValue.sync="EmployeeInf.telephoneNumber"
                ref="telephoneNumber"
                @input.native="validateForm('telephoneNumber')"
                @change.native="setIsChange"
                tabindex="13"
              ></base-input>
            </div>
            <div class="form-item">
              <div class="form-item-label">Email</div>
              <base-input
                :isEmail="true"
                :inputValue.sync="EmployeeInf.email"
                ref="email"
                @keyup.native="validateForm('email')"
                @change.native="setIsChange"
                tabindex="14"
              ></base-input>
            </div>
            <div class="form-item hidden">
              <div class="form-item-label"></div>
              <input class="form-item-input" type="text" />
            </div>
          </div>
          <div class="form-row d-flex">
            <div class="form-item pr6">
              <div class="form-item-label">Tài khoản ngân hàng</div>
              <base-input
                :inputValue.sync="EmployeeInf.bankAccountNumber"
                ref="bankAccountNumber"
                @change.native="setIsChange"
                tabindex="15"
              ></base-input>
            </div>
            <div class="form-item pr6">
              <div class="form-item-label">Tên ngân hàng</div>
              <base-input
                :inputValue.sync="EmployeeInf.bankName"
                ref="bankName"
                @change.native="setIsChange"
                tabindex="16"
              ></base-input>
            </div>
            <div class="form-item">
              <div class="form-item-label">Chi nhánh</div>
              <base-input
                :inputValue.sync="EmployeeInf.bankBranchName"
                ref="bankBranchName"
                @change.native="setIsChange"
                tabindex="17"
              ></base-input>
            </div>
            <div class="form-item hidden">
              <div class="form-item-label"></div>
              <input class="form-item-input" type="text" />
            </div>
          </div>
        </div>
        <div class="form-footer d-flex">
          <div class="left-side group-btn d-flex">
            <div
              class="cancel-btn form-footer-btn pointer"
              tabindex="18"
              @click="closeForm"
              @keypress.enter="closeForm"
            >
              Hủy
            </div>
          </div>
          <div class="right-side group-btn d-flex">
            <div
              class="form-footer-btn pointer"
              tabindex="19"
              @click="saveForm"
              @keypress.enter="saveForm"
            >
              Cất
            </div>
            <div
              class="form-footer-green-btn pointer"
              @click="saveForm('addNew')"
              tabindex="20"
              @keypress.enter="saveForm('addNew')"
              @keydown.tab.prevent="focusFirst"
            >
              Cất và thêm
            </div>
          </div>
        </div>
      </form>
    </Draggable>
    <popup-content
      v-if="isOpenPopup"
      :Content="popupContent"
      :PopupType="popupType"
      @closePopup="closePopup"
      @closePopupAndForm="
        isOpenPopup = false;
        closeForm();
      "
      @saveForm="
        isOpenPopup = false;
        saveForm();
      "
    ></popup-content>
  </div>
</template>

<script>
import EmployeeApi from "../../api/components/employee/EmployeeApi";
import Enumeration from "../../js/enum/Enumeration";
import EnumResources from "../../js/enum/EnumResources";
import BaseInput from "../base/BaseInput.vue";
import BaseCheckBox from "../base/BaseCheckBox.vue";
import BaseDropdown from "../base/BaseDropdown.vue";
import DatePicker from "vue2-datepicker";
import "vue2-datepicker/index.css";
import PopupContent from "../popup/PopupContent.vue";
export default {
  components: {
    BaseCheckBox,
    BaseInput,
    BaseDropdown,
    DatePicker,
    PopupContent,
  },
  name: "DialogEmployee",
  props: {
    EmployeeInf: {},
    Departments: [],
    FormState: String,
  },
  data() {
    return {
      inputChecked: false,
      employeeInf: {},
      newEmployeeCode: "",
      formIndex: 0,
      isChecked: false,
      failList: [],
      isChange: false,
      isOpenPopup: false,
      popupContent: "",
      popupType: "",
      departmentIdTooltip: "",
      employeeCodeTooltip: "",
      employeeNameTooltip: "",
    };
  },
  mounted() {
    // console.log(this.$refs.employeeCode);
    this.$refs.employeeCode.$el.lastChild.focus();
  },
  methods: {
    /**
     * Hàm trả về đúng khi có dữ liệu thay đổi
     * CreateBy: NTDIEM(24/08/2021)
     */
    setIsChange() {
      this.isChange = true;
    },
    /**
     * Hàm focus vào ô đầu tiên khi ấn tab ở nút cuối của form
     * CreateBy: NTDIEM(23/08/2021)
     */
    focusFirst() {
      this.$refs.employeeCode.$el.lastChild.focus();
    },
    /**
     * Hàm focus vào ô input đầu tiên bị lỗi
     * CreateBy: NTDIEM(23/08/2021)
     */
    focusFirstInputFail() {
      var field = this.failList[0];
      this.$refs[field].$el.querySelector("input").focus();
    },
    /**
     * Hàm focus vào input bên trong component
     * CreateBy: NTDIEM(24/08/2021)
     */
    focusInput(inputName, index) {
      console.log(this.$refs[inputName].$el.querySelector("input"));
      this.$refs[inputName].$el
        .querySelector("input")
        .setAttribute("tabindex", index);
      this.$refs[inputName].$el.querySelector("input").focus();
    },
    /**
     * Hàm đóng Form thông tin nhân viên
     * CreateBy: NTDIEM(17/08/2021)
     */
    closeForm() {
      if (this.isChange) {
        this.openPopup("Notify", "");
        this.isChange = false;
      } else {
        this.$emit("close-form");
      }
    },
    /**
     * Hàm đóng popup
     * CreateBy: NTDIEM(23/08/2021)
     */
    closePopup(){
       this.isOpenPopup = false;
       this.focusFirstInputFail();
    },
    /**
     * Hàm lưu thông tin nhân viên
     * CreateBy: NTDIEM(17/08/2021)
     */
    saveForm(state) {
      this.isChange = false;
      this.convertForm();
      var employeeInf = JSON.stringify(this.EmployeeInf);
      console.log(this.employeeInf);
      for (let ref in this.$refs) {
        this.validateForm(ref);
      }
      if (this.failList.length > 0) {
        var field = this.failList[0];
        // console.log();
        this.$emit(
          "openToast",
          "warning",
          "Vui lòng nhập đủ và đúng kiểu dữ liệu"
        );
        this.openPopup("Exception", this.$refs[field].inputName);
      } else {
        if (this.FormState == "post") {
          EmployeeApi.post(employeeInf)
            .then((res) => {
              console.log(res);
              this.getNewForm();
              this.$emit("loading", true);
              if (res.data.success == true) {
                if (state != "addNew") {
                  this.closeForm();
                  this.$emit("openToast", "success", "Thêm dữ liệu thành công");
                }
              } else {
                console.log(this.EmployeeInf.employeeCode);
                this.openPopup("Warning", "", this.EmployeeInf.employeeCode);
              }
            })
            .catch((res) => {
              console.log(res);
            });
        } else {
          EmployeeApi.put(this.employeeInf.employeeId, employeeInf)
            .then((res) => {
              console.log(res);
              this.getNewForm();
              if (res.data.success == true) {
                this.$emit("loading", true);
                if (state != "addNew") {
                  this.closeForm();
                  this.$emit("openToast", "success", "Sửa dữ liệu thành công");
                }
              } else {
                this.openPopup("Warning", "", this.EmployeeInf.employeeCode);
              }
            })
            .catch((res) => {
              console.log(res);
            });
        }
      }
    },
    /**
     * Hàm mở popup thông báo
     * CreateBy: NTDIEM(24/08/2021)
     */
    openPopup(popupType, popupContent) {
      this.popupContent = popupContent;
      this.popupType = popupType;
      this.isOpenPopup = true;
    },
    /**
     * Hàm validate Form thông tin nhân viên
     * CreateBy: NTDIEM(20/08/2021)
     */
    validateForm(e) {
      var inputValue = this.$refs[e].$el.firstChild.value;
      //validate các trường bắt buộc không được để trống
      if (!inputValue && this.$refs[e].isRequired) {
        console.log(this.$refs[e]);
        this.$refs[e].failState = true;
        this[`${e}Tooltip`] = this.$refs[e].inputName + " không được để trống";
        this.failList.push(e);
      } else {
        this[`${e}Tooltip`] = "";
        this.$refs[e].failState = false;
        const index = this.failList.indexOf(e);
        if (index > -1) {
          this.failList.splice(index, 1);
        }
      }

      //Validate Email
      // if (inputValue && this.$refs[e].isEmail) {
      //   const re =
      //     /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      //   if (!re.test(String(inputValue).toLowerCase())) {
      //     this.$refs[e].failState = true;
      //     this.$refs[e].$el.firstChild.title = "Email không đúng định dạng";
      //     this.failList.push(e);
      //   } else {
      //     this.$refs[e].failState = false;
      //     const index = this.failList.indexOf(e);
      //     if (index > -1) {
      //       this.failList.splice(index, 1);
      //     }
      //     // this.failList.splice(this.failList.indexOf(e),1);
      //   }
      // }
      //Validate số điện thoại
      // if (inputValue && this.$refs[e].isPhoneNumber) {
      //   const tel = /(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b/;
      //   if (!tel.test(inputValue)) {
      //     this.$refs[e].failState = true;
      //     this.$refs[e].$el.firstChild.title =
      //       "Số điện thoại không đúng định dạng";
      //     this.failList.push(e);
      //   } else {
      //     this.$refs[e].failState = false;
      //     const index = this.failList.indexOf(e);
      //     if (index > -1) {
      //       this.failList.splice(index, 1);
      //     }
      //     // this.failList.splice(this.failList.indexOf(e),1);
      //   }
      // }
    },
    /**
     * Hàm convet form từ client lên server
     * CreateBy: NTDIEM(20/08/2021)
     */
    convertForm() {
      //Convert phòng ban sang departmentId
      for (var department of this.Departments) {
        if (this.EmployeeInf["departmentId"] == department["departmentName"]) {
          this.EmployeeInf["departmentId"] = department["departmentId"];
        }
      }
      //convert dữ liệu giới tính sang enum
      this.EmployeeInf["gender"] = this.convertGender(
        this.EmployeeInf["gender"]
      );
    },
    /**
     * Hàm convert giới tính từ client lên server
     * CreateBy: NTDIEM(21/08/2021)
     */
    convertGender(data) {
      var enumResourceGender = EnumResources.Gender;
      for (var value in enumResourceGender) {
        if (data == enumResourceGender[value]) {
          return Enumeration.Gender[value].toString();
        }
      }
    },
    /**
     * Lấy mã nhân viên mới
     * CreateBy: NTDIEM(20/08/2021)
     */
    getNewForm() {
      console.log("gọi cha láy form mới");
      this.$emit("getNewForm");
    },
    /**
     * Đổi dữ liệu ngày tháng cho form
     * CreateBy: NTDIEM(23/08/2021)
     */
    formatDate(time) {
      if (time != null) {
        let dateString = String(time),
          d,
          x;
        d = dateString.split("/");
        x = d[1] + "/" + d[0] + "/" + d[2];
        return new Date(x);
      }
    },
    /**
     * Set dữ liệu giới tính khi check vào ô giới tính tương ưng
     * CreateBy: NTDIEM(23/08/2021)
     */
    setGender(gender) {
      this.EmployeeInf.gender = gender;
    },
  },
  created() {
    this.employeeInf = this.EmployeeInf;
    this.EmployeeInf.dateOfBirth = this.formatDate(
      this.EmployeeInf.dateOfBirth
    );
    this.EmployeeInf.identityDate = this.formatDate(
      this.EmployeeInf.identityDate
    );
  },
};
</script>

<style>
@import "../../css/dialog/DialogEmployee.css";
@import "../../css/common/Common.css";
</style>
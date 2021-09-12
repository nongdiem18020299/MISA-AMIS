<template>
  <div class="popup-wrap d-flex">
    <div class="popup-container">
      <div class="popup-content" v-if="PopupType == 'Delete'">
        <div class="popup-detail d-flex">
          <div class="popup-icon"></div>
          <div class="popup-notify">
            Bạn có thực sự muốn xóa Nhân viên &lt;<span>{{ Content }}</span>&gt; không?
          </div>
        </div>
      </div>
      <div class="popup-content" v-if="PopupType == 'Notify'">
        <div class="popup-detail d-flex">
          <div class="popup-icon-notify"></div>
          <div class="popup-notify">
            Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
          </div>
        </div>
      </div>
      <div class="popup-content" v-if="PopupType == 'Exception'">
        <div class="popup-detail d-flex">
          <div class="popup-icon-exception"></div>
          <div class="popup-notify">
            <span>{{ Content }}</span> không được để trống.
          </div>
        </div>
      </div>
      <div class="popup-content" v-if="PopupType == 'Warning'">
        <div class="popup-detail d-flex">
          <div class="popup-icon"></div>
          <div class="popup-notify">
            Mã nhân viên &lt;<span>{{ Content }}</span>&gt; đã tồn tại trong hệ thống.
          </div>
        </div>
      </div>
      <div class="popup-footer">
        <div class="popup-button-group d-flex" v-if="PopupType == 'Delete'">
          <div class="popup-footer left-side d-flex">
            <div class="footer-popup-btn pointer" @click="closePopup">
              Không
            </div>
          </div>
          <div class="popup-footer right-side d-flex">
            <div class="footer-green-btn pointer" @click="deleteEmployee">
              Có
            </div>
          </div>
        </div>
        <div class="popup-button-group d-flex" v-if="PopupType == 'Notify'">
          <div class="popup-footer left-side d-flex">
            <div class="footer-popup-btn pointer" @click="closePopup">Hủy</div>
          </div>
          <div class="popup-footer right-side d-flex">
            <div class="footer-popup-btn pointer" @click="closePopupAndForm">
              Không
            </div>
            <div class="footer-green-btn pointer" @click="closePopupAndSave">
              Có
            </div>
          </div>
        </div>
        <div
          class="popup-button-group d-flex align-center"
          v-if="PopupType == 'Exception'"
        >
          <div class="footer-green-btn pointer" @click="closePopup">Đóng</div>
        </div>
        <div
          class="popup-button-group d-flex right-side"
          v-if="PopupType == 'Warning'"
        >
          <div class="footer-green-btn pointer" @click="closePopup">Đồng ý</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EmployeeApi from "../../api/components/employee/EmployeeApi";
// import PopupWarning from './PopupWarning.vue';
export default {
  components: {},
  name: "PopupContent",
  props: {
    EmployeeId: String,
    PopupType: String,
    Content: String,
  },
  created() {},
  methods: {
    /**
     * Hàm đóng popup
     * CreateBy: NTDIEM(19/08/2021)
     */
    closePopup() {
      this.$emit("closePopup");
    },
    /**
     * Hàm xóa nhân viên
     * CreateBy: NTDIEM(19/08/2021)
     */
    deleteEmployee() {
      var me = this;
      console.log(this.EmployeeId);
      EmployeeApi.delete(this.EmployeeId)
        .then((res) => {
          console.log(res + "Xóa");
          me.$emit("loading", true);
          me.$emit("openToast", "success", "Xóa dữ liệu thành công");
          this.closePopup(true);
        })
        .catch((res) => {
          me.$emit("loading", true);
          me.$emit("openToast", "fail", "Xóa dữ liệu thất bại");
          this.closePopup(true);

          console.log(res);
        });
    },
    /**
     * Hàm đóng form và popup
     * CreateBy: NTDIEM(23/08/2021)
     */
    closePopupAndForm() {
      this.$emit("closePopupAndForm");
    },
    /**
     * Hàm đóng form và lưu dữ liệu
     * CreateBy: NTDIEM(23/08/2021)
     */
    closePopupAndSave() {
      this.$emit("saveForm");
      this.closePopup();
    },
  },
};
</script>

<style scoped>
@import "../../css/popup/Popup.css";
@import "../../css/common/Common.css";
</style>
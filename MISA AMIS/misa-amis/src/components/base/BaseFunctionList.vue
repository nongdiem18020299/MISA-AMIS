<template>
  <div class="dropdown-select-list">
    <ul class="list">
      <li @click="openFormReplication">Nhân bản</li>
      <li @click="openPopup">Xóa</li>
      <li @click="closeDropList">Ngưng sử dụng</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "DropdownList",
  props: {},
  methods: {
    /**
     * Hàm mở popup thông báo xóa
     * CreateBy: NTDIEM(19/08/2021)
     */
    openPopup() {
      this.$emit("openPopup", 'Delete');
      this.closeDropList();
    },
    /**
     * Hàm mở form nhân bản
     * CreateBy: NTDIEM(20/08/2021)
     */
    openFormReplication(){
      this.$emit("openForm");
      this.closeDropList();
    },
    /**
     * Hàm đóng danh sách chức năng
     * CreateBy: NTDIEM(20/08/2021)
     */
    closeDropList(){
      this.$emit("CloseDrop");
    }
  },
};
</script>

<style scoped>
@import "../../css/base/FunctionBox.css";
</style>
<template>
  <div class="function-box">
    <div class="func-box-tag d-flex">
      <div class="func-box-tagname pointer"
        @click="openForm"
      >Sửa</div>
      <div
        class="dropdown-icon"
        v-bind:class="{ 'show-border': isShowBorder}"
        @click="openDrop"
        ref="dropIcon"
      ></div>
    </div>
  </div>
</template>

<script>
// import DropdownList from './DropdownList.vue';
export default {
  components: {},
  name: "FunctionBox",
  props: {
    isDrop: Boolean,
  },
  data() {
    return {
      posTop: 0,
      isShowBorder: false,
    };
  },
  created(){
  },
  methods: {
    /**
     * Hàm mở drop các chức năng
     * CreateBy: NTDIEM(19/08/2021)
     */
    openDrop() {
      if (!this.isDrop) {
        this.posTop = this.$refs.dropIcon.getBoundingClientRect().top;
        this.isShowBorder = true;
        this.$emit("getInFo");
        this.$emit("openDrop", this.posTop);
      }
      else{
        this.isShowBorder = false;
        this.$emit("closeDrop");
      }
      // console.log(dropIcon);
    },
    /**
     * Hàm mở Form thông tin nhân viên
     * CreateBy: NTDIEM(17/08/2021)
     */
    openForm(){
      this.$emit("getInFo");
      this.$emit('openForm');
    }
  },
  watch:{
    isDrop:function(){
      if(!this.isDrop){
        this.isShowBorder = false;
      }
    }
  }
};
</script>

<style scoped>
@import "../../css/base/FunctionBox.css";
</style>
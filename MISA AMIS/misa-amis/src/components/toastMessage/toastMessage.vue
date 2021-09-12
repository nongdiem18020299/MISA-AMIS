<template>
  <div id="toast">
    <div v-bind:class="`toast-box d-flex ${closeToastMess}`" v-if="isOpen">
      <div v-bind:class="`toast-icon ${toastType}`">
        <i v-bind:class="`${toastIconClass}`"> </i>
      </div>
      <div class="toast-content">{{ toastMessage }}</div>
      <div
        v-bind:class="`toast-close close-${toastType}`"
        v-on:click="closeToast"
      >
        <i class="fas fa-times"></i>
      </div>
    </div>
  </div>
</template>

<style>
@import url("../../css/toastMessage/ToastMessage.css");
@import "../../css/common/Common.css";
</style>

<script>
export default {
  name: "ToastMessage",
  props: {
    toastType: String,
    toastMessage: String,
  },
  data() {
    return {
      toastIconClass: "",
      closeToastMess: "",
      isOpen: false,
    };
  },
  created() {
    console.log(this.toastType);
    switch (this.toastType) {
      case "success":
        this.toastIconClass = "fas fa-check";
        break;
      case "fail":
        this.toastIconClass = "fas fa-exclamation-triangle";
        break;
      case "warning":
        this.toastIconClass = "fas fa-exclamation";
        break;
      case "info":
        this.toastIconClass = "fas fa-info";
        break;
      default:
        break;
    }
    this.isOpen = true;
    setTimeout(() => (this.closeToastMess = "hidden"), 3000);
  },
  methods: {
    closeToast() {
      this.closeToastMess = "hidden";
    },
  },
};
</script>
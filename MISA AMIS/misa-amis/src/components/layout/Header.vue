<template>
  <div class="header d-flex">
      <div class="branch d-flex left-side">
          <div class="menu-icon pointer"></div>
          <div class="branch-name">CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC</div>
          <div class="drop-icon"></div>
      </div>
      <div class="header-right-side d-flex right-side">
          <div class="notify-icon pointer" v-tooltip.bottom-center="'Thông báo'"></div>
          <div class="user-avt pointer"></div>
          <div class="user-name pointer">Nông Thị Diễm</div>
          <div class="drop-icon-user pointer"></div>
      </div>
  </div>
</template>

<script>
export default {
    name:"Header",
    components:{

    }
}
</script>

<style>
@import '../../css/layout/Header.css'
</style>
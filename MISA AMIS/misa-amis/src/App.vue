<template>
  <div id="app" class="d-flex">
    <sidebar></sidebar>
    <!-- <router-link to="/Employee">EmployeeLayout</router-link> -->
    <router-view><employee-layout></employee-layout></router-view>
      
  </div>
</template>
<style>
@import './css/common/Main.css';
@import './css/layout/Home.css';
</style>
<script>
import EmployeeLayout from './components/layout/employee/EmployeeLayout.vue'
import Sidebar from './components/layout/Sidebar.vue'
// import HelloWorld from './components/HelloWorld.vue'
export default {
  name: 'App',
  components: {
    Sidebar,
    EmployeeLayout
  }
}
</script>

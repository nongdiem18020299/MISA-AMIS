<template>
    <div id="employee-header" class="d-flex">
        <div class="employee-header-title">Nhân viên</div>
        <div class="add-employee-btn pointer"
            v-tooltip.top-center="'Nút thêm mới nhân viên'"
            @click="openForm"
        >Thêm mới nhân viên</div>
    </div>
</template>

<style scoped>
@import '../../../css/layout/EmployeeHeader.css';
</style>

<script>
export default {
    name:"EmployeeHeader",
    components:{

    },
    methods: {
    /**
     * Hàm mở Form thông tin nhân viên
     * CreateBy: NTDIEM(18/08/2021)
     */
        openForm(){
            this.$emit('open-form');
        }
    }
}
</script>
<template>
    <div class="sidebar">
    <div class="sidebar-header d-flex">
        <a class="sidebar-menu-icon"></a>
        <a class="sidebar-logo">
            <img class="img-logo" src="..\..\assets\Resource\img\Logo_Module_TiengViet_White.66947422.svg" alt="">
        </a>
    </div>
    <div class="sidebar-list-item">
        <router-link style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Tổng quan">
            <div class="item-icon d-flex">
                <div class="icon dash-board"></div>
            </div>
            <div class="item-title">Tổng quan</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Employee" class=" sidebar-item pointer d-flex" title="Tiền mặt">
            <div class="item-icon d-flex">
                <div class="icon money"></div>
            </div>
            <div class="item-title">Tiền mặt</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Tiền gửi">
            <div class="item-icon d-flex">
                <div class="icon deposits"></div>
            </div>
            <div class="item-title">Tiền gửi</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Mua hàng">
            <div class="item-icon d-flex">
                <div class="icon purchase"></div>
            </div>
            <div class="item-title">Mua hàng</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Bán hàng">
            <div class="item-icon d-flex">
                <div class="icon sell"></div>
            </div>
            <div class="item-title">Bán hàng</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Quản lý hóa đơn">
            <div class="item-icon d-flex">
                <div class="icon bill"></div>
            </div>
            <div class="item-title">Quản lý hóa đơn</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Kho">
            <div class="item-icon d-flex">
                <div class="icon warehouse"></div>
            </div>
            <div class="item-title">Kho</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Công cụ dụng cụ">
            <div class="item-icon d-flex">
                <div class="icon tools"></div>
            </div>
            <div class="item-title">Công cụ dụng cụ</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Tài sản cố định">
            <div class="item-icon d-flex">
                <div class="icon asset"></div>
            </div>
            <div class="item-title">Tài sản cố định</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Thuế">
            <div class="item-icon d-flex">
                <div class="icon tax"></div>
            </div>
            <div class="item-title">Thuế</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Giá thành">
            <div class="item-icon d-flex">
                <div class="icon price"></div>
            </div>
            <div class="item-title">Giá thành</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Tổng hợp">
            <div class="item-icon d-flex">
                <div class="icon total"></div>
            </div>
            <div class="item-title">Tổng hợp</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Ngân sách">
            <div class="item-icon d-flex">
                <div class="icon budget"></div>
            </div>
            <div class="item-title">Ngân sách</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Báo cáo">
            <div class="item-icon d-flex">
                <div class="icon report"></div>
            </div>
            <div class="item-title">Báo cáo</div>
        </router-link>
        <router-link  style="text-decoration: none;" to="/Developing" class=" sidebar-item pointer d-flex" title="Phân tích tài chính">
            <div class="item-icon d-flex">
                <div class="icon financial"></div>
            </div>
            <div class="item-title">Phân tích tài chính</div>
        </router-link>
    </div>
    </div>
</template>
<style scoped>
@import '../../css/layout/Sidebar.css'
</style>
<script>
export default {
    name:"Sidebar"
}
</script>
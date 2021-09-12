<template>
  <div class="footer d-flex">
    <div class="total-record">
      Tổng số: <b>{{ TotalRecord }}</b> bản ghi
    </div>
    <div class="footer-right-side d-flex">
      <div class="drop-down-footer">
        <input
          readonly
          class="drop-footer-selected pointer"
          v-bind:class="{ 'border-green': focusOn }"
          v-bind:value="pageSize+' bản ghi trên 1 trang'"
          @focus="focusOn = true"
          @blur="(focusOn = false), (isDrop = false)"
          @click="selectItem"
        />
        <ul v-if="isDrop" class="drop-footer-list pointer">
          <li  @click="selectPageSize(100)" v-bind:class="{'selected-paging' : pageSize==100}">100 bản ghi trên 1 trang</li>
          <li  @click="selectPageSize(50)" v-bind:class="{'selected-paging' : pageSize==50}">50 bản ghi trên 1 trang</li>
          <li  @click="selectPageSize(30)" v-bind:class="{'selected-paging' : pageSize==30}">30 bản ghi trên 1 trang</li>
          <li  @click="selectPageSize(20)" v-bind:class="{'selected-paging' : pageSize==20}">20 bản ghi trên 1 trang</li>
          <li  @click="selectPageSize(10)" v-bind:class="{'selected-paging' : pageSize==10}">10 bản ghi trên 1 trang</li>
        </ul>
        <div @click="selectItem" class="drop-footer-icon-wrap d-flex pointer">
          <div
            v-bind:class="{ 'drop-footer-icon-rotate': isDrop }"
            class="drop-footer-icon"
          ></div>
        </div>
      </div>
      <div class="paging d-flex">
        <div class="prev pointer" @click="goToPrevPage" :disabled="isFirstPage" v-bind:class="{'disabled' : isFirstPage}">
          Trước
        </div>
        <div
          class="page-number-list d-flex"
          v-for="page in pages"
          :key="page.name"
        >
          <div
            class="page-num"
            v-bind:class="{ 'focus-page-num': page.name == PageNumber + 1 }"
            @click="onFocus(page.name)"
          >
            {{ page.name }}
          </div>
        </div>
        <div class="next pointer" @click="goToNextPage" :disabled="isLastPage" v-bind:class="{'disabled' : isLastPage}">
          Sau
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import BaseDropdown from '../box/BaseDropdown.vue';
export default {
  components: {},
  name: "EmployeeFooter",
  props: {
    TotalPage: Number,
    TotalRecord: Number,
    PageNumber: Number,
  },
  data() {
    return {
      pageIndex: 0,
      isFocus: false,
      pageSize: 20,
      pageNumber: 0,
      focusOn: false,
      isDrop: false,
    };
  },
  created() {
    // this.pageNumber = this.PageNumber;
    this.paging(this.pageIndex, this.pageSize);
  },
  methods: {
    /**
     * Hàm phân trang
     * CreateBy: NTDIEM(17/08/2021)
     */
    paging(pageNum, pageSize) {
      this.$emit("footer-paging", pageNum, this.pageSize);
      console.log(pageSize);
      console.log(
        this.TotalPage + " " + this.TotalRecord + " " + this.PageNumber
      );
    },
    /**
     * Hàm focus vào số trang
     * CreateBy: NTDIEM(17/08/2021)
     */
    onFocus(i) {
      this.isFocus = true;
      console.log(i);
      this.paging(i - 1, this.pageSize);

      // if(this.AcountRecord>0){
      // }
    },
    // goToFirstPage() {
    //   if (!this.isFirstPage> 0) {
    //     this.paging(0, this.pageSize);
    //   }
    // },
    /**
     * Hàm chuyển đến trang trước
     * CreateBy: NTDIEM(17/08/2021)
     */
    goToPrevPage() {
      if (!this.isFirstPage > 0) {
        this.paging(this.PageNumber - 1, this.pageSize);
      }
    },
    /**
     * Hàm chuyển đến trang sau
     * CreateBy: NTDIEM(17/08/2021)
     */
    goToNextPage() {
      if (!this.isLastPage > 0) {
        this.paging(this.PageNumber + 1, this.pageSize);
      }
    },
    // goToLastPage() {
    //   if (!this.isLastPage> 0) {
    //     this.paging(this.TotalPage - 1, this.pageSize);
    //   }
    // },
    /**
     * Hàm mở đóng drop để chọn phân trang
     * CreateBy: NTDIEM(23/08/2021)
     */
    selectItem() {
      if (!this.isDrop) {
        this.isDrop = true;
        this.isFocus = true;
      } else {
        this.isDrop = false;
        this.isFocus = false;
      }
    },

    /**
     * Hàm chọn phân trang
     * CreateBy: NTDIEM(23/08/2021)
     */
    selectPageSize(pageSize){
      this.pageSize = pageSize;
      this.isDrop = false;
      this.paging(this.pageIndex,this.pageSize);
    }
  },
  computed: {
    /**
     * Tính số trang đầu tiên xuất hiện trên danh sách phân trang
     * CreateBy: NTDIEM(17/08/2021)
     */
    startPage() {
      if (this.PageNumber == 0 || this.PageNumber == 1) {
        return 1;
      }

      if (this.PageNumber == this.TotalPage - 1) {
        return this.TotalPage - 3;
      }
      return this.PageNumber - 1;
    },
    /**
     * Đối trượng trang
     * CreateBy: NTDIEM(17/08/2021)
     */
    pages() {
      const range = [];

      for (
        let i = this.startPage;
        i <= Math.min(this.startPage + 3, this.TotalPage);
        i += 1
      ) {
        range.push({
          name: i,
          isDisabled: i === this.PageNumber,
        });
      }

      return range;
    },
    /**
     * Biến trả về có phải trang đầu tiên hay không
     * CreateBy: NTDIEM(17/08/2021)
     */
    isFirstPage() {
      return this.PageNumber == 0;
    },
    /**
     * Biến trả về có phải trang cuối hay không
     * CreateBy: NTDIEM(17/08/2021)
     */
    isLastPage() {
      return this.PageNumber == this.TotalPage - 1;
    },
  },
};
</script>

<style>
@import "../../../css/layout/EmployeeFooter.css";
@import "../../../css/common/Common.css";
</style>
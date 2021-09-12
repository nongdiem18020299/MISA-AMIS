<template>
  <div class="auto-dropdown">
    <input
      autocomplete="off"
      class="selected-item"
      v-bind:class="{
        'border-red': failState,
        'border-green': onFocus && !failState,
      }"
      type="text"
      v-model="searchInput"
      v-on:input="autocompleteInput()"
      v-on:focus="onFocus = true"
      v-on:blur="(onFocus = false), (isDrop = false)"
      @keydown="selectItem"
      :tabindex="tabindex"
    />
    <div
      class="drop-container d-flex"
      @click="dropItem"
      v-bind:class="{ 'on-focus-item': isDrop }"
    >
      <div class="drop-icon-input"></div>
    </div>
    <ul class="select-list" id="autocomplete" v-show="isDrop">
      <li
        v-for="(item, i) in listItemShow"
        :key="i"
        v-on:click="getItem(item, i)"
        v-bind:class="[isFocus || liIndex == i ? 'on-focus-item' : '', '']"
        v-bind:id="i"
      >
        {{ item }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "BaseDropdown",
  props: {
    isRequired: Boolean,
    inputName: String,
    defaultValue: String,
    valueArray: [],
    value: String,
    tabindex: String,
    // dropdownName: String,
  },
  data() {
    return {
       failState: false,
      searchInput: "",
      listItem: [],
      listItemShow: [],
      isDrop: false,
      isFocus: false,
      liIndex: 0,
      selectedIndex: 0,
      dropName: "",
      onFocus: false,
    };
  },
  methods: {
    /**
     * Hàm dropdown danh sách item
     * CreateBy: NTDIEM(20/08/2021)
     */
    dropItem() {
      if (this.isDrop) {
        this.isDrop = false;
        this.onFocus = false;
      } else {
        this.isDrop = true;
        this.onFocus = true;
      }
      this.liIndex = this.selectedIndex;
      this.listItemShow = this.listItem;
    },
    /**
     * Hàm lấy dữ liệu để lọc
     * CreateBy: NTDIEM(20/08/2021)
     */
    getItem(item, i) {
      this.isDrop = false;
      this.searchInput = item;
      this.liIndex = i;
      this.onFocus = false;
    },
    /**
     * Hàm autocomplete combobox
     * CreateBy: NTDIEM(20/08/2021)
     */
    autocompleteInput() {
      let inputText = this.searchInput;
      this.listItemShow = [];
      if (inputText == "") {
        this.isDrop = false;
      }
      for (let i in this.listItem) {
        let item = this.listItem[i];
        if (
          item.substr(0, inputText.length).toUpperCase() ==
          inputText.toUpperCase()
        ) {
          this.listItemShow.push(item);
          this.isDrop = true;
        }
      }
    },
    /**
     * Hàm lựa chọn cấc item bằng phím
     * CreateBy: NTDIEM(20/08/2021)
     */
    selectItem(e) {
      if (e.key == "ArrowUp") {
        this.liIndex--;
      }
      if (e.key == "ArrowDown") {
        this.liIndex++;
      }
      if (e.key == "Enter") {
        let focusLi = document.getElementById(this.liIndex);
        focusLi.click();
      }
      if (this.liIndex >= this.listItemShow.length) {
        this.liIndex = 0;
      }
      if (this.liIndex < 0 && e.key == "ArrowUp") {
        this.liIndex = this.listItemShow.length - 1;
      }
    },
  },
  created() {
    this.searchInput = this.value;
    for (var field in this.valueArray) {
      this.listItem.push(this.valueArray[field]["departmentName"]);
      if (this.valueArray[field]["departmentName"] == this.value) {
        this.liIndex = field;
      }
    }
    this.listItemShow = this.listItem;
  },
  watch: {
    searchInput: function (newValue) {
      this.$emit("update:value", newValue);
    },
  },
};
</script>
<style scoped>
@import "../../css/base/Dropdown.css";
</style>
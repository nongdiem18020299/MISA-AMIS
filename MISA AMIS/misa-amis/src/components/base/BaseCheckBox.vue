<template>
  <div class="check-box">
    <div
      class="checkbox-container"
      v-bind:class="{
        'border-checked': isShowBorder,
        'checkbox-radio-container': isRadioCheckbox,
      }"
      ref="Checkbox"
    >
      <input
        class="pointer"
        :type="inputName"
        :tabindex="tabindex"
        name="baseCheckBox"
        @click="setCheckbox"
        :checked="isChecked"
        @focus="setCheckbox"
        @blur="isShowBorder = false"
      />
      <div
        v-bind:class="[isRadioCheckbox ? 'check-mark-radio' : '', 'check-mark']"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "BaseCheckBox",
  props: {
    isRadioCheckbox: Boolean,
    Checked: Boolean,
    inputName: String,
    tabindex: Number,
  },
  data() {
    return {
      isChecked: false,
      isShowBorder: false,
    };
  },
  created() {
    this.isChecked = this.Checked;
    this.isShowBorder = this.isChecked;
  },
  methods: {
    setCheckbox() {
      if (this.isRadioCheckbox) {
        this.isChecked = true;
        this.isShowBorder = true;
      }
    },
  },
};
</script>

<style>
@import "../../css/base/Checkbox.css";
</style>
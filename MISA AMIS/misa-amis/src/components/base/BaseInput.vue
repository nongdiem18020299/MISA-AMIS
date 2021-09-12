<template>
  <div>
    <input
      v-bind:type="inputType"
      v-bind:value="inputValue"
      v-on:keyup="onChange($event)"
      v-on:focus="onFocus = true"
      v-on:focusout="onFocus = false"
      class="form-item-input"
      v-bind:class="{'border-red': failState, 'border-green': onFocus&&!failState}"
      :tabindex="tabindex"
    />
  </div>
</template>

<style>
@import url("../../css/common/Common.css");
</style>

<script>
// import TooltipInput from "@/components/tooltip/TooltipInput";
export default {
  name: "BaseInput",
  components: {
    // TooltipInput,
  },
  data() {
    return {
      onFocus: false,
      failState: false,
      tooltipContent:""
    };
  },
  props: ["inputName", "inputValue", "inputType", "isRequired","isEmail","isPhoneNumber","isIdentifyNumber","isTaxCode","tabindex","isMoney","isNumber"],
  methods: {
    onChange(event) {
      this.$emit("update:inputValue", event.target.value);
    },
  },
};
</script>
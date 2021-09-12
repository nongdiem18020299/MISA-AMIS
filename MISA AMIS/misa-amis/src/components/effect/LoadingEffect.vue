<template>
<div class="loading-container d-flex">
    <object :data="loadEffectUrl" type="" class="loading"></object>
</div>
 
</template>

<script>
export default {
    name:"LoadEffect",
    data(){
    return {
      loadEffectUrl: require('../../assets/Resource/loading.svg')
    }
  }
}
</script>

<style>
@import "../../css/effect/LoadEffect.css"
</style>
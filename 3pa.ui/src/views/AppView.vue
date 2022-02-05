<template>
    <router-view/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
    msg: String
  }
})
export default class AppBody extends Vue{

}
</script>

<style>
</style>
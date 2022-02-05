<template>
  <div>
    <h2>HomeView</h2>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
    msg: String
  }
})
export default class HomeView extends Vue{

}
</script>

<style>
</style>
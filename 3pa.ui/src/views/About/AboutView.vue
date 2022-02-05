<template>
  <div>
    <h2>AboutBody</h2>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
    msg: String
  }
})
export default class AboutBody extends Vue{

}
</script>

<style>
</style>
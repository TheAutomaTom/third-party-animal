<template>
  <div>
    <h2>LoginModal</h2>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
    msg: String
  }
})
export default class LoginModal extends Vue{

}
</script>

<style>
</style>
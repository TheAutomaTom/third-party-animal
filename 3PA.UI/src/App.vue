<template>
  <div>
    <app-body/>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import AppBody from "./components/AppBody.vue"

@Component({
  components: {
    AppBody
  },
})
export default class App extends Vue {

}
</script>

<style>
</style>
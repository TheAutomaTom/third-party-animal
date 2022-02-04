<template>
    <router-view/>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import AboutBody from "./About/AboutBody.vue"
import PublicRecordsConsumerBody from "./PublicRecordsConsumer/PublicRecordsConsumerBody.vue"


@Component({
  components: {
    AboutBody,
    PublicRecordsConsumerBody
  },
})
export default class AppBody extends Vue {

}
</script>

<style>
</style>
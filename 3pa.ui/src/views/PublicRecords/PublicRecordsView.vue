<template>
  <manifest-summary/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData"
import ManifestSummary from "./ManifestSummary.vue"
import apiControl from "@/Views/_components/apiControl.vue"
@Options({
  components: {
    PublicRecordsModule,
    ManifestSummary,
    apiControl
  }
})
export default class PublicRecordsView extends Vue{
}
</script>

<style>
</style>
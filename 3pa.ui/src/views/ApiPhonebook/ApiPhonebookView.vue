<template>
  <div>
    <h4>3PA.API Test Harness</h4>

    <api-get-counties/>
    <api-get-county-name-from-id/>
    <api-get-manifest-summary/>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData";
import apiGetCounties from "./apiGetCounties.vue";
import apiGetCountyNameFromId from "./apiGetCountyNameFromId.vue";
import apiGetManifestSummary from "./apiGetManifestSummary.vue";

@Options({
  components: {
    PublicRecordsModule,
    apiGetCounties,
    apiGetCountyNameFromId,
    apiGetManifestSummary
  }
})
export default class ApiPhonebookView extends Vue{
}
</script>

<style>
</style>
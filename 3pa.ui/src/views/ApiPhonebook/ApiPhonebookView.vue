<template>
  <div>
    <h4>3PA.API Test Harness</h4>

    <api-get-counties/>
    <api-get-county-name-from-id/>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData"
import apiGetCounties from "./apiGetCounties.vue"
import apiGetCountyNameFromId from "./apiGetCountyNameFromId.vue"

@Options({
  components: {
    PublicRecordsModule,
    apiGetCounties,
    apiGetCountyNameFromId
  }
})
export default class ApiPhonebookView extends Vue{
  test(){
   PublicRecordsModule._api.getManifestSummary(); 
  }
}
</script>

<style>
</style>
<template>
  <div>
    <h4>3PA.API Test Harness</h4>
    <api-control/>
    <api-control/>
  </div>
  <manifest-summary/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData"
import apiControl from "@/Views/_components/apiControl.vue"
@Options({
  components: {
    PublicRecordsModule,
    apiControl
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
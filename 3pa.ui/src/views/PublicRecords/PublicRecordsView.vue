<template>
  <div>

    <button 
      type="button"
      @click="test"
    >Test Api!</button>
<!--     
    <p>Select file to upload:</p>
    <input type="file"
           id="filePicker"
           ref="fileInput"
           @change="previewFiles" />
    
    <p>State: {{usState}}</p>
    <p>Category: {{category}}</p>

    <button @click="postCsv()">
      Send it!
    </button>

    <div><button @click="getCountyName">Test County Code!</button></div> 
-->
  </div>
  <manifest-summary/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import ManifestSummary from "./ManifestSummary.vue"
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData"

@Options({
  components: {
    ManifestSummary,
    PublicRecordsModule
  }
})
export default class PublicRecordsView extends Vue{
  test(){
   PublicRecordsModule._api.getManifestSummary(); 
  }
}
</script>

<style>
</style>
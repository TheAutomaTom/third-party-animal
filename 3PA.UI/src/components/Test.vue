<template>
  
  <div>
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

  </div>

  
</template>

<script lang="ts">  
import { Component } from "vue-property-decorator";
import Vue from "vue";
import {TestModule} from "../store/Modules/testData"


@Component
  export default class Test extends Vue{
  usState = ""
  category = ""

  get fileInput(){
      return this.$refs.fileInput as HTMLInputElement;
  }

  postCsv(){
    const file: File = (this.$refs.fileInput as HTMLInputElement).files![0];
    TestModule.postCsvToSql("Nc", "Voter", file);//this.usState, this.category, this.fileToUpload!);
    
  }

  getCountyName(){
    TestModule.getCountyName();
  }

}
  

</script>
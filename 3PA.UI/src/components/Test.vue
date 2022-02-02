<template>
  
  <div>
    <!-- https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/radio -->
    <p>Select file to upload:</p>
    <input 
      type="file"
      id="filePicker"
      ref="fileInput"
      @change="previewFiles"
    />
    <!--:accept="allowedContentTypes"-->
    <p>State: FL</p>
    <p>Category: Voter Identities</p>
    <button
      @click="post()"
    >Send it!</button>
  </div>

  
</template>

<script lang="ts">  
import { Component } from "vue-property-decorator";
import Vue from "vue";
import {TestModule} from "../store/Modules/testData"
import {AppStateModule} from "../store/Modules/appStateData"
//import { ApiClient } from "@/connector/ApiClient";

@Component
  export default class Test extends Vue{
    usState = ""
    category = ""

    previewFiles(){
      const file: File = this.fileInput.files![0];
      console.warn(`Preview File: ${file.name}`);
    }
    private get fileInput(): HTMLInputElement {
        return this.$refs.fileInput as HTMLInputElement;
    }

    post(){
      
      const file: File = (this.$refs.fileInput as HTMLInputElement).files![0];

      console.warn(`Upload File: ${file.name}`);
      console.warn(`TestVue file sees: ${AppStateModule.testMessage}`);


      TestModule.postCsvToSql( "Fl", "Voter", file);//this.usState, this.category, this.fileToUpload!);

    }

  }



</script>
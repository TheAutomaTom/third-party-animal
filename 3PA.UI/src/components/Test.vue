<template>
  
  <div>
    <p>Here we go...</p>

    <input 
      type="file"
      id="file-input" 
      :v-model="fileToUpload"
      />
    <!--:accept="allowedContentTypes"-->
  </div>
  
</template>

<script lang="ts">  
  import Vue from 'vue';
  export default class Test extends Vue{
    fileToUpload: File|undefined;

    async put(){
      try{
        Vue.prototype.top = window.top;
        let headers = new Vue.prototype.top.Headers();
        
        
        headers.append("Content-Type",(fileToUpload as File).type);
        const response = await window.top.WithIdentity.put(

        )

      }


    }


    mounted(){

    }
  }



</script>
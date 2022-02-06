<template>
	<div class="api-control">

<!-- TITLE..................................................... -->
    <div class="title=wrapper">      
      <button class="title-button"
        type="button"
        @click="ApiCalled"
      >
        <h3>
          GET /api/PublicRecord/Counties/Dictionary/{{usState}}
        </h3>
      </button>
    </div>

<!-- INPUTS.................................................... -->
    <div class="inputs-wrapper">    
      
      <input type="radio" id="Fl" name="UsState" value="Fl">
        <label for="html">Florida</label>
      
      <input type="radio" id="Nc" name="UsState" value="Nc">
        <label for="css">North Carolina</label>

    </div>

<!-- RESPONSE.................................................. -->
    <div class="response-wrapper">
      <span id="response-field">
        "..."
      </span>
    </div>
        
	</div>
  <hr/>  
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
@Options({})
export default class ApiControl extends Vue{
  url="wtf";
  ApiCalled(){
    console.warn(`ApiCalled: ${this.url}`);
  }
}
</script>

<style>
.api-control {
  width: auto;
  padding: 0.2em;
  /* 
  display: grid;
  grid-gap: 5px;
  grid-template-columns: 12em auto;
  grid-template-rows: 1.5em 1.5em auto min-content;
  width: 80em;
  
  */
}  
.api-control button{
  width: auto;
  margin: auto; 
  text-align: left;
}  

</style>
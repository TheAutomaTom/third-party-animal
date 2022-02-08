<template>
	<div class="api-control">

<!-- TITLE..................................................... -->
    <div class="title=wrapper">      
      <button class="title-button"
        type="button"
        @click="this.$emit('api-called')"
      >
        <h3>
          <slot name="call-name"/>
        </h3>
      </button>
    </div>

<!-- INPUTS.................................................... -->
    <div class="inputs-wrapper">
          <slot name="inputs"/>
    </div>

<!-- RESPONSE.................................................. -->
    <div class="response-wrapper" >
      <p id="response-field" >
          <slot name="response"/>
      </p>
    </div>
        
	</div>
  <hr/>  
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({})
export default class ApiControl extends Vue{}
</script>

<style>
.api-control {
  width: auto;
  padding: 0.2em;
}  
.api-control button{
  width: auto;
  margin: auto; 
  text-align: left;
}  

.inputs-wrapper{
  padding-left: 1em;
}
.response-wrapper{
  margin: 0.5em 1em;
  background-color: var(--bgc-dark);
}
.response-wrapper>p{
  margin-left: 1em;
  padding: 1em 0.25em;
  
}

</style>
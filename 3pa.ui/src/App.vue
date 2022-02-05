<template>
  <div id="nav">
    <router-link to="/">Home</router-link> | 
    <router-link to="/about">About</router-link> | 
    <router-link to="/public-records/consumer">Public Records Consumer</router-link>
  </div>


  <router-view/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  
})
export default class About extends Vue{


}
</script>
<style lang="stylus">
#app
  font-family Avenir, Helvetica, Arial, sans-serif
  -webkit-font-smoothing antialiased
  -moz-osx-font-smoothing grayscale
  text-align center
  color #2c3e50
  margin-top 60px
</style>

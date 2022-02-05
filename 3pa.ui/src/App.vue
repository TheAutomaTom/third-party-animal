<template>
  <div class="grid">

      <div class="header">
        <div class="nav-title">
          <router-link to="/">Third Party Animal</router-link>
        </div>
        <div class="nav-links">
          <router-link to="/public-records/consumer">Public Records Consumer</router-link> |
          <router-link to="/about">About 3PA</router-link> 
        </div>
      </div>

      <div class="left-side">
        <ul>
          <li><router-link to="/public-records/consumer">  Public Records Consumer</router-link></li>
          <li><router-link to="/about">  About 3PA</router-link> </li>
        </ul>
      </div>

      <div class="router-view">
        <section>
          <router-view/>
        </section>
      </div>


      <div class="footer">
        <div class="nav-title">
          <router-link to="/">Third Party Animal</router-link> 
        </div>
        <div class="nav-links">
          <router-link to="/public-records/consumer">Public Records Consumer</router-link> |
          <router-link to="/about">About 3PA</router-link> 
        </div>
      </div>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
//import  "./Infra/stylesheets/display.css"
//import  "./Infra/stylesheets/css-grid.css"

@Options({})
export default class About extends Vue{


}
</script>


<style lang="css">
  html, body {
    margin: 0;
    height: 100%;
    background-color: #0c0c0d;
  }  
  body{
    color: white;    
  }
  a{
    color: beige;
  }
  a:link {
    
    text-decoration: none;
  }
  a:hover {
    color: white;
      text-decoration: underline;
  }
  ul{
    list-style-type: circle;
  }
  .grid {
    display: grid;
    grid-gap: 5px;
    grid-template-columns: 12em auto 12em;
    grid-template-rows: min-content auto min-content;
    height: 99.5vh;
    max-width: 80em;;
    margin:auto;
    background-color: #0e0e11;
  }
  .header, .footer {
    grid-column-start: 1;
    grid-column-end: 4;
    background-color: #161618;
    height: 1em;
  } 
  .nav-title{
    float: left;
  }
  .nav-links{
    float: right;
  }
  .router-view{  
    grid-column-start: 2;
    grid-column-end: 4;
    background-color: #27272b;
  }
</style>
<template>
<title>Third Party Animal - Our Voter Data Aggigator</title>
    	<div class="crt-screen"/>
      <div class="grid">

      <div class="header">
        <div class="nav-title">
          <router-link to="/">Third Party Animal</router-link>
        </div>
        <div class="nav-links">
          <router-link to="/public-records">Public Records</router-link> |
          <router-link to="/about">About 3PA</router-link> 
        </div>
      </div>

      <div class="left-side">
        <ul>
          <li><router-link to="/api-phonebook">Api Phonebook</router-link></li>
          <li><router-link to="/public-records">Public Records</router-link></li>
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
          <router-link to="/public-records">Public Records</router-link> |
          <router-link to="/about">About 3PA</router-link> 
        </div>
      </div>

  </div>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import "@/Assets/Styles/App-Colors.css";
import "@/Assets/Styles/App-Layout.css";

@Options({})
export default class About extends Vue{}
</script>
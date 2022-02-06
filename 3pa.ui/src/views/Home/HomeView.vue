<template>
  <div>
      <span class="ascii">
        ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄/;~-..__-=<br>
        ███─▄─▄─█─█─█▄─██▄─▄▄▀█▄─▄▄▀█████/▄─<br>
        █████─███─▄─██─███─▄─▄██─██─██████─<br>
        ████▄▄███▄█▄█▄▄▄██▄█▄▄██▄▄▄▄██████<br >
        ██▄─▄▄─██▀▄─▄█▄─▄▄▀█─▄─▄─█▄─█─▄███<br>
        ███─▄▄▄██─▀─███─▄─▄███─████▄─▄███..<br>
        ███▄█████▄█▄▄██▄█▄▄███▄████▄▄██████▄`-<br>
        █▀▄─▄█─▀█▄─█▄▄██─▀█▀─██▀▄─█▄─▄███▄─~<br >
        █─▀─██─█▄▀─██─██─█─█─██─▀─██─██▀█▄▄▄─<br>
        █▄█▄▄█▄███▄█▄▄▄█▄███▄▄█\▄█▄██▄▄▄▄▄\^─.<br>
        
    </span>
    <span> Our Voter Data Aggrigator - 2022</span>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';

@Options({
  props: {
    msg: String
  }
})
export default class HomeView extends Vue{

}
</script>

<style>
.ascii{
    margin: 0;
    padding: 0;
    font: 150% monospaced;
}
</style>
<template>
  <div class="about">
    <p>Thanks for reviewing 3PA!</p>
    <p>Check out more on <a href="https://github.com/TheAutomaTom/third-party-animal">Github!</a></p>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { AppStateModule } from "@/infra/store/Modules/appStateData"

@Options({
  props: {
    msg: String
  }
})
export default class About extends Vue{

}
</script>

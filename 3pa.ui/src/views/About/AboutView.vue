<template>
  <div class="about">
    <span>About!</span>
    <p>{{message}}</p>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { AppStateModule } from "@/Infra/store/Modules/appStateData"

@Options({
  props: {
    msg: String
  }
})
export default class About extends Vue{
get message(){
  return AppStateModule.testMessage;
}

}
</script>

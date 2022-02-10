<template>
  <manifest-summary/>
</template>
<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/infra/store/Modules/PublicRecordsData";
import ManifestSummary from "@/views/PublicRecords/ManifestSummary.vue";
import apiControl from "@/views/_components/apiControl.vue";
@Options({
  components: {
    PublicRecordsModule,
    ManifestSummary,
    apiControl
  }
})
export default class PublicRecordsView extends Vue{
}
</script>
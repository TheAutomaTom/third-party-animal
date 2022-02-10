<template>
	<api-control @api-called="callApi"	>
		<template v-slot:call-name>
			GET /api/PublicRecord/Manifest
		</template>

		<template v-slot:inputs>
		</template>

		<template v-slot:response>

			<div v-for="summary in response.manifestSummaries" :key="summary.usState">
				
						<span>State: {{summary.usState}}</span>
						<div v-for="manifest in summary.manifests" :key="manifest.fileName">
							<p>File Name: {{manifest.fileName}} (Recorded: {{manifest.dateProcessed}})</p>
							<p>Records: {{manifest.validated}} ({{manifest.orphaned}} orphans)</p>
						</div>
				
			</div>
		</template>

	</api-control>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/infra/store/Modules/PublicRecordsData";
import apiControl from "@/views/_components/apiControl.vue"
import selectUsState from "@/views/_components/selectUsState.vue";
import { ManifestSummariesDto } from '@/infra/repository/Dtos/PublicRecordsDtos';
@Options({
  components: {
    PublicRecordsModule,
    apiControl,
		selectUsState
  }
})
export default class apiGetCounties extends Vue{
	response = {} as ManifestSummariesDto;
	
  async callApi(){
		this.response = await PublicRecordsModule._api.getManifestSummaries();
		console.dir(this.response);
		console.dir(this.response.manifestSummaries);
		
  }

}
</script>

<style scoped>
table{
 width: 30em;
}
tr{
 width: 15em;
}
</style>
<template>
	<api-control @api-called="callApi"	>
		<template v-slot:call-name>
			GET /api/PublicRecord/Manifest
		</template>

		<template v-slot:inputs>
		</template>

		<template v-slot:response>
			<table>
				<tr>{{output.usState}}</tr>
				<tr v-for="(county, index) in output.counties" :key="index">
					<td>{{index}}</td>
					<td>{{county}}</td>
				</tr>
			</table>			 
		</template>

	</api-control>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData"
import apiControl from "@/Views/_components/apiControl.vue"
import selectUsState from "@/Views/_components/selectUsState.vue";
import { ManifestSummaryDto } from '@/Infra/repository/Dtos/PublicRecordsDtos';
@Options({
  components: {
    PublicRecordsModule,
    apiControl,
		selectUsState
  }
})
export default class apiGetCounties extends Vue{
	inputUsState: string = "";
	output = {} as ManifestSummaryDto;
	
  async callApi(){
		if(this.inputUsState != null){
		this.output = await PublicRecordsModule._api.getManifestSummary();
		}
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
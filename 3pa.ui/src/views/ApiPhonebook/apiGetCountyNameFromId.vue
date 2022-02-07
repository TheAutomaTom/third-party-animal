<template>
	<api-control @apiCalled="callApi"	>
		<template v-slot:call-name>GET /api/PublicRecord/Counties/NameFromId/{{urlUsState}}/{{urlCountyId}}</template>

		<template v-slot:inputs>
			<select-us-state @us-state-selected="inputUsState=$event" controlId="apiGetCountyNameFromId"/>
			<input type="text" v-model="inputCountyId"/>
		</template>

		<template v-slot:response>
			<h3>{{output}}</h3>
		</template>

	</api-control>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData";
import { CountyIdToNameDto } from '@/Infra/repository/Dtos/PublicRecordsDtos';
import apiControl from "@/Views/_components/apiControl.vue";
import selectUsState from "@/Views/_components/selectUsState.vue";

@Options({
  components: {
    PublicRecordsModule,
    apiControl,
		selectUsState
  }
})
export default class apiGetCountyNameFromId extends Vue{
	inputUsState: string = "";	
	inputCountyId: string = "...";
	output: string = "...";
	
	get urlCountyId(){
		return this.inputUsState == "" 
			? "{UsState}" : this.inputUsState;
	}
	get urlUsState(){
		return this.inputCountyId == "" 
			? "{CountyId}" : this.inputCountyId;
	}

  async callApi(){
		const response: CountyIdToNameDto = await PublicRecordsModule._api
				.getCountyNameFromId(this.inputUsState, this.inputCountyId);
		this.output = response.properName;
  }

}
</script>
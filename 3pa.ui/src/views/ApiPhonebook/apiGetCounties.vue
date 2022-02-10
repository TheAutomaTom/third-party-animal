<template>
	<api-control @api-called="callApi"	>
		<template v-slot:call-name>
			GET /api/PublicRecord/Counties/Dictionary/{{urlUsState}}
		</template>

		<template v-slot:inputs>
			<select-us-state @us-state-selected="inputUsState=$event" controlId="apiGetCounties"/>
		</template>

		<template v-slot:response>
			<table>
				<tr style="text-decoration:underline;">{{output.usState}}</tr>
				<tr v-for="(county, index) in output.counties" :key="index">
					<td style="width: 3em;">{{index}}</td>
					<td>{{county}}</td>
				</tr>
			</table>			 
		</template>

	</api-control>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData";
import apiControl from "@/views/_components/apiControl.vue"
import selectUsState from "@/views/_components/selectUsState.vue";
import { CountiesDictionaryDto } from '@/Infra/repository/Dtos/PublicRecordsDtos';
@Options({
  components: {
    PublicRecordsModule,
    apiControl,
		selectUsState
  }
})
export default class apiGetCounties extends Vue{
	inputUsState: string = "";
	output = {} as CountiesDictionaryDto;

	get urlUsState(){
		return this.inputUsState == "" 
			? "{UsState}" : this.inputUsState;
	}
	
  async callApi(){
		if(this.inputUsState != null){
		this.output = await PublicRecordsModule._api
				.getCountyNamesDictionary(this.inputUsState);
				console.dir(this.output);
		}
  }

}
</script>
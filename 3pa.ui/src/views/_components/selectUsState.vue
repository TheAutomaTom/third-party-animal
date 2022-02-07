<template>
	<div v-for="state in usStates" :key="state.id">
		<input type="radio"
			:value="state.id"
			:name="`selectUsState-${controlId}`"
			@input="this.$emit('us-state-selected', $event.target.value)"
		>
		<label :for="`selectUsState-${controlId}`">{{state.name}}</label><br>
		
	</div>
</template>
<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { Prop } from "vue-property-decorator";
import { PublicRecordsModule } from "@/Infra/store/Modules/PublicRecordsData";
@Options({
  components: {
    PublicRecordsModule
  }
})
export default class selectUsState extends Vue{
	@Prop({type: String, default:"No-Input"}) controlId!: string;
	get usStates(){
		return PublicRecordsModule.UsStates;
	}
}
</script>
<style>

</style>
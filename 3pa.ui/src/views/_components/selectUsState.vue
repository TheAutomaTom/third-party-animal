<template>
	<div v-for="state in usStates" :key="state.id" class="wrapper">
		<input type="radio"
			@input="this.$emit('us-state-selected', $event.target.value)"
			:name="`selectUsState-${controlId}`"
			:value="state.id"
		>
		<label>{{state.name}}</label><br>
		
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
<style scoped>
.wrapper{
	margin: 0.25em;
	font-size: 1.25em;
}
input[type="radio"]{
	margin: 0.5em 1em;
}
</style>
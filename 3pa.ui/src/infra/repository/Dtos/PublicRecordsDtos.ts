export type CountiesDictionaryDto = {
	usState: string;
	counties: Map<string, string>;
}

export type CountyIdToNameDto = {
	countyId: string;
	properName: string;
	usState: string;
}

export type ManifestSummariesDto = {
	//manifestSummaries: Array<ManifestSummary>;
	manifestSummaries: [{
		usState: string;
		manifests: Array<Manifest>;	
	}]


}
// export type ManifestSummary = {
// 	UsState: string;
// 	Manifests: Array<Manifest>;
// }
export type Manifest = {	
	fileName: string;
	dateProcessed: string
	validated: number;
	orphaned: number;
}
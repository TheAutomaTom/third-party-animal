export type CountiesDictionaryDto = {
	usState: string;
	counties: Map<string, string>;
}

export type ManifestSummaryDto = {
	UsState: string;
	Manifests: Manifest[];
}

export type Manifest = {	
	FileName: string;
	Date: string
	Validated: number;
	Orphaned: number;
}
export type CountyIdToNameDto = {
	countyId: string;
	properName: string;
	usState: string;
}
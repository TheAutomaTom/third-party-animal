export type CountiesDictionary = {
	UsState: string;
	Dictionary: [{
		id: string,
		name: string
	}]
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
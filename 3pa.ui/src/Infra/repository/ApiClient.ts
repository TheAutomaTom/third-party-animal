import * as pub from './Dtos/PublicRecordsDtos';
export class ApiClient{  
  _baseUrl: string;

  constructor() {
    this._baseUrl = process.env.VUE_APP_3PA_API_BASE_URL as string;
  }  
  
  async get(url: string){
    return await fetch(url, {
      method: "GET",
      mode: 'cors',
      headers: { "Accept": "application/json" }
    });
  }
  
  async getCountyNamesDictionary(usState: string): Promise<pub.CountiesDictionaryDto> {
    const res = await this.get(`${ this._baseUrl }/PublicRecord/Counties/Dictionary/${usState}`);
    if (res.ok) {
      return await res.json() as pub.CountiesDictionaryDto;
    } else {
      throw Error(res.statusText);
    }
  }

  async getCountyNameFromId(usState: string, countyId: string): Promise<pub.CountyIdToNameDto>{
    const res = await this.get(`${ this._baseUrl }/PublicRecord/Counties/NameFromId/${usState}/${countyId}`);
    if (res.ok) {
      return await res.json() as pub.CountyIdToNameDto;
    } else {
      throw Error(res.statusText);
    }
  }

  async getCountyIdFromFileName(usState: string, category: string, fileName: string){
    const res = await this.get(`${ this._baseUrl }/PublicRecord/Describe/${usState}/${category}/${fileName}`);
    if (res.ok) {
      return await res.json() as string;
    } else {
      throw Error(res.statusText);
    }
  }

  async getManifestSummary(){    
    const res = await this.get(`${ this._baseUrl }/PublicRecord/Manifest`);
    if (res.ok) {
      return await res.json() as pub.ManifestSummaryDto;
    } else {
      throw Error(res.statusText);
    }
  }

  async postCsvToSql(usState: string, category: string, file: File) {
    const url = `${this._baseUrl}/PublicRecord/ToSql/${usState}/${category}`;
    const formData = new FormData();
    formData.append('file', file)

    const res = await fetch(url, {
      method: 'POST',
      mode: 'cors',
      headers: { "Accept": "application/json" },
      body: formData
    })
    .then(response => response.json())
    .catch(error => {
      console.error('Error:', error);
    });

    if (res.ok) {
      return await res.json() as pub.ManifestDto;
    } else {
      throw Error(res.statusText);
    }

  }




}
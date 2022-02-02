// import { someModule } from "../some/path"; 
export class ApiClient{
  _baseUrl: string;

  constructor() {
    console.warn("ApiClient CTOR'd!!!");
    this._baseUrl = process.env.VUE_APP_3PA_API_BASE_URL

  }

  async postCsvToSql(usState: string, category: string, file: File){ 
    
    console.warn("From Api CLient: " + file.name);

    var fs = require('fs');
    const url = `${this._baseUrl}/api/PublicRecords/sql/from-public-records/${usState}/${category}-file`

    try {
      const res = await fetch(url, {
        method: "POST",
        headers: {
          "Accept": "application/json",
          "Content-Type": "multipart/form-data"
        },
        body: fs.createWriteStream(file)
      });
      if (res.ok) {
        const data = await res.json(); // as VehicleInfoDTO;
        return data;
      } else {
        throw Error(res.statusText);
      }
    } catch (error) {
      throw error; //Error(error;
    }

  }



}
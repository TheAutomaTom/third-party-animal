export class ApiClient{
  _baseUrl: string;

  constructor() {
    this._baseUrl = process.env.VUE_APP_3PA_API_BASE_URL as string;
  }

  async postCsvToSql(usState: string, category: string, file: File) {
    const url = `${this._baseUrl}/PublicRecords/Consumer/sql/from-public-records/Fl/Voter-file`;


    const formData = new FormData();

    //Note: The first param of append matches convention in asp controller
    formData.append('file', file)

     console.warn("formData.....vvv.............vvv.............");
     console.dir(formData);
     console.warn(".............^^^.............^^^.............");

     await fetch(url, {
      method: 'POST',
      body: formData,
    })
    .then(response => response.json())
    .then(result => {

         console.warn("result.......vvv.............vvv.............");
         console.dir(result);
         console.warn(".............^^^.............^^^.............");
      console.log('Success:', result);
    })
    .catch(error => {

      console.warn("error........vvv.............vvv.............");
      console.dir(error);
      console.warn(".............^^^.............^^^.............");
      console.error('Error:', error);
    });




  }



  async getCountyName(usState: string, countyCode: string){
    ///api/PublicRecords / Conventions / { state } / county - name / { countyCode }
    const url = `${ this._baseUrl }/PublicRecords/Conventions/${ usState }/county-name/${ countyCode }`;
    //native methods...
    const res = await fetch(url, {
      method: "GET",
      headers: {
        "Accept": "application/json"
      },
    });
    if (res.ok) {
      return await res.json();
    } else {
      throw Error(res.statusText);
    }



  }


}
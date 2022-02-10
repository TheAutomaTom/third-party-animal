import { Module, RegisterOptions, VuexModule } from "vuex-class-modules";
import { store } from ".."
import { ApiClient } from "../../repository/ApiClient"

export interface IPublicRecordsData{
  _api: ApiClient;
  UsStates: {id: string, name: string}[];
}

@Module
class PublicRecords extends VuexModule implements IPublicRecordsData{
  _api: ApiClient;

  constructor(o: RegisterOptions) {
    super(o);
    this._api = new ApiClient;
		
  }

  get UsStates(){ 
    return [
      {id: "Fl", name: "Florida"},
      {id: "Nc", name: "North Carolina"}
    ]
  }

}

export const PublicRecordsModule: IPublicRecordsData = new PublicRecords({ store, name: "_public-records" });
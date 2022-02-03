import { Module, VuexModule, RegisterOptions } from 'vuex-class-modules';
import {AppStateModule, IAppStateData } from "./appStateData"
//import { ApiClient } from '@/connector/ApiClient';
import store from '..';

export interface ITestData{}

@Module
class TestData extends VuexModule implements ITestData{
  private _app: IAppStateData;
  //private _api: ApiClient;

   constructor(o: RegisterOptions) {
    super(o);
    this._app = AppStateModule;
    //this._api = new ApiClient;
  }

  postCsvToSql(usState: string, category: string, file: File){
    //console.warn("From Module: " + this._app._api._baseUrl)
    console.warn("From TestModule: " + file.name);
    //this._app._api.postCsvToSql(usState, category, file);

    console.warn(this._app.testMessage);
    //console.warn(this._api._baseUrl);
    
  }


}
export const TestModule = new TestData({ store, name: "testData" });
import { Module, VuexModule, RegisterOptions } from 'vuex-class-modules';
import { ApiClient } from '@/infrastructure/ApiClient';
import store from '..';

export interface ITestData{}

@Module
class TestData extends VuexModule implements ITestData{
  private _api: ApiClient;

   constructor(o: RegisterOptions) {
    super(o);
    this._api = new ApiClient;
  }

  postCsvToSql(usState: string, category: string, file: File){
    this._api.postCsvToSql(usState, category, file);
  }

  getCountyName() {
    this._api.getCountyName("Fl", "OKA");
  }


}
export const TestModule = new TestData({ store, name: "testData" });
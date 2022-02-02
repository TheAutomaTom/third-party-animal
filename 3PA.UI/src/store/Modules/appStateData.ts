import { Module, RegisterOptions, VuexModule } from "vuex-class-modules";
import store from "@/store";
import { ApiClient } from "@/connector/ApiClient";

export interface IAppStateData{
  _api: ApiClient;
  isLoading: boolean;
  isInModal: boolean;

  testMessage: string;
}

@Module
class AppState extends VuexModule implements IAppStateData{
  public readonly _api : ApiClient;
  isLoading = false;
  isInModal = false;

  testMessage= "AppState testMessage!";
  
  constructor(o: RegisterOptions) {
    super(o);
    this._api = new ApiClient;
    console.warn("AppState CTOR'd!!!");
  }
}

export interface RootState {
  app: IAppStateData;
}

export const AppStateModule = new AppState({ store, name: "appState" });
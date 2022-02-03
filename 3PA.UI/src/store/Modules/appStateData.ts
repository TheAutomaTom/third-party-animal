import { Module, RegisterOptions, VuexModule } from "vuex-class-modules";
import store from "@/store";
import { ApiClient } from "@/connector/ApiClient";

export interface IAppStateData{
  _api: ApiClient;
  isLoading: boolean;
  isInModal: boolean;
}

@Module
class AppState extends VuexModule implements IAppStateData{
  public readonly _api : ApiClient;
  isLoading = false;
  isInModal = false;
  
  constructor(o: RegisterOptions) {
    super(o);
    this._api = new ApiClient;
  }
}

export interface RootState {
  app: IAppStateData;
}

export const AppStateModule = new AppState({ store, name: "appState" });
import Vue from "vue";
import Vuex from "vuex";
import { IAppStateData } from "./Modules/appStateData";

Vue.use(Vuex);

export interface RootState {
  app: IAppStateData;
}

// Declare empty store first, dynamically register all modules later.
export default new Vuex.Store<RootState>({});
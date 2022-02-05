import { Module, RegisterOptions, VuexModule } from "vuex-class-modules";
import { store } from ".."

export interface IAppStateData{
	isLoading: boolean;
  isInModal: boolean;
	testMessage: string;
}

@Module
class AppState extends VuexModule implements IAppStateData{
	// state
  isLoading = false;
  isInModal = false;
	testMessage = "It's working!";

  constructor(o: RegisterOptions) {
    super(o);
  }
}

export const AppStateModule: IAppStateData = new AppState({ store, name: "_state" });
import { createApp } from "vue";
import App from "./App.vue";
import router from "./Infra/router/index";
import { store } from "./Infra/store/index";

createApp(App)
	.use(store)
	.use(router)
	.mount("#app")

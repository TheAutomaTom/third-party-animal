import { createApp } from "vue";
import App from "./App.vue";
import router from "./Infrastructure/router/index";
import { store } from "./Infrastructure/store/index";

createApp(App)
	.use(store)
	.use(router)
	.mount("#app")

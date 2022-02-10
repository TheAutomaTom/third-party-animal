import { createApp } from "vue";
import App from "./App.vue";
import router from "./infra/router/index";
import { store } from "./infra/store/index";

const _app = createApp(App);

_app.use(store)
		.use(router)	

_app.mount("#app")
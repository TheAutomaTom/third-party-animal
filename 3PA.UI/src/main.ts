import Vue from 'vue'
import App from './App.vue'
import VueRouter from "vue-router";
import routes from "./infrastructure/routes";

//I bet the reason I couldn't access _app._api is because this was missing:
import store from "./store";

Vue.config.productionTip = false

Vue.use(VueRouter);
const router = new VueRouter({
  routes
});

new Vue({
  store,
  router,
  render: h => h(App),
}).$mount('#app')

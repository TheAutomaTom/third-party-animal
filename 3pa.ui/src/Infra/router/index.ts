import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'

import HomeView from "@/Views/Home/HomeView.vue"
import AboutView from "@/Views/About/AboutView.vue"
import PublicRecordsConsumerView from "@/Views/PublicRecordsConsumer/PublicRecordsConsumerView.vue"

import LoginModal from "@/Views/Modals/LoginModal.vue"


const routes: Array<RouteRecordRaw> = [
  // Pages:
  { path: "/", component: HomeView },
  { path: "/about", component: AboutView },
  { path: "/public-records/consumer", component: PublicRecordsConsumerView },
  
  // Modals:
  { path: "/login", component: LoginModal },

  // Default behavior:
  { path: '/:pathMatch(.*)', name: 'bad-not-found', component: HomeView },

];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

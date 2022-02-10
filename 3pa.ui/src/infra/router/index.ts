import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
// Pages...
import HomeView from "@/views/Home/HomeView.vue"
import AboutView from "@/views/About/AboutView.vue"
import PublicRecordsView from "@/views/PublicRecords/PublicRecordsView.vue"
import ApiPhonebookView from "@/views/ApiPhonebook/ApiPhonebookView.vue"
// Models...
import LoginModal from "@/views/Modals/LoginModal.vue"

const routes: Array<RouteRecordRaw> = [
  // Pages:
  { path: "/", component: HomeView },
  { path: "/about", component: AboutView },
  { path: "/public-records", component: PublicRecordsView },  
  { path: "/api-phonebook", component: ApiPhonebookView },
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

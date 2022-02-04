// Pages:
import HomeBody from "@/components/Home/HomeBody.vue"
import AboutBody from "@/components/About/AboutBody.vue"
import PublicRecordsConsumer from "@/components/PublicRecordsConsumer/PublicRecordsConsumerBody.vue"
// Modals:
import LoginModal from "@/components/Modals/LoginModal.vue"

const routes = [
  // Pages:
  { path: "/", component: HomeBody },
  { path: "/about", component: AboutBody },
  { path: "/public-records/consumer", component: PublicRecordsConsumer },
  
  // Modals:
  { path: "/login", component: LoginModal },

  // Utility:  
  { path: "*", redirect: "/"},

];
    

export default routes;
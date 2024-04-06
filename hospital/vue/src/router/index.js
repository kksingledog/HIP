import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import BlogView from "../views/BlogView.vue";
import NewsList from "../views/NewsList.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import ForgotPassword from "../views/ForgotPassword.vue";
import ProfileComponent from "../components/Profile/ProfileComponent.vue";
import ContactUs from "../components/Profile/ContactUs.vue";
import UpgradePremium from "../components/Profile/UpgradePremium.vue";
import AnalysisIllness from "../views/AnalysisIllness.vue"; //為老戴加油1
import NearbyHospital from "../views/NearbyHospital.vue"; //為老戴加油2
import ReviewAnalysis from "../views/ReviewAnalysis.vue"; //為老戴加油3
import firebase from "firebase/app";
import "firebase/auth";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
    meta: {
      //用來改變網頁上面的名子
      title: "Home",
      requiresAuth: false,
    },
  },
  {
    path: "/BlogView", //
    name: "Blogs", //自己取
    component: BlogView, //同import 那的
    meta: {
      title: "Blogs",
      requiresAuth: false,
    },
  },
  {
    path: "/NewsList", //
    name: "news", //自己取
    component: NewsList, //同import 那的
    meta: {
      title: "NewsList",
      requiresAuth: false,
    },
  },
  {
    path: "/Login", //
    name: "Login", //自己取
    component: LoginView, //同import 那的
    meta: {
      title: "Login",
      requiresAuth: false,
    },
  },
  {
    path: "/Register", //
    name: "Register", //自己取
    component: RegisterView, //同import 那的
    meta: {
      title: "Register",
      requiresAuth: false,
    },
  },
  {
    path: "/ForgotPassword", //
    name: "ForgotPassword", //自己取
    component: ForgotPassword, //同import 那的
    meta: {
      title: "ForgotPassword",
      requiresAuth: false,
    },
  },
  {
    path: "/profile", //
    name: "Profile", //自己取
    component: ProfileComponent, //同import 那的
    meta: {
      title: "Profile",
      requiresAuth: true,
    },
  },
  {
    path: "/AnalysisIllness", //
    name: "AnalysisIllness", //自己取
    component: AnalysisIllness, //同import 那的
    meta: {
      title: "AnalysisIllness",
      requiresAuth: false,
    },
  },
  {
    path: "/NearbyHospital", //
    name: "NearbyHospital", //自己取
    component: NearbyHospital, //同import 那的
    meta: {
      title: "NearbyHospital",
      requiresAuth: false,
    },
  },
  {
    path: "/ReviewAnalysis", //
    name: "ReviewAnalysis", //自己取
    component: ReviewAnalysis, //同import 那的
    meta: {
      title: "ReviewAnalysis",
      requiresAuth: false,
    },
  },
  {
    path: "/ContactUs", //
    name: "ContactUs", //自己取
    component: ContactUs, //同import 那的
    meta: {
      title: "ContactUs",
      requiresAuth: true,
    },
  },
  {
    path: "/UpgradePremium", //
    name: "UpgradePremium", //自己取
    component: UpgradePremium, //同import 那的
    meta: {
      title: "UpgradePremium",
      requiresAuth: true,
    },
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  document.title = `${to.meta.title} | H.I.P`;
  next();
});

router.beforeEach(async (to, from, next) => {
  let user = firebase.auth().currentUser;
  let admin = null;
  if (user) {
    let token = await user.getIdTokenResult();
    admin = token.claims.admin;
  }
  if (to.matched.some((res) => res.meta.requiresAuth)) {
    if (user) {
      if (to.matched.some((res) => res.meta.requiresAdmin)) {
        if (admin) {
          return next();
        }
        return next({ name: "home" });
      }
      return next();
    }
    return next({ name: "home" });
  }
  return next();
});

export default router;

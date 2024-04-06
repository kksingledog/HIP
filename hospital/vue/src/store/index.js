import Vue from "vue";
import Vuex from "vuex";
import firebase from "firebase/app";
import "firebase/auth";
import db from "../firebase/firebaseInit";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    sampleBlogCards: [
      //在首頁的HomePageBox會用到
      {
        blogTitle: "年節狂吃「這類食物」身體爆警訊！",
        blogCoverPhoto: "News1",
        blogDate:
          "過年期間，很多民眾擋不助美食誘惑，吃進大魚大肉，不管煎的、滷的，尤其油炸食物更是許多人最愛，該怎麼適量攝取又能維持健康，對很多人來說很難，但若不節制，引發疾病可就麻煩了。此時，靠著每年健康檢查提前揪出毛病很重要，但健康檢查報告的結果您是否真的看懂？報告出現紅字，對身體有什麼影響？",
        //NewsLink: "https://health.tvbs.com.tw/medical/337608",
      },
      {
        blogTitle: "新聞標題 2",
        blogCoverPhoto: "stock-2",
        blogDate: "May 1,2021",
      },
      {
        blogTitle: "新聞標題 3",
        blogCoverPhoto: "stock-3",
        blogDate: "May 1,2021",
      },
      {
        blogTitle: "新聞標題 4",
        blogCoverPhoto: "stock-4",
        blogDate: "May 1,2021",
      },
    ],
    editPost: null,
    user: null,
    profileEmail: null,
    profileFirstName: null,
    profileLastName: null,
    profileUsername: null,
    profileId: null,
    profileInitials: null,
  },
  getters: {},
  mutations: {
    //字面意思:"突變"，用來改變頁面狀態用
    toggleEditPost(state, payload) {
      //此mutation是用來練習用，不用理這個
      state.editPost = payload;
    },
    updateUser(state, payload) {
      state.user = payload;
    },
    setProfileInfo(state, doc) {
      state.profileId = doc.id;
      state.profileEmail = doc.data().email;
      state.profileFirstName = doc.data().firstName;
      state.profileLastName = doc.data().lastName;
      state.profileUsername = doc.data().userName;
    },
    setProfileInitials(state) {
      state.profileInitials =
        state.profileFirstName.match(/(\b\S)?/g).join("") +
        state.profileLastName.match(/(\b\S)?/g).join("");
    },
    changeFirstName(state, payload) {
      state.profileFirstName = payload;
    },
    changeLastName(state, payload) {
      state.profileLastName = payload;
    },
    changeUsername(state, payload) {
      state.profileUsername = payload;
    },
  },
  actions: {
    async getCurrentUser({ commit }) {
      const dataBase = await db
        .collection("users")
        .doc(firebase.auth().currentUser.uid);
      const dbResults = await dataBase.get();
      commit("setProfileInfo", dbResults);
      commit("setProfileInitials");
      console.log(dbResults);
    },
    async updateUserSettings({ commit, state }) {
      const dataBase = await db.collection("users").doc(state.profileId);
      await dataBase.update({
        firstName: state.profileFirstName,
        lastName: state.profileLastName,
        userName: state.profileUsername,
      });
      commit("setProfileInitials");
    },
  },
  modules: {},
});

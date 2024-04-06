import firebase from "firebase/app";
import "firebase/firestore";

const firebaseConfig = {
  apiKey: "AIzaSyAkfe_cgCN5S6Nl_WzKF67_ycLuIhSdaDI",
  authDomain: "project2-6a533.firebaseapp.com",
  projectId: "project2-6a533",
  storageBucket: "project2-6a533.appspot.com",
  messagingSenderId: "239781488306",
  appId: "1:239781488306:web:ecb26d04251935504a8bab",
};

const firebaseApp = firebase.initializeApp(firebaseConfig);
const timestamp = firebase.firestore.FieldValue.serverTimestamp;

export { timestamp };
export default firebaseApp.firestore();

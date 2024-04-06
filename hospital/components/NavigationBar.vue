<template>
  <header>
    <nav class="container">
      <div class="branding">
        <router-link class="header" :to="{ name: 'home' }"> H.I.P.</router-link>
      </div>
      <div class="nav-links">
        <ul v-show="!mobile">
          <router-link class="link" :to="{ name: 'AnalysisIllness' }"
            >症狀分析</router-link
          >
          <router-link class="link" :to="{ name: 'NearbyHospital' }"
            >附近院所</router-link
          >
          <router-link class="link" :to="{ name: 'news' }"
            >醫療新聞</router-link
          >
          <router-link class="link" :to="{ name: 'ReviewAnalysis' }"
            >評價分析</router-link
          >
          <router-link v-if="!user" class="link" :to="{ name: 'Login' }"
            >login/register</router-link
          >
        </ul>
        <div
          v-show="!mobile"
          v-if="user"
          @click="toggleProfileMenu"
          class="profile"
          ref="profile"
        >
          <!--此區塊對應主頁登入後最右邊的個人檔案-->
          <span>{{ this.$store.state.profileInitials }}</span>
          <div v-show="profileMenu" class="profile-menu">
            <div class="info">
              <p class="initials">{{ this.$store.state.profileInitials }}</p>
              <div class="right">
                <p>
                  {{ this.$store.state.profileFirstName }}
                  {{ this.$store.state.profileLastName }}
                </p>
                <p>{{ this.$store.state.profileUserName }}</p>
                <p>{{ this.$store.state.profileEmail }}</p>
              </div>
            </div>
            <div class="options">
              <div class="option">
                <router-link class="option" :to="{ name: 'Profile' }">
                  <userIcon class="icon" />
                  <p>Profile</p>
                </router-link>
              </div>
              <div class="option">
                <router-link class="option" :to="{ name: 'UpgradePremium' }">
                  <upgradeIcon class="icon" />
                  <p>升級Premium</p>
                </router-link>
              </div>
              <div class="option">
                <router-link class="option" :to="{ name: 'ContactUs' }">
                  <adminIcon class="icon" />
                  <p>聯絡我們</p>
                </router-link>
              </div>
              <div @click="signOut" class="option">
                <signOutIcon class="icon" />
                <p>Sign Out</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </nav>
    <menuIcon @click="toggleMobileNav" class="menu-icon" v-show="mobile" />
    <transition name="mobile-nav">
      <ul class="mobile-nav" v-show="mobileNav">
        <router-link class="link" :to="{ name: 'AnalysisIllness' }"
          >症狀分析</router-link
        >
        <router-link class="link" :to="{ name: 'NearbyHospital' }"
          >附近院所</router-link
        >
        <router-link class="link" :to="{ name: 'news' }">醫療新聞</router-link>
        <router-link class="link" :to="{ name: 'ReviewAnalysis' }"
          >評價分析</router-link
        >
        <router-link v-if="!user" class="link" :to="{ name: 'Login' }"
          >login/register</router-link
        >
        <router-link v-if="user" class="link" :to="{ name: 'Profile' }"
          >profile</router-link
        >
      </ul>
    </transition>
  </header>
</template>

<script>
import menuIcon from "../assets/Icons/bars-regular.svg";
import userIcon from "../assets/Icons/user-alt-light.svg";
import adminIcon from "../assets/Icons/user-crown-light.svg";
import upgradeIcon from "../assets/Icons/upgrade.svg";
import signOutIcon from "../assets/Icons/sign-out-alt-regular.svg";
import firebase from "firebase/app";
import "firebase/auth";

export default {
  name: "NavigationView",
  components: {
    menuIcon,
    userIcon,
    adminIcon,
    signOutIcon,
    upgradeIcon,
  },
  data() {
    return {
      profileMenu: null,
      mobile: null,
      mobileNav: null,
      windowWidth: null,
    };
  },
  created() {
    window.addEventListener("resize", this.checkScreen);
    this.checkScreen();
  },
  methods: {
    checkScreen() {
      this.windowWidth = window.innerWidth;
      if (this.windowWidth <= 970) {
        this.mobile = true;
        return;
      }
      this.mobile = false;
      this.mobileNav = false;
      return;
    },

    toggleMobileNav() {
      this.mobileNav = !this.mobileNav;
    },
    toggleProfileMenu(e) {
      if (e.target === this.$refs.profile) {
        this.profileMenu = !this.profileMenu;
      }
    },

    signOut() {
      firebase.auth().signOut();
      window.location.reload();
    },
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
};
</script>

<style lang="scss" scoped>
header {
  background-color: #fff;
  padding: 0 25px;
  // eslint-disable-next-line prettier/prettier, prettier/prettier
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1),
    0 2px 4px -1px rgba(0, 0, 0, 0.06);
  z-index: 99;

  .link {
    font-size: 20px;
    font-weight: 800;
    padding: 0 8px;
    transition: 0.3s color ease;

    &:hover {
      color: #1eb8b8;
    }
  }

  nav {
    display: flex;
    padding: 25px 0;

    .branding {
      display: flex;
      align-items: center;
      font-size: 48px;
      font-weight: bold;

      .header {
        font-weight: 600;
        font-size: 24 px;
        color: #000;
        text-decoration: none;
      }
    }

    .nav-links {
      position: relative;
      display: flex;
      flex: 1;
      align-items: center;
      justify-content: flex-end;

      ul {
        margin-right: 32px;

        .link {
          margin-right: 32px;
        }

        .link:last-child {
          margin-right: 0;
        }
      }

      .profile {
        position: relative;
        cursor: pointer;
        display: flex;
        align-items: center;
        justify-content: center;
        width: 40px;
        height: 40px;
        border-radius: 50%;
        color: #fff;
        background-color: #303030;

        span {
          pointer-events: none;
        }

        .profile-menu {
          position: absolute;
          top: 60px;
          right: 0;
          width: 250px;
          background-color: #303030;
          box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1),
            0 2px 4px -1px rgba(0, 0, 0, 0.06);

          .info {
            display: flex;
            align-items: center;
            padding: 15px;
            border-bottom: 1px solid #fff;

            .initials {
              position: initial;
              width: 40px;
              height: 40px;
              background-color: #fff;
              color: #303030;
              display: flex;
              align-items: center;
              justify-content: center;
              border-radius: 50%;
            }

            .right {
              flex: 1;
              margin-left: 24px;

              p:nth-child(1) {
                font-size: 14px;
              }

              p:nth-child(2),
              p:nth-child(3) {
                font-size: 12px;
              }
            }
          }

          .options {
            padding: 15px;
            .option {
              text-decoration: none;
              color: #fff;
              display: flex;
              align-items: center;
              margin-bottom: 12px;

              .icon {
                width: 18px;
                height: auto;
              }
              p {
                font-size: 14px;
                margin-left: 12px;
              }

              &:last-child {
                margin-bottom: 0px;
              }
            }
          }
        }
      }
    }
  }

  .menu-icon {
    cursor: pointer;
    position: absolute;
    top: 48px;
    right: 25px;
    height: 30px;
    width: auto;
  }

  .mobile-nav {
    padding: 20px;
    width: 70%;
    max-width: 250px;
    display: flex;
    flex-direction: column;
    position: fixed;
    height: 100%;
    background-color: #303030;
    top: 0;
    left: 0;

    .link {
      padding: 15px 0;
      color: #fff;
    }
  }

  .mobile-nav-enter-active,
  .mobile-nav-leave-active {
    transition: all 1s ease;
  }

  .mobile-nav-enter {
    transform: translateX(-250px);
  }

  .mobile-nav-enter-to {
    transform: translateX(0);
  }

  .mobile-nav-leave-to {
    transform: translateX(-250px);
  }
}
</style>

<template>
  <div class="profile">
    <Modal
      v-if="modalActive"
      :modalMessage="modalMessage"
      v-on:close-modal="closeModal"
    />
    <div class="container">
      <h2>聯絡我們</h2>
      <div class="profile-info">
        <div class="input">
          <label for="firstName">First Name:</label>
          <input type="text" id="firstName" v-model="firstName" />
        </div>
        <div class="input">
          <label for="lastName">Last Name:</label>
          <input type="text" id="lastName" v-model="lastName" />
        </div>
        <div class="input">
          <label for="email">Email:</label>
          <input disabled type="text" id="email" v-model="email" />
        </div>
        <div class="input">
          <label for="email">Title:</label>
          <input type="text" id="email" />
        </div>
        <div class="input2">
          <label for="email">Content:</label>
          <input type="text" id="email" />
        </div>
        <button @click="updateProfile">送出訊息</button>
      </div>
    </div>
  </div>
</template>

<script>
import Modal from "../ForgotPassword/ModalComponent.vue";
export default {
  name: "ProfileComponent",
  components: {
    Modal,
  },
  data() {
    return {
      modalMessage: "訊息送出成功",
      modalActive: null,
    };
  },
  methods: {
    updateProfile() {
      this.$store.dispatch("updateUserSettings");
      this.modalActive = !this.modalActive;
    },
    closeModal() {
      this.modalActive = !this.modalActive;
    },
  },
  computed: {
    firstName: {
      get() {
        return this.$store.state.profileFirstName;
      },
    },
    lastName: {
      get() {
        return this.$store.state.profileLastName;
      },
    },
    username: {
      get() {
        return this.$store.state.profileUsername;
      },
    },
    email: {
      get() {
        return this.$store.state.profileEmail;
      },
    },
  },
};
</script>

<style lang="scss" scoped>
.profile {
  .container {
    max-width: 1000px;
    padding: 60px 25px;

    h2 {
      text-align: center;
      margin-bottom: 16px;
      font-weight: 300;
      font-size: 32px;
    }

    .profile-info {
      border-radius: 8px;
      box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1),
        0 2px 4px -1px rgba(0, 0, 0, 0.06);
      padding: 32px;
      background-color: #f1f1f1;
      display: flex;
      flex-direction: column;
      max-width: 600px;
      margin: 32px auto;

      .initials {
        position: initial;
        width: 80px;
        height: 80px;
        font-size: 32px;
        background-color: #303030;
        color: #fff;
        display: flex;
        align-self: center;
        align-items: center;
        justify-content: center;
        border-radius: 50%;
      }

      .input {
        margin: 16px 0;

        label {
          font-size: 14px;
          display: block;
          padding-bottom: 6px;
        }
        input {
          width: 100%;
          border-radius: 10px;
          border: none;
          background-color: #ffbfff;
          padding: 8px;
          height: 50px;
          @media (min-width: 900px) {
          }

          &:focus {
            outline: none;
          }
        }
      }

      .input2 {
        margin: 16px 0;

        label {
          font-size: 14px;
          display: block;
          padding-bottom: 6px;
        }
        input {
          width: 100%;
          border-radius: 10px;
          border: none;
          background-color: #ffbfff;
          padding: 8px;
          height: 200px;
          @media (min-width: 900px) {
          }

          &:focus {
            outline: none;
          }
        }
      }

      button {
        align-self: center;
      }
    }
  }
}
</style>

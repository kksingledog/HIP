<template>
  <div>
    <a href="#" id="show-modal" @click="menuClicked">
      <img :class="{ active: showModal }" alt="Menu" src="@/assets/menu.png" />
    </a>
    <div id="menu-modal" v-if="showModal">
      <div v-for="item of providers" :key="item.id" class="menu-choice">
        <input
          type="checkbox"
          :id="item.id"
          :value="item.id"
          v-model="checkedSources"
        />
        <label :for="item.id">{{ item.name }}</label>
        &nbsp;
        <img class="source-icon" :src="item.icon ?? null" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AppMenu",
  props: ["providers"],
  data() {
    return {
      showModal: false,
      checkedSources: [this.providers[0].id],
    };
  },
  methods: {
    menuClicked() {
      this.showModal = !this.showModal;
      if (!this.showModal) {
        this.$emit("clicked", this.checkedSources);
      }
    },
  },
};
</script>

<style scoped>
a img {
  transition: all 0.3s ease-in;
}
.active {
  transform: rotate(-90deg);
  opacity: 0.5;
}
a img:hover {
  transform: rotate(-90deg);
}

.source-icon {
  width: 24px;
  height: auto;
  vertical-align: bottom;
}

#menu-modal {
  position: absolute;
  background: #00adad;
  color: #fff;
  transform: translate(-250px, 20px);
  width: 250px;
  border-radius: 7px;
  border-top-right-radius: 0;
  padding: 15px;
}

.menu-choice {
  font-size: 1.2em;
  padding: 5px;
}

.menu-choice input {
  margin-right: 10px;
}
</style>

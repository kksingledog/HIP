<template>
  <div class="infocard">
    <div class="information">
      <p class="date">{{ mdata.date }}</p>
      <h3>{{ mdata.title }}</h3>
      <p>{{ mdata.news }}</p>
      <p class="link">
        <a target="_blank" :href="mdata.link">
          前往閱讀 {{ mdata.source }}
          <span class="spaceHover">&nbsp;</span>
          >
        </a>
      </p>
    </div>
    <div class="photography">
      <a target="_blank" :href="mdata.link">
        <img
          v-if="mdata.photoUrl && mdata.photoUrl.length"
          :src="mdata.photoUrl"
          alt="Photo"
        />
        <img
          v-if="!mdata.photoUrl || !mdata.photoUrl.length"
          src="@/assets/bg.png"
          alt="Photo Non disponible"
        />
      </a>
    </div>
  </div>
</template>

<script>
export default {
  name: "InfoCard",
  props: {
    mdata: {},
  },
  data() {
    return {
      backupURL: "@/assets/bg.png",
    };
  },
};
</script>

<style scoped>
.infocard {
  background: #fff;
  display: flex;
  margin: 0 auto;
  margin-top: 30px;
  margin-bottom: 10px;
  padding: 15px;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1),
    0 2px 4px -1px rgba(0, 0, 0, 0.06);
  border-radius: 7px;
  min-height: 150px;
  max-width: 650px;
}
.information {
  background-color: #fff;
  display: flex;
  flex-direction: column;
  flex-basis: 60%;
}
.photography {
  text-align: right;
  vertical-align: middle;
  align-self: right;
  flex-basis: 40%;
  padding: 30px 5px;
}
.photography img {
  border-radius: 7px;
  right: 0px;
  max-width: 250px;
  height: auto;
}
h3,
p {
  margin: 2px 0;
  margin-right: 10px;
}
h3 {
  font-size: 1em;
}
p.date {
  font-size: 0.9em;
}
a {
  text-decoration: none;
  color: var(--black-color);
}
a:hover {
  color: var(--blackdrop-color);
}
a:hover span.spaceHover::before {
  content: "_";
  color: #303030;
}
.information p.link {
  padding-top: 20px;
}
@media (max-width: 800px) {
  .infocard {
    flex-direction: column-reverse;
  }
  .photography {
    text-align: center;
  }
  .photography img {
    max-width: 100%;
    height: auto;
  }
}
</style>

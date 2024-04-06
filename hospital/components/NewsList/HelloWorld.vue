<template>
  <div class="hello">
    <h2>醫療新聞</h2>
    <p>
      <span v-for="item of newsSources" :key="item"> {{ item }} &nbsp; </span>
      <span v-if="!newsSources.length">抱歉，您未點擊任何資料 !</span>
    </p>
  </div>
</template>

<script>
export default {
  name: "HelloWorld",
  props: {
    msg: String,
    newsSources: Array,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
div.hello {
  max-width: 600px;
  margin: 0 auto;
}
h2 {
  text-align: center;
  font-size: 50px;
  margin-bottom: 20px;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
p {
  padding: 5px;
  border-top-right-radius: 7px;
  background: #00adad;
  color: #fff;
}
</style>

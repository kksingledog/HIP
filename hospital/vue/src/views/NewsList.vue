<template>
  <div class="news">
    <HeaderBox @updateSource="reloadFeed" :providers="providers" />
    <HelloWorld msg="Welcome" :newsSources="getPrettyNewsSources()" />
    <div
      id="pagetop"
      class="fixed right-0 bottom-0"
      v-show="scY > 300"
      @click="toTop"
    ></div>
    <div v-for="item of items" :key="item.title">
      <InfoCard :mdata="item" />
    </div>
  </div>
</template>

<script>
import InfoCard from "../components/NewsList/InfoCard.vue";
import HeaderBox from "../components/NewsList/HeaderBox.vue";
import HelloWorld from "../components/NewsList/HelloWorld.vue";
export default {
  name: "BlogsView",
  components: { InfoCard, HeaderBox, HelloWorld },
  mounted() {
    window.addEventListener("scroll", this.handleScroll);
  },
  data() {
    return {
      scTimer: 0,
      scY: 0,
      providers: [
        {
          id: "franceinfo",
          name: "最新新聞",
          url: "https://news.ltn.com.tw/rss/sports.xml",
          icon: "https://www.francetvinfo.fr/favicon.ico",
        },
        {
          id: "lemonde",
          name: "假新聞迷思",
          url: "https://news.ltn.com.tw/rss/all.xml",
          icon: "https://www.lemonde.fr/favicon.ico",
        },
        {
          id: "lefigaro",
          name: "Le Figaro",
          url: "https://www.lefigaro.fr/rss/figaro_actualites.xml",
          icon: "https://www.lefigaro.fr/favicon.ico",
        },
        {
          id: "lexpress",
          name: "L'Express",
          url: "https://www.lexpress.fr/rss/alaune.xml",
          icon: "https://www.lexpress.fr/favicon.ico",
        },
        {
          id: "lesechos",
          name: "Les Echos",
          url: "https://syndication.lesechos.fr/rss/Echos_monde.xml",
          icon: "https://static.lesechos.com/92e40a9a0703634421493f0428f24d1e.png",
        },
        {
          id: "nouvelobs",
          name: "L'Obs",
          url: "https://www.nouvelobs.com/monde/rss.xml",
          icon: "https://www.nouvelobs.com/favicon.ico",
        },
      ],
      items: [],
      newsSources: ["franceinfo"],
    };
  },
  methods: {
    handleScroll: function () {
      if (this.scTimer) return;
      this.scTimer = setTimeout(() => {
        this.scY = window.scrollY;
        clearTimeout(this.scTimer);
        this.scTimer = 0;
      }, 100);
    },
    toTop: function () {
      window.scrollTo({
        top: 0,
        behavior: "smooth",
      });
    },
    getPrettyNewsSources() {
      let prettyNews = [];
      this.newsSources.forEach((element) => {
        this.providers.forEach((newsProvider) => {
          if (newsProvider.id === element) {
            prettyNews.push(newsProvider.name);
          }
        });
      });
      return prettyNews;
    },
    reloadFeed(updatedSources) {
      if (JSON.stringify(this.newsSources) != JSON.stringify(updatedSources)) {
        this.newsSources = updatedSources;
        this.items = [];
        updatedSources.forEach((element) => {
          this.providers.forEach((newsProvider) => {
            if (element === newsProvider.id) {
              this.getRss(newsProvider.url, newsProvider.name);
            }
          });
        });
      }
    },
    async getRss(url, source) {
      if (!url) {
        url = this.providers[0].url;
      }
      if (!source) {
        source = this.providers[0].name;
      }
      const res = await fetch('http://localhost:5003/api/News');
      const { contents } = await res.json();
      const feed = new window.DOMParser().parseFromString(contents, "text/xml");
      const items = feed.querySelectorAll("NewsData");
      let newitems = [...items].map((el) => ({
          title: this.cleanNews(this.safegetXML(el, "NewsTitles")),
          news: this.cleanNews(this.safegetXML(el, "NewsArtical")),
          date: this.safegetXML(el, "NewsTimes"),
          link: this.safegetXML(el, "NewsHref"),
        photoUrl: this.photoParserXML(el),
        source: source,
      }));
      this.items = [...this.items, ...newitems];
    },
    photoParserXML(el) {
      if (
        el &&
        el.querySelector("enclosure") &&
        el.querySelector("enclosure").getAttribute
      ) {
        return el.querySelector("enclosure").getAttribute("url");
      }
      if (el && el.lastElementChild && el.lastElementChild.getAttribute) {
        return el.lastElementChild.getAttribute("url");
      }
      return "";
    },
    safegetXML(el, selectMe) {
      if (!el) return "";
      let selected = el.querySelector(selectMe);
      if (!selected) {
        return "";
      }
      return selected.innerHTML;
    },
    cleanNews(dirty) {
      let clean = dirty
        .replace("<![CDATA[", "")
        .replace("]]>", "")
        .replace("&quot;", "'")
        .replace("&#039;", "'")
        .replace("&nbsp;", " ")
        .replace(".&nbsp;", " ");
      return clean;
    },
  },
  created: function () {
    this.getRss();
  },
};
</script>

<style scoped>
:root {
  --primary-color: #4fb2b2;
  --primary-shade-color: #20605d;
  --background-color: #303030;
  --background-shade-color: #f2efe2;
  --black-color: #2c3e50;
  --blackdrop-color: #2c3e5033;
}
.news {
  background-color: #bfbfbf;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--primary-shade-color);
  margin-top: 10px;
}
h3 {
  font-size: 18px;
}
#pagetop {
  position: fixed;
  left: 80vw;
  bottom: 10px;
  background: var(--primary-color);
  color: var(--background-color);
  border-radius: 7px;
}
</style>

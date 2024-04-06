<template>
  <footer>
    <div class="container">
      <div class="left">
        <div class="col-1">
          <RouterLink class="header" :to="{ name: 'home' }"> H.I.P </RouterLink>
          <ul>
            <li>
              <a href="#">
                <youTube class="svg-icon" />
              </a>
            </li>
            <li>
              <a href="#">
                <twitter class="svg-icon" />
              </a>
            </li>
            <li>
              <a href="#">
                <instagram class="svg-icon" />
              </a>
            </li>
            <li>
              <a href="#">
                <linkedin class="svg-icon" />
              </a>
            </li>
          </ul>
        </div>
        <div class="col-2">
          <ul>
            <RouterLink class="link" :to="{ name: 'AnalysisIllness' }">
              症狀分析
            </RouterLink>
            <RouterLink class="link" :to="{ name: 'NearbyHospital' }">
              附近院所
            </RouterLink>
            <RouterLink class="link" :to="{ name: 'news' }">
              醫療新聞
            </RouterLink>
            <RouterLink class="link" :to="{ name: 'ReviewAnalysis' }">
              評價分析
            </RouterLink>
            <RouterLink v-if="!user" class="link" :to="{ name: 'Login' }">
              Login In/Register
            </RouterLink>
          </ul>
        </div>
      </div>
      <div class="right">
        <p>Copyright@ 2022-2023 H.I.P All right reserved</p>
      </div>
    </div>
  </footer>
</template>

<script>
import youTube from "../assets/Icons/youtube-brands.svg";
import twitter from "../assets/Icons/twitter-brands.svg";
import instagram from "../assets/Icons/instagram-brands.svg";
import linkedin from "../assets/Icons/linkedin-brands.svg";
export default {
  name: "footer-vue",
  components: {
    youTube,
    twitter,
    instagram,
    linkedin,
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
};
</script>

<style lang="scss" scoped>
footer {
  margin-top: auto;
  padding: 30px 25px; //邊框大小
  background-color: #303030; //背景顏色

  .container {
    display: flex;
    flex-direction: column;
    gap: 32px;

    @media (min-width: 800px) {
      flex-direction: row;
      gap: 32px;
    }

    > div {
      display: flex;
      flex: 1;
    }

    .left {
      gap: 32px;
      color: #fff;
      flex-direction: column;
      align-items: center;

      @media (min-width: 800px) {
        flex-direction: row;
        align-items: initial;
        gap: 0;
      }

      .header {
        text-align: center;
        font-size: 48px;
        color: #fff;
        text-decoration: none;
        font-weight: 600;
        @media (min-width: 800px) {
          text-align: initial;
        }
      }

      ul {
        gap: 16px;
        list-style: none;
        display: flex;
      }

      .col-1,
      .col-2 {
        gap: 32px;
        display: flex;
        flex: 1;

        @media (min-width: 800px) {
          gap: 0;
        }
      }

      .col-1 {
        flex-direction: column;

        h2 {
          text-align: center;

          @media (min-width: 800px) {
            text-align: initial;
          }
        }

        ul {
          margin-top: auto;

          li {
            display: flex;
            align-items: center;

            .svg-icon {
              width: 24px;
              height: auto;
              color: #fff;
            }
          }
        }
      }

      .col-2 {
        ul {
          height: 100%;
          justify-content: center; //水平置中
          flex-direction: row; //橫向排列
          flex-wrap: wrap; //如果子元素數量較多時，內容常會被壓縮且擠在同一行，這時我們就可以透過 flex-wrap 來換行

          @media (min-width: 800px) {
            flex-direction: column; //垂直排列
          }

          .link {
            font-size: 16px;
            font-weight: 500; //字體粗細
            color: #fff; //字體顏色
            text-decoration: none; //設定文字的裝飾
            text-align: center; //垂直置中
          }
        }
      }
    }

    .right {
      gap: 32px;
      color: #fff;
      align-items: center;
      flex-direction: column;

      @media (min-width: 800px) {
        align-items: flex-end;
        gap: 0;
      }
    }

    p {
      margin-top: auto;
    }
  }
}
</style>

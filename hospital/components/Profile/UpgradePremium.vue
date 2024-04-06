<template>
  <div class="upgrade">
    <h2>升級成為 Premium</h2>
    <div class="container">
      <div class="profile-info">
        <h2>一般會員</h2>
        <p>收費標準 : 免費</p>
        <span>■ 免錢的誰不愛</span>
        <span>■ 一般病徵分析</span>
      </div>
    </div>
    <div class="container">
      <div class="profile-info">
        <h2>Premium</h2>
        <p>收費標準 : 500元/月</p>
        <span>■ 醫師的評價及推薦指數</span>
        <span>■ 超級不定期消息</span>
        <button @click="updateProfile"><span>立即升級</span></button>
      </div>
    </div>
  </div>
</template>

<script></script>

<style lang="scss" scoped>
.upgrade {
  h2 {
    text-align: center;
    margin-top: 50px;
    font-size: 50px;
  }

  .container {
    float: left;
    max-width: 1000px;
    padding: 10px 25px;
    width: 500px;
    margin-left: 178px;
    margin-top: 20px;

    .profile-info {
      border-radius: 8px;
      box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1),
        0 2px 4px -1px rgba(0, 0, 0, 0.06);
      padding: 10px;
      background-color: #008f8f;
      display: flex;
      flex-direction: column;
      max-width: 600px;
      margin: 32px auto;
      border: #000;
      border-width: 10px;
      height: 450px;
      margin-top: 20px;

      h2 {
        font-weight: 700;
        font-size: 35px;
        color: #fff;
        margin-top: 30px;
      }

      p {
        text-align: center;
        font-weight: 500;
        font-size: 25px;
        color: #fff;
        margin-top: 20px;
      }

      span {
        color: #fff;
        font-size: 30px;
        font-weight: 400;
        margin-top: 50px;
      }

      button {
        align-self: center;
        padding: 20px 40px;
        margin-top: 50px;

        span {
          font-size: 20px;
          font-weight: 700;
        }
      }
    }
  }
}
</style>

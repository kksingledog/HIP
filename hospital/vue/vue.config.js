const { defineConfig } = require("@vue/cli-service");
module.exports = defineConfig({
  transpileDependencies: true,
});
module.exports = {
  //1. 需先删除默认配置中处理svg
  chainWebpack: (config) => {
    config.module.rules.delete("svg");
  },
  // 2.配置loader
  configureWebpack: {
    module: {
      rules: [
        {
          test: /\.svg$/,
          loader: "vue-svg-loader",
        },
      ],
    },
  },
};

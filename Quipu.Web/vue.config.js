module.exports = {
  devServer: {
    proxy: "http://192.168.1.166:5000",
  },

  transpileDependencies: ["vuetify", "quasar"],

  pluginOptions: {
    quasar: {
      importStrategy: "kebab",
      rtlSupport: false,
    },
  },
};

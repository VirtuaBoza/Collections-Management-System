const path = require('path'); // module built into node.js for pathing
const webpack = require('webpack'); // to access plugins built into webpack
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
  entry: {
    vendor: './client/vendor.js',
    main: './client/main.js',
    'main-validation': './client/main-validation.js',
    'collection-create': './client/collection-create.js',
  },
  output: {
    path: path.resolve(__dirname, 'wwwroot/dist'),
    filename: '[name].js'
  },
  plugins: [
    new webpack.ProvidePlugin({
      $: 'jquery',
      jQuery: 'jquery',
      'window.jQuery': 'jquery',
      Popper: ['popper.js', 'default']
    }),
    new MiniCssExtractPlugin({
      filename: "[name].css",
      chunkFilename: "[id].css"
    })
  ],
  module: {
    rules: [{
      test: /\.scss$/,
      use: [
        MiniCssExtractPlugin.loader,
        "css-loader",
        "sass-loader"
      ]
    }]
  }
};

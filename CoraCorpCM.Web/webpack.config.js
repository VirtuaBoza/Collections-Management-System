const path = require('path'); // module built into node.js for pathing
const webpack = require('webpack'); // to access plugins built into webpack

module.exports = {
    entry: './client/main.js',
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery'
        })]
};

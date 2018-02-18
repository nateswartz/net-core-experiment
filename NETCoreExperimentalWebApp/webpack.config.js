'use strict'
const path = require('path')

module.exports = {
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        },
        extensions: ['*', '.js', '.vue', '.json']
    },
    entry: {
        home: path.resolve(__dirname, './VueApp/homePage.js'),
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        publicPath: 'dist/',
        filename: 'build.js'
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            }
        ]
    }
}

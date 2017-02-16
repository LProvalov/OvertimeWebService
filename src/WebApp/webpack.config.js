"use strict";

var path = require('path');
var CopyWebpackPlugin = require('copy-webpack-plugin');
var WatchIgnorePlugin = require('webpack').WatchIgnorePlugin;

var dir_js = path.resolve(__dirname, 'wwwroot/js');
var dir_css = path.resolve(__dirname, "wwwroot/css");
var dir_build = path.resolve(__dirname, "wwwroot/dist");
var dir_test_html = path.resolve(__dirname, "wwwroot/tests/html");
var dir_test_dist = path.resolve(__dirname, "wwwroot/tests/dist");
var dir_libs = path.resolve(__dirname, "wwwroot/lib");

module.exports = {
    context: dir_js,
    entry: path.resolve(dir_js, 'app.js'),
    output: {
        path: dir_build,
        filename: "bundle.js"
    },    
    module: {
        loaders: [
            {
                test: dir_js,
                loader: "babel-loader",                
            }
        ]
    },
    plugins: [
        new WatchIgnorePlugin([
            path.resolve(__dirname, "wwwroot/tests"),
            path.resolve(__dirname, "wwwroot/tests/dist"),
            path.resolve(__dirname, "wwwroot/tests/html"),
            path.resolve(dir_libs, "**/")
        ]),
        new CopyWebpackPlugin([
            { from: dir_test_html, to: dir_test_dist },
            { from: dir_css, to: dir_test_dist },
            { from: dir_build, to: dir_test_dist }
        ]),

    ],
    devtool: 'source-map',
    devServer: {
        contentBase: [dir_test_dist, dir_css],
        contentPath: dir_test_dist,
        host: "localhost",
        port: 5900,
        output: dir_test_dist
    },
};
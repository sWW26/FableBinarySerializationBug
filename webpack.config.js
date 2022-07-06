// Note this only includes basic configuration for development mode.
// For a more comprehensive configuration check:
// https://github.com/fable-compiler/webpack-config-template

var path = require("path");

module.exports = {
    mode: "development",
    entry: "./src/FableBinarySerializationBug.Client/App.fs.js",
    output: {
        path: path.join(__dirname, "./public"),
        filename: "bundle.js",
    },
    devServer: {
        publicPath: "/",
        contentBase: "./public",
        port: 8080,
        host: '0.0.0.0',
        port: 8080,
        proxy: {
            '/api/**': {
                target: 'http://localhost:5000',
                changeOrigin: true
            },
        }
    },
    module: {
    }
}

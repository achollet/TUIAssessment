import { join } from "path";
import { ProvidePlugin, DefinePlugin, DllPlugin, optimize } from "webpack";
import ExtractTextPlugin from "extract-text-webpack-plugin";

export default env => {
  const isDevBuild = !(env && env.prod);
  const extractCSS = new ExtractTextPlugin("vendor.css");

  return [
    {
      stats: { modules: false },
      resolve: { extensions: [".js"] },
      entry: {
        vendor: [
          "bootstrap",
          "bootstrap/dist/css/bootstrap.css",
          "event-source-polyfill",
          "isomorphic-fetch",
          "jquery",
          "vue",
          "vue-router"
        ]
      },
      module: {
        rules: [
          {
            test: /\.css(\?|$)/,
            use: extractCSS.extract({
              use: isDevBuild ? "css-loader" : "css-loader?minimize"
            })
          },
          {
            test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/,
            use: "url-loader?limit=100000"
          }
        ]
      },
      output: {
        path: join(__dirname, "wwwroot", "dist"),
        publicPath: "dist/",
        filename: "[name].js",
        library: "[name]_[hash]"
      },
      plugins: [
        extractCSS,
        new ProvidePlugin({ $: "jquery", jQuery: "jquery" }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
        new DefinePlugin({
          "process.env.NODE_ENV": isDevBuild ? '"development"' : '"production"'
        }),
        new DllPlugin({
          path: join(__dirname, "wwwroot", "dist", "[name]-manifest.json"),
          name: "[name]_[hash]"
        })
      ].concat(isDevBuild ? [] : [new optimize.UglifyJsPlugin()])
    }
  ];
};

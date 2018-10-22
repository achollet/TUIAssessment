import "./css/site.css";
import "bootstrap";
import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

const routes = [
  {
    path: "/flightcreator",
    component: require("./components/flightcreator/flightcreator.vue.html")
  },
  {
    path: "/flightsreport",
    component: require("./components/flightsreport/flightsreport.vue.html")
  }
];

new Vue({
  el: "#app-root",
  router: new VueRouter({ mode: "history", routes: routes }),
  render: h => h(require("./components/app/app.vue.html"))
});

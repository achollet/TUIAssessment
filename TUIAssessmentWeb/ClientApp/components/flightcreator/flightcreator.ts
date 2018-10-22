import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({
  components: {
    AirportsDropDownComponent: require("../airportsdropdown/airportsdropdown.vue.html")
  }
})
export default class FlightCreatorComponent extends Vue {}

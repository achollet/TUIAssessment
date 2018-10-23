import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({
  components: {
    FlightCreatorForm: require('../flightcreator/flightcreator.vue.html')
  }
})
export default class HomeComponent extends Vue {}

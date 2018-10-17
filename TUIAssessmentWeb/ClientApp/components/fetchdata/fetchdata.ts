import Vue from "vue";
import { Component } from "vue-property-decorator";

interface Flights {
  id: number;
  departureAirportCode: string;
  arrivalAirportCode: string;
  distance: number;
  timeOfFlight: number;
  volumeOfCarburant: number;
  creationDate: string;
  updateDate: string;
}

@Component
export default class FetchDataComponent extends Vue {
  flights: Flights[] = [];

  mounted() {
    fetch("api/SampleData/FlightsReport")
      .then(response => response.json() as Promise<Flights[]>)
      .then(data => {
        this.flights = data;
      });
  }
}

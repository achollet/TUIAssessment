import Vue from 'vue';

interface Airport {
  code: string;
  name: string;
}

export default class AirportsDropDownComponent extends Vue {
  airports: Airport[] = [];

  mounted() {
    fetch('api/FlightCreator/GetAirports')
      .then(response => response.json() as Promise<Airport[]>)
      .then(data => (this.airports = data));
  }
}

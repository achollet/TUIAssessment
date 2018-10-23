import Vue from 'vue';

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

export default class FlightsReportComponent extends Vue {
  flights: Flights[] = [];

  mounted() {
    fetch('api/FlightsReport/GetReport')
      .then(response => response.json() as Promise<Flights[]>)
      .then(data => {
        this.flights = data;
      });
  }
}

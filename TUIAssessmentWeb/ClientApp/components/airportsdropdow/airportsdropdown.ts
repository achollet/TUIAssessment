import Vue from "vue";

interface Airport {
  code: string;
  name: string;
}

export default class AirportsDropDownComponent extends Vue {
  airports: Airport[] = [];

  mounted() {
    fetch("api/FlightCreator/GetAirports")
      .then(response => response.json() as Promise<Airport[]>)
      .then(
        data =>
          (this.airports = [
            { code: "LAX", name: "Los Angeles International Airport" },
            { code: "CDG", name: "Charles De Gaulle International Airport" },
            {
              code: "JFK",
              name: "John Fidzgerald Kennedy International Airport"
            }
          ])
      );
  }
}

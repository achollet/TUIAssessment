Feature: FlightReportController

Scenario: Asking for report when no flight exist in database
    Given No flight have been saved in database
    When I ask for the flight report
    Then The response code is 404

Scenario: Asking for report
    Given At least one flight has been saved in database
    When I ask for the flight report
    Then The response code is 200
    And The list of flight model is not empty

Scenario: Delete the flight id:-1
    Given At least one flight has been saved in database
    When I ask to delete the flight id -1
    Then The response code is 400

Scenario: Delete the flight id:1
    Given The database contains a flight with id 1
    When I ask to delete the flight id 1
    Then The response code is 200
    And The flight report list does not contains flightId: 1




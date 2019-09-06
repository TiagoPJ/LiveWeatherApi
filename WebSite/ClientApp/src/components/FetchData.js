import React, { Component } from "react";
import { Form, Button, Label, Input, Col, Row, FormGroup } from "reactstrap";
import axios from "axios";
import TableWeather from "./TableWeather";
import Flatpickr from "react-flatpickr";
import "flatpickr/dist/themes/material_blue.css";
import moment from "moment";
import "moment-timezone";

export class FetchData extends Component {
  static displayName = FetchData.name;

  state = {
    weatherForecasts: [],
    citys: [],
    selectValue: [],
    loading: false,
    unit: "C",
    activeInterval: false,
    date: {
      initial: null,
      final: null
    }
  };

  componentDidMount() {
    this.fetchCities();
  }

  handleChange = event => {
    let opts = [],
      opt;

    for (let i = 0, len = event.target.options.length; i < len; i++) {
      opt = event.target.options[i];

      if (opt.selected) {
        opts.push(opt.value);
      }
    }

    this.setState({ selectValue: opts });
  };

  fetchWeatherForecast = () => {
    if (!this.state.selectValue.length) alert("City is required.");
    else if (!this.state.date.initial) alert("Initial date is required.");
    else if (!this.state.date.final) alert("Final date is required.");
    else {
      this.setState({
        loading: true,
        weatherForecasts: null
      });

      if (!this.state.activeInterval)
        // Reload function 15 mnts
        setInterval(() => this.fetchWeatherForecast(), 900000);

      const payload = {
        cities: this.state.selectValue,
        dtInitial: this.state.date.initial,
        dtFinal: this.state.date.final,
        unit: this.state.unit
      };

      axios
        .post(`http://localhost:5002/LiveWeather/GetWeatherForecast`, payload)
        .then(response => {
          const { data } = response;
          if (data.isOk) {
            this.setState({
              loading: false,
              weatherForecasts: data.return,
              activeInterval: true
            });
          } else
            alert(
              "There was an error searching weather forecast: " + data.errorList
            );
        });
    }
  };

  fetchCities = () => {
    axios
      .get(`http://localhost:5002/LiveWeather/GetCitiesDefault`)
      .then(response => {
        const { data } = response;
        if (data.isOk) this.setState({ citys: data.return });
        else alert("There was an error searching cities: " + data.errorList);
      });
  };

  handleSetDate = dt => {
    this.setState({
      date: {
        initial: moment(dt[0]).format(),
        final: moment(dt[1]).format()
      }
    });
  };

  handleSetUnit = unitCurrent => {
    this.setState({ unit: unitCurrent });
  };

  render() {
    return (
      <div>
        <h1>
          Weather forecast in {this.state.unit}° &nbsp;
          <Button
            size="lg"
            color={this.state.unit === "C" ? "primary" : "secondary"}
            onClick={() => this.handleSetUnit("C")}
          >
            C°
          </Button>
          &nbsp;
          <Button
            size="lg"
            color={this.state.unit === "F" ? "primary" : "secondary"}
            onClick={() => this.handleSetUnit("F")}
          >
            F°
          </Button>
        </h1>
        <p>
          This component demonstrates fetching data from
          LiveWeatherApi(OpenWeather).
        </p>
        <Form>
          <Row>
            <Col md={6}>
              <FormGroup>
                <Label for="rangeDate">Range Date:</Label>
                <Flatpickr
                  type="date"
                  className="form-control"
                  id="rangeDate"
                  onChange={date => this.handleSetDate(date)}
                  options={{
                    mode: "range",
                    minDate: "today",
                    maxDate: new Date().fp_incr(5),
                    dateFormat: "d-m-Y"
                  }}
                />
                <p>
                  <em>Free allows you to select only the 5 day period!</em>
                </p>
                <Button
                  color="primary"
                  onClick={() => this.fetchWeatherForecast()}
                >
                  Buscar
                </Button>
              </FormGroup>
            </Col>
            <Col md={6}>
              <FormGroup>
                <Label for="selectMultiCities">Select City(ies)</Label>
                <Input
                  type="select"
                  name="selectMulti"
                  id="selectMultiCities"
                  multiple
                  onChange={this.handleChange}
                  value={this.state.selectValue}
                >
                  >
                  {this.state.citys.map(item => (
                    <option key={item.id} value={item.name}>
                      {item.name}
                    </option>
                  ))}
                </Input>
              </FormGroup>
            </Col>
          </Row>
        </Form>
        &nbsp;
        {this.state.loading ? (
          <p>
            <em>Loading...</em>
          </p>
        ) : (
          ""
        )}
        &nbsp;
        {this.state.weatherForecasts
          ? this.state.weatherForecasts.map(forecasts => (
              <div key={forecasts.city.id}>
                <h2>{forecasts.city.name}</h2>
                <h5>{forecasts.forecastCurrent.weather[0].description}</h5>
                <TableWeather
                  only={true}
                  unit={this.state.unit}
                  city={forecasts.city}
                  forecastCurrent={forecasts.forecastCurrent}
                  forecastList={forecasts.forecastList}
                ></TableWeather>
              </div>
            ))
          : ""}
      </div>
    );
  }
}

import React, { Component } from "react";
import { Button } from "reactstrap";
import ModalForecast from "./ModalForecast";
import moment from "moment";
import "moment-timezone";

export default class TableWeather extends Component {
  state = {
    modal: false
  };

  toggle = () => {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  };

  render() {
    const forecastCurrent = this.props.forecastCurrent;
    const forecastList = this.props.forecastList;
    const unit = this.props.unit;
    return (
      <table className="table borderless">
        <thead>
          <tr>
            <th>#</th>
            <th>Date/Hour</th>
            <th>Temp. ({unit}°)</th>
            <th>Temp. Min. ({unit}°)</th>
            <th>Temp. Max. ({unit}°)</th>
            <th>Humidity</th>
            <th>Pressure</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {this.state.modal ? (
            <ModalForecast
              unit={unit}
              forecastList={forecastList}
              show={this.state.modal}
              title={this.props.city.name}
              close={this.toggle}
            ></ModalForecast>
          ) : (
            ""
          )}
          {this.props.only ? (
            <tr>
              <td>
                <img
                  alt="ddd"
                  src={`http://openweathermap.org/img/w/${forecastCurrent.weather[0].icon}.png`}
                ></img>
              </td>
              <td>
                {moment(forecastCurrent.date).format("DD/MM/YYYY h:mm:ss a")}
              </td>
              <td>{forecastCurrent.temperature.temp.toFixed(1)}°</td>
              <td>{forecastCurrent.temperature.temperatureMin.toFixed(1)}°</td>
              <td>{forecastCurrent.temperature.temperatureMax.toFixed(1)}°</td>
              <td>{forecastCurrent.temperature.humidity}%</td>
              <td>{forecastCurrent.temperature.pressure} hpa</td>
              <td>
                <Button
                  color="primary"
                  onClick={() => this.toggle()}
                  style={{ marginBottom: "1rem" }}
                >
                  More Days (Range Date)
                </Button>
              </td>
            </tr>
          ) : (
            forecastList.map((forecast, index) => (
              <tr key={index}>
                <td>
                  <img
                    alt="ddd"
                    src={`http://openweathermap.org/img/w/${forecast.weather[0].icon}.png`}
                  ></img>
                </td>
                <td>{moment(forecast.date).format("DD/MM/YYYY h:mm:ss a")}</td>
                <td>{forecast.temperature.temp.toFixed(1)}°</td>
                <td>{forecast.temperature.temperatureMin.toFixed(1)}°</td>
                <td>{forecast.temperature.temperatureMax.toFixed(1)}°</td>
                <td>{forecast.temperature.humidity}%</td>
                <td>{forecast.temperature.pressure} hpa</td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    );
  }
}

import React, { Component } from "react";
import { Modal, ModalHeader, ModalBody, ModalFooter, Button } from "reactstrap";
import TableWeather from "./TableWeather";

export default class ModalForecast extends Component {
  render() {
    return (
      <Modal
        size="lg"
        style={{ maxWidth: "1600px", width: "80%" }}
        isOpen={this.props.show}
        toggle={this.props.close}
        className={this.props.className}
      >
        <ModalHeader toggle={this.props.close}>{this.props.title}</ModalHeader>

        <ModalBody>
          <p>
            <em>
              Forecast time every 3 hours, according to the informed date.
            </em>
          </p>
          <TableWeather
            only={false}
            unit={this.props.unit}
            forecastList={this.props.forecastList}
          ></TableWeather>
        </ModalBody>
        <ModalFooter>
          <Button color="primary" onClick={this.props.close}>
            Close
          </Button>{" "}
        </ModalFooter>
      </Modal>
    );
  }
}

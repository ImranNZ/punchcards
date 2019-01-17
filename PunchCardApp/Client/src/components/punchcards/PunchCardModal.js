import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { addPunchCard } from "../../actions/punchCardActions";
import TextAreaFieldGroup from "../common/TextAreaFieldGroup";
import DatePicker from "react-datepicker";

import "react-datepicker/dist/react-datepicker.css";

class PunchCardModal extends Component {
  constructor(props) {
    super(props);
    this.state = {
      description: "",
      punchIn: "",
      punchOut: "",
      errors: {}
    };

    this.onChange = this.onChange.bind(this);
    this.onPunchInChange = this.onPunchInChange.bind(this);
    this.onPunchOutChange = this.onPunchOutChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);
  }

  componentWillReceiveProps(newProps) {
    if (newProps.errors) {
      this.setState({ errors: newProps.errors });
    }
  }

  onPunchInChange(date) {
    this.setState({
      punchIn: date
    });
  }

  onPunchOutChange(date) {
    this.setState({
      punchOut: date
    });
  }

  onChange(e) {
    this.setState({ [e.target.name]: e.target.value });
  }

  onSubmit(e) {
    e.preventDefault();

    const { user } = this.props.auth;

    const newPunchCard = {
      description: this.state.description,
      punchIn: this.state.punchIn,
      punchOut: this.state.punchOut,
      userId: user.name
    };

    this.props.addPunchCard(newPunchCard);
    this.setState({ description: "" });
    this.setState({ punchIn: "" });
    this.setState({ punchOut: "" });
  }

  render() {
    return (
      <div
        className="modal fade"
        id="punchCardModal"
        tabIndex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true"
      >
        <div className="modal-dialog modal-dialog-centered" role="document">
          <div className="modal-content">
            <div className="modal-header">
              <h5 className="modal-title" id="exampleModalLongTitle">
                Punch Card Details
              </h5>
              <button
                type="button"
                className="close"
                data-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body">
              <form onSubmit={this.onSubmit} autoComplete="off">
                <div className="form-group">
                  <label htmlFor="punchCarddesc" style={{ float: "left" }}>
                    Description
                  </label>

                  <TextAreaFieldGroup
                    id="punchCarddesc"
                    name="description"
                    value={this.state.description}
                    onChange={this.onChange}
                  />
                </div>
                <div className="form-group">
                  <div className="col">
                    <div className="row">
                      <label htmlFor="punchIn" style={{ float: "left" }}>
                        Time in
                      </label>
                    </div>
                    <div className="row">
                      <DatePicker
                        id="punchIn"
                        className="form-control"
                        selected={this.state.punchIn}
                        onChange={this.onPunchInChange}
                        showTimeSelect
                        timeFormat="HH:mm"
                        timeIntervals={15}
                        dateFormat="MMMM d, yyyy h:mm aa"
                        timeCaption="time"
                      />
                    </div>
                  </div>
                </div>
                <div className="form-group">
                  <div className="col">
                    <div className="row">
                      <label htmlFor="punchOut" style={{ float: "left" }}>
                        Time out
                      </label>
                    </div>
                    <div className="row">
                      <DatePicker
                        id="punchOut"
                        className="form-control"
                        selected={this.state.punchOut}
                        onChange={this.onPunchOutChange}
                        showTimeSelect
                        timeFormat="HH:mm"
                        timeIntervals={15}
                        dateFormat="MMMM d, yyyy h:mm aa"
                        timeCaption="time"
                      />
                    </div>
                  </div>
                </div>

                <div className="modal-footer">
                  <button
                    type="button"
                    className="btn btn-secondary"
                    data-dismiss="modal"
                  >
                    Close
                  </button>
                  <button type="submit" className="btn btn-primary">
                    Save changes
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

PunchCardModal.propTypes = {
  addPunchCard: PropTypes.func.isRequired,
  auth: PropTypes.object.isRequired,
  errors: PropTypes.object.isRequired
};

const mapStateToProps = state => ({
  auth: state.auth,
  errors: state.errors
});

export default connect(
  mapStateToProps,
  { addPunchCard }
)(PunchCardModal);

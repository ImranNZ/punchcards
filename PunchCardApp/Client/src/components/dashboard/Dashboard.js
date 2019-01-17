import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import PunchCardModal from '../punchcards/PunchCardModal';
import { getPunchCards } from '../../actions/punchCardActions';
import PunchCardTable from './PunchCardTable';
import isEmpty from '../../validation/is-empty';
import Spinner from '../common/Spinner';

class Dashboard extends Component {
  componentDidMount() {
    this.props.getPunchCards();
  }

  render() {
    const { user } = this.props.auth;
    const { punchCards, loading } = this.props.punchCards;

    let dashboardSection;

    if (isEmpty(punchCards) || loading) {
      dashboardSection = <p>You have not yet created any punch cards</p>;
    } else {
      dashboardSection = <PunchCardTable punchCards={punchCards} />;
    }

    return (
      <div className="dashboard">
        <div className="container">
          <div className="row">
            <div className="col-md-12">
              <h1 className="display-4">Dashboard</h1>
              <div>
                <p className="lead text-muted">
                  Welcome {user.given_name}
                  {isEmpty(punchCards)
                    ? ''
                    : ', here are your current time entries.'}
                </p>
                {dashboardSection}
                <button
                  type="button"
                  className="btn btn-lg btn-info"
                  data-toggle="modal"
                  data-target="#punchCardModal"
                >
                  Add punch card
                </button>
                <PunchCardModal />
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

Dashboard.propTypes = {
  getPunchCards: PropTypes.func.isRequired,
  auth: PropTypes.object.isRequired,
  punchCards: PropTypes.object.isRequired
};

const mapStateToProps = state => ({
  auth: state.auth,
  punchCards: state.punchCards
});

export default connect(
  mapStateToProps,
  { getPunchCards }
)(Dashboard);

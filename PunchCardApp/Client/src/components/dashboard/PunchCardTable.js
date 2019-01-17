import React, { Component } from "react";
import moment from "moment";

class PunchCardTable extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="punch-card-table">
        <table className="table">
          <thead>
            <tr>
              <th scope="col" style={{ textAlign: "left" }}>
                Description
              </th>
              <th scope="col">Time in</th>
              <th scope="col">Time out</th>
              <th scope="col">Date</th>
            </tr>
          </thead>
          <tbody>
            {this.props.punchCards.map(x => (
              <tr>
                <td style={{ textAlign: "left" }}>{x.description}</td>
                <td>{moment(x.punchIn).format("h:mm")}</td>
                <td>{moment(x.punchOut).format("h:mm")}</td>
                <td>{moment(x.punchOut).format("L")}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

export default PunchCardTable;

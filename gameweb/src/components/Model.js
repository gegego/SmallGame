import React from 'react';
import PropTypes from 'prop-types';
import './Floodit.css';

class Model extends React.Component {
  render() {
    // Render nothing if the "show" prop is false
    if(!this.props.show) {
      return null;
    }
    return (
      <div className="modal">
        <div className="modal-content">
          {this.props.children}
          <div className="btnColor">
            <button style={{backgroundColor:"gray"}} onClick={this.props.onClose}>
              Again
            </button>
          </div>
        </div>
      </div>
    );
  }
}

Model.propTypes = {
  onClose: PropTypes.func.isRequired,
  show: PropTypes.bool,
  children: PropTypes.node
};

export default Model;

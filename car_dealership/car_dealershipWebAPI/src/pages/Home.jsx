/**
 * @jsx React.DOM
 */

'use strict';

var React = require('react');

var VehicleInventoryTable = require('../pages/VehicleInventoryTable.jsx');


var HomePage = React.createClass({
  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-sm-4">
            <h3>Vehicles</h3>
            <div className="container">  
              <VehicleInventoryTable/>
            </div>  
          
          </div>
        </div>
      </div>
    );
  }
});

module.exports = HomePage;


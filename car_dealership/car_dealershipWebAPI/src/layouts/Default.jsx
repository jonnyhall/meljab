/**
 * @jsx React.DOM
 */

'use strict';

var React = require('react');
var {Link} = require('react-router');
var Navbar = require('../components/Navbar.jsx');

var DefaultLayout = React.createClass({
  render() {
    return (
      <div>
        <Navbar />
        <div className="jumbotron">
          <div className="container text-center">
            <h1>Vehicle Inventory Finder</h1>
            <p>Finding the perfect car is now easy</p>
          </div>
        </div>
        <this.props.activeRouteHandler />
      </div>
);
}
});

module.exports = DefaultLayout;

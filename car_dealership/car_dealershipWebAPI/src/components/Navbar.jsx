/**
 * @jsx React.DOM
 */

'use strict';

var React = require('react');
var {Link} = require('react-router');

var Navbar = React.createClass({
  url: function() {
    return window.location.origin;
  },
  render() {
    return (
      <div className="navbar-top">
        <div className="container">
          <Link className="navbar-brand row" to="home">
            <img src={this.url() + '/images/logo-small.png'} width="38" height="38" alt="React" />
            {' ReactJS/C# Test Project by Jon Hall'}
          </Link>
        </div>
      </div>
    );
  }
});

module.exports = Navbar;



/**
 * @jsx React.DOM
 

'use strict';

var React = require('react');
var {Link} = require('react-router');

var Navbar = React.createClass({
  render() {
    return (
      <div className="navbar-top">
        <div className="container">
          <Link className="navbar-brand row" to="home">
            <img src="/images/logo-small.png" width="38" height="38" alt="React" />
            {' Facebook React Starter Kit'}
          </Link>
        </div>
      </div>
    );
  }
});

module.exports = Navbar;

*/
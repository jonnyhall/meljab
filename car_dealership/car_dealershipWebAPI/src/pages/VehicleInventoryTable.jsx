
/**
 * @jsx React.DOM
 */

/* */
'use strict';
var React = require('react');

var formatter = new Intl.NumberFormat('en-US', {
  style: 'currency',
  currency: 'USD',
  minimumFractionDigits: 2,
});

var VehicleInventoryRow = React.createClass({ 
  render: function () {  
    return(  
      <tr>  
        <td>{this.props.item.make}</td>  
        <td>{this.props.item.year}</td>  
        <td>{this.props.item.color}</td>  
        <td>{formatter.format(this.props.item.price)}</td>  
        <td><input type="checkbox" checked={this.props.item.hasSunroof} readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.isFourWheelDrive}  readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.hasLowMiles}  readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.hasPowerWindows} readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.hasNavigation}  readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.hasHeatedSeats}  readOnly/></td>   
        <td><input type="checkbox" checked={this.props.item.hasAutomaticTransmission}  readOnly/></td> 
      </tr>  
    );
  
  }  
});

var PhraseSearch = React.createClass({
  parsePhrase: function(event) {
    var phrase = event.target.value.trim();
    var phraseArr = phrase.split(" ");
    var updatedList = this.props.items;
    var globalControlDictionary = this.props.controlDictionary;
    var listKeys = this.props.listKeys;
    var operators = {};

    phraseArr = phraseArr.filter(function(item) {
      return (
        item.toLowerCase().trim() !== ""
      );
    });

    operators = phraseArr.filter(function(item) {
      return (
        item.toLowerCase() === "and" ||
          item.toLowerCase() === "or"
      );
    });

    phraseArr = phraseArr.filter(function(item) {
      return (
        item.toLowerCase() !== "and" &&
          item.toLowerCase()  !== "or"
      );
    });

    if (phraseArr.length === 0) {
      globalControlDictionary =  {};
      this.props.controlDictionary = {};
    }

    var boolPhraseDictionary = [];
    var phraseDictionary = [];

    phraseArr.forEach(function (word) {
      boolPhraseDictionary.push({ searchPhrase: word.toLowerCase(), phrase: "", value: ""});
      phraseDictionary.push({ searchPhrase: word.toLowerCase(), phrase: "", value: ""});
    });
  

    boolPhraseDictionary = boolPhraseDictionary.map(function (item) {
      listKeys.forEach(function (key) {
        if (key.toLowerCase().indexOf(item.searchPhrase) !== -1) {
          item.phrase = key;
          item.value = "true";
        }
      });
      return item;
    });

    phraseDictionary = phraseDictionary.map(function (item) {
      listKeys.forEach(function (key) {
        updatedList.forEach(function (listItem) {
          if (listItem[key].toString().toLowerCase().trim().indexOf(item.searchPhrase) !== -1) {
            item.phrase = key;
            item.value = listItem[key].toString().toLowerCase().trim();
          }
        });
       
      });
      return item;
    });

    boolPhraseDictionary.forEach(function (item) {
      phraseDictionary.push(item);
    });

    phraseDictionary.forEach(function (dictionaryItem) {
      globalControlDictionary[dictionaryItem.phrase] = dictionaryItem.value;
    });

    operators.forEach(function (operator) {
      globalControlDictionary["operator"] = operator;
    });

    this.props.controlDictionary = globalControlDictionary;
    this.filterFromChild();
  },
  filterFromChild: function(){  
    var val = this.props.controlDictionary; 
    this.props.filterFromChild(val);
  },
  resetSearch: function() {
    var e = new Event('input', { bubbles: true });
    var input = document.querySelector('#searchPhrase');
    input.value = "";

    var controlArr = [];
    this.props.listKeys.forEach(function(key) {
      controlArr.push(document.getElementById(key));
    });

    input.dispatchEvent(e);
    this.props.resetSearch(controlArr);
  },
  render: function() {
    var instructions = "What you are looking for?";
    return (  <tbody>  
                <tr>
                    <td colSpan="2">
                    <label>{instructions} </label>
                    </td>
                    <td colSpan="8">
                    <input  style={{width: 775}}  type="textarea" id="searchPhrase" ref="searchPhrase" 
                        placeholder="Use AND/OR 'cars with a sunroof, power windows, AND heated seats.' Or 'sunroof, power windows, OR heated seats.'"
                        onChange={this.parsePhrase}/>
                    </td>
                    <td>
                        <input type="button" value="Reset" onClick={this.resetSearch}/>
                    </td>
                </tr>
              </tbody>  
    );  
  }  
});

var List = React.createClass({
  render: function(){  
    var rows = [];  
    this.props.items.forEach(function (item) {  
      rows.push(<VehicleInventoryRow  key={item._id} item={item}/>);  
    });  
    return (  <tbody>  
              {rows}  
              </tbody>  
            );  
  }  
});

var VehicleInventoryTable = React.createClass({  
  filterList: function(event, resetData) {
    this.getAllRefs(resetData);
    if (event) {
      if (event.target.type !== "checkbox") {
        this.state.controlDictionary[event.target.id] = event.target.value.trim();
      } else {
        this.state.controlDictionary[event.target.id] = event.target.checked ? event.target.checked.toString() : "";
      }
    }
    var updatedList = this.state.initialItems;
    var controlDictionary = this.state.controlDictionary;
  
    var operator = controlDictionary["operator"] && controlDictionary["operator"].length > 0
      ? controlDictionary["operator"]
      : "and";

    //I know that the filtering logic below is atrocious, but I didn't know how to compare all properties for all items in the controlDictionary at the same time.  
    updatedList = updatedList.filter(function(item) {
       if (operator !== "and") {
         return (
           controlDictionary["make"].toString().length > 0 ? item.make.toString().toLowerCase().search(controlDictionary["make"].toString().toLowerCase()) !== -1 : false ||
           controlDictionary["year"].toString().length > 0 ? item.year.toString().toLowerCase().search(controlDictionary["year"].toString().toLowerCase()) !== -1 : false ||
           controlDictionary["color"].toString().length > 0 ? item.color.toString().toLowerCase().search(controlDictionary["color"].toString().toLowerCase()) !== -1 : false ||
           controlDictionary["price"].toString().length > 0 ? item.price.toString().toLowerCase().search(controlDictionary["price"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasSunroof"].toString().length > 0 ? item.hasSunroof.toString().toLowerCase().search(controlDictionary["hasSunroof"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["isFourWheelDrive"].toString().length > 0 ? item.isFourWheelDrive.toString().toLowerCase().search(controlDictionary["isFourWheelDrive"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasLowMiles"].toString().length > 0 ? item.hasLowMiles.toString().toLowerCase().search(controlDictionary["hasLowMiles"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasPowerWindows"].toString().length > 0 ? item.hasPowerWindows.toString().toLowerCase().search(controlDictionary["hasPowerWindows"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasNavigation"].toString().length > 0 ? item.hasNavigation.toString().toLowerCase().search(controlDictionary["hasNavigation"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasHeatedSeats"].toString().length > 0 ? item.hasHeatedSeats.toString().toLowerCase().search(controlDictionary["hasHeatedSeats"].toString().toLowerCase()) !== -1  : false||
           controlDictionary["hasAutomaticTransmission"].toString().length > 0 ? item.hasAutomaticTransmission.toString().toLowerCase().search(controlDictionary["hasAutomaticTransmission"].toString().toLowerCase()) !== -1  : false 
         );
       } else {
         return (
           item.make.toString().toLowerCase().search(controlDictionary["make"].toString().toLowerCase()) !== -1 &&
             item.year.toString().toLowerCase().search(controlDictionary["year"].toString().toLowerCase()) !== -1 &&
             item.color.toString().toLowerCase().search(controlDictionary["color"].toString().toLowerCase()) !== -1 &&
             item.price.toString().toLowerCase().search(controlDictionary["price"].toString().toLowerCase()) !== -1 &&
             item.hasSunroof.toString().toLowerCase().search(controlDictionary["hasSunroof"].toString().toLowerCase()) !== -1 &&
             item.isFourWheelDrive.toString().toLowerCase().search(controlDictionary["isFourWheelDrive"].toString().toLowerCase()) !== -1 &&
             item.hasLowMiles.toString().toLowerCase().search(controlDictionary["hasLowMiles"].toString().toLowerCase()) !== -1 &&
             item.hasPowerWindows.toString().toLowerCase().search(controlDictionary["hasPowerWindows"].toString().toLowerCase()) !== -1 &&
             item.hasNavigation.toString().toLowerCase().search(controlDictionary["hasNavigation"].toString().toLowerCase()) !== -1 &&
             item.hasHeatedSeats.toString().toLowerCase().search(controlDictionary["hasHeatedSeats"].toString().toLowerCase()) !== -1 &&
             item.hasAutomaticTransmission.toString().toLowerCase().search(controlDictionary["hasAutomaticTransmission"].toString().toLowerCase()) !== -1 
         );
       }

     

    });
   
    var controlsHaveValues = false;
    for(var key in this.state.controlDictionary){
     var value = this.state.controlDictionary[key].toString() !== "false" && this.state.controlDictionary[key].toString().length > 0;
      if (value) {
        controlsHaveValues = value;
        break;
      }
    }

    if (controlsHaveValues) {
      this.setState({items: updatedList});
    } else {
      this.setState({items: this.state.initialItems});
    }
    
   
  },
  filterFromChild: function(data){  
    this.setState({controlDictionary: data.length > 0 ? data : {} });
    this.filterList();
  }, 
  getInitialState: function() {
    return{
      initialItems: [],
      items: [],
      listKeys: [],
      controlDictionary: {},
      searchPhraseDictionary: {},
      reset: false
  }  
  },  
  resetSearch: function(controlArr) {
    controlArr.forEach(function(control) {
      if (control.type === "checkbox") {
        control.checked = false;
      } else {
        control.value = "";
      }
    });
    this.filterList(null, true);
  },
  componentWillMount: function(){  
    var xhr = new XMLHttpRequest();  
    xhr.open('get', "http://localhost/CarDealership/api/Vehicles", true);  
    xhr.onload = function () {  
      var response = JSON.parse(xhr.responseText);  
      this.setState({ initialItems: response });
      this.setState({ items: this.state.initialItems });
      this.setState({listKeys : ["make","year","color","price","hasSunroof","isFourWheelDrive","hasLowMiles","hasPowerWindows","hasNavigation","hasHeatedSeats","hasAutomaticTransmission"]});
    }.bind(this);  
    xhr.send();  
  },  
  getAllRefs: function(resetData) {
    for (var ref in this.refs) {
      var input = this.refs[ref];
      this.state.controlDictionary[input.props.id] = (resetData !== true && this.state.controlDictionary[input.props.id] 
        && this.state.controlDictionary[input.props.id].length > 0) ? this.state.controlDictionary[input.props.id].toString(): "";
    }
  },
  render: function(){
    return (
      <div>
        <form>
          <fieldset className="form-group">
            <table className="table">  
              <PhraseSearch  items={this.state.items} controlDictionary={this.state.controlDictionary} 
                listKeys={this.state.listKeys} resetSearch={this.resetSearch} filterFromChild={this.filterFromChild} val={this.state.controlDictionary}/>
              <thead>  
              <tr>  
                <th>Make</th>  
                <th>Year</th>  
                <th>Color</th>  
                <th>Price</th>  
                <th>Sunroof</th>  
                <th>4WD</th>  
                <th>Low Mileage</th>  
                <th>Power Windows</th>
                <th>Navigation</th>
                <th>Heat Seats</th>
                <th>Automatic Transmission</th>
              </tr>  
              </thead>  
  
              <tbody>  
              <tr style={{backgroundColor: "#f1f1f1"}}>              
              <td><input type="text" style={{width: 50}} id="make" ref="make" placeholder="Search" onChange={this.filterList}/></td>  
              <td><input type="text" style={{width: 50}}  id="year"  ref="year" placeholder="Search" onChange={this.filterList}/></td>  
              <td><input type="text" style={{width: 75}}  id="color"  ref="color" placeholder="Search" onChange={this.filterList}/></td> 
              <td><input type="text"  style={{width: 75}} id="price"  ref="price" placeholder="Search" onChange={this.filterList}/></td>   
              <td><input type="checkbox" id="hasSunroof" ref="hasSunroof"  onClick={this.filterList}/></td> 
              <td><input type="checkbox" id="isFourWheelDrive"  ref="isFourWheelDrive" onChange={this.filterList}/></td> 
              <td><input type="checkbox" id="hasLowMiles"  ref="hasLowMiles"  onChange={this.filterList}/></td> 
              <td><input type="checkbox" id="hasPowerWindows"  ref="hasPowerWindows"  onChange={this.filterList}/></td> 
              <td><input type="checkbox" id="hasNavigation"  ref="hasNavigation"  onChange={this.filterList}/></td> 
              <td><input type="checkbox" id="hasHeatedSeats"  ref="hasHeatedSeats"  onChange={this.filterList}/></td> 
              <td><input type="checkbox" id="hasAutomaticTransmission"  ref="hasAutomaticTransmission"  onChange={this.filterList}/></td> 

              </tr>
              <List items={this.state.items}/>
              </tbody>  
  
            </table>
          </fieldset>
        </form>
        
      </div>
    );
  } 
      
});


module.exports = VehicleInventoryTable;


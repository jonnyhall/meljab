================================================================================
==       React.js/C#  Test Project by Jon Hall						  ==
================================================================================

The VehicleInventoryTable.jsx file is where the majority of the React.js logic 
is located. 

Although I have done tutorials on React.js, this assignment was challenging
since I have not used React.js professionally before. 

However, since beginning and progressing through the different stages of development 
using React.js, I have come to appreciate its simplicity and speed. 


This is a cross-platform project template built on top of the Facebook's React.js
library and powered by Node.js-based development tools and utilities (it requires
Node.js only at development time, you don't need to have it installed on your web
server, unless you want to). It contains only front-end part of a web application
and is recommended to be paired with a server-side project (REST API, Web Sockets)

PREREQUISITES
--------------------------------------------------------------------------------

- IIS
- .NET framework 4.5.2
- Preferably VS 2015 or greater
- Node.js
- NPM (comes with Node.js)
- Gulp (to install run: npm install -g gulp)

SETTING UP IIS to Run Web API 
--------------------------------------------------------------------------------
In the VehicleInventoryTable.jsx file I am hitting a Web API endpoint to get
all vehicles from a JSON file. 

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

I set up a "CareDealership" web app under my Default Web Site and pointed it to the 
root of the car_dealershipWebAPI project in the car_dealership solution. 

If you open IIS and right click on the Default Web Site node and select "Add Application" 
and set the alias to "CarDealership" and the Physical path to the root of where ever you
put the car_dealershipWebAPI project, the endpoint should be able to be accessed from 
the VehicleInventoryTable.jsx file. 

I used IIS for the Web API endpoints because I didn't know how to serve them via Gulp yet. 

SWAGGER:
I have also installed Swagger to be able to view and test the Web API endpoints.

You can view the Swagger UI at http://localhost/CarDealership/swagger if your IIS 
application was set up like mine was. 


HOW TO RESTORE NPM PACKAGES
--------------------------------------------------------------------------------

Open a console window, change the working directory to a folder where project
files are located, then run:

> npm install

Note: If you see error messages during install, something went wrong, check this
      page https://github.com/TooTallNate/node-gyp/ The packages listed in the
      package.json file are installed into the 'node_modules' folder. You can
      delete this folder if needed by running: cmd /c "rmdir /s /q node_modules"

HOW TO BUILD
--------------------------------------------------------------------------------

> gulp build                  # Builds the project in debug mode (default)
> gulp build --release        # Builds the project in release mode

Note: The build output files are written into the .\build folder.
      The build logic is described in gulpfile.js.

HOW TO BUILD AND RUN
--------------------------------------------------------------------------------

> gulp                        # Build the project and open it in a browser
> gulp --release              # Same as above, but using release mode

Note: It will build the project, run a development HTTP server (BrowserSync),
      open the home page of your web application in a browser window and start
      watching for modifications in files (LiveReload).

HOW TO DEPLOY
--------------------------------------------------------------------------------

> gulp deploy                 # Deploys the app from the .\build folder
> gulp deploy --production    # Same as above, but using a different destination


SUPPORT
--------------------------------------------------------------------------------

Have questions, feedback or need help?
Contact me on https://www.codementor.io/koistya

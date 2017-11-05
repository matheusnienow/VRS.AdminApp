# VRS.AdminApp

This is the app used to manage the VRS system. 

This app does not have direct access to the system database, thus all data manipulation should be done through the wcf service VRS.WebApi (https://github.com/matheusnienow/VehicleRentSystem).

The project is using the MVC pattern, all business logic is contained inside the respective controllers.

# List manager for basic CRUD operations.

### Built With

![.Net Core 3.1](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

### Project structure

#### DataAccess

Data access contains an interface and a service file which is the core communitacion endpoint for the LiteDb database. It can use the LiteDb with its own Nugget package extension.

#### InfocompassBackend

InfocompassBackend is a .NET Core 3.1 Web API application. It't the core of the application and contains services and controllers and additional options and settings.

##### Controller: 

It is the first layer of the application. This is where the endpoints are written for the REST API. ListController only contains basic CRUD operations for the list management system.

##### Services:

Services includes two types of files, interafaces and implementations of them. Here is the buisness logic between data from/to the frontend and from/to the database.

##### Models

Models are the type classes of objects. They play a big role in OOP. For this project only 2 models were needed, the ListModel for the database object and ListViewModel, the object that is given to the frontend.

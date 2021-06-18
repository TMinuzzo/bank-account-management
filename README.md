# Bank Account Management
A simple bank account application.
## About
This project presents a client-server architecture, which the server was implemented following the concepts of Domain Driven Design and loosely coupled layers. 
The current server implementation uses .NET 3.1, and ASP.NET as the Application Layer. A MySQL database was used for the persistence of the data, and [Entity Framework] (https://github.com/dotnet/efcore) as the ORM. 
For the client side, was developed a React webpage with the framework [Material UI] (https://material-ui.com/) to help with the presentation layer. 

## Getting Started
### Prerequisites
- Node
- Visual Studio with ASP.NET and .NET Core 3.1 components
- Docker 

### Installation

- For the client:

  Inside the BankAccount/ClientApp/ directory:
  ```
  npm install
  ```
  ```
  npm run start
  ```
  The client will be running on localhost:3000


- For the server, database and tests:

  To run the MySQL database, on the root directory:
  ```
  docker-compose up
  ```
  To interact with the database:
  ```
  docker-compose exec mysql -u admin -p 123
  ```
  To run the server build the project using Visual Studio, and the server will be started at localhost:44323

  The server unit tests can be run using the Visual Studio.

### Structure and Architecture
This project contains two main Entities that are persisted into the database as tables. 
- `User` - corresponds to the users of the bank accounts.
- `Transaction` - corresponds to the transactions that can be made by the users. Deposit, Withdraw and Payment inherits from this Entity.

There are four main layers on the project, following the DDD approach:
1. Application Layer: entry point for the requests, redirecting them to the internal layers.
2. Domain Layer: The core of the business logic,  providing classes and interfaces to be used on the business rules.
3. Service: Also contains part of the business logic, with the main role of being the communication with the Repositories.
4. Infrastructure: Used for external communication with the database, mapping the entities to tables and doing CRUDs.

The unit tests cover the Entities and its validations. There are also some tests that could be considered as integration tests, to validate the database communication but also the Infrastructure layer. 

### Endpoints
The server exposes the following endpoints, using the REST pattern:
- POST `api/user/`: creates a new user, with the provided name.
- GET `api/user/` : gets all users from the database.
- GET `api/user/{id}`: gets the user with the specified id.
- POST `api/transaction/deposit`: creates a new deposit with the provided amount, for the provided user.
- POST `api/transaction/withdraw`: creates a new withdraw with the provided amount, for the provided user.
- POST `api/transaction/payment`: creates a new payment with the provided amount, destination and description for the provided user.
- GET `api/transaction/history/{username}`: shows the history of all transactions for the user, sorted by date. 



### Further Improvements

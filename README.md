# ParkBee Developer Assessment

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```

  4.  Getting Started     
     
      ```
      docker-compose up
      ```

## Technologies
* .NET 5
* Entity Framework Core 

## Functionalities
-  Basic CRUD operations with CQRS + MediatR  
-  Authentication backed by JWT (role based)
-	 Domain driven design implementation
-	 Unit and Integration Tests



- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=myPass123" -p 1433:1433 --name primeHotelDb -d mcr.microsoft.com/mssql/server:2017-latest
- dotnet ef --startup-project ../Parkbee.Api migrations add MigrationName -c ApplicationDbContext

Restaurant Order API

A simple ASP.NET Core Web API for managing restaurant orders using SQLite and Entity Framework Core.

Features
  Create new orders
  View all orders
  Sort orders by total amount 
  Update order status
  Delete all orders (testing utility)
  Automatic total price calculation
  SQLite database persistence
  Swagger API documentation
  
Tech Stack
  .NET 9
  ASP.NET Core Web API
  Entity Framework Core
  SQLite
  Swagger / OpenAPI
  
Project Structure
  Controllers → API endpoints
  Services → Business logic
  Infrastructure → Database layer
  Dtos → Request/Response models
  Models → Domain entities
  
Setup Instructions
1. Clone repository
2. Restore dependencies
  dotnet restore
3. Apply database migrations
  dotnet ef database update
4. Run application
dotnet run

http://localhost:5074

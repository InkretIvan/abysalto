Restaurant Order API

A simple ASP.NET Core Web API for managing restaurant orders using SQLite and Entity Framework Core.

Features
1. Create new orders
2. View all orders
3. Sort orders by total amount 
4. Update order status
5. Delete all orders (testing utility)
6. Automatic total price calculation
7. SQLite database persistence
8. Swagger API documentation
  
Tech Stack
1. .NET 9
2. ASP.NET Core Web API
3. Entity Framework Core
4. SQLite
5. Swagger / OpenAPI
  
Project Structure
1. Controllers → API endpoints
2. Services → Business logic
3. Infrastructure → Database layer
4. Dtos → Request/Response models
5. Models → Domain entities
  
Setup Instructions
1. Clone repository
2. Restore dependencies
dotnet restore
3. Apply database migrations
4. dotnet ef database update
5. Run application
6. dotnet run

http://localhost:5074

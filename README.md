# 🔐 User Authentication & Product Catalog API  

A secure **JWT-based authentication system** with a product catalog, built with **ASP.NET Core 8**, **Entity Framework Core**, and **SQL Server (Dockerized)**.  

## Demostration
### Create user
![](https://github.com/eljorgecruz/.net-loginJwt/blob/main/create_user.gif)

### Log in
![](https://github.com/eljorgecruz/.net-loginJwt/blob/main/login.gif)

## 🚀 Features  
- **JWT Authentication** (Register, Login, Token Generation)  
- **Product Catalog** (Protected endpoints for authorized users)  
- **Database-First Approach** (SQL Server schema designed first, then EF Core scaffolding)  
- **Dockerized SQL Server** (Easy setup for development)  

## 📦 Tech Stack  
- Backend: ASP.NET Core 8  
- Database: SQL Server in Docker  
- ORM: Entity Framework Core  
- Authentication: JWT Bearer Tokens  

## 🛠️ Setup & Installation  

### Prerequisites  
- [Docker](https://www.docker.com/)  
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- IDE (Visual Studio 2022  

### 1. Run SQL Server Container  
```bash
docker compose up -d

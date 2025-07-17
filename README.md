# AspNetCoreJwtAuthStarter-Template

🚀 **ASP.NET Core 8 JWT Authentication Starter with Role-Based Authorization**

This repository is a **starter template** for implementing JWT authentication and role-based authorization in **ASP.NET Core 8**, designed for easy reuse in multiple projects.

---
## 📸 Screenshots
<img width="1829" height="902" alt="image" src="https://github.com/user-attachments/assets/5398a06e-b80e-40c5-b806-c57de8cf7f48" />
<img width="1830" height="616" alt="image" src="https://github.com/user-attachments/assets/64fb9611-c586-4bf3-b212-2604a78787db" />
<img width="988" height="526" alt="image" src="https://github.com/user-attachments/assets/0d5d2400-c194-4dca-8015-cebede7725f7" />


---
## ✨ Features

✅ ASP.NET Core 8 Web API  
✅ JWT Authentication (Login, Register, Protected Endpoints)  
✅ Role-Based Authorization (SuperAdmin, Admin, User)  
✅ Clean, readable, beginner-friendly structure  
✅ Swagger UI with JWT Bearer authentication  
✅ Ready for deployment

## ⚙️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server / LocalDB
- Visual Studio 2022 / VS Code

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository
### 2️⃣ Update Database
        - Check your appsettings.json for the connection string.
        
        - Apply EF Core migrations:
          dotnet ef database update
### 3️⃣ Run the Project

🔐 JWT Authentication
Register: POST /api/auth/register
Login: POST /api/auth/login (returns JWT token)
Use the Authorize (🔒) button in Swagger and enter Bearer {token} to test protected endpoints.

🛡️ Protected Endpoints
✅ /api/user/profile → accessible by any authenticated user
✅ /api/admin/users → accessible by Admin and SuperAdmin
✅ /api/superadmin/users → accessible by SuperAdmin only


🛡️ Roles
-SuperAdmin
-Admin
-User

🗂️ Project Structure
AspNetCoreJwtAuthStarter/
 ├── Controllers/
 ├── Data/
 ├── Models/
 ├── Services/
 ├── Helpers/
 ├── Program.cs
 ├── appsettings.json
 └── ...

 📚 Learning Purpose
This repository was created as part of my learning journey in mastering ASP.NET Core 8, JWT Authentication, and clean backend structuring.

Feel free to use it, study it, or provide feedback so we can learn together.



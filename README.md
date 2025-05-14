# 🌱 Agri-Energy Connect — Web Application Prototype

**Student Name:** Sashiel Moonsamy  
**Student Number:** ST10028058  
**Module:** PROG7311 — Programming 3A  
**Part 2:** Functional Web Application Development  

---

## 🌍 1. Project Overview

**Agri-Energy Connect** is a role-based ASP.NET Core MVC web platform designed to connect South African farmers with renewable energy providers. It allows users to manage agricultural products, share sustainability knowledge, and collaborate on green solutions.

**User Roles:**
- **Farmers**: Submit and manage products  
- **Employees**: Manage farmers, view and filter products  

🎯 **Goal:** Support the adoption of eco-friendly technologies in agriculture.

---

## 🛠️ 2. Core Technologies

| Category       | Technology                          | Purpose                                                        |
|----------------|--------------------------------------|----------------------------------------------------------------|
| Framework      | ASP.NET Core MVC                    | Implements MVC architecture for maintainable structure         |
| ORM            | Entity Framework Core               | Database operations and validation                             |
| Authentication | ASP.NET Identity with Roles         | Secure login + role management                                 |
| UI             | Razor Views, Bootstrap 5, Bootswatch| Responsive and styled interface                                |
| IDE            | Visual Studio 2022                  | Development environment                                        |
| Database       | SQL Server + SSMS 20                | Structured relational data storage                             |

---

## 📁 3. Installed Packages & Dependencies

### 🔧 Backend (NuGet)

- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.AspNetCore.Identity.EntityFrameworkCore  
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore  
- Microsoft.AspNetCore.Identity.UI  
- Microsoft.AspNetCore.Authentication.Cookies  
- Microsoft.Extensions.Logging.Console  
- Microsoft.VisualStudio.Web.CodeGeneration.Design  

### 🎨 Frontend

- Bootstrap 5 (via CDN)  
- Bootswatch Theme (via CDN)

---

## 🔑 4. Main Features

### ✅ Role-Based Access
- Secure login using ASP.NET Identity
- Employees manage farmer access

### 👨‍🌾 Farmer Features
- Add, edit, and delete products
- Filter products by **type** and **date**

### 🧑‍💼 Employee Features
- Register/manage farmer profiles
- View and filter all products
- Edit or delete farmer records

### 🔐 Validation & Security
- Data annotations for validation
- Anti-forgery tokens on forms
- Role-based controller access

---

## 📄 5. Database Overview

### Identity Tables
- `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`

### Domain Tables
- `Farmers`
- `Products`

---

## 👥 6. Seeded User Accounts

| Role     | Email                     | Password     |
|----------|---------------------------|--------------|
| Employee | employee@email.com        | Pa$$w0rd!    |
| Employee | employee2@email.com       | Pa$$w0rd!    |
| Farmer   | farmer@email.com          | Pa$$w0rd!    |
| Farmer   | farmer2@email.com         | Pa$$w0rd!    |

**Seeded Products (for `farmer@email.com`):**
- Organic Carrots
- Wheat Grain
- Sunflower Seeds

> Images linked via: `/images/products/carrots.jpg`, `/wheat.jpg`, `/sunflower.jpg`

---

## 🧭 7. User Instructions

### 🧑‍💼 For Employees:
- **Login**: `/Identity/Account/Login`
- Manage farmer accounts
- View/filter all products
- Perform CRUD on farmer data

### 👨‍🌾 For Farmers:
- **Login**: `/Identity/Account/Login`
- Add/manage products
- Filter products by type or date

---

## 🎥 8. Demo Video

📺 Full walkthrough (to be added):

Includes:
- Login and registration
- Product filtering and management
- Employee dashboard and CRUD

---

## 📚 9. References

- [EF Core in ASP.NET MVC (Microsoft, 2024)](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0)
- [ASP.NET Identity Overview (Microsoft, 2025)](https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity)
- [Download SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- [Bootswatch Themes](https://bootswatch.com)
- [ASP.NET Core MVC Overview](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-9.0)
- [Secure Authentication in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0)

---

## 🧾 10. Project Structure

| Path                | Description                               |
|---------------------|-------------------------------------------|
| `/Models`           | Entity classes (e.g. Farmer, Product)     |
| `/Controllers`      | Logic and HTTP routing                    |
| `/Views`            | Razor UI pages                           |
| `/Data`             | EF DbContext and configuration            |
| `/Areas/Identity`   | Identity UI for login, register, etc.     |

---

## 🎨 11. UI/UX Considerations

- Mobile-first responsive layout  
- ARIA labels for accessibility  
- Bootswatch themes for visual polish  
- CDN usage for performance  
- Anti-forgery security on forms  

---

⚙️ 12. Developer Setup Guide
📦 Requirements
Visual Studio 2022+

.NET 8.0 SDK+

SQL Server + SSMS v20+

🔄 Setup Workflow
1. Clone or Extract the Repository
Open the .sln file in Visual Studio

2. Install Dependencies
In Package Manager Console:

bash
Copy
Edit
Update-Package -reinstall
3. Configure Connection String
In appsettings.json:

json
Copy
Edit
 "ConnectionStrings": {
   "DefaultConnection": "Server=SASHIEL-PC;Database=ST10028058_Agri-Energy;Trusted_Connection=True;TrustServerCertificate=True;"
4. Apply EF Core Migrations
In Package Manager Console:

bash
Copy
Edit
Update-Database
5. Run the Application
Press Ctrl + F5

Or click the green Start button in Visual Studio

6. Test Functionality
✅ Use the seeded credentials

✅ Log in as Employee or Farmer

✅ Add, edit, or delete products (Farmer)

✅ View and filter products (Employee)

✅ Manage farmer records (Employee)

✅ Ensure role-based access is enforced

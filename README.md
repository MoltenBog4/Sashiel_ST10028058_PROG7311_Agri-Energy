📝 How the Application Works
🌿 Agri-Energy Connect — ASP.NET Core MVC Application
This web app is a prototype designed to connect farmers with green technology platforms. It uses role-based access to allow Farmers and Employees to perform specific actions.

👤 User Roles and Their Capabilities
🧑‍🌾 Farmer
Can log in to the system

Can add new products (with type, date, and image)

Can view all their own products

🧑‍💼 Employee
Can log in to the system

Can add new farmers, including:

Their name

Login email

Password

Can view all farmers

Can view all products from all farmers

Can filter products by type and date

🗂️ Core Features by Functionality
Feature	Description
Authentication	Users log in with email + password using Identity
Role Management	Users are assigned "Farmer" or "Employee" roles
Farmer Management	Employees can create and list farmers
Product Management	Farmers can add/view their products; Employees can view and filter
Image Upload	Farmers can upload an image with each product
Responsive Design	Works on desktop, tablet, and mobile

🔐 Login Credentials (Seeded Users)
🧑‍💼 Employee
Email: employee@email.com

Password: Pa$$w0rd!

🧑‍🌾 Farmer
Email: farmer@email.com

Password: Pa$$w0rd!

Use these accounts to test different roles.

🔧 Tech Stack
ASP.NET Core MVC (.NET 8)

ASP.NET Core Identity

Entity Framework Core (Code-First)

SQL Server LocalDB

Razor Views

Bootstrap (optional styling)

Agri-Energy Connect — Web Application Prototype

Student Name: Sashiel Moonsamy Student Number: ST10028058 Module: PROG7311 — Programming 3APart: 2 — Functional Web Application Development

1. 🌍 Project Overview

Agri-Energy Connect is a role-based ASP.NET Core MVC web platform designed to connect South African farmers with renewable energy providers. It enables users to manage agricultural products, share sustainability knowledge, and streamline collaboration. The platform includes two main user types: Farmers and Employees, each with specific access rights and dashboard capabilities. The goal is to support the adoption of eco-friendly technologies in agriculture.

2. 🛠️ Core Technologies

Category

Technology

Purpose

Framework

ASP.NET Core MVC

Implements MVC architecture for maintainable and testable applications.

ORM

Entity Framework Core

Simplifies DB operations and supports migrations and model validation.

Authentication

ASP.NET Identity with Roles

Enables secure login with fine-grained role management (Farmer/Employee).

UI Layout

Razor Views, Bootstrap 5, Bootswatch

Provides responsive design and UI consistency across devices.

IDE

Visual Studio 2022

Professional IDE for development, testing, and debugging.

Database

SQL Server with SSMS 20

Industry-standard relational database for structured data storage.

3. 📁 Installed Packages and Dependencies

Backend (NuGet):

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Microsoft.AspNetCore.Identity.EntityFrameworkCore

Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

Microsoft.AspNetCore.Identity.UI

Microsoft.AspNetCore.Authentication.Cookies

Microsoft.Extensions.Logging.Console

Microsoft.VisualStudio.Web.CodeGeneration.Design

Frontend:

Bootstrap 5 (via CDN)

Bootswatch Theme (via CDN)

4. 🔑 Main Features

Role-Based Access:

Secure login with ASP.NET Identity

Farmers submit access requests (approval by Employees)

Employees manage user roles

Farmer Features:

Add, update, delete own products

Filter products by date or type

Simple and responsive dashboard

Employee Features:

Register and manage farmer profiles

View all products submitted across the platform

Filter products by date, category, or farmer

Approve/deny farmer registration requests

Validation and Security:

Backend and frontend validation via data annotations

Anti-forgery tokens and role-checking applied

5. 📄 Database Overview (via SSMS)

Key Tables:

AspNetUsers, AspNetRoles, AspNetUserRoles – for Identity and role management

Farmers, Products, FarmerAccountRequests – application-specific tables

Sample Users (Seeded):

Role

Email

Password

Employee

employee1@example.com

Employee123!

Farmer

farmer1@example.com

Farmer123!

6. 👨‍🌾 User Instructions

For Employees:

Login: /Identity/Account/Login

Manage farmers, approve requests, view/filter all products

For Farmers:

Login: /Identity/Account/Login

Add/manage products

Filter by product type or date

7. 🎥 Demo Video

Watch the complete system walkthrough showing login, dashboards, product handling, and approvals:

YouTube Link: To be updated with final video URL

8. 📚 References

Microsoft Learn, 2024. Tutorial: Get started with EF Core in an ASP.NET MVC web app. [Online]https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0 [Accessed 9 May 2025].

Microsoft Learn, 2025. Introduction to ASP.NET Identity. [Online]https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity [Accessed 9 May 2025].

Microsoft Learn, 2024. Download SQL Server Management Studio (SSMS). [Online]https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms [Accessed 9 May 2025].

Bootswatch, 2025. Free Themes for Bootstrap. [Online]https://bootswatch.com [Accessed 9 May 2025].

Microsoft Learn, 2024. What is ASP.NET Core MVC?. [Online]https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-9.0 [Accessed 9 May 2025].

Microsoft Learn, 2025. Secure user authentication in ASP.NET Core. [Online]https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0 [Accessed 9 May 2025].

9. 📂 Project Structure

Path

Description

/Models

Entity classes (e.g. Farmer, Product)

/Controllers

Handles logic and HTTP request routing

/Views

Razor pages for frontend presentation

/Data

Contains DbContext, database seeding, and migrations

/Areas/Identity

Authentication and role management using ASP.NET Identity

10. 🌈 UI/UX Considerations

Mobile-first layout with responsive breakpoints

Accessibility support via labels and ARIA attributes

Lightweight front-end using CDN links for better performance

Bootswatch themes for polished and consistent visuals

Security: Anti-forgery tokens and secure data validation

11. 👨‍💻 Developer Setup Guide (Final Section)

This section provides a comprehensive guide for developers setting up the project locally.

🔧 Requirements:

Visual Studio 2022+ with ASP.NET and web development workload

.NET SDK 8.0+

SQL Server + SQL Server Management Studio (v20 or later)

🔄 Setup Workflow:

1. Clone or Extract the Repository

Open the .sln file in Visual Studio

2. Install Dependencies

Tools > NuGet Package Manager > Package Manager Console
Update-Package -reinstall

3. Configure Connection String

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=AgriEnergyDB;Trusted_Connection=True;"
}

4. Apply EF Core Migrations

Update-Database

5. Run the Application

Press Ctrl + F5 or use the green "Start" button in Visual Studio.

Application will launch in your browser.

6. Test Functionality

Use the seeded Employee and Farmer credentials to explore all key features.

If you encounter connection issues, ensure SQL Server is running and the connection string is accurate.

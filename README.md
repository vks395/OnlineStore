OnlineStore\README.md
# OnlineStore

OnlineStore is an ASP.NET MVC web application for managing products and users in an online store environment. The project is built on .NET Framework 4.8 and uses C# 7.3.

## Features

-User Management: Add, edit, and view users with role-based access (customers, sellers, administrators).
-Product Management: Sellers can add, edit, and delete products, including uploading product images.
-Role-Based Authorization: Access to features is controlled by user roles using custom authorization filters.
-Image Upload and Preview: Product images can be uploaded and previewed before saving.
-Client-Side Validation: Uses jQuery validation for form inputs.
-Modernizr Integration: Detects browser features for progressive enhancement.

## Project Structure

- `Controllers/` - MVC controllers for handling user and product actions.
- `Models/` - View models and data models for users and products.
- `Views/` - Razor views for UI rendering.
- `DAL/` - Data access layer for database operations.
- `BAL/` - Business access layer for business logic.
- `Scripts/` - JavaScript files for client-side logic.
- `Content/` - CSS and static assets.

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET Framework 4.8
- SQL Server (for database)

### Setup

1.Clone the repository

-----------------------------------------------------

2.Open the solution in Visual Studio 2022.

3.Restore NuGet packages  
Visual Studio will automatically restore packages on build.

4.Configure the database connection  
Update the connection string in `Web.config` to point to your SQL Server instance.

5.Build and run the application  
Press `F5` or use the __Start Debugging__ command.

## Usage

-Log in with a valid user account.
-Sellers can add, edit, and delete products.
-Administrators can manage users and view all products.
-Customers can view product details.

## Technologies Used

- ASP.NET MVC 5
- Entity Framework
- jQuery & jQuery Validation
- Modernizr
- Bootstrap

## Notes

- Product images are stored in the `/write/UploadedImages/images/` directory.
- Only image files with extensions `.jpg`, `.Jpg`, `.png`, or `jpeg` are allowed for upload.
- Custom authorization attributes are used for role-based access control.




# Programme Management System

An ASP.NET Core MVC web application for managing academic programmes, including students, lecturers, modules, and their relationships.

## Tech Stack

- **Framework:** ASP.NET Core MVC (.NET)
- **Database:** SQL Server via Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **ORM:** Entity Framework Core (Code-First)

## Models

| Model | Description |
|---|---|
| `Student` | Stores student details: name, email, phone number, year of study |
| `Lecturer` | Stores lecturer details: name, email, department |
| `Module` | Stores module details: name, code, credits, academic year |
| `Registration` | Junction table linking students to modules they are enrolled in |
| `ModuleAssignment` | Junction table linking lecturers to modules they are assigned to teach |

## Features

- **Student Management** – Create, view, edit, and delete student records
- **Lecturer Management** – Create, view, edit, and delete lecturer records
- **Module Management** – Create, view, edit, and delete module records
- **Student-Module Registration** – Students can be registered to modules via the `Registration` entity
- **Lecturer-Module Assignment** – Lecturers can be assigned to modules via the `ModuleAssignment` entity
- **Authentication** – User login/registration powered by ASP.NET Core Identity (email confirmation required)

## Database

The `ApplicationDbContext` extends `IdentityDbContext` and configures the following relationships:

- A `ModuleAssignment` belongs to one `Lecturer` and one `Module`
- A `Registration` belongs to one `Student` and one `Module`

Migrations are managed via Entity Framework Core. The connection string is configured in `appsettings.json` under `DefaultConnection`.

## Getting Started

### Prerequisites

- .NET SDK (6.0 or later)
- SQL Server (local or remote)

### Setup

1. Clone the repository
2. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Your SQL Server connection string here"
   }
   ```
3. Apply migrations to create the database:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Navigate to `https://localhost:{port}` in your browser

## Project Structure

```
ProgrammeManagementSystem/
├── Controllers/
│   ├── LecturersController.cs
│   ├── ModulesController.cs
│   └── StudentsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Lecturer.cs
│   ├── Module.cs
│   ├── ModuleAssignment.cs
│   ├── Registration.cs
│   └── Student.cs
└── Program.cs
```

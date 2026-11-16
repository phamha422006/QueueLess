# QueueLess – Online Appointment Booking System

QueueLess is a personal project that aims to simplify online appointment booking. Customers can choose services, check available time slots, and book appointments online.

## Technologies

- **Backend:** ASP.NET Core Web API (.NET 10)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core (Code-First)
- **Authentication:** ASP.NET Core Identity
- **Frontend:** HTML, CSS, JavaScript (Planned)
- **Version Control:** Git & GitHub

## Current Features

- ASP.NET Core Web API setup
- SQL Server database connection
- Entity Framework Core integration
- Code-First database migrations
- Initial database schema
- User, service, staff schedule, and appointment models

## Planned Features

- User registration and login
- Role-based authorization (Customer, Staff, Admin)
- Service management (CRUD)
- Staff working schedule management
- Appointment booking and cancellation
- Available time slot validation
- Appointment conflict prevention
- Frontend integration using JavaScript Fetch API

## Database Design

The initial database includes:

- **Application Users:** User accounts and identity information
- **Services:** Available appointment services
- **Staff Schedules:** Staff working days and hours
- **Appointments:** Customer bookings and appointment statuses

ASP.NET Core Identity also generates supporting tables for authentication and role management.

## Project Structure

```text
QueueLess.Api/
├── Controllers/
├── Data/
├── DTOs/
├── Models/
├── Migrations/
├── Properties/
├── Program.cs
└── appsettings.json
```

## Getting Started

### Prerequisites

- .NET 10 SDK
- Microsoft SQL Server
- Visual Studio Code or Visual Studio

### Setup

1. Clone the repository:

```bash
git clone https://github.com/YOUR_USERNAME/QueueLess.git
```

2. Navigate to the project directory:

```bash
cd QueueLess.Api
```

3. Configure the SQL Server connection string in your local configuration.

4. Apply database migrations:

```bash
dotnet ef database update
```

5. Run the application:

```bash
dotnet run
```

## Project Status

Currently under development. New features will be implemented incrementally.

## Author

Developed as a personal learning project to practice ASP.NET Core Web API, Entity Framework Core, SQL Server, and full-stack development.
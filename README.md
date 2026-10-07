# DVLD - Driving Vehicle Licensing Department

A desktop application for managing driving vehicle licensing operations, built with **C# WinForms** and **SQL Server**.

## Overview

DVLD is a comprehensive management system that handles the full lifecycle of driving licenses — from application and testing to issuance, renewal, and replacement. It follows a clean **3-tier architecture** (Presentation → Business → Data Access).

## Features

- **People Management** — Add, edit, search, and delete person records
- **User Management** — Create and manage system users with authentication
- **License Applications** — Process local and international driving license applications
- **Test Scheduling** — Schedule and manage vision, written, and practical driving tests
- **License Operations**:
  - Issue first-time driving licenses
  - Renew expired licenses
  - Replace lost or damaged licenses
  - Detain and release licenses
  - Issue international driving licenses
- **Application & Test Type Configuration** — Manage fees, descriptions, and settings
- **Login System** — Secure login with "Remember Me" functionality

## Architecture

```
DVLD.slnx
├── DVLD/              # Presentation Layer (WinForms UI)
├── Business/          # Business Logic Layer
├── DataAccess/        # Data Access Layer (SQL Server)
└── Common/            # Shared utilities (Session, RememberMe)
```

| Layer        | Description                                              |
|--------------|----------------------------------------------------------|
| **DVLD**     | WinForms UI — forms, dialogs, and user interactions      |
| **Business** | Business rules, validation, and domain logic             |
| **DataAccess** | ADO.NET data operations with SQL Server                |
| **Common**   | Cross-cutting concerns like session and helper utilities  |

## Tech Stack

- **Language**: C# (.NET)
- **UI Framework**: Windows Forms (WinForms)
- **Database**: SQL Server
- **ORM**: ADO.NET (raw SQL with parameterized queries)
- **Architecture**: 3-Tier (Presentation → Business → Data Access)

## Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB, Express, or full edition)
- Visual Studio 2022 or later (recommended)

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/<your-username>/DVLD.git
   cd DVLD
   ```

2. **Restore the database**
   - Open **SQL Server Management Studio (SSMS)**
   - Right-click on **Databases** → **Restore Database...**
   - Select **Device** → click **...** → **Add** → browse to the `DVLD.bak` file included in the repo
   - Click **OK** to restore the database

3. **Configure the connection string**
   - Update the connection string in `DataAccess/DataAccessSettings.cs` to match your SQL Server instance

4. **Build and run**
   ```bash
   dotnet build
   dotnet run --project DVLD
   ```

## Default Login Credentials

| Username    | Password |
|-------------|----------|
| `Msaqer77`  | `1234`   |

> **Note:** You can create additional users from the application after logging in.

## License

This project is open source. Feel free to use and modify it.

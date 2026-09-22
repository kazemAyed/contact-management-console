# Contact Management Solution

A layered **C# .NET Framework 4.8 contact management application** built with a Console UI, Business Logic Layer, and Data Access Layer.

The application provides a simple CRUD workflow for managing contacts stored in a SQL Server database. The console interface includes formatted screens, input validation, confirmation prompts, and clear success/error messages.

## Features

- List all contacts
- Add a new contact
- Update an existing contact
- Delete a contact with confirmation
- Find a contact by ID
- Store contact information including:
  - Contact ID
  - First name
  - Last name
  - Email
  - Phone
  - Address
  - Country ID
- SQL Server database access through ADO.NET
- Parameterized SQL commands
- DTO-based data transfer between application layers
- Repository-style data access
- Interface-based contracts
- Console input validation
- Formatted and colorized console UI

## Architecture

The solution is organized into three main projects:

```text
ContactManagementSolution
│
├── DataAccessLayer
│   ├── DataAccess
│   │   ├── ContactRepository.cs
│   │   ├── CountryRepository.cs
│   │   ├── Interfaces
│   │   └── DatabaseConfig
│   │       ├── Contact_Queries.cs
│   │       ├── Country_Queries.cs
│   │       └── DataConnections
│   │           └── ContactsDB_Connection.cs
│   ├── Entities
│   │   ├── DtoContact.cs
│   │   └── DtoCountry.cs
│   └── DataAccessLayer.csproj
│
├── BusinessLogicLayer
│   ├── DTOs
│   │   ├── DtoContact.cs
│   │   └── DtoCountry.cs
│   ├── Interfaces
│   │   ├── IContact.cs
│   │   ├── ICountry.cs
│   │   └── ICRUD.cs
│   ├── Services
│   │   ├── Contact.cs
│   │   └── Countrycs.cs
│   └── BusinessLogicLayer.csproj
│
├── UIContactConsole
│   ├── Helpers
│   │   └── ConsoleHelper.cs
│   ├── Screens
│   │   └── ContactScreen.cs
│   ├── Program.cs
│   └── UIContactConsole.csproj
│
└── ContactManagementSolution.sln
```

### Layer Responsibilities

#### 1. UIContactConsole

The presentation layer of the application.

It is responsible for:

- Displaying the menu
- Reading user input
- Validating basic console input
- Displaying contact information
- Showing operation results
- Calling the Business Logic Layer

The main screen is implemented in:

```text
UIContactConsole/Screens/ContactScreen.cs
```

#### 2. BusinessLogicLayer

The application/service layer between the UI and database.

It is responsible for:

- Providing contact operations to the UI
- Working with business-level DTOs
- Calling repository methods
- Mapping Data Access entities to Business Logic DTOs

Main service:

```text
BusinessLogicLayer/Services/Contact.cs
```

#### 3. DataAccessLayer

The database access layer.

It is responsible for:

- Opening SQL Server connections
- Executing SQL commands
- Reading data with `SqlDataReader`
- Inserting, updating, deleting, and retrieving contacts
- Managing SQL queries
- Mapping database records to data entities

Main repository:

```text
DataAccessLayer/DataAccess/ContactRepository.cs
```

## Technology Stack

| Technology | Usage |
|---|---|
| C# | Application development |
| .NET Framework 4.8 | Target framework |
| Visual Studio | Development environment |
| SQL Server | Database |
| ADO.NET | Database communication |
| `SqlConnection` | SQL Server connection |
| `SqlCommand` | SQL command execution |
| `SqlDataReader` | Reading query results |
| Console Application | User interface |
| Git / GitHub | Version control and project hosting |

## Database

The project expects a SQL Server database named:

```text
ContactsDB
```

The current connection configuration uses:

```text
Server=.;
Database=ContactsDB;
Trusted_Connection=True;
TrustServerCertificate=True;
```

This means the application expects a local SQL Server instance and Windows authentication.

### Expected tables

The source code currently works with these tables:

```text
Contacts
Countries
```

The `Contacts` table is expected to contain fields corresponding to:

```text
ContactID
FirstName
LastName
Email
Phone
Address
CountryID
```

`CountryID` is used to associate a contact with a country.

> The repository currently contains country-related interfaces and classes, but the country CRUD implementation is not completed in the current project version.

## Contact CRUD Operations

The application supports the following operations:

### List Contacts

Retrieves all contacts from the database and displays them in a formatted table.

### Add Contact

The user enters:

```text
First Name
Last Name
Email
Phone
Address
Country
```

The application inserts the new record and displays the generated contact ID.

### Update Contact

The user provides a contact ID and enters the updated contact information.

### Delete Contact

The application asks the user to confirm the deletion before removing the contact.

Example:

```text
Are you sure you want to delete contact 10? (Y/N):
```

### Find Contact by ID

Retrieves one contact using its ID and displays its details.

## Console Interface

The application provides a menu similar to:

```text
╔═════════════════════════════════════════╗
║                                         ║
║           CONTACT MANAGEMENT            ║
║                                         ║
╠═════════════════════════════════════════╣
║                                         ║
║     [1]    List Contacts                ║
║     [2]    Add Contact                  ║
║     [3]    Update Contact               ║
║     [4]    Delete Contact               ║
║     [5]    Find Contact By ID           ║
║     [6]    Exit                         ║
║                                         ║
╚═════════════════════════════════════════╝
```

The UI also uses colors and formatted borders to make operations easier to follow.

## How the Application Works

A typical request flows through the application as follows:

```text
User
  │
  ▼
UIContactConsole
  │
  ▼
BusinessLogicLayer
  │
  ▼
ContactRepository
  │
  ▼
SQL Server
  │
  ▼
ContactRepository
  │
  ▼
BusinessLogicLayer
  │
  ▼
UIContactConsole
  │
  ▼
User
```

For example, when adding a contact:

```text
Console Input
     ↓
ContactScreen.AddContact()
     ↓
Contact Service
     ↓
ContactRepository.Add()
     ↓
SQL INSERT
     ↓
Generated ContactID
     ↓
Console Success Message
```

## Getting Started

### Prerequisites

Before running the project, make sure you have:

- Windows
- Visual Studio 2022 or a compatible Visual Studio version
- .NET Framework 4.8 Developer Pack
- SQL Server
- A SQL Server instance accessible as `.`

### 1. Clone the repository

```bash
git clone <your-repository-url>
```

Then enter the project directory:

```bash
cd ContactManagementSolution
```

### 2. Open the solution

Open:

```text
ContactManagementSolution.sln
```

with Visual Studio.

### 3. Configure SQL Server

Create a database named:

```text
ContactsDB
```

Create the required `Contacts` and `Countries` tables according to the fields expected by the repositories.

### 4. Check the database connection

The connection string is located at:

```text
DataAccessLayer/DataAccess/DatabaseConfig/DataConnections/ContactsDB_Connection.cs
```

Current configuration:

```csharp
public const string ContactsDBConnectionString =
    @"
         Server=.;
         Database=ContactsDB;
         Trusted_Connection=True;
         TrustServerCertificate=True;
    ";
```

Update it if your SQL Server instance uses a different server name or authentication configuration.

### 5. Build the solution

In Visual Studio:

```text
Build → Build Solution
```

or use:

```text
Ctrl + Shift + B
```

### 6. Set the startup project

Because `DataAccessLayer` and `BusinessLogicLayer` are class libraries, they should not be started directly.

Set:

```text
UIContactConsole
```

as the startup project.

Then run the application.

## Project Dependencies

The project references are structured as:

```text
UIContactConsole
       │
       ▼
BusinessLogicLayer
       │
       ▼
DataAccessLayer
       │
       ▼
SQL Server
```

This keeps the console interface separated from database implementation details.

## Design Patterns and Concepts Used

The current implementation demonstrates several important software development concepts:

- Layered architecture
- Repository pattern
- Service layer
- DTOs
- Interfaces
- Separation of concerns
- CRUD operations
- ADO.NET
- Parameterized SQL
- Object mapping between layers
- Input validation
- Dependency through project references

## Security Considerations

The current project is designed as a learning/project implementation and should be improved before being used in a production environment.

Recommended improvements include:

- Move the database connection string out of source code.
- Use secure configuration management.
- Avoid displaying raw database exception messages directly to users.
- Add stronger validation for email, phone, and other fields.
- Implement proper logging.
- Complete country CRUD functionality.
- Add database constraints and foreign keys.
- Consider dependency injection instead of directly creating repositories/services.
- Add automated tests.
- Add a dedicated configuration strategy for different environments.

## Current Limitations

Based on the current project implementation:

- Country repository operations are not yet implemented.
- Country queries are currently empty.
- The country selection displayed by the console is currently hard-coded.
- Database configuration is stored directly in the source code.
- Validation is mainly focused on basic console input.
- There are no automated unit/integration tests included in the current solution.
- The application currently uses a console interface rather than a web UI or REST API.

## Future Improvements

Possible future versions could include:

- Dynamic country loading from the database
- Full Country CRUD support
- Better validation
- Search by name/email/phone
- Pagination for large contact lists
- Dependency Injection
- Logging
- Unit tests
- Integration tests
- Configuration files/environment-specific settings
- Improved exception handling
- REST API layer
- Web-based user interface
- Authentication and authorization
- Database migrations
- More reusable console UI components

## Learning Goals

This project is useful for practicing:

- C# application architecture
- Multi-layered applications
- SQL Server integration
- ADO.NET
- CRUD operations
- Repository design
- DTO mapping
- Interfaces and abstractions
- Console application design
- Clean separation between UI, business logic, and data access

## License

This project does not currently specify a license.

If you plan to publish the project publicly on GitHub, add a license file that matches how you want others to use, modify, and distribute the project.

## Author

**Kazem Ayeed**

GitHub: `https://github.com/KazemAyeed`

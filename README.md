**[System Screenshots.pdf](./System%20Screenshots.pdf)**

# COMPANY EXPENSE REPORT DATABASE SYSTEM


## Description

Developed a VB.NET and Microsoft Access-based system to manage employee expense reports, departmental records, and financial data. Implemented normalized tables, queries, and views for efficient data handling, along with a role-based access control system tailored for administrators, managers, and employees. Integrated features such as automated approval workflows, real-time notifications, and reporting tools to streamline operations. Strengthened security through multi-factor authentication, encryption, and audit trails, ensuring data integrity and compliance.

## Features

- **Role-Based Access Control**: Separate interfaces and permissions for Administrators, Managers, and Employees.
- **Expense Report Management**: Submit, approve, and track employee expense reports.
- **Departmental and Financial Data Handling**: Manage departmental records and financial information with normalized database structures.
- **Automated Approval Workflows**: Streamlined processes for expense approvals.
- **Real-Time Notifications**: Alerts for status updates and approvals.
- **Reporting Tools**: Generate reports using integrated ReportViewer controls.
- **Security Features**:
  - Multi-Factor Authentication (MFA)
  - Password encryption using SHA256 hashing
  - Audit trails for tracking changes
  - Session timeout management
  - Protection against multiple failed login attempts

## Prerequisites

- **Operating System**: Windows (compatible with .NET Framework)
- **.NET Framework**: Version 4.7.2 or higher
- **Database**: MySQL Server (running on localhost)
- **MySQL Connector/NET**: Version 8.2.0
- **Database Name**: `company_expense_db`
- **MySQL User**: root (with no password, as per default connection string)

## Database Setup

The application connects to a MySQL database with the following connection string:
```
server=localhost; user=root; password=; database=company_expense_db;
```

You need to create the database `company_expense_db` and set up the required tables (e.g., `accounts`, `employees`, `departments`, `expense_types`, etc.) with appropriate relationships. The schema should include normalized tables for efficient data handling.

Note: An Access database file `ms1.mdb` is included in the project, which may contain sample data or schema reference.

## Installation

1. Ensure MySQL Server is installed and running on your local machine.
2. Create the required database and tables as mentioned above.
3. Install .NET Framework 4.7.2 if not already present on your system.
4. The application is pre-compiled, so no build is required.

## How to Run

To run the application, use the provided shortcut:

- Double-click on `COMPANY_EXPENSE - Shortcut.lnk` to launch the executable.

Alternatively, navigate to the `COMPANY_EXPENSE/bin/Debug/` directory and run `COMPANY_EXPENSE.exe`.

## Usage

1. Launch the application using the shortcut.
2. Log in with your credentials (email and password).
3. Complete multi-factor authentication if enabled.
4. Access features based on your role:
   - **Employee**: Submit expense reports, view personal expenses.
   - **Manager**: Approve expenses, view reports.
   - **Admin**: Manage users, departments, audit trails, and system settings.

## Technologies Used

- **Programming Language**: VB.NET
- **Framework**: .NET Framework 4.7.2
- **Database**: MySQL
- **UI**: Windows Forms
- **Reporting**: Microsoft ReportViewer
- **Security**: SHA256 hashing, MFA

## Notes

- Ensure the MySQL server is accessible and the database is properly configured before running the application.
- The application includes session management to prevent unauthorized access.
- For any issues, check the audit trail or logs within the application.

## License

[Add license information if applicable]

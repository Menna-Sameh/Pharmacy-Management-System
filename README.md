# Pharmacy Management System

## Project Overview

The **Pharmacy Management System** is a **Windows Forms** desktop application designed to manage pharmaceutical data efficiently. The system provides functionalities for **Excel Data Import and Mapping, Database Management with CRUD Operations, and Report Generation (Excel Export)**. The application follows **SOLID** principles, leverages **Entity Framework (EF) Core** for database operations, and utilizes **LINQ** for data querying.

---

## Features & Modules

### 1. Excel Data Import and Mapping

#### **Functionality**
- **File Upload:** Users can upload Excel files (`.xlsx`) containing pharmaceutical data.
- **Reflection-Based Mapping:** The application dynamically maps Excel columns to class properties (e.g., `Customer`, `Product`).
  - If column names match property names, the data is mapped automatically.
  - If there are mismatches (e.g., missing columns), the system displays an error message.

#### **Key Operations**
- Import and parse Excel files.
- Dynamically create class instances using **Reflection**.

#### **SOLID Principles Applied**
- **Single Responsibility Principle (SRP):** This module is responsible for handling Excel file reading and mapping logic only.
- **Open/Closed Principle (OCP):** New class types or Excel formats can be added without modifying existing logic.

---

### 2. Database Management and CRUD Operations (EF Core & LINQ)

#### **Functionality**
- **Database Management:** Manages all interactions with the database using **Entity Framework Core**.
- **CRUD Operations:**
  - **Create:** Save imported Excel data to the database.
  - **Read:** Retrieve and display data from the database using **LINQ queries**.
  - **Update:** Modify records, with changes tracked in real-time using EF Core.
  - **Delete:** Remove records securely with user confirmation.

#### **Key Operations**
- Interact with the database via **EF Core** for data persistence.
- Use **LINQ queries** for efficient data retrieval and filtering.

#### **SOLID Principles Applied**
- **Liskov Substitution Principle (LSP):** New entity types can be added without breaking existing functionality.
- **Dependency Inversion Principle (DIP):** High-level modules depend on abstractions (interfaces), not concrete EF Core classes.

---

### 3. Report Generation (Excel Export)

#### **Functionality**
- **Report Generation:** Users can generate reports based on stored data.
- **Excel Export:** Uses **EPPlus** (or a similar library) to export data from the database into a well-structured Excel sheet.

#### **Key Operations**
- Extracts data from the database via **LINQ**.
- Generates structured **Excel reports** preserving class properties as column headers.
- **Generic Export:** The report generation method is designed to handle **any class and Excel sheet format dynamically**.

---

## Workflow

1. **User uploads an Excel file** (containing customer, product, or transaction data).
2. **System dynamically maps the data** to appropriate class properties using **Reflection**.
3. **Data is stored in the database** using **EF Core**.
4. **Users perform CRUD operations** (Create, Read, Update, Delete) on the data.
5. **After modifications, reports can be generated and exported** as Excel files.

---

## Authentication Module

- **User Login System:** The application includes a **secure login system** to authenticate users before accessing features.
- **Role-Based Access Control (RBAC):** Different levels of access for admins and employees.

---

## Technologies Used

- **Windows Forms (.NET Framework/.NET Core)** – UI Development
- **Entity Framework (EF) Core** – ORM for database interactions
- **LINQ** – Querying and manipulating data
- **Reflection** – Dynamic mapping of Excel data
- **EPPlus (or similar)** – Excel file handling (Import & Export)
- **SQL Server** – Database management
- **C# (.NET)** – Backend logic and business rules

---

## Future Enhancements

- Implementing **Role-Based Authentication** for secure access.
- Adding **error logging** and handling for better debugging.
- Enhancing the **UI/UX design** for improved user experience.
- Introducing **barcode scanning** for pharmaceutical products.
- Optimizing **performance for large dataset handling**.


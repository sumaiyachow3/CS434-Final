**Healthcare Appointment Platform**

This is a web based management system built with ASP.NET MVC that allows different users to do different things.

*Project Overview*
This is a multi-role web application with three user types:
* Patients : Register, Login, book appointments with doctors, can see upcoming appointments, and simulated reminders
* Doctors : Log in and view their appointment dashboard
* Admins : Manage users and doctors through an admin panel

*Setup Instructions*
1. Clone the repository
2. Open the solution and configure database connection in web.config with your mySQL credentials
3. Create database and table
   CREATE DATABASE healthcare_db;
USE healthcare_db;
CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    Password VARCHAR(100),
    Role VARCHAR(20)
);
CREATE TABLE Doctors (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT,
    Specialization VARCHAR(100),
    Availability TEXT,
    Rating DOUBLE,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
CREATE TABLE Appointments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PatientId INT,
    DoctorId INT,
    DateTime DATETIME,
    Status VARCHAR(20),
    FOREIGN KEY (PatientId) REFERENCES Users(Id),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);
CREATE TABLE Ratings (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    DoctorId INT,
    PatientId INT,
    Score INT
);
5. run database migrations 
6. Create and admin account in mySQL
   INSERT INTO Users (Name, Email, Password, Role)
   VALUES ('Admin', 'adminemail', 'yourpassword', 'Admin');
7. You can now run the project!


*Technologies Used*
* Visual Studio 2019+
* Languages: C# , HTML, CSS
* ASP.NET MVC 5
* Entity Framework 6
* mySQL Server
  

*Screenshots*
Log in Page:
<img width="667" height="719" alt="Screenshot 2026-04-26 201922" src="https://github.com/user-attachments/assets/6e1936b8-f0a8-4b9c-bf7d-ac0babbd3aa2" />

Admin Panel:
<img width="603" height="359" alt="Screenshot 2026-04-26 202020" src="https://github.com/user-attachments/assets/85a143cb-4ef3-4d39-81d5-ac6a6a7d4388" />

Book Appointment:
<img width="904" height="656" alt="Screenshot 2026-04-26 202043" src="https://github.com/user-attachments/assets/390c14e6-89df-4d82-b28b-4f65e80af104" />

Doctor Dashboard:
<img width="910" height="459" alt="Screenshot 2026-04-26 202100" src="https://github.com/user-attachments/assets/8f9ecda4-2559-42dc-9159-948d66e27503" />

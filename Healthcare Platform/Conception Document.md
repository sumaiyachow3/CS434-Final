MVC Architecture Diagram  
 

| USER (Browser) |
| :---: |

↓  HTTP Request

| CONTROLLER LAYER |
| :---: |

 

| AccountController | AdminController | DoctorController | AppointmentController |
| :---: | :---: | :---: | :---: |

↓  Reads/Writes           	↓  Returns

| MODEL LAYER User  , Doctor  , Appointment ApplicationDbContext | VIEW LAYER Account,  Admin,  Doctor,  Appointment,  Shared, |
| :---: | :---: |

↓  Entity Framework

| DATABASE (MySQL) |
| :---: |

   
Each controller handles HTTP requests for its domain. Controllers query the database through Entity Framework, pass data to Razor Views via ViewBag or strongly-typed models, and redirect between actions based on session state and role.  
 

# Entity-Relationship (ER) Diagram

The database consists of three primary entities: Users, Doctors, and Appointments.  
 

| USERS   PK  Id (int)  	Name (string)  	Email (string)  	Password (string)  	Role (string) | DOCTORS   PK  Id (int) FK  UserId (int)  	Specialization (string)  	Availability (string)  	Rating (double) | APPOINTMENTS   PK  Id (int) FK  PatientId (int) FK  DoctorId (int)  	DateTime (DateTime)  	Status (string) |
| :---- | :---- | :---- |

   
Relationships:  
•        Users (1) — (1) Doctors: One user can be assigned as one doctor. Doctor.UserId is a foreign key to Users.Id.  
•        Users (1) — (M) Appointments: One patient (user) can have many appointments. Appointments.PatientId is a foreign key to Users.Id.  
•        Doctors (1) — (M) Appointments: One doctor can have many appointments. Appointments.DoctorId is a foreign key to Doctors.Id.

# Navigation Flow

 

| Home |
| :---: |

↓

| Login Page |
| :---: |

↓  Role check after login

| PATIENT   Book Appointments My Appointments | DOCTOR   → Doctor Dashboard | ADMIN   →Index →View Users →View Doctors → Add Doctor |
| ----- | :---: | :---: |

↓  All roles

| Logout Redirects to Login |
| :---: |

   
Any unauthenticated or unauthorized access to a protected route redirects the user back to Login.  
 

# Class Diagram

## Model Classes

| Class | Property | Type | Description |
| :---- | :---- | :---- | :---- |
| User | Id | int (PK) | Auto-increment primary key |
|   | Name | string | Full name of the user |
|   | Email | string | Login email address |
|   | Password | string | Plain text password (unhashed) |
|   | Role | string | Patient, Doctor, or Admin |
| Doctor | Id | int (PK) | Auto-increment primary key |
|   | UserId | int (FK) | References Users.Id |
|   | Specialization | string | Medical specialization |
|   | Availability | string | Available hours/days |
|   | Rating | double | Doctor rating out of 5 |
| Appointment | Id | int (PK) | Auto-increment primary key |
|   | PatientId | int (FK) | References Users.Id |
|   | DoctorId | int (FK) | References Doctors.Id |
|   | DateTime | DateTime | Date and time of appointment |
|   | Status | string | Pending, Confirmed, or Cancelled |

 

## ViewModel Classes

| Class | Property | Purpose |
| :---- | :---- | :---- |
| DoctorAppointmentViewModel | PatientName | Resolved name for the doctor's dashboard view |
|   | DateTime | Appointment date and time |
|   | Status | Appointment status string |
| AppointmentViewModel | DoctorId | Selected doctor for booking |
|   | DateTime | Chosen appointment time |

 

## Controller Classes

| Controller | Key Actions |
| :---- | :---- |
| AccountController | Register (GET/POST), Login (GET/POST), Logout |
| AdminController | Index, Users, Doctors, AddDoctor (GET/POST), DeleteDoctor |
| DoctorController | Dashboard |
| AppointmentController | Book (GET/POST), MyAppointments |


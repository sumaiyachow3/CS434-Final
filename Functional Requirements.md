# Problem Description

The healthcare industry relies heavily on manual and fragmented processes for managing patient appointments, doctor schedules, and administrative oversight. Patients often face difficulty booking appointments efficiently, doctors lack a centralized view of their schedules, and administrators have limited tools to manage platform users. The Healthcare Platform addresses these challenges by providing a unified, role-based web application that streamlines appointment booking, doctor management, and administrative control which are all accessible through a browser without requiring additional software.  
 

# User Roles

| Role | Access Level | Description |
| :---- | :---- | :---- |
| Patient | Limited | Can register, log in, and book appointments with available doctors. |
| Doctor | Moderate | Can log in and view their personal appointment dashboard showing scheduled patients. |
| Admin | Full | Can manage all users and doctors: view user list, add new doctors, and delete doctor profiles. |

 

# Use Cases

## Patient Use Cases

| Use Case | Description |
| :---- | :---- |
| Register Account | Patient fills in name, email, and password to create an account with the Patient role. |
| Login | Patient logs in with email and password. Session is created with UserId and Role. |
| Book Appointment | Patient selects a doctor, date, and time to schedule an appointment. |
| View Appointments | Patient views a list of their upcoming and past appointments. |
| Logout | Patient ends their session and is redirected to the login page. |

## Doctor Use Cases

| Use Case | Description |
| :---- | :---- |
| Login | Doctor logs in with credentials linked to their Doctor profile. |
| View Dashboard | Doctor views all appointments assigned to them, showing patient name, date/time, and status. |
| Logout | Doctor ends their session securely. |

 

## Admin Use Cases

| Use Case | Description |
| :---- | :---- |
| Login as Admin | Admin logs in with a manually created admin account. |
| View All Users | Admin sees a list of all registered users with their name, email, and role. |
| View All Doctors | Admin sees a list of all doctors with their specialization, availability, and rating. |
| Add Doctor | Admin assigns an existing user as a doctor by selecting from a dropdown and entering specialization, availability, and rating. |
| Delete Doctor | Admin removes a doctor profile from the system. |
| Logout | Admin ends their session securely. |

 

# Features List

## Authentication & Authorization

•        User registration with name, email, password, and role assignment  
•        Session-based login with role stored in session (Patient, Doctor, Admin)  
•        Route protection: all sensitive pages check session role before rendering  
•        Logout clears session and redirects to login  
 

## Patient Features

•        Registration form creates a new user with the Patient role  
•        Appointment booking with doctor selection, date, and time  
•        View list of personal appointments with status  
 

## Doctor Features

•        Login redirects to personal dashboard  
•        Dashboard displays all appointments for that doctor  
•        Shows patient name, appointment date/time, and current status  
•        Dashboard correctly resolves Doctor.Id vs User.Id to filter appointments  
 

## Admin Features

•        Admin panel accessible only to users with the Admin role  
•        View all registered users in a table  
•        View all doctors in a table  
•        Add a new doctor by assigning an existing user and entering doctor details  
•        Validation prevents duplicate doctor assignments for the same user  
•        Delete a doctor profile with null-safety guard  
 
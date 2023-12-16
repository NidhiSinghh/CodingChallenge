CREATE DATABASE HOSPITAL_SYSTEM;

USE HOSPITAL_SYSTEM;

CREATE TABLE Patients 
( patient_id INT IDENTITY PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
date_of_birth DATE,
gender VARCHAR(10),
contact_number VARCHAR(15),
address VARCHAR(100) );

CREATE TABLE Doctors ( doctor_id INT IDENTITY PRIMARY KEY, first_name
VARCHAR(50), last_name VARCHAR(50), specialization VARCHAR(100),
contact_number VARCHAR(15) ); 


CREATE TABLE Appointments ( appointment_id INT IDENTITY PRIMARY KEY,
patient_id INT, doctor_id INT, appointment_date DATETIME, description
TEXT, FOREIGN KEY (patient_id) REFERENCES Patients(patient_id),
FOREIGN KEY (doctor_id) REFERENCES Doctors(doctor_id) ); 

CREATE TABLE Billing ( bill_id INT iDENTITY PRIMARY KEY, patient_id INT,
doctor_id INT, appointment_id INT, bill_date DATE, amount DECIMAL(10,
2), payment_status VARCHAR(20), FOREIGN KEY (patient_id)
REFERENCES Patients(patient_id), FOREIGN KEY (doctor_id) REFERENCES
Doctors(doctor_id), FOREIGN KEY (appointment_id) REFERENCES
Appointments(appointment_id) ); 

drop table medications
CREATE TABLE Medications ( medication_id INT IDENTITY PRIMARY KEY,
appointment_id INT, medication_name VARCHAR(100),
dosage VARCHAR(50), 
FOREIGN KEY (appointment_id) REFERENCES Appointments(appointment_id) );

drop table LabTests
CREATE TABLE LabTests ( test_id INT IDENTITY PRIMARY KEY, appointment_id INT,
test_name VARCHAR(100), test_result TEXT,
FOREIGN KEY (appointment_id) REFERENCES Appointments(appointment_id) ); 

DROP TABLE USERS
CREATE TABLE Users ( user_id INT IDENTITY PRIMARY KEY, username
VARCHAR(50) UNIQUE, password VARCHAR(100), user_type
VARCHAR(20) );



drop table medications

INSERT INTO Patients (first_name, last_name, date_of_birth, gender, contact_number, address)
VALUES 
  ('John', 'Doe', '1990-05-15', 'Male', '1234567890', '123 Main St')
  INSERT INTO Patients (first_name, last_name, date_of_birth, gender, contact_number, address)
VALUES 
  ('Jane', 'Smith', '1985-08-22', 'Female', '9876543210', '456 Oak St'),
  ('Alice', 'Johnson', '1978-12-10', 'Female', '5551112222', '789 Elm St'),
  ('Bob', 'Williams', '1995-03-25', 'Male', '4443332222', '567 Pine St'),
  ('Eva', 'Brown', '1982-06-18', 'Female', '9998887777', '234 Cedar St'),
  ('David', 'Jones', '1992-09-07', 'Male', '7776665555', '890 Birch St');

  INSERT INTO Doctors (first_name, last_name, specialization, contact_number)
VALUES 
  ('Dr. Smith', 'Johnson', 'Cardiology', '1112223333'),
  ('Dr. Lisa', 'Anderson', 'Pediatrics', '4445556666'),
  ('Dr. Richard', 'Clark', 'Orthopedics', '7778889999'),
  ('Dr. Sarah', 'Williams', 'Dermatology', '3334445555'),
  ('Dr. Michael', 'Moore', 'Oncology', '6667778888'),
  ('Dr. Emily', 'Taylor', 'Neurology', '9990001111');

  INSERT INTO Appointments (patient_id, doctor_id, appointment_date, description)
VALUES 
  (1, 3, '2023-01-10', 'Regular checkup');
  INSERT INTO Appointments (patient_id, doctor_id, appointment_date, description)
VALUES
  (2, 2, '2023-02-15 14:30:00', 'Vaccination'),
  (3, 1, '2023-03-20 11:45:00', 'Bone fracture consultation'),
  (4, 4, '2023-04-05 09:15:00', 'Skin rash examination'),
  (5, 5, '2023-05-12 15:00:00', 'Cancer screening'),
  (6, 6, '2023-06-28 13:30:00', 'Neurological disorder evaluation');

  INSERT INTO Billing (patient_id, doctor_id, appointment_id, bill_date, amount, payment_status)
VALUES 
  (1, 3, 1, '2023-01-10', 150.00, 'Paid'),
  (2, 2, 2, '2023-02-15', 75.50, 'Pending'),
  (3, 1, 3, '2023-03-20', 200.00, 'Paid'),
  (4, 4, 4, '2023-04-05', 120.75, 'Pending'),
  (5, 5, 5, '2023-05-12', 300.25, 'Paid'),
  (6, 6, 6, '2023-06-28', 180.50, 'Pending');

  INSERT INTO Medications (appointment_id, medication_name, dosage)
VALUES 
  (1, 'Aspirin', '50mg'),
  (3, 'Ibuprofen', '200mg'),
  (5, 'Chemotherapy', 'Varies'),
  (6, 'Lamotrigine', '100mg'),
  (2, 'Vitamin D', '10mcg'),
  (4, 'Hydrocortisone', '2.5% cream');

  INSERT INTO LabTests (appointment_id, test_name, test_result)
VALUES 
  (1, 'Blood Pressure', '120/80 mmHg'),
  (3, 'X-ray', 'No fractures detected'),
  (5, 'Biopsy', 'Negative for cancer cells'),
  (2, 'Blood Test', 'Vitamin D deficiency'),
  (4, 'Skin Culture', 'Positive for fungal infection'),
  (6, 'MRI', 'Abnormal brain activity');

  INSERT INTO Users (username, password, user_type)
VALUES 
  ('admin', 'admin123', 'Admin'),
  ('doctor1', 'doctor123', 'Doctor'),
  ('nurse1', 'nurse123', 'Nurse'),
  ('receptionist1', 'receptionist123', 'Receptionist');
using HospitalSystem.Exceptions;
using HospitalSystem.Model;
using Microsoft.VisualBasic;
using system.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    internal class HospitalRepository : IHospitalRepository
    {

        //Sql Connection and Sql Command
        public string connectionString;
        SqlCommand cmd = null;
        //private List<Vehicle> availableVehicles;

        public HospitalRepository()
        {
            connectionString = DbUtil.GetConnectionString();
            cmd = new SqlCommand();

        }

        public int addPatient(Patient patient)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO Patients values (@first_name, @last_name, @date_of_birth, @gender, @contact_number, @address)";
                cmd.Parameters.AddWithValue("@first_Name", patient.firstName);
                cmd.Parameters.AddWithValue("@last_Name", patient.lastName);
                cmd.Parameters.AddWithValue("@date_of_birth", patient.dateOfBirth);
                cmd.Parameters.AddWithValue("@gender", patient.gender);
                cmd.Parameters.AddWithValue("@contact_number", patient.contactNumber);
                cmd.Parameters.AddWithValue("@address", patient.address);


                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addPstatus = cmd.ExecuteNonQuery();
                return addPstatus;
            }




        }

        public int cancelAppointment(int apId)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "DELETE FROM Appointments WHERE appointment_id = @appointmentId";
                    cmd.Parameters.AddWithValue("@appointmentId", apId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();

                    int delstatus = cmd.ExecuteNonQuery();
                    return delstatus;

                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public int deletePatient(int patientId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {





                // Now, delete the patient
                cmd.CommandText = "DELETE FROM Patients WHERE patient_id = @patientId";
                cmd.Parameters.AddWithValue("@patientId", patientId);
                cmd.Connection = connection;
                connection.Open();

                int delp = cmd.ExecuteNonQuery();

                if (delp != 0)
                {
                    return delp;
                }
                else
                {
                    throw new PatientNumberNotFoundException($"Patient id {patientId} does not exist");


                }

            }

        }

        //public void deletePatient(int patientId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Patient> getAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Patients ";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Patient patient = new Patient();
                        patient.patientId = (int)reader["patient_id"];
                        patient.firstName = (string)reader["first_name"];
                        patient.lastName = (string)reader["last_name"];
                        patient.dateOfBirth = (DateTime)reader["date_of_birth"];
                        patient.gender = (string)reader["gender"];
                        patient.contactNumber = (string)reader["contact_number"];
                        patient.address = (string)reader["address"];
                        patients.Add(patient);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return patients;
        }

        public Appointment getAppointmentById(int aptId)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {


                    cmd.CommandText = "SELECT * FROM Appointments WHERE appointment_id = @appointmentId";
                    cmd.Parameters.AddWithValue("@appointmentId", aptId);

                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment()
                        {
                            appointmentId = (int)reader["appointment_id"],
                            patientId = (int)reader["patient_id"],
                            doctorId = (int)reader["doctor_id"],
                            appointmentDate = (DateTime)reader["appointment_date"],
                            description = (string)reader["Description"],
                        };
                        return appointment;

                    }


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }

        public List<Appointment> getAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> aptForDoctor = new List<Appointment>();

            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {


                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT * FROM Appointments WHERE doctor_id = @doctorId";
                        cmd.Parameters.AddWithValue("@doctorId", doctorId);

                        cmd.Connection = sqlconnection;
                        sqlconnection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Appointment apt = new Appointment();

                            apt.appointmentId = (int)reader["appointment_id"];
                            apt.patientId = (int)reader["patient_id"];
                            apt.doctorId = (int)reader["doctor_id"];
                            apt.appointmentDate = (DateTime)reader["appointment_date"];
                            apt.description = (string)reader["Description"];
                            aptForDoctor.Add(apt);
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return aptForDoctor;

        }

        public List<Appointment> getAppointmentsForPatient(int patientId)
        {
            List<Appointment> aptForPatient = new List<Appointment>();

            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {



                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM Appointments WHERE patient_id = @patId";
                cmd.Parameters.AddWithValue("@patId", patientId);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment apt = new Appointment();

                    apt.appointmentId = (int)reader["appointment_id"];
                    apt.patientId = (int)reader["patient_id"];
                    apt.doctorId = (int)reader["doctor_id"];
                    apt.appointmentDate = (DateTime)reader["appointment_date"];
                    apt.description = (string)reader["Description"];
                    aptForPatient.Add(apt);
                }

                if (aptForPatient.Count > 0)
                {
                    return aptForPatient;

                }
                else
                {
                    throw new PatientNumberNotFoundException($"Patient id {patientId} does not exist");
                }
            }


        }







        public Patient getPatientById(int patientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "Select * FROM Patients Where patient_id=@pid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pid", patientId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient patient = new Patient()
                    {
                        patientId = (int)reader["patient_id"],
                        firstName = (string)reader["first_name"],
                        lastName = (string)reader["last_name"],
                        dateOfBirth = (DateTime)reader["date_of_birth"],


                        gender = (string)reader["gender"],
                        contactNumber = (string)reader["contact_number"],
                        address = (string)reader["address"],
                    };
                    return patient;

                };

                throw new PatientNumberNotFoundException($"Patient id {patientId} does not exist");

            }


        }



        public int scheduleappointment(Appointment appointment)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {



                    StringBuilder sb = new StringBuilder();


                    sb.Append("INSERT INTO Appointments ");
                    sb.Append(" VALUES (@patientId, @doctorId, @appointmentDate, @description)");

                    cmd.Parameters.Clear();
                    cmd.CommandText = sb.ToString();

                    cmd.Parameters.AddWithValue("@patientId", appointment.patientId);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.doctorId);
                    cmd.Parameters.AddWithValue("@appointmentDate", appointment.appointmentDate);
                    cmd.Parameters.AddWithValue("@description", appointment.description);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int addappstat = cmd.ExecuteNonQuery();
                    return addappstat;



                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public int updateAppointment(Appointment appointment)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {


                    StringBuilder sb = new StringBuilder();

                    cmd.Parameters.Clear();
                    sb.Append("UPDATE Appointments ");
                    sb.Append("SET patient_id = @patientId, doctor_id = @doctorId,appointment_date = @appointmentDate, description = @description ");



                    cmd.CommandText = sb.ToString();


                    cmd.Parameters.AddWithValue("@patientId", appointment.patientId);
                    cmd.Parameters.AddWithValue("@doctorId", appointment.doctorId);
                    cmd.Parameters.AddWithValue("@appointmentDate", appointment.appointmentDate);
                    cmd.Parameters.AddWithValue("@description", appointment.description);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    int updateappstat = cmd.ExecuteNonQuery();
                    return updateappstat;

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public int updatePatient(Patient patient)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                StringBuilder sb = new StringBuilder();


                sb.Append("UPDATE Patients ");
                sb.Append("SET first_name = @fname, ");
                sb.Append("last_name = @lname, ");
                sb.Append("date_of_birth = @dob, ");
                sb.Append("gender = @gender, ");
                sb.Append("contact_number = @pno, ");
                sb.Append("address = @address ");
                sb.Append("WHERE patient_id = @pid");
                cmd.Parameters.Clear();
                cmd.CommandText = sb.ToString();

                cmd.Parameters.AddWithValue("@fname", patient.firstName);
                cmd.Parameters.AddWithValue("@lname", patient.lastName);
                cmd.Parameters.AddWithValue("@dob", patient.dateOfBirth);
                cmd.Parameters.AddWithValue("@gender", patient.gender);
                cmd.Parameters.AddWithValue("@pno", patient.contactNumber);
                cmd.Parameters.AddWithValue("@address", patient.address);
                cmd.Parameters.AddWithValue("@pid", patient.patientId);

                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                int updatePstatus = cmd.ExecuteNonQuery();


                return updatePstatus;
            }

        }
    }

}

using HospitalSystem.Exceptions;
using HospitalSystem.Model;
using HospitalSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HospitalSystem.Service
{
    internal class HospitalService : IHospitalService
    {

        IHospitalRepository ihospitalrepository = new HospitalRepository();

        public void addPatient()
        {
            Console.WriteLine("add first name");
            string fname = Console.ReadLine();
            Console.WriteLine("last name");
            string lname = Console.ReadLine();
            Console.WriteLine("dob");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("gneder");
            string gender = Console.ReadLine();
            Console.WriteLine("contact no");
            string pno = Console.ReadLine();
            Console.WriteLine("adress");
            string address = Console.ReadLine();

            Patient addP = new Patient()
            {
                firstName = fname,
                lastName = lname,
                dateOfBirth = dob,
                gender = gender,
                contactNumber = pno,
                address = address

            };
            int addedPateint = ihospitalrepository.addPatient(addP);

            if (addedPateint != 0)
            {
                Console.WriteLine("Patietn added success");
            }
            else
            {
                Console.WriteLine("patient adding failed");
            }
        }

        public void apptmntById()
        {
            Console.WriteLine("Enter appointent id");
            int aptId = int.Parse(Console.ReadLine());
            Appointment aptByid = ihospitalrepository.getAppointmentById(aptId);

            Console.WriteLine(aptByid);

        }

        public void cancelAppointment()
        {
            Console.WriteLine("Enter appt id");
            int aptId = int.Parse(Console.ReadLine());
            int delaptstat = ihospitalrepository.cancelAppointment(aptId);
            if (delaptstat != 0)
            {
                Console.WriteLine("appoitnmen deleted");
            }
            else
            {
                Console.WriteLine("appt not deleted");
            }
        }

        public void deletePatient()
        {
            try
            {
                Console.WriteLine("ente rpatient id");
                int paid = int.Parse(Console.ReadLine());
                int delstatus = ihospitalrepository.deletePatient(paid);
                if (delstatus > 0)
                {
                    Console.WriteLine("patient deleted");
                }
                else
                {
                    Console.WriteLine("couldnt be deleeted");
                }
            }
            catch (PatientNumberNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void getAllPatients()
        {
            List<Patient> resultAllPatient = ihospitalrepository.getAllPatients();
            foreach (Patient patient in resultAllPatient)
            {
                Console.WriteLine(patient);
            }
        }

        public void getAppointmentsForDoctor()
        {
            Console.WriteLine("Enter doctors id whoise appoitmetn you want to see");
            int docId = int.Parse(Console.ReadLine());
            List<Appointment> aptfordoc = ihospitalrepository.getAppointmentsForDoctor(docId);
            foreach (Appointment appointment in aptfordoc)
            {
                Console.WriteLine(appointment);
            }


        }

        public void getAppointmentsForPatient()
        {
            try
            {
                Console.WriteLine("Enter patient id whoise appoitmetn you want to see");
                int pId = int.Parse(Console.ReadLine());
                List<Appointment> aptfordoc = ihospitalrepository.getAppointmentsForPatient(pId);
                foreach (Appointment appointment in aptfordoc)
                {
                    Console.WriteLine(appointment);
                }
            }
            catch (PatientNumberNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public void getPatientById()
        {
            try
            {
                Console.WriteLine("Enter id");
                int enteredId = int.Parse(Console.ReadLine());
                Patient patientById = ihospitalrepository.getPatientById(enteredId);
                Console.WriteLine(patientById);
            }
            catch (PatientNumberNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void scheduleAppointment()
        {
            Console.WriteLine("Enter patienr id");
            int pid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter doc id");
            int did = int.Parse(Console.ReadLine());
            Console.WriteLine("enter date");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter description");
            string des = Console.ReadLine();
            Appointment apt = new Appointment()
            {
                patientId = pid,
                doctorId = did,
                appointmentDate = date,
                description = des
            };
            int schedulestat = ihospitalrepository.scheduleappointment(apt);
            if (schedulestat != 0)
            {
                Console.WriteLine("Schedule added");
            }
            else
            {
                Console.WriteLine("Schedule not taken");
            }
        }

        public void updateAppointment()
        {
            Console.WriteLine("Enter appoitnmet id");
            int aid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter patient id");
            int pid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter doc id");
            int did = int.Parse(Console.ReadLine());
            Console.WriteLine("enter date");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter description");
            string des = Console.ReadLine();
            Appointment apt = new Appointment()
            {
                appointmentId = aid,
                patientId = pid,
                doctorId = did,
                appointmentDate = date,
                description = des
            };
            int updatestat = ihospitalrepository.updateAppointment(apt);
            if (updatestat != 0)
            {
                Console.WriteLine("update added");
            }
            else
            {
                Console.WriteLine("update not taken");
            }
        }


        public void updatePatient()
        {
            try
            {
                Console.WriteLine("enter id for which you want to update");
                int eneteredId = int.Parse(Console.ReadLine());
                Console.WriteLine("add first name");
                string fname = Console.ReadLine();
                Console.WriteLine("last name");
                string lname = Console.ReadLine();
                Console.WriteLine("dob");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("gneder");
                string gender = Console.ReadLine();
                Console.WriteLine("contact no");
                string pno = Console.ReadLine();
                Console.WriteLine("adress");
                string address = Console.ReadLine();

                Patient updateP = new Patient()
                {
                    patientId = eneteredId,
                    firstName = fname,
                    lastName = lname,
                    dateOfBirth = dob,
                    gender = gender,
                    contactNumber = pno,
                    address = address

                };

                int updateStatus = ihospitalrepository.updatePatient(updateP);
                if (updateStatus != 0)
                {
                    Console.WriteLine("updated");
                }
                else
                {
                    Console.WriteLine("didnt update");
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

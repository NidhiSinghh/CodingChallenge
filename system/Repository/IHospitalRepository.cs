using HospitalSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    internal interface IHospitalRepository
    {
        Patient getPatientById(int patientId);
        List<Patient> getAllPatients();
        int addPatient(Patient patient);
        int updatePatient(Patient patient);
        int deletePatient(int patientId);
        Appointment getAppointmentById(int appointmentId);
        List<Appointment> getAppointmentsForPatient(int patientId);
        List<Appointment> getAppointmentsForDoctor(int doctorId);
        int scheduleappointment(Appointment appointment);
        int updateAppointment(Appointment appointment);
        int cancelAppointment(int appointmentId);

    }
}

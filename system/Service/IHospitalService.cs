using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Service
{
    internal interface IHospitalService
    {
        void getAllPatients();
        void getPatientById();
        void addPatient();
        void updatePatient();
        void deletePatient();
        void apptmntById();
        void getAppointmentsForDoctor();
        void getAppointmentsForPatient();
        void scheduleAppointment();
        void updateAppointment();
        void cancelAppointment();
    }
}

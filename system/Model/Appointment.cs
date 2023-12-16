using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class Appointment
    {
        public int appointmentId; 
        public int patientId;
        public int doctorId; 
        public DateTime appointmentDate; 
        public String description;

        public override string ToString()
        {
            return $"Appointment id:{appointmentId}\tPatient Id:{patientId}\tDoctor id:{doctorId}\tAppt date:{appointmentDate.ToString("dd/MM/yyyy")}\t Description:{description}";
        }
    }
}

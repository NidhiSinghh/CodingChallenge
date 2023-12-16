using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class Billing
    {
        private int billId; 
        private int patientId; 
        private int doctorId; 
        private int appointmentId; 
        private DateTime billDate; 
        private Decimal amount; 
        private String paymentStatus;

        public override string ToString()
        {
            return $"Patient id:{patientId}";
        }
    }
}

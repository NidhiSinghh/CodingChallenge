using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class Medication
    {
        private int medicationId; 
        private int appointmentId; 
        private String medicationName; 
        private String dosage;

        public override string ToString()
        {
            return $"Medication id:{medicationId}";
        }
    }

}

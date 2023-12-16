using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class Doctor
    {
        
            private int doctorId;
            private String firstName;
            private String lastName;
            private String specialization;
            private String contactNumber;
        public override string ToString()
        {
            return $"Dcotor id:{doctorId}";
        }


    }
}

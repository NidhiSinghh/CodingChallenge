using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class Patient
    {
        public  int patientId;
        public String firstName;
        public String lastName;
        public DateTime dateOfBirth;
        public String gender;
        public String contactNumber;
        public String address;

        public override string ToString()
        {
            return $"Patient id:{patientId}\tFirst Name:{firstName}\tLAst name:{lastName}\tDOB:{dateOfBirth.ToString("dd/MM/yyyy")}\tGender:{gender}\tNumber:{contactNumber}\tAddress:{address}";
        }
    }
}

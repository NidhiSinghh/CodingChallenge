using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Exceptions
{
    internal class PatientNumberNotFoundException:ApplicationException
    {
        public PatientNumberNotFoundException() { }
        public PatientNumberNotFoundException(string message) : base(message) { }
    }
}

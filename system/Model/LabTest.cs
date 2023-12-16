using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class LabTest
    {
        private int testId; 
        private int appointmentId;
        private String testName;
        private String testResult;

        public override string ToString()
        {
            return $"Test id:{testId}";
        }
    }
}

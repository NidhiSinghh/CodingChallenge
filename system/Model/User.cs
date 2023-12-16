using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Model
{
    internal class User
    {

        private int userId; 
        private String username;
        private String password; 
        private String userType;

        public override string ToString()
        {
            return $"User id:{userId}";
        }
    }

    
}

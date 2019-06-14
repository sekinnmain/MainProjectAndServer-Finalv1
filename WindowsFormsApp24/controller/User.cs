using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUsers
{
    public class User
    {
        public string FirstName { get; set; }//שם פרטי של המתמש
        public string LastName { get; set; }//שם משפחה של המתמש
        public string Email { get; set; }//כתובת המייל של המתמש   
        public string PhoneNumber { get; set; }//מספר הטלפון של המשתמש
        public string Address { get; set; }//כתובת של המשתמש
        public string userType { get; set; }//סוג המשתמש

            
    }
}

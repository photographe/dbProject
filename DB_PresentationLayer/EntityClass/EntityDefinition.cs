using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_PresentationLayer.EntityClass
{
    public class EntityDefinition
    {
        string userName;
        string Password;
    }

    public class Profile
    {
        public string Name;
        public string Email;
        public string UserName;
        public string Password;
        public string Phone;
        public string Address;
        public string Contribute;
        public string AddReview;
    }

    public class Booking
    {
        public string Source;
        public string Destination;
        public string UserName;
        public string UberTime;
        public string UberPrice;
        public string LyftTime;
        public string LyftPrice;
        public string YellowTime;
        public string YellowPrice;
    }

    public class Registration
    {
        public string Name;
        public string Email;
        public string UserName;
        public string Password;
        public string Phone;
        public string Address;
        bool IsStudent;
    }
    public class Login
    {
        public string UserName;
        public string Password;
    }

    public class ExecutionTime
    {
        public DateTime startTime;
        public DateTime endTime;
        public DateTime TimeTaken;
    }
}
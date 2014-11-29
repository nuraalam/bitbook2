using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldInASPDOTNetMVC.Models
{
    public class Student
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public double LastPaymentAmount { set; get; }
        public System.DateTime PostedDate { get; set; }
    }
}
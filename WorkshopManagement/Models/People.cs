using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    public abstract class People 
    {
        public string name { get; private set;}
        protected int age { get; private set; }
        protected string phoneNumber { get; private set; }
        protected string job { get; private set; }

        protected People(string _name, int _age, string _phoneNumber, string _job)
        {
            this.name = _name;
            this.job = _job;
            this.age = _age;
            this.phoneNumber = _phoneNumber;
        }


    }
}

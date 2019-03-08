﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rmdb.Domain.Model
{
    public class Person
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? Deceased { get; set; }

        private Person() { }

        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }
    }
}
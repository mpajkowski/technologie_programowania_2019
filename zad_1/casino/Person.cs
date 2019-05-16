﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    public class Person
    {
        public Person(string name, string surname, string phoneNumber, Address address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

    }
}
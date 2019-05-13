﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kasyno
{
    class Gambler
    {
        public Gambler(Guid id, string name, string surname, string phoneNumber, string address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
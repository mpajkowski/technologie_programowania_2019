using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace kasyno
{
    class Address
    {
        public Address(string city, int postalCode, string street, RegionInfo country)
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            Country = country;
        }

        public string City { get; set; }
        public int PostalCode { get; set; }
        public string Street { get; set; }
        public RegionInfo Country { get; set; }
    }   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace casino
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string city, string postalCode, string street, RegionInfo country)
        {
            City = city;
            PostalCode = postalCode;
            Street = street;
            Country = country;
        }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public RegionInfo Country { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(PostalCode)}: {PostalCode}, {nameof(Street)}: {Street}, {nameof(Country)}: {Country}";
        }

        public override bool Equals(object obj)
        {
            var address = obj as Address;
            return address != null &&
                   City == address.City &&
                   PostalCode == address.PostalCode &&
                   Street == address.Street &&
                   EqualityComparer<RegionInfo>.Default.Equals(Country, address.Country);
        }

        public override int GetHashCode()
        {
            var hashCode = 1741022360;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<RegionInfo>.Default.GetHashCode(Country);
            return hashCode;
        }
    }   
}

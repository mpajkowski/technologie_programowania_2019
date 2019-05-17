using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace casino
{
    public class Address
    {
        public Address()
        {
            Id = Guid.NewGuid();
        }

        public Address(string city, string postalCode, string street, string country)
        {
            Id = Guid.NewGuid();
            City = city;
            PostalCode = postalCode;
            Street = street;
            Country = country;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            var address = obj as Address;
            return address != null &&
                   Id.Equals(address.Id) &&
                   PersonId.Equals(address.PersonId) &&
                   City == address.City &&
                   PostalCode == address.PostalCode &&
                   Street == address.Street &&
                   Country == address.Country;
        }

        public override int GetHashCode()
        {
            var hashCode = 1351278517;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(PersonId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(PostalCode)}: {PostalCode}, {nameof(Street)}: {Street}, {nameof(Country)}: {Country}";
        }
    }   
}

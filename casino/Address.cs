using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace casino
{
    [DataContract]
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

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public Guid PersonId { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
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

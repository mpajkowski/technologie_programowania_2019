using System;
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

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Id.Equals(person.Id) &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   PhoneNumber == person.PhoneNumber &&
                   EqualityComparer<Address>.Default.Equals(Address, person.Address);
        }

        public override int GetHashCode()
        {
            var hashCode = -53900819;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PhoneNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<Address>.Default.GetHashCode(Address);
            return hashCode;
        }
    }
}

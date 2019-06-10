using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    [DataContract]
    public abstract class Person
    {
        public Person(string name, string surname, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}," +
                   $" {nameof(Name)}: {Name}," +
                   $" {nameof(Surname)}: {Surname}," +
                   $" {nameof(PhoneNumber)}: {PhoneNumber},";
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }

        public override bool Equals(object obj)
        {
            var person = obj as Person;
            return person != null &&
                   Id.Equals(person.Id) &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   PhoneNumber == person.PhoneNumber;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

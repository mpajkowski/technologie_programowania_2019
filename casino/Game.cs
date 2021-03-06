﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace casino
{
    [DataContract]
    public class Game
    {
        public Game() { }
        public Game(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }

        public override bool Equals(object obj)
        {
            var game = obj as Game;
            return game != null &&
                   Id.Equals(game.Id) &&
                   Name.Equals(game.Name);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

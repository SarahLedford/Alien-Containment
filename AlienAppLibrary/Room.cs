using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAppLibrary
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCurrentRoom { get; set; }

        public Room(string name, string description, bool isCurrentRoom)
        {
            Name = name;
            Description = description;
            IsCurrentRoom = isCurrentRoom;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\n" +
                $"{Description}");
        }
    }
}

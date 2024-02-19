using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string GamerTag { get; set; }

        // Constructor
        public Player(string firstName, string lastName, int age, string country, string gamerTag)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Country = country;
            GamerTag = gamerTag;
        }

        // Method to get player's full name
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Method to display player's information
        public override string ToString()
        {
            return $"Name: {GetFullName()}, Age: {Age}, Country: {Country}, GamerTag: {GamerTag}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Tournament
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Timezone { get; set; }
        public string GamerTag { get; set; }
        public string EmailAddress { get; set; }

        // Constructor
        public Player(int id, string firstName, string lastName, int timeZone, string gamerTag, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Timezone = timeZone;
            GamerTag = gamerTag;
            EmailAddress = emailAddress;
        }

        // Method to get player's full name
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Method to display player's information
        public override string ToString()
        {
            return $"Name: {GetFullName()}, Country: {Timezone}, GamerTag: {GamerTag}, Email Address {EmailAddress}";
        }
    }
}

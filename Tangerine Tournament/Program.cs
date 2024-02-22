/*
namespace Tangerine_Tournament
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
*/
using System;

using System;

namespace Tangerine_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of players
            Player player1 = new Player(1, "John", "Doe", 5, "JohnDoe", "john@example.com");
            Player player2 = new Player(2, "Jane", "Smith", 3, "JaneSmith", "jane@example.com");
            Player player3 = new Player(3, "Mike", "Johnson", 8, "MikeJohnson", "mike@example.com");

            // Create instances of teams
            Team team1 = new Team(101, "Team Alpha", player1);
            Team team2 = new Team(102, "Team Beta", player2);

            // Add players to teams
            team1.AddPlayer(player1);
            team1.AddPlayer(player2);
            team2.AddPlayer(player3);

            // Create a tournament builder instance
            TournamentBuilder tournamentBuilder = new TournamentBuilder();

            // Create a tournament
            string tournamentName = "Tournament5";
            tournamentBuilder.CreateTournament(tournamentName, "Single Elimination");

            // Add players and teams to the tournament
            tournamentBuilder.AddPlayer(tournamentName, player1);
            tournamentBuilder.AddPlayer(tournamentName, player2);
            tournamentBuilder.AddPlayer(tournamentName, player3);

            tournamentBuilder.AddTeam(tournamentName, team1);
            tournamentBuilder.AddTeam(tournamentName, team2);

            // Assign players to teams
            tournamentBuilder.AssignPlayers(tournamentName, team1);
            tournamentBuilder.AssignPlayers(tournamentName, team2);

            // Update player information
            player1.FirstName = "Johnny";
            tournamentBuilder.UpdatePlayer(tournamentName, player1);

            // Update team information
            team1.TeamName = "Updated Team Alpha";
            tournamentBuilder.UpdateTeam(tournamentName, team1);

            // Remove a player
            tournamentBuilder.RemovePlayer(tournamentName, player3);

            // Remove a team
            tournamentBuilder.RemoveTeam(tournamentName, team2);

            TestPlayerAndTeam();
            TestTournamentInfo();
        }

        static void TestPlayerAndTeam()
        {
            // Load player and team information
            Tangerine_Tournament.TournamentGetter tournamentGetter = new Tangerine_Tournament.TournamentGetter("SampleTournament");
            Tangerine_Tournament.Player player = tournamentGetter.GetPlayer(1);
            Tangerine_Tournament.Team team = tournamentGetter.GetTeam(1);

            // Display player and team information
            Console.WriteLine("Player Information:");
            Console.WriteLine(player);
            Console.WriteLine();

            Console.WriteLine("Team Information:");
            Console.WriteLine(team);
            Console.WriteLine();
        }

        static void TestTournamentInfo()
        {
            // Load tournament information
            Tangerine_Tournament.TournamentGetter tournamentGetter = new Tangerine_Tournament.TournamentGetter("SampleTournament");
            Tangerine_Tournament.SingleElimination tournamentInfo = tournamentGetter.GetTournamentInfo();

            // Display tournament information
            Console.WriteLine("Tournament Information:");
            Console.WriteLine($"Name: {tournamentInfo.Name}");
            Console.WriteLine($"Date: {tournamentInfo.Date}");
            Console.WriteLine($"Type: {tournamentInfo.Type}");
            Console.WriteLine();
        }
    }




}
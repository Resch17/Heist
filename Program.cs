using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╒══════════════════╕");
            Console.WriteLine("│ Plan Your Heist! │");
            Console.WriteLine("╘══════════════════╛");
            Console.WriteLine("");
            
            int bankLevel = 0;
            bool enteringBank = true;
            while (enteringBank)
            {
                Console.WriteLine("Enter the bank's difficulty level: ");
                Console.Write(" > ");
                string bankLevelInput = Console.ReadLine();
                try
                {
                    bankLevel = int.Parse(bankLevelInput);
                    enteringBank = false;
                }
                catch
                {
                    Console.WriteLine("Must be an integer. Press any key to try again...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            List<TeamMember> teamRoster = new List<TeamMember>();
            bool adding = true;
            while (adding)
            {
                Console.WriteLine("Enter a team member's name: ");
                Console.Write(" > ");
                string newMemberName = Console.ReadLine();

                if (newMemberName != "")
                {
                    int newMemberSkill = TeamMember.SkillInput(newMemberName);
                    decimal newMemberCourage = TeamMember.CourageInput(newMemberName);
                    TeamMember member = new TeamMember(newMemberName, newMemberSkill, newMemberCourage);
                    teamRoster.Add(member);
                    Console.Clear();
                }
                else
                {
                    adding = false;
                    Console.Clear();
                }
            }
            Console.WriteLine($"Your team has {teamRoster.Count} members. Press any key to continue...");
            Console.ReadKey();

            bool enteringTrials = true;
            int trials = 0;
            while (enteringTrials)
            {
                Console.Clear();
                Console.WriteLine("How many trial runs do you want to do?");
                Console.Write(" > ");
                string trialInput = Console.ReadLine();
                try
                {
                    trials = int.Parse(trialInput);
                    enteringTrials = false;
                }
                catch
                {
                    Console.WriteLine("Bad number, try again.");
                }
            }

            int successCount = 0;
            int failureCount = 0;

            for (int i = 0; i < trials; i++)
            {
                int luck = new Random().Next(-10, 10);
                int bankDifficulty = bankLevel + luck;
                List<int> teamSkills = teamRoster.Select(member => member.SkillLevel).ToList();
                int teamSkillTotal = teamSkills.Sum();
                bool heistSuccess;
                if (teamSkillTotal >= bankDifficulty)
                {
                    heistSuccess = true;
                    successCount++;
                }
                else
                {
                    heistSuccess = false;
                    failureCount++;
                }

                Console.WriteLine("");
                Console.WriteLine("╒════════════════════════════╕");
                Console.WriteLine($"          Heist #{i + 1}");
                Console.WriteLine("╞════════════════════════════╛");
                Console.WriteLine($"│  Bank Difficulty: {bankDifficulty}");
                Console.WriteLine($"│  Crew Skill: {teamSkillTotal}");
                Console.WriteLine("│  ");
                Console.WriteLine($"│  Heist Outcome: {(heistSuccess ? "Success!" : "Failure!")} ");
                Console.WriteLine("╘═════════════════════════════");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.WriteLine("");
                Console.ReadKey();
            }

            Console.WriteLine(" Here's how you fared: ");
            Console.WriteLine("═════════════════════════");
            Console.WriteLine($"  Successes: {successCount}");
            Console.WriteLine($"  Failures:  {failureCount}");
            Console.WriteLine("═════════════════════════");
            Console.WriteLine("Press any key to exit...");
        }
    }
}

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
            List<TeamMember> teamRoster = new List<TeamMember>();
            bool adding = true;
            while (adding)
            {
                Console.WriteLine("Enter a team member's name: ");
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
            Console.WriteLine($"Your team has {teamRoster.Count} members:");
            int luck = new Random().Next(-10, 10);
            int bankDifficulty = 100 + luck;
            List<int> teamSkills = teamRoster.Select(member=>member.SkillLevel).ToList();
            int teamSkillTotal = teamSkills.Sum();
            bool heistSuccess;
            if (teamSkillTotal >= bankDifficulty)
            {
                heistSuccess = true;
            } else
            {
                heistSuccess = false;
            }
            Console.WriteLine("╒════════════════════════════╕");
            Console.WriteLine("│        Heist Report        │");
            Console.WriteLine("╞════════════════════════════╛");
            Console.WriteLine($"│  Bank Difficulty: {bankDifficulty}");
            Console.WriteLine($"│  Crew Skill: {teamSkillTotal}");
            Console.WriteLine("│  ");
            Console.WriteLine($"│  Heist Outcome: {(heistSuccess ? "Success!" : "Failure!")} ");
            Console.WriteLine("╘════════════════════════════╛");
            
        }
    }
}

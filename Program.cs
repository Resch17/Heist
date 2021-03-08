using System;
using System.Collections.Generic;

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
            foreach (TeamMember member in teamRoster)
            {
                member.DisplayInfo();
            }
        }
    }
}

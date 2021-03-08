using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╒══════════════════╕");
            Console.WriteLine("│ Plan Your Heist! │");
            Console.WriteLine("╘══════════════════╛");

            Console.WriteLine("Enter a team member's name: ");
            string newMemberName = Console.ReadLine();

            int newMemberSkill = TeamMember.SkillInput(newMemberName);

            decimal newMemberCourage = TeamMember.CourageInput(newMemberName);

            TeamMember member = new TeamMember(newMemberName, newMemberSkill, newMemberCourage);
            member.DisplayInfo();
        }
    }
}

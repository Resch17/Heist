using System;

namespace Heist
{
    class TeamMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public decimal CourageFactor { get; set; }
        public TeamMember(string name, int skill, decimal courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }
        public static int SkillInput(string newMemberName)
        {
            int output = 0;
            while (output == 0)
            {
                Console.WriteLine($"Enter {newMemberName}'s skill level: ");                
                Console.Write(" > ");
                string newMemberSkillInput = Console.ReadLine();
                try
                {
                    output = int.Parse(newMemberSkillInput);
                }
                catch
                {
                    Console.WriteLine("Positive integers only, please...");
                }
            }
            return output;
        }
        
        public static decimal CourageInput(string newMemberName)
        {
            decimal output = -1.0m;
            while (output < 0.0m || output > 2.0m)
            {
                Console.WriteLine($"Enter {newMemberName}'s courage factor (must be between 0.0 and 2.0): ");                
                Console.Write(" > ");
                string newMemberCourageInput = Console.ReadLine();
                try
                {
                    output = decimal.Parse(newMemberCourageInput);                    
                }
                catch
                {
                    Console.WriteLine("Please make sure the courage factor is between 0.0 and 2.0");
                }
            }
            return output;
        }

        public void DisplayInfo(){
            Console.WriteLine("╒═════════════════════");
            Console.WriteLine($"│ Name: {Name}");
            Console.WriteLine($"│ Skill level: {SkillLevel}");
            Console.WriteLine($"│ Courage factor: {CourageFactor}");
            Console.WriteLine("╘═════════════════════");
        }
    }
}
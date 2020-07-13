using System;
using FamilyTreeProject.BusinessLogicLayer;

namespace FamilyTreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t Hello Team! \n");
            Console.Write("Enter the name of the person : ");
            string name = Console.ReadLine();
            Console.WriteLine();
            // Instantiating the family
            BusinessLogic family = new BusinessLogic();
            ListNode grandParents = family.GetGrandParents(name);
            ListNode grandChildren = family.GetGrandChildren(name);
            // Displaying a list of Grandparents
            Console.WriteLine($"Grandparents of {name}:");
            Display(grandParents);
            // Displaying a list of Grandchildren
            Console.WriteLine($"Grandchildren of {name}:");
            Display(grandChildren);
        }

        /// <summary>
        /// Displays the ListNode
        /// </summary>
        /// <param name="members">Members in the ListNode <see cref="ListNode"/></param>
        private static void Display(ListNode members)
        {
            if (members.IsEmpty())
            {
                Console.WriteLine("List is empty.");
            }
            else
            {
                Node start = members.GetStart();
                while(start != default)
                {
                    Console.WriteLine(start.Name);
                    start = start.Next;
                }
            }
            Console.WriteLine();
        }
    }
}

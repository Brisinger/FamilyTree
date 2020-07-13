
namespace FamilyTreeProject.BusinessLogicLayer
{
    public class Node
    {
        #region properties
        public string Name { get; set; }
        public string Relationship { get; set; }
        public Node Next { get; set; }
        #endregion properties

        #region constructors
        public Node(string name = "", string status = "", Node next = default )
        {
            Name = name;
            Relationship = status;
            Next = next;
        }
        #endregion constructors
    }
}

using FamilyTreeProject.DataAccessLayer;

namespace FamilyTreeProject.BusinessLogicLayer
{
    public class BusinessLogic
    {
        #region private fields
        /// <summary>
        /// Sample data
        /// </summary>
        private string[] _input;

        /// <summary>
        /// List of families
        /// </summary>
        private ListNode[] _family;

        /// <summary>
        /// Status in a family
        /// </summary>
        private string[] _status;
        #endregion private fields

        #region constructors
        public BusinessLogic()
        {
            _status = new string[] { "H", "W", "F", "M", "Child", "Sib" };
            _input = DataAccess.GetSample();
            _family = new ListNode[_input.Length];
            for (int i = 0; i < _input.Length; i++)
            {
                _family[i] = CreateList(_input[i], _family[i]);
            }
        }
        #endregion constructors

        #region private methods
        /// <summary>
        /// Creates a family list
        /// </summary>
        /// <param name="input">Sample data representing a family</param>
        /// <param name="family">Family list node</param>
        /// <returns><c>CreateList</c> returns a single linked list that represents a family <see cref="ListNode"/></returns>
        private ListNode CreateList(string input, ListNode family)
        {
            family = new ListNode();
            string name = string.Empty, relationship = string.Empty, content = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case var ch when ch == '–' || ch == '-':
                        relationship = content;
                        content = string.Empty;
                        break;
                    case ',':
                        name = content;
                        family.Insert(name, relationship);
                        content = string.Empty;
                        break;
                    default:
                        content += input[i];
                        break;
                }
            }
            // Inserting the last member in the sample input for the family
            family.Insert(content, relationship);
            // Finding Relationship of the first node in the family based on input.
            Node start = family.GetStart();
            if (start.Relationship == string.Empty && start.Next.Relationship == _status[1])
            {
                start.Relationship = _status[0];
            }
            else if (start.Relationship == string.Empty && start.Next.Relationship == _status[0])
            {
                start.Relationship = _status[1];
            }
            return family;
        }
        #endregion private methods

        #region public methods
        /// <summary>
        /// Fetches Grand Parents of a person.
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <returns><c>GetGrandParents</c> returns a list of GrandParents for the given person</returns>
        public ListNode GetGrandParents(string name)
        {
            ListNode grandParents = new ListNode();
            for (int i = _family.Length - 1; i >= 0; i--)
            {   // Searching for the family in which the person is a child
                if (_family[i].Search(name, _status[4]))
                {
                    Node start = _family[i].GetStart();
                    // Searching for Grand Parents in the family
                    while (start != default)
                    {
                        if (start.Relationship == _status[2] || start.Relationship == _status[3])
                        {
                            if (start.Name != string.Empty)
                            {
                                grandParents.Insert(start.Name, start.Relationship);
                            }
                        }
                        start = start.Next;
                    }
                }
            }
            return grandParents;
        }
        /// <summary>
        /// Fetches Grand Children of a person.
        /// </summary>
        /// <param name="name">Name of the person</param>
        /// <returns><c>GetGrandChildren</c> returns a list of GrandChildren for the given person</returns>
        public ListNode GetGrandChildren(string name)
        {
            ListNode grandChildren = new ListNode();
            for (int i = 0; i < _family.Length; i++)
            {   // Searching for the family in which the person is a Father/Mother
                if (_family[i].Search(name, _status[2]) || _family[i].Search(name, _status[3]))
                {
                    Node start = _family[i].GetStart();
                    // Searching for Grand Children in the family
                    while (start != default)
                    {
                        if (start.Relationship == _status[4])
                        {
                            if (start.Name != string.Empty)
                            {
                                grandChildren.Insert(start.Name, start.Relationship);
                            }
                        }
                        start = start.Next;
                    }
                }
            }
            return grandChildren;
        }
        #endregion public methods
    }
}
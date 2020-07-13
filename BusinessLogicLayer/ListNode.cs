using System;

namespace FamilyTreeProject.BusinessLogicLayer
{
    public class ListNode
    {
        #region fields
        private Node start;
        #endregion fields

        #region constructors
        public ListNode()
        {
            start = default;
        }
        #endregion constructors

        #region public methods
        /// <summary>
        /// Checks list is empty
        /// </summary>
        /// <returns><c>IsEmpty</c> returns true if list empty, otherwise <c>IsEmpty</c> returns false if list has a node</returns>
        public bool IsEmpty()
        {
            return start == default;
        }
        /// <summary>
        /// Returns the start of the list
        /// </summary>
        /// <returns>start <c>Node</c> of list <see cref="Node"/></returns>
        public Node GetStart()
        {
            return start;
        }
        /// <summary>
        /// Returns the last node in the list
        /// </summary>
        /// <returns>last <c>Node</c> of list <see cref="Node"/></returns>
        public Node GetLast()
        {
            if(IsEmpty())
            {
                return default;
            }
            Node p = start;
            while(p.Next != default)
            {
                p = p.Next;
            }
            return p;
        }
        /// <summary>
        /// Inserts a new node at the end.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public void Insert(string name, string status)
        {
            // Check for empty list
            if (IsEmpty())
            {
                start = new Node(name.Trim(), status.Trim());
            }
            else if (!Search(name.Trim(), status.Trim()))
            {
                // Gets the last node of the list
                Node end = GetLast();
                end.Next = new Node(name.Trim(), status.Trim());
            }
        }
        /// <summary>
        /// Searches a node in the list.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="status">Relationship status of that person.</param>
        /// <returns><c>Search</c> returns true if a person with the relationship status exists in the list, otherwise returns false.</returns>
        public bool Search(string name, string status)
        {
            Node p = start;
            while(p != default)
            {
                if(string.Compare(p.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0 && 
                    string.Compare(p.Relationship, status, StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    break;
                }
                p = p.Next;
            }
            return p != default;
        }
        #endregion public methods
    }
}

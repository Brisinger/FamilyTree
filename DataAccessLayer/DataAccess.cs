using System.IO;

namespace FamilyTreeProject.DataAccessLayer
{
    /// <summary>
    /// Class to access the sample data
    /// </summary>
    public static class DataAccess
    {
        #region private fields
        private static readonly string FilePath;
        #endregion private fields

        #region constructors
        static DataAccess()
        {
            FilePath = "../../../../DataAccessLayer/Sample.txt";
        }
        #endregion constructors

        #region public methods
        /// <summary>
        /// Gets the sample data line by line.
        /// </summary>
        /// <returns>Array of strings representing each line in the sample data..</returns>
        public static string[] GetSample()
        {
            return File.ReadAllLines(FilePath);
        }
        #endregion public methods
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_OOP_Inheritance
{

    internal class Course
    {

        #region Fields

        // Classic property, using fields
        private string courseName;

        #endregion
        
        #region Properties

        // Auto-implemented property
        internal int CourseID { get; set; }

        internal string CourseName {
            get { return courseName; }
            set { courseName = value; }
        }

        #endregion

        #region Constructors

        internal Course()
        {
            CourseID = 0;
            CourseName = string.Empty;
        }

        internal Course(int courseID, string courseName)
        {
            CourseID = courseID;
            CourseName = courseName;
        }

        #endregion

        #region Methods

        internal void ListCourse()
        {
            Console.WriteLine($"Course ID: {CourseID}\nCourse name: {CourseName}");
        }

        #endregion

    }

}

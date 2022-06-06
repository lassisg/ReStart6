using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D01_OOP_Encapsulation
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

        #region Methods

        internal void ListCourse()
        {
            Console.WriteLine($"Course ID {CourseID}: {CourseName}");
        }

        #endregion

    }

}

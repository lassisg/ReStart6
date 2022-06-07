using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D04_OOP_Abstraction
{
    internal abstract class Course
    {
        
        #region Properties

        internal int CourseID { get; set; }
        internal string CourseName { get ; set; }

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

        // Método para ser substituido nas classes derivadas --> polimorfismo = override
        internal virtual void ListCourse()
        {
            Console.WriteLine($"ID: {CourseID}; Name: {CourseName}");
        }

        // Método que não tem implementação e que obriga a ser implementado na classe derivada
        internal abstract void Billing();

        #endregion

    }

}

using System;

namespace D03_OOP_Polymorphism
{

    // Inheritance
    internal class CourseSoftSkills : Course
    {

        #region Properties

        internal string Area { get; set; }

        #endregion

        #region Constructors

        // Mapear os construtores desta classe para os da classe base
        internal CourseSoftSkills() : base()
        {
            Area = string.Empty;
        }

        internal CourseSoftSkills(int courseID, string courseName, string area) : base(courseID, courseName)
        {
            Area = area;
        }

        #endregion

        #region Methods

        // Override
        internal override void ListCourse()
        {
            Console.WriteLine($"ID: {CourseID}; Name: {CourseName}; Area: {Area}");
        }

        #endregion

    }

}

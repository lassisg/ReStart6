using System;

namespace D03_OOP_Polymorphism
{

    internal class CourseIT : Course
    {

        #region Properties

        internal string Area { get; set; }
        internal bool? HasExam { get; set; }

        #endregion

        #region Constructors

        // Mapear os construtores desta classe para os da classe base
        internal CourseIT() : base()
        {
            Area = string.Empty;
            HasExam = null;
        }

        internal CourseIT(int courseID, string courseName, string area, bool hasExam) : base(courseID, courseName)
        {
            Area = area;
            HasExam = hasExam;
        }

        #endregion

        #region Methods

        // Overload 1
        internal void ListCourse(string area)
        {
            Console.WriteLine($"ID: {CourseID}; Name: {CourseName}; Area {area}");
        }

        // Overload 2
        internal void ListCourse(string area, bool? hasExam)
        {
            Console.WriteLine($"ID: {CourseID}; Name: {CourseName}; Area {area}; Exam: {hasExam}");
        }

        #endregion

    }

}

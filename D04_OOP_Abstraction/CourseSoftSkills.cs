using System;

namespace D04_OOP_Abstraction
{

    // Inheritance
    internal class CourseSoftSkills : Course
    {

        #region Properties

        // Overrided Classification
        internal override string Classification { get; set; }

        // Nova
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

        // Pode fazer (override) de CourseList()
        internal override void ListCourse()
        {
            Console.WriteLine($"ID: {0} \nName: {1} \nArea: {2} \nClassification: {3}", 
                CourseID, 
                CourseName, 
                Area, 
                Classification);
        }

        // Tem de implementar Billing()
        internal override void Billing()
        {
            Console.WriteLine("It's time to get paid!");
        }

        #endregion

    }

}

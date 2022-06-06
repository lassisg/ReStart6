namespace D02_OOP_Inheritance
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

    }

}

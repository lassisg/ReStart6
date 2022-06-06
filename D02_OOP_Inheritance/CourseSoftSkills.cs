using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_OOP_Inheritance
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
    }

}

using System;
using System.Collections.Generic;
using System.Linq;

namespace D02_EF6_CF
{

    internal class Blog
    {

        #region Scalar properties

        public int BlogId { get; set; }
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public virtual List<Post> Posts { get; set; }

        #endregion

    }

}

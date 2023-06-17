using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D02_EF6_CF
{

    internal class Post
    {

        #region Scalar properties

        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        #endregion

        #region Navigation properties

        public virtual Blog Blog { get; set; }

        #endregion

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace fistEntity.model
{
   public class Author
    {
        public int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ICollection<Post> Posts  { get; set; }
    }
}

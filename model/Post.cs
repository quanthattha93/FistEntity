using System;
using System.Collections.Generic;
using System.Text;

namespace fistEntity.model
{
    public class Post
    {
        public int Id
        {
            get;
            set;
        }
        public string Title
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }
        public Author Author { get; set; }
    }
}

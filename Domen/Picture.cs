using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Picture : BaseEntity
    {
        public string Name { get; set; }

        public Post Post { get; set; }

        public int PostId{get; set;}
    }
}

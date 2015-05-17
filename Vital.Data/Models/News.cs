using System;
using System.Collections.Generic;

namespace Vital.Data.Models
{
    public partial class News : Repository.EntityBase
    {

        public int ID { get; set; }
        public string NewsTitle { get; set; }
        public System.DateTime NewsDate { get; set; }
        public string NewsCaption { get; set; }
        public string NewsContent { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}

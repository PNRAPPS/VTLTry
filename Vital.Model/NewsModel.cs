using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class NewsModel
    {
        public int ID { get; set; }
        public string NewsTitle { get; set; }
        public System.DateTime NewsDate { get; set; }
        public string NewsCaption { get; set; }
        public string NewsContent { get; set; }

        public System.DateTime DateCreated { get; set; }
    }
}

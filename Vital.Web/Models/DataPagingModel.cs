using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vital.Web.Models
{
    public class DataPagingModel<T>
    {
        public int Page { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
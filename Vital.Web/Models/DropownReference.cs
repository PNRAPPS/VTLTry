using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vital.Web.Models
{
    public class DropownReference
    {
        public static IEnumerable<SelectListItem> GetLocationCountries()
        {
            yield return new SelectListItem() { Text = "Canada", Value = "CA" };
            yield return new SelectListItem() { Text = "USA", Value = "US" };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Vital.Service
{
    public interface ILookupService
    {
        string GetLookupText(string code, string value);
        string GetLookupValue(string code, string text);
        IEnumerable<SelectListItem> GetMinutes();
        IEnumerable<SelectListItem> GetHours();
        IEnumerable<SelectListItem> GetCollectionDates();
        IEnumerable<SelectListItem> GetPickupLocations();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Data.Models;
using Repository;
using System.Web.Mvc;

namespace Vital.Service
{
    public class LookupService : ILookupService
    {

        readonly IRepository<LookupTable> _lookupRespository;

        public LookupService(
            IRepository<LookupTable> lookupRepository)
        {
            this._lookupRespository = lookupRepository;
        }

        public string GetLookupText(string code, string value)
        {
            return _lookupRespository.Query().Get().First(r => r.LookupCode.Equals(code) && r.LookupValue.Equals(value)).LookupText;
        }

        public string GetLookupValue(string code, string text)
        {
            return _lookupRespository.Query().Get().First(r => r.LookupCode.Equals(code) && r.LookupText.Equals(text)).LookupValue;
        }

        public IEnumerable<SelectListItem> GetMinutes()
        {
            for (int i = 1; i <= 60; i++)
            {
                yield return new SelectListItem() { Value = i.ToString("D2"), Text = i.ToString("D2") };
            }
        }

        public IEnumerable<SelectListItem> GetHours()
        {
            for (int i = 1; i <= 12; i++)
            {
                yield return new SelectListItem() { Value = i.ToString("D2"), Text = i.ToString("D2") };
            }
        }

        public IEnumerable<SelectListItem> GetCollectionDates()
        {
            int ctr = 1;
            int collectedDate = 0;

            do
            {
                DateTime currentDate = DateTime.Now.AddDays(ctr);
                string valueDate = currentDate.Year.ToString() + currentDate.Month.ToString("00") + currentDate.Day.ToString("00");

                switch (currentDate.ToString("dddd"))
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        yield return new SelectListItem() { Value = valueDate, Text = @String.Format("{0:dddd, MMMM d, yyyy}", currentDate) };
                        collectedDate = collectedDate + 1;
                        break;
                    default:
                        break;
                }

                ctr = ctr + 1;

            } while (collectedDate < 3);
        }

        public IEnumerable<SelectListItem> GetPickupLocations()
        {
            yield return new SelectListItem() { Text = "Choose One", Value = "-99" };
            yield return new SelectListItem() { Text = "Front Door", Value = "01" };
            yield return new SelectListItem() { Text = "Back Door", Value = "02" };
            yield return new SelectListItem() { Text = "Shipping", Value = "03" };
            yield return new SelectListItem() { Text = "Receiving", Value = "04" };
            yield return new SelectListItem() { Text = "Reception", Value = "05" };
            yield return new SelectListItem() { Text = "Office", Value = "06" };
            yield return new SelectListItem() { Text = "Mail Room", Value = "07" };
            yield return new SelectListItem() { Text = "Garage", Value = "08" };
            yield return new SelectListItem() { Text = "Upstairs", Value = "09" };
            yield return new SelectListItem() { Text = "Downstairs", Value = "10" };
            yield return new SelectListItem() { Text = "Guard House", Value = "11" };
            yield return new SelectListItem() { Text = "Third Party", Value = "12" };
            yield return new SelectListItem() { Text = "Warehouse", Value = "13" };
        }
    }
}

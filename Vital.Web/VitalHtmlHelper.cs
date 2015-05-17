using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vital.Model;

namespace Vital.Web
{
    public static class VitalHtmlHelper
    {

        public static SelectList ToSelectList(this IEnumerable<ValueText> data)
        {
            return new SelectList(data, "Value", "Text");
        }
        public static IEnumerable<ValueText> GetUnitOfMeasure()
        {
            yield return new ValueText() { Value = "2", Text = "Metric (kilograms/centimeters)" };
            yield return new ValueText() { Value = "1", Text = "Imperial (pounds/inches)" };
        }

        public static IEnumerable<ValueText> GetReturnAddressOption()
        {
            yield return new ValueText() { Value = "1", Text = "Same as Ship From" };
            yield return new ValueText() { Value = "2", Text = "Enter a Different Return Address" };
        }

        public static IEnumerable<ValueText> GetPackageType()
        {
            yield return new ValueText() { Value = "-99", Text = "-- Select Package Type --" };

            yield return PackagingTypeEnum.ExpressBox.ToValueText();
            yield return PackagingTypeEnum.PAK.ToValueText();
            yield return PackagingTypeEnum.Tube.ToValueText();
            yield return PackagingTypeEnum.OtherPackaging.ToValueText();
            yield return PackagingTypeEnum.ExpressEnvelope.ToValueText();

        }
        public static IEnumerable<ValueText> GetServiceType()
        {
            yield return new ValueText() { Value = "-99", Text = "-- Select Service Type --" };

            yield return ServiceTypeEnum.ExpressEarlyAM.ToValueText();
            yield return ServiceTypeEnum.Express.ToValueText();
            yield return ServiceTypeEnum.ExpressSaver.ToValueText();
            yield return ServiceTypeEnum.Expedited.ToValueText();
            yield return ServiceTypeEnum.Standard.ToValueText();
            yield return ServiceTypeEnum.Freight.ToValueText();

        }

        public static IEnumerable<ValueText> GetStateProvince()
        {
            yield return new ValueText() { Value = "-99", Text = "-- Select State/Province --" };
            yield return new ValueText() { Value = "AB", Text = "Alberta" };
            yield return new ValueText() { Value = "BC", Text = "British Columbia" };
            yield return new ValueText() { Value = "MB", Text = "Manitoba" };
            yield return new ValueText() { Value = "NB", Text = "New Brunswick" };
            yield return new ValueText() { Value = "NL", Text = "Newfoundland and Labrador" };
            yield return new ValueText() { Value = "NT", Text = "Northwest Territory" };
            yield return new ValueText() { Value = "NS", Text = "Nova Scotia" };
            yield return new ValueText() { Value = "NU", Text = "Nunavut" };
            yield return new ValueText() { Value = "ON", Text = "Ontario" };
            yield return new ValueText() { Value = "PE", Text = "Prince Edward Island" };
            yield return new ValueText() { Value = "QC", Text = "Quebec" };
            yield return new ValueText() { Value = "SK", Text = "Saskatchewan" };
            yield return new ValueText() { Value = "YT", Text = "Yukon" };
        }

        public static IEnumerable<ValueText> GetCountryList()
        {
            yield return new ValueText() { Value = "-99", Text = "-- Select Country --" };
            yield return new ValueText() { Value = "CA", Text = "Canada" };
            //yield return new ValueText() { Value = "AF", Text = "Afghanistan" };
            //yield return new ValueText() { Value = "AL", Text = "Albania" };
            //yield return new ValueText() { Value = "DZ", Text = "Algeria" };
            //yield return new ValueText() { Value = "AS", Text = "American Samoa" };
            //yield return new ValueText() { Value = "AD", Text = "Andorra" };
            //yield return new ValueText() { Value = "AO", Text = "Angola" };
            //yield return new ValueText() { Value = "AI", Text = "Anguilla" };
            //yield return new ValueText() { Value = "AG", Text = "Antigua Barbuda" };
            //yield return new ValueText() { Value = "AR", Text = "Argentina" };
            //yield return new ValueText() { Value = "AM", Text = "Armenia" };
            //yield return new ValueText() { Value = "AW", Text = "Aruba" };
            //yield return new ValueText() { Value = "AU", Text = "Australia" };
            //yield return new ValueText() { Value = "AT", Text = "Austria" };
            //yield return new ValueText() { Value = "AZ", Text = "Azerbaijan" };
            //yield return new ValueText() { Value = "A2", Text = "Azores" };
            //yield return new ValueText() { Value = "BS", Text = "Bahamas" };
            //yield return new ValueText() { Value = "BH", Text = "Bahrain" };
            //yield return new ValueText() { Value = "BD", Text = "Bangladesh" };
            //yield return new ValueText() { Value = "BB", Text = "Barbados" };
            //yield return new ValueText() { Value = "BY", Text = "Belarus" };
            //yield return new ValueText() { Value = "BE", Text = "Belgium" };
            //yield return new ValueText() { Value = "BZ", Text = "Belize" };
            //yield return new ValueText() { Value = "BJ", Text = "Benin" };
            //yield return new ValueText() { Value = "BM", Text = "Bermuda" };
            //yield return new ValueText() { Value = "BT", Text = "Bhutan" };
            //yield return new ValueText() { Value = "BO", Text = "Bolivia" };
            //yield return new ValueText() { Value = "BQ", Text = "Bonaire, St. Eustatius, Saba" };
            //yield return new ValueText() { Value = "BA", Text = "Bosnia" };
            //yield return new ValueText() { Value = "BW", Text = "Botswana" };
            //yield return new ValueText() { Value = "BR", Text = "Brazil" };
            //yield return new ValueText() { Value = "VG", Text = "British Virgin Isles" };
            //yield return new ValueText() { Value = "BN", Text = "Brunei" };
            //yield return new ValueText() { Value = "BG", Text = "Bulgaria" };
            //yield return new ValueText() { Value = "BF", Text = "Burkina Faso" };
            //yield return new ValueText() { Value = "BI", Text = "Burundi" };
            //yield return new ValueText() { Value = "KH", Text = "Cambodia" };
            //yield return new ValueText() { Value = "CM", Text = "Cameroon" };
            //yield return new ValueText() { Value = "CA", Text = "Canada" };
            //yield return new ValueText() { Value = "IC", Text = "Canary Islands" };
            //yield return new ValueText() { Value = "CV", Text = "Cape Verde" };
            //yield return new ValueText() { Value = "KY", Text = "Cayman Islands" };
            //yield return new ValueText() { Value = "CF", Text = "Central African Republic" };
            //yield return new ValueText() { Value = "TD", Text = "Chad" };
            //yield return new ValueText() { Value = "CL", Text = "Chile" };
            //yield return new ValueText() { Value = "CN", Text = "China, People's Republic of" };
            //yield return new ValueText() { Value = "CO", Text = "Colombia" };
            //yield return new ValueText() { Value = "KM", Text = "Comoros" };
            //yield return new ValueText() { Value = "CG", Text = "Congo" };
            //yield return new ValueText() { Value = "CK", Text = "Cook Islands" };
            //yield return new ValueText() { Value = "CR", Text = "Costa Rica" };
            //yield return new ValueText() { Value = "HR", Text = "Croatia" };
            //yield return new ValueText() { Value = "CW", Text = "Curacao" };
            //yield return new ValueText() { Value = "CY", Text = "Cyprus" };
            //yield return new ValueText() { Value = "CZ", Text = "Czech Republic" };
            //yield return new ValueText() { Value = "CD", Text = "Democratic Republic of Congo" };
            //yield return new ValueText() { Value = "DK", Text = "Denmark" };
            //yield return new ValueText() { Value = "DJ", Text = "Djibouti" };
            //yield return new ValueText() { Value = "DM", Text = "Dominica" };
            //yield return new ValueText() { Value = "DO", Text = "Dominican Republic" };
            //yield return new ValueText() { Value = "EC", Text = "Ecuador" };
            //yield return new ValueText() { Value = "EG", Text = "Egypt" };
            //yield return new ValueText() { Value = "SV", Text = "El Salvador" };
            //yield return new ValueText() { Value = "EN", Text = "England" };
            //yield return new ValueText() { Value = "GQ", Text = "Equatorial Guinea" };
            //yield return new ValueText() { Value = "ER", Text = "Eritrea" };
            //yield return new ValueText() { Value = "EE", Text = "Estonia" };
            //yield return new ValueText() { Value = "ET", Text = "Ethiopia" };
            //yield return new ValueText() { Value = "FO", Text = "Faeroe Islands" };
            //yield return new ValueText() { Value = "FJ", Text = "Fiji" };
            //yield return new ValueText() { Value = "FI", Text = "Finland" };
            //yield return new ValueText() { Value = "FR", Text = "France" };
            //yield return new ValueText() { Value = "GF", Text = "French Guiana" };
            //yield return new ValueText() { Value = "PF", Text = "French Polynesia" };
            //yield return new ValueText() { Value = "GA", Text = "Gabon" };
            //yield return new ValueText() { Value = "GM", Text = "Gambia" };
            //yield return new ValueText() { Value = "GE", Text = "Georgia" };
            //yield return new ValueText() { Value = "DE", Text = "Germany" };
            //yield return new ValueText() { Value = "GH", Text = "Ghana" };
            //yield return new ValueText() { Value = "GI", Text = "Gibraltar" };
            //yield return new ValueText() { Value = "GR", Text = "Greece" };
            //yield return new ValueText() { Value = "GL", Text = "Greenland" };
            //yield return new ValueText() { Value = "GD", Text = "Grenada" };
            //yield return new ValueText() { Value = "GP", Text = "Guadeloupe" };
            //yield return new ValueText() { Value = "GU", Text = "Guam" };
            //yield return new ValueText() { Value = "GT", Text = "Guatemala" };
            //yield return new ValueText() { Value = "GG", Text = "Guernsey" };
            //yield return new ValueText() { Value = "GN", Text = "Guinea" };
            //yield return new ValueText() { Value = "GW", Text = "Guinea-Bissau" };
            //yield return new ValueText() { Value = "GY", Text = "Guyana" };
            //yield return new ValueText() { Value = "HT", Text = "Haiti" };
            //yield return new ValueText() { Value = "HO", Text = "Holland" };
            //yield return new ValueText() { Value = "HN", Text = "Honduras" };
            //yield return new ValueText() { Value = "HK", Text = "Hong Kong" };
            //yield return new ValueText() { Value = "HU", Text = "Hungary" };
            //yield return new ValueText() { Value = "IS", Text = "Iceland" };
            //yield return new ValueText() { Value = "IN", Text = "India" };
            //yield return new ValueText() { Value = "ID", Text = "Indonesia" };
            //yield return new ValueText() { Value = "IQ", Text = "Iraq" };
            //yield return new ValueText() { Value = "IL", Text = "Israel" };
            //yield return new ValueText() { Value = "IT", Text = "Italy" };
            //yield return new ValueText() { Value = "CI", Text = "Ivory Coast" };
            //yield return new ValueText() { Value = "JM", Text = "Jamaica" };
            //yield return new ValueText() { Value = "JP", Text = "Japan" };
            //yield return new ValueText() { Value = "JE", Text = "Jersey" };
            //yield return new ValueText() { Value = "JO", Text = "Jordan" };
            //yield return new ValueText() { Value = "KZ", Text = "Kazakhstan" };
            //yield return new ValueText() { Value = "KE", Text = "Kenya" };
            //yield return new ValueText() { Value = "KI", Text = "Kiribati" };
            //yield return new ValueText() { Value = "KO", Text = "Kosrae" };
            //yield return new ValueText() { Value = "KW", Text = "Kuwait" };
            //yield return new ValueText() { Value = "KG", Text = "Kyrgyzstan" };
            //yield return new ValueText() { Value = "LA", Text = "Laos" };
            //yield return new ValueText() { Value = "LV", Text = "Latvia" };
            //yield return new ValueText() { Value = "LB", Text = "Lebanon" };
            //yield return new ValueText() { Value = "LS", Text = "Lesotho" };
            //yield return new ValueText() { Value = "LR", Text = "Liberia" };
            //yield return new ValueText() { Value = "LY", Text = "Libya" };
            //yield return new ValueText() { Value = "LI", Text = "Liechtenstein" };
            //yield return new ValueText() { Value = "LT", Text = "Lithuania" };
            //yield return new ValueText() { Value = "LU", Text = "Luxembourg" };
            //yield return new ValueText() { Value = "MO", Text = "Macau" };
            //yield return new ValueText() { Value = "MK", Text = "Macedonia (FYROM)" };
            //yield return new ValueText() { Value = "MG", Text = "Madagascar" };
            //yield return new ValueText() { Value = "M3", Text = "Madeira" };
            //yield return new ValueText() { Value = "MW", Text = "Malawi" };
            //yield return new ValueText() { Value = "MY", Text = "Malaysia" };
            //yield return new ValueText() { Value = "MV", Text = "Maldives" };
            //yield return new ValueText() { Value = "ML", Text = "Mali" };
            //yield return new ValueText() { Value = "MT", Text = "Malta" };
            //yield return new ValueText() { Value = "MH", Text = "Marshall Islands" };
            //yield return new ValueText() { Value = "MQ", Text = "Martinique" };
            //yield return new ValueText() { Value = "MR", Text = "Mauritania" };
            //yield return new ValueText() { Value = "MU", Text = "Mauritius" };
            //yield return new ValueText() { Value = "YT", Text = "Mayotte" };
            //yield return new ValueText() { Value = "MX", Text = "Mexico" };
            //yield return new ValueText() { Value = "FM", Text = "Micronesia" };
            //yield return new ValueText() { Value = "MD", Text = "Moldova" };
            //yield return new ValueText() { Value = "MC", Text = "Monaco" };
            //yield return new ValueText() { Value = "MN", Text = "Mongolia" };
            //yield return new ValueText() { Value = "ME", Text = "Montenegro" };
            //yield return new ValueText() { Value = "MS", Text = "Montserrat" };
            //yield return new ValueText() { Value = "MA", Text = "Morocco" };
            //yield return new ValueText() { Value = "MZ", Text = "Mozambique" };
            //yield return new ValueText() { Value = "NA", Text = "Namibia" };
            //yield return new ValueText() { Value = "NP", Text = "Nepal" };
            //yield return new ValueText() { Value = "NL", Text = "Netherlands" };
            //yield return new ValueText() { Value = "NC", Text = "New Caledonia" };
            //yield return new ValueText() { Value = "NZ", Text = "New Zealand" };
            //yield return new ValueText() { Value = "NI", Text = "Nicaragua" };
            //yield return new ValueText() { Value = "NE", Text = "Niger" };
            //yield return new ValueText() { Value = "NG", Text = "Nigeria" };
            //yield return new ValueText() { Value = "NF", Text = "Norfolk Island" };
            //yield return new ValueText() { Value = "NB", Text = "Northern Ireland" };
            //yield return new ValueText() { Value = "MP", Text = "Northern Mariana Islands" };
            //yield return new ValueText() { Value = "NO", Text = "Norway" };
            //yield return new ValueText() { Value = "OM", Text = "Oman" };
            //yield return new ValueText() { Value = "PK", Text = "Pakistan" };
            //yield return new ValueText() { Value = "PW", Text = "Palau" };
            //yield return new ValueText() { Value = "PA", Text = "Panama" };
            //yield return new ValueText() { Value = "PG", Text = "Papua New Guinea" };
            //yield return new ValueText() { Value = "PY", Text = "Paraguay" };
            //yield return new ValueText() { Value = "PE", Text = "Peru" };
            //yield return new ValueText() { Value = "PH", Text = "Philippines" };
            //yield return new ValueText() { Value = "PL", Text = "Poland" };
            //yield return new ValueText() { Value = "PO", Text = "Ponape" };
            //yield return new ValueText() { Value = "PT", Text = "Portugal" };
            //yield return new ValueText() { Value = "PR", Text = "Puerto Rico" };
            //yield return new ValueText() { Value = "QA", Text = "Qatar" };
            //yield return new ValueText() { Value = "IE", Text = "Republic Of Ireland" };
            //yield return new ValueText() { Value = "RE", Text = "Reunion" };
            //yield return new ValueText() { Value = "RO", Text = "Romania" };
            //yield return new ValueText() { Value = "RT", Text = "Rota" };
            //yield return new ValueText() { Value = "RU", Text = "Russia" };
            //yield return new ValueText() { Value = "RW", Text = "Rwanda" };
            //yield return new ValueText() { Value = "S1", Text = "Saba" };
            //yield return new ValueText() { Value = "SP", Text = "Saipan" };
            //yield return new ValueText() { Value = "WS", Text = "Samoa" };
            //yield return new ValueText() { Value = "SM", Text = "San Marino" };
            //yield return new ValueText() { Value = "ST", Text = "Sao Tome/Principe" };
            //yield return new ValueText() { Value = "SA", Text = "Saudi Arabia" };
            //yield return new ValueText() { Value = "SF", Text = "Scotland" };
            //yield return new ValueText() { Value = "SN", Text = "Senegal" };
            //yield return new ValueText() { Value = "RS", Text = "Serbia" };
            //yield return new ValueText() { Value = "SC", Text = "Seychelles" };
            //yield return new ValueText() { Value = "SL", Text = "Sierra Leone" };
            //yield return new ValueText() { Value = "SG", Text = "Singapore" };
            //yield return new ValueText() { Value = "SK", Text = "Slovakia" };
            //yield return new ValueText() { Value = "SI", Text = "Slovenia" };
            //yield return new ValueText() { Value = "SB", Text = "Solomon Islands" };
            //yield return new ValueText() { Value = "ZA", Text = "South Africa" };
            //yield return new ValueText() { Value = "KR", Text = "South Korea" };
            //yield return new ValueText() { Value = "ES", Text = "Spain" };
            //yield return new ValueText() { Value = "LK", Text = "Sri Lanka" };
            //yield return new ValueText() { Value = "SX", Text = "St Maarten and St Martin" };
            //yield return new ValueText() { Value = "BL", Text = "St. Barthelemy" };
            //yield return new ValueText() { Value = "SW", Text = "St. Christopher" };
            //yield return new ValueText() { Value = "C3", Text = "St. Croix" };
            //yield return new ValueText() { Value = "E2", Text = "St. Eustatius" };
            //yield return new ValueText() { Value = "UV", Text = "St. John" };
            //yield return new ValueText() { Value = "KN", Text = "St. Kitts &#38; Nevis" };
            //yield return new ValueText() { Value = "LC", Text = "St. Lucia" };
            //yield return new ValueText() { Value = "VL", Text = "St. Thomas" };
            //yield return new ValueText() { Value = "VC", Text = "St. Vincent&#47;Grenadines" };
            //yield return new ValueText() { Value = "SR", Text = "Suriname" };
            //yield return new ValueText() { Value = "SZ", Text = "Swaziland" };
            //yield return new ValueText() { Value = "SE", Text = "Sweden" };
            //yield return new ValueText() { Value = "CH", Text = "Switzerland" };
            //yield return new ValueText() { Value = "TA", Text = "Tahiti" };
            //yield return new ValueText() { Value = "TW", Text = "Taiwan" };
            //yield return new ValueText() { Value = "TJ", Text = "Tajikistan" };
            //yield return new ValueText() { Value = "TZ", Text = "Tanzania" };
            //yield return new ValueText() { Value = "TH", Text = "Thailand" };
            //yield return new ValueText() { Value = "TL", Text = "Timor Leste" };
            //yield return new ValueText() { Value = "TI", Text = "Tinian" };
            //yield return new ValueText() { Value = "TG", Text = "Togo" };
            //yield return new ValueText() { Value = "TO", Text = "Tonga" };
            //yield return new ValueText() { Value = "ZZ", Text = "Tortola" };
            //yield return new ValueText() { Value = "TT", Text = "Trinidad &#38; Tobago" };
            //yield return new ValueText() { Value = "TU", Text = "Truk" };
            //yield return new ValueText() { Value = "TN", Text = "Tunisia" };
            //yield return new ValueText() { Value = "TR", Text = "Turkey" };
            //yield return new ValueText() { Value = "TM", Text = "Turkmenistan" };
            //yield return new ValueText() { Value = "TC", Text = "Turks &#38; Caicos Islands" };
            //yield return new ValueText() { Value = "TV", Text = "Tuvalu" };
            //yield return new ValueText() { Value = "UG", Text = "Uganda" };
            //yield return new ValueText() { Value = "UA", Text = "Ukraine" };
            //yield return new ValueText() { Value = "UI", Text = "Union Island" };
            //yield return new ValueText() { Value = "AE", Text = "United Arab Emirates" };
            //yield return new ValueText() { Value = "GB", Text = "United Kingdom" };
            //yield return new ValueText() { Value = "US", Text = "United States" };
            //yield return new ValueText() { Value = "UY", Text = "Uruguay" };
            //yield return new ValueText() { Value = "VI", Text = "US Virgin Islands" };
            //yield return new ValueText() { Value = "UZ", Text = "Uzbekistan" };
            //yield return new ValueText() { Value = "VU", Text = "Vanuatu" };
            //yield return new ValueText() { Value = "VA", Text = "Vatican City State" };
            //yield return new ValueText() { Value = "VE", Text = "Venezuela" };
            //yield return new ValueText() { Value = "VN", Text = "Vietnam" };
            //yield return new ValueText() { Value = "VR", Text = "Virgin Gorda" };
            //yield return new ValueText() { Value = "WL", Text = "Wales" };
            //yield return new ValueText() { Value = "WF", Text = "Wallis &#38; Futuna Islands" };
            //yield return new ValueText() { Value = "YA", Text = "Yap" };
            //yield return new ValueText() { Value = "YE", Text = "Yemen" };
            //yield return new ValueText() { Value = "ZM", Text = "Zambia" };
            //yield return new ValueText() { Value = "ZW", Text = "Zimbabwe" };
        }

        public static IEnumerable<ValueText> GetSaveOptionForAddressList()
        {
            yield return SaveOptionForAddress.SelectOne.ToValueText();
            yield return SaveOptionForAddress.SaveAsNewEntry.ToValueText();
            yield return SaveOptionForAddress.UpdateEntry.ToValueText();
            yield return SaveOptionForAddress.DontSaveEntry.ToValueText();
        }

        public static IEnumerable<ValueText> GetNumberOfPackage() {

            for (int i = 1; i <= 20 ; i++)
            {
                yield return new ValueText() { Text = i.ToString(), Value = i.ToString() };
            }

        }

    }
}
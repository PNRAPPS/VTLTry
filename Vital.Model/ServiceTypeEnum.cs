using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class ServiceTypeAttribute : Attribute
    {
        public ServiceTypeAttribute(string value, string description)
        {
            this.Value = value;
            this.Description = description;
        }
        public string Value { get; set; }
        public string Description { get; set; }
    }
    public enum ServiceTypeEnum
    {

        [ServiceType("014", "UPS Express Early A.M.")]
        ExpressEarlyAM,

        [ServiceType("001", "UPS Express")]
        Express,

        [ServiceType("013", "UPS Express Saver")]
        ExpressSaver,

        [ServiceType("002", "UPS Expedited")]
        Expedited,

        [ServiceType("011", "UPS Standard")]
        Standard,

        [ServiceType("998", "Freight (typically over 150 lbs)")]
        Freight,
    }

    public static class ServiceTypeEnumExtension
    {

        public static ServiceTypeEnum GetEnumByValue(string value)
        {
            var type = typeof(ServiceTypeEnum);
            var result = type.GetMembers().Where(x => x.GetCustomAttributes(typeof(ServiceTypeAttribute), true).Any())
                .Where(x =>
                {
                    return (x.GetCustomAttributes(typeof(ServiceTypeAttribute), true).First() as ServiceTypeAttribute).Value == value;
                }).FirstOrDefault();
            return (ServiceTypeEnum)Enum.GetValues(typeof(ServiceTypeEnum)).Cast<object>().FirstOrDefault(x => x.ToString() == result.Name);
        }

        public static string GetDescription(this ServiceTypeEnum option)
        {
            var type = typeof(ServiceTypeEnum);
            var memInfo = type.GetMember(option.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(ServiceTypeAttribute),
                false);
            var description = ((ServiceTypeAttribute)attributes[0]).Description;
            return description;
        }

        public static string GetValue(this ServiceTypeEnum option)
        {
            var type = typeof(ServiceTypeEnum);
            var memInfo = type.GetMember(option.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(ServiceTypeAttribute),
                false);
            var value = ((ServiceTypeAttribute)attributes[0]).Value;
            return value;
        }

        public static ValueText ToValueText(this ServiceTypeEnum option)
        {
            return new ValueText() { Value = option.GetValue(), Text = option.GetDescription() };
        }
    }
}

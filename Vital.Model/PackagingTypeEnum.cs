using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public class PackagingTypeAttribute : Attribute
    {
        public PackagingTypeAttribute(string value, string description)
        {
            this.Value = value;
            this.Description = description;
        }
        public string Value { get; set; }
        public string Description { get; set; }
    }
    public enum PackagingTypeEnum
    {
        [PackagingType("21", "UPS Express Box")]
        ExpressBox,

        [PackagingType("04", "UPS PAK")]
        PAK,

        [PackagingType("03", "UPS Tube")]
        Tube,

        [PackagingType("02", "Other Packaging")]
        OtherPackaging,

        [PackagingType("01", "UPS Express Envelope")]
        ExpressEnvelope,

    }

    public static class PackagingTypeEnumExtension
    {

        public static PackagingTypeEnum GetEnumByValue(string value)
        {
            var type = typeof(PackagingTypeEnum);
            var result = type.GetMembers().Where(x => x.GetCustomAttributes(typeof(PackagingTypeAttribute), true).Any())
                .Where(x =>
                {
                    return (x.GetCustomAttributes(typeof(PackagingTypeAttribute), true).First() as PackagingTypeAttribute).Value == value;
                }).FirstOrDefault();
            return (PackagingTypeEnum)Enum.GetValues(typeof(PackagingTypeEnum)).Cast<object>().FirstOrDefault(x => x.ToString() == result.Name);
        }

        public static string GetDescription(this PackagingTypeEnum option)
        {
            var type = typeof(PackagingTypeEnum);
            var memInfo = type.GetMember(option.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(PackagingTypeAttribute),
                false);
            var description = ((PackagingTypeAttribute)attributes[0]).Description;
            return description;
        }

        public static string GetValue(this PackagingTypeEnum option)
        {
            var type = typeof(PackagingTypeEnum);
            var memInfo = type.GetMember(option.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(PackagingTypeAttribute),
                false);
            var value = ((PackagingTypeAttribute)attributes[0]).Value;
            return value;
        }

        public static ValueText ToValueText(this PackagingTypeEnum option)
        {
            return new ValueText() { Value = option.GetValue(), Text = option.GetDescription() };
        }
    }
}

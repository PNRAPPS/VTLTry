using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vital.Model
{
    public enum SaveOptionForAddress
    {
        [Description("-- Select One --")]
        SelectOne = -99,

        [Description("Save As New Entry")]
        SaveAsNewEntry = 1,

        [Description("Update Entry")]
        UpdateEntry = 2,

        [Description("Don't Save Entry")]
        DontSaveEntry = 3,
    }

    public static class SaveOptionForAddressExtension
    {
        public static string GetDescription(this SaveOptionForAddress option)
        {
            var type = typeof(SaveOptionForAddress);
            var memInfo = type.GetMember(option.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute),
                false);
            var description = ((DescriptionAttribute)attributes[0]).Description;
            return description;
        }

        public static ValueText ToValueText(this SaveOptionForAddress option)
        {
            return new ValueText() { Value = ((int)option).ToString(), Text = option.GetDescription() };
        }
    }

}

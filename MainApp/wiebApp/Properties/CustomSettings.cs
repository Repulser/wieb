using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiebApp.Models;

namespace wiebApp.Properties
{
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public ColorPath SelectedAccentColor
        {
            get => ((ColorPath)(this["SelectedAccentColor"]));
            set => this["SelectedAccentColor"] = value;
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public ColorPath SelectedThemeColor
        {
            get => ((ColorPath)(this["SelectedThemeColor"]));
            set => this["SelectedThemeColor"] = value;
        }
    }
}

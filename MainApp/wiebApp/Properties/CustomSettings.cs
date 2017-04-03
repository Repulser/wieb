using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wiebApp.SharedResources;

namespace wiebApp.Properties
{
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public ColorPath AccentColor
        {
            get
            {
                return ((ColorPath)(this["AccentColor"]));
            }
            set
            {
                this["AccentColor"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public ColorPath ThemeColor
        {
            get
            {
                return ((ColorPath)(this["ThemeColor"]));
            }
            set
            {
                this["ThemeColor"] = value;
            }
        }
    }
}

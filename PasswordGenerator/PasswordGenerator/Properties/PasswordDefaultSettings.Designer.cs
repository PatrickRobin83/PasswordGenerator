﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PasswordGenerator.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.10.0.0")]
    internal sealed partial class PasswordDefaultSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PasswordDefaultSettings defaultInstance = ((PasswordDefaultSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PasswordDefaultSettings())));
        
        public static PasswordDefaultSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsDigitUseChecked {
            get {
                return ((bool)(this["IsDigitUseChecked"]));
            }
            set {
                this["IsDigitUseChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsCapitalUseChecked {
            get {
                return ((bool)(this["IsCapitalUseChecked"]));
            }
            set {
                this["IsCapitalUseChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsNonCapitalUseChecked {
            get {
                return ((bool)(this["IsNonCapitalUseChecked"]));
            }
            set {
                this["IsNonCapitalUseChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsSpecialCharacterUseChecked {
            get {
                return ((bool)(this["IsSpecialCharacterUseChecked"]));
            }
            set {
                this["IsSpecialCharacterUseChecked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PasswordLength {
            get {
                return ((int)(this["PasswordLength"]));
            }
            set {
                this["PasswordLength"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PasswordAmount {
            get {
                return ((int)(this["PasswordAmount"]));
            }
            set {
                this["PasswordAmount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsSettingsSave {
            get {
                return ((bool)(this["IsSettingsSave"]));
            }
            set {
                this["IsSettingsSave"] = value;
            }
        }
    }
}

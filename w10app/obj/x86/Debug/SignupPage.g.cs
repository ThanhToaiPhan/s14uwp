﻿#pragma checksum "D:\Works\Phims14\w10app\w10app\SignupPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FD9A0E6B3AE1CB1F36784DDC6A87FB61"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace w10app
{
    partial class SignupPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.PageContent = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Documents.Hyperlink element2 = (global::Windows.UI.Xaml.Documents.Hyperlink)(target);
                    #line 131 "..\..\..\SignupPage.xaml"
                    ((global::Windows.UI.Xaml.Documents.Hyperlink)element2).Click += this.TermOfServiceClick;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Documents.Hyperlink element3 = (global::Windows.UI.Xaml.Documents.Hyperlink)(target);
                    #line 134 "..\..\..\SignupPage.xaml"
                    ((global::Windows.UI.Xaml.Documents.Hyperlink)element3).Click += this.PrivacyPolicyClick;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}


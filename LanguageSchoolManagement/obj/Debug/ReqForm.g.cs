﻿#pragma checksum "..\..\ReqForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DEE56797CEB36215B9201DCC776C973343399B0A0D838EB2A8E8D8E8DC1AE5DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LanguageSchoolManagement;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LanguageSchoolManagement {
    
    
    /// <summary>
    /// ReqForm
    /// </summary>
    public partial class ReqForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\ReqForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoiceLanguage;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ReqForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoiceLevel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ReqForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ChoiceIntensity;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ReqForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextSurname;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ReqForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextName;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LanguageSchoolManagement;component/reqform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReqForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\ReqForm.xaml"
            ((LanguageSchoolManagement.ReqForm)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ChoiceLanguage = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ChoiceLevel = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ChoiceIntensity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.TextSurname = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\ReqForm.xaml"
            this.TextSurname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Surname);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TextName = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\ReqForm.xaml"
            this.TextName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_Name);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 55 "..\..\ReqForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClickInfo);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


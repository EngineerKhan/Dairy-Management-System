﻿#pragma checksum "..\..\..\EmployeeEntryView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "239D426BD22F38820D7A97F6AFFBD0AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DMS.Presentation;
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


namespace DMS.Presentation {
    
    
    /// <summary>
    /// EmployeeEntryView
    /// </summary>
    public partial class EmployeeEntryView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid EntryGrid;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxName;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxFatherName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCurrentAddress;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPermanentAddress;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roleComboBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCNIC;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerDOB;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerJoiningDate;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSalary;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\EmployeeEntryView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDescription;
        
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
            System.Uri resourceLocater = new System.Uri("/DMS.Presentation;component/employeeentryview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EmployeeEntryView.xaml"
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
            
            #line 8 "..\..\..\EmployeeEntryView.xaml"
            ((DMS.Presentation.EmployeeEntryView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Control_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EntryGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.textBoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxFatherName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBoxCurrentAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textBoxPermanentAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.roleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\EmployeeEntryView.xaml"
            this.roleComboBox.Loaded += new System.Windows.RoutedEventHandler(this.ComboBox_Loaded);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\EmployeeEntryView.xaml"
            this.roleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.roleComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBoxCNIC = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\EmployeeEntryView.xaml"
            this.textBoxCNIC.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxCNIC_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.datePickerDOB = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.datePickerJoiningDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.textBoxSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.textBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

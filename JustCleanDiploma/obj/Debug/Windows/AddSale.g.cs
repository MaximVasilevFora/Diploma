﻿#pragma checksum "..\..\..\Windows\AddSale.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A67BD79050618058ED1D50A5C19EAC7A75B84B2983516F4432409D93EE867B07"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JustCleanDiploma.Windows;
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


namespace JustCleanDiploma.Windows {
    
    
    /// <summary>
    /// AddSale
    /// </summary>
    public partial class AddSale : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 106 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox ContentBox;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AttributeGrid;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Office;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserCombo;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Good;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantity;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker SaleDate;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\Windows\AddSale.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
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
            System.Uri resourceLocater = new System.Uri("/JustCleanDiploma;component/windows/addsale.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddSale.xaml"
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
            
            #line 12 "..\..\..\Windows\AddSale.xaml"
            ((JustCleanDiploma.Windows.AddSale)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\Windows\AddSale.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\Windows\AddSale.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ContentBox = ((System.Windows.Controls.Viewbox)(target));
            return;
            case 5:
            this.AttributeGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.Office = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.UserCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Good = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.Quantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 149 "..\..\..\Windows\AddSale.xaml"
            this.Quantity.GotFocus += new System.Windows.RoutedEventHandler(this.Quantity_GotFocus);
            
            #line default
            #line hidden
            
            #line 149 "..\..\..\Windows\AddSale.xaml"
            this.Quantity.LostFocus += new System.Windows.RoutedEventHandler(this.Quantity_LostFocus);
            
            #line default
            #line hidden
            
            #line 149 "..\..\..\Windows\AddSale.xaml"
            this.Quantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Quantity_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            
            #line 150 "..\..\..\Windows\AddSale.xaml"
            this.Price.GotFocus += new System.Windows.RoutedEventHandler(this.Price_GotFocus);
            
            #line default
            #line hidden
            
            #line 150 "..\..\..\Windows\AddSale.xaml"
            this.Price.LostFocus += new System.Windows.RoutedEventHandler(this.Price_LostFocus);
            
            #line default
            #line hidden
            
            #line 150 "..\..\..\Windows\AddSale.xaml"
            this.Price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Price_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SaleDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 12:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            
            #line 154 "..\..\..\Windows\AddSale.xaml"
            this.Description.GotFocus += new System.Windows.RoutedEventHandler(this.Description_GotFocus);
            
            #line default
            #line hidden
            
            #line 154 "..\..\..\Windows\AddSale.xaml"
            this.Description.LostFocus += new System.Windows.RoutedEventHandler(this.Description_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


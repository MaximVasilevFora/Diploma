﻿#pragma checksum "..\..\..\Windows\SaleGoodDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D8134ABE3E766FFFAADD932EB6DD77E8FBE6745A9829DF1D7C44B32EF9EC09BF"
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
    /// SaleGoodDialog
    /// </summary>
    public partial class SaleGoodDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 72 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Quantity;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Price;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker SaleDate;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox UserMail;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Office;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Windows\SaleGoodDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Enter;
        
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
            System.Uri resourceLocater = new System.Uri("/JustCleanDiploma;component/windows/salegooddialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SaleGoodDialog.xaml"
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
            
            #line 8 "..\..\..\Windows\SaleGoodDialog.xaml"
            ((JustCleanDiploma.Windows.SaleGoodDialog)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Quantity = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Quantity.GotFocus += new System.Windows.RoutedEventHandler(this.Quantity_GotFocus);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Quantity.LostFocus += new System.Windows.RoutedEventHandler(this.Quantity_LostFocus);
            
            #line default
            #line hidden
            
            #line 72 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Quantity.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Quantity_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Price = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Price.GotFocus += new System.Windows.RoutedEventHandler(this.Price_GotFocus);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Price.LostFocus += new System.Windows.RoutedEventHandler(this.Price_LostFocus);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Price_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PriceTextBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.SaleDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.UserMail = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Office = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Enter = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\Windows\SaleGoodDialog.xaml"
            this.Enter.Click += new System.Windows.RoutedEventHandler(this.Enter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


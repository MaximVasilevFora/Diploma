﻿#pragma checksum "..\..\..\..\Pages\AdminPages\Money.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "62B585EFB61F93BF97B14DFB6CB25401AD999790021FB89FDC04E81DF3FA57A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JustCleanDiploma.Pages.AdminPages;
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


namespace JustCleanDiploma.Pages.AdminPages {
    
    
    /// <summary>
    /// Money
    /// </summary>
    public partial class Money : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker BeginDate;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker EndDate;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GoodRevenue;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OrderRevenue;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GoodProfit;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ImagineCost;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Pages\AdminPages\Money.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Export;
        
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
            System.Uri resourceLocater = new System.Uri("/JustCleanDiploma;component/pages/adminpages/money.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdminPages\Money.xaml"
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
            this.BeginDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.EndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.GoodRevenue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.OrderRevenue = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.GoodProfit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ImagineCost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\..\Pages\AdminPages\Money.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Export = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\..\Pages\AdminPages\Money.xaml"
            this.Export.Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


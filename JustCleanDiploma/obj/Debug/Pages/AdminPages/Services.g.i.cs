﻿#pragma checksum "..\..\..\..\Pages\AdminPages\Services.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8274F963F7A73499B2CF4615A9127C047F2A98DF5229F6D6891818F2D409F74F"
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
    /// Services
    /// </summary>
    public partial class Services : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 100 "..\..\..\..\Pages\AdminPages\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ServiceName;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\Pages\AdminPages\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddService;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\Pages\AdminPages\Services.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ServiceList;
        
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
            System.Uri resourceLocater = new System.Uri("/JustCleanDiploma;component/pages/adminpages/services.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdminPages\Services.xaml"
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
            this.ServiceName = ((System.Windows.Controls.TextBox)(target));
            
            #line 100 "..\..\..\..\Pages\AdminPages\Services.xaml"
            this.ServiceName.GotFocus += new System.Windows.RoutedEventHandler(this.ServiceName_GotFocus);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\..\Pages\AdminPages\Services.xaml"
            this.ServiceName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ServiceName_TextChanged);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\..\Pages\AdminPages\Services.xaml"
            this.ServiceName.LostFocus += new System.Windows.RoutedEventHandler(this.ServiceName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddService = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\..\Pages\AdminPages\Services.xaml"
            this.AddService.Click += new System.Windows.RoutedEventHandler(this.AddService_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ServiceList = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 117 "..\..\..\..\Pages\AdminPages\Services.xaml"
            ((System.Windows.Controls.Grid)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ServiceCard_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

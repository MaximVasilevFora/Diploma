﻿#pragma checksum "..\..\..\Windows\AdminWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4ACC09D511C9ED03DD9438BB5DC10BDE7838F65D00394104CFBA2C9C52171DA4"
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
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition sidePanel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem UsersView;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem OfficesView;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem ClientsView;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem OrderView;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem SalesView;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem GoodsView;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem ServicesView;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem ProvidersView;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid panelHeader;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame ContentFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/JustCleanDiploma;component/windows/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AdminWindow.xaml"
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
            this.sidePanel = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 2:
            
            #line 23 "..\..\..\Windows\AdminWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UsersView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 29 "..\..\..\Windows\AdminWindow.xaml"
            this.UsersView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ListViewItem_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OfficesView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 36 "..\..\..\Windows\AdminWindow.xaml"
            this.OfficesView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OfficesView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ClientsView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 43 "..\..\..\Windows\AdminWindow.xaml"
            this.ClientsView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ClientsView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.OrderView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 50 "..\..\..\Windows\AdminWindow.xaml"
            this.OrderView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.OrderView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.SalesView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 57 "..\..\..\Windows\AdminWindow.xaml"
            this.SalesView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SalesView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GoodsView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 64 "..\..\..\Windows\AdminWindow.xaml"
            this.GoodsView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.GoodsView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ServicesView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 71 "..\..\..\Windows\AdminWindow.xaml"
            this.ServicesView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ServicesView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ProvidersView = ((System.Windows.Controls.ListViewItem)(target));
            
            #line 78 "..\..\..\Windows\AdminWindow.xaml"
            this.ProvidersView.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ProvidersView_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.panelHeader = ((System.Windows.Controls.Grid)(target));
            
            #line 88 "..\..\..\Windows\AdminWindow.xaml"
            this.panelHeader.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.PanelHeader_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ContentFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


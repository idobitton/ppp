﻿#pragma checksum "..\..\Pizza.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "48633B98A60D79AF92A9F10FC9FC522C8C1F180AD1D73F058EAEF09E8EE4FC43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp50;


namespace WpfApp50 {
    
    
    /// <summary>
    /// Pizza
    /// </summary>
    public partial class Pizza : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\Pizza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox extra_cmbbx;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Pizza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox location_cmbbx;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Pizza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button finish;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\Pizza.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add_extra;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp50;component/pizza.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Pizza.xaml"
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
            
            #line 8 "..\..\Pizza.xaml"
            ((WpfApp50.Pizza)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.extra_cmbbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.location_cmbbx = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.finish = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Pizza.xaml"
            this.finish.Click += new System.Windows.RoutedEventHandler(this.finish_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.add_extra = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\Pizza.xaml"
            this.add_extra.Click += new System.Windows.RoutedEventHandler(this.add_extra_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


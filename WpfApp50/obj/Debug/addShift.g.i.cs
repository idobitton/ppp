﻿#pragma checksum "..\..\addShift.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "756209D4CC06C52BF558477464F66F76A636A2A93DDDD3441A62A479A6909B5B"
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
    /// addShift
    /// </summary>
    public partial class addShift : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sbmt_btn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label time_lbl;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label date_lbl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar calendar;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton mornng_rdb;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton evnng_rdb;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid emp_dtgrid;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\addShift.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox msg_lsb;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp50;component/addshift.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\addShift.xaml"
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
            
            #line 8 "..\..\addShift.xaml"
            ((WpfApp50.addShift)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.sbmt_btn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\addShift.xaml"
            this.sbmt_btn.Click += new System.Windows.RoutedEventHandler(this.sbmt_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.time_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.date_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.calendar = ((System.Windows.Controls.Calendar)(target));
            return;
            case 6:
            this.mornng_rdb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.evnng_rdb = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.emp_dtgrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 41 "..\..\addShift.xaml"
            this.emp_dtgrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.emp_dtgrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.msg_lsb = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

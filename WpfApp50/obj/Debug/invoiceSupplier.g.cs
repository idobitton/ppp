﻿#pragma checksum "..\..\invoiceSupplier.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DFC17187FB08E4BE17E27458A0510DA6BD76FBC5621A7386F355A1CCB9061D0B"
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
    /// invoiceSupplier
    /// </summary>
    public partial class invoiceSupplier : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label supplier_name_lbl;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label notes_lbl;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label payment_name_lbl;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dscnt_lbl;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label gdbye_lbl;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid fprice_dtgrid1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid fprice_dtgrid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid product_dtgrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\invoiceSupplier.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button payment_btn;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp50;component/invoicesupplier.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\invoiceSupplier.xaml"
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
            
            #line 8 "..\..\invoiceSupplier.xaml"
            ((WpfApp50.invoiceSupplier)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.supplier_name_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.notes_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.payment_name_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.dscnt_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.gdbye_lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.fprice_dtgrid1 = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.fprice_dtgrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.product_dtgrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.payment_btn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\invoiceSupplier.xaml"
            this.payment_btn.Click += new System.Windows.RoutedEventHandler(this.payment_btn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


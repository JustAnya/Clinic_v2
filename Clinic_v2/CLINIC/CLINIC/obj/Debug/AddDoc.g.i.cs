﻿#pragma checksum "..\..\AddDoc.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "11036FC36EBABC03AEFB43AC4C4125F6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CLINIC;
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


namespace CLINIC {
    
    
    /// <summary>
    /// AddDoc
    /// </summary>
    public partial class AddDoc : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox list_spec;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ab_d;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox list_day;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton sm1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton sm2;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtomR;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list_all_time;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AddDoc.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button update;
        
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
            System.Uri resourceLocater = new System.Uri("/CLINIC;component/adddoc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddDoc.xaml"
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
            this.list_spec = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\AddDoc.xaml"
            this.list_spec.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.list_Specialty);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ab_d = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\AddDoc.xaml"
            this.ab_d.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.login_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.list_day = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.sm1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.sm2 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.add = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\AddDoc.xaml"
            this.add.Click += new System.Windows.RoutedEventHandler(this.ButtomReg_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtomR = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\AddDoc.xaml"
            this.ButtomR.Click += new System.Windows.RoutedEventHandler(this.ButtomR_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.list_all_time = ((System.Windows.Controls.ListBox)(target));
            
            #line 46 "..\..\AddDoc.xaml"
            this.list_all_time.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.list_Work);
            
            #line default
            #line hidden
            return;
            case 9:
            this.save = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\AddDoc.xaml"
            this.save.Click += new System.Windows.RoutedEventHandler(this.Butt);
            
            #line default
            #line hidden
            return;
            case 10:
            this.update = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\AddDoc.xaml"
            this.update.Click += new System.Windows.RoutedEventHandler(this.Butt2);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 52 "..\..\AddDoc.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Autors\Autorzy_Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2DCB93956D3E15DA6F4FF6886593190ACF990E229DF407110C5A88E190DC8769"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Biblioteka_system;
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


namespace Biblioteka_system {
    
    
    /// <summary>
    /// Autorzy_Page
    /// </summary>
    public partial class Autorzy_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView_authors;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Add_Author;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Edit_Author;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Delete_Author;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Autors\Autorzy_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_number;
        
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
            System.Uri resourceLocater = new System.Uri("/Biblioteka_system;component/autors/autorzy_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Autors\Autorzy_Page.xaml"
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
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\Autors\Autorzy_Page.xaml"
            this.txt_search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Txt_szukaj_autorow_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listView_authors = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.btn_Add_Author = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Autors\Autorzy_Page.xaml"
            this.btn_Add_Author.Click += new System.Windows.RoutedEventHandler(this.Btn_dodaj_autora_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_Edit_Author = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Autors\Autorzy_Page.xaml"
            this.btn_Edit_Author.Click += new System.Windows.RoutedEventHandler(this.Btn_edytuj_autora_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_Delete_Author = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Autors\Autorzy_Page.xaml"
            this.btn_Delete_Author.Click += new System.Windows.RoutedEventHandler(this.Btn_edytuj_autora_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbl_number = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


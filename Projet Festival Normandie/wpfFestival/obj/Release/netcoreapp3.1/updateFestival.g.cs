﻿#pragma checksum "..\..\..\updateFestival.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0FE5A90F810C4F78F35AC8074D7A58BE7E1F2874"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using wpfFestival;


namespace wpfFestival {
    
    
    /// <summary>
    /// updateFestival
    /// </summary>
    public partial class updateFestival : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LbFestivals;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nomFestivalBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lieuFestivalBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionFestivalBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image oldpictureBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image newpictureBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\updateFestival.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pathlogoBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wpfFestival;component/updatefestival.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\updateFestival.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LbFestivals = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\updateFestival.xaml"
            this.LbFestivals.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LbFestivals_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nomFestivalBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lieuFestivalBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.descriptionFestivalBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 33 "..\..\..\updateFestival.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.oldpictureBox = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.newpictureBox = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            
            #line 38 "..\..\..\updateFestival.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnLoadImage);
            
            #line default
            #line hidden
            return;
            case 9:
            this.pathlogoBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


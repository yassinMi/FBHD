﻿#pragma checksum "..\..\ButtonMi.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FB934AB05C93AE583CC6B2A5BC390BBC4E885CAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Media.Effects;
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
using fbhd;


namespace fbhd {
    
    
    /// <summary>
    /// ButtonMi
    /// </summary>
    public partial class ButtonMi : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal fbhd.ButtonMi userControl;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Expression.Media.Effects.BloomEffect bloo;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualStateGroup VisualStateGroup;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState Hover;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState Normal;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState Pressed;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState disabled;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button coreButton;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\ButtonMi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock caption;
        
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
            System.Uri resourceLocater = new System.Uri("/fbhd;component/buttonmi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ButtonMi.xaml"
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
            this.userControl = ((fbhd.ButtonMi)(target));
            
            #line 9 "..\..\ButtonMi.xaml"
            this.userControl.MouseEnter += new System.Windows.Input.MouseEventHandler(this.userControl_MouseEnter);
            
            #line default
            #line hidden
            
            #line 9 "..\..\ButtonMi.xaml"
            this.userControl.MouseLeave += new System.Windows.Input.MouseEventHandler(this.userControl_MouseLeave);
            
            #line default
            #line hidden
            
            #line 9 "..\..\ButtonMi.xaml"
            this.userControl.Loaded += new System.Windows.RoutedEventHandler(this.userControl_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\ButtonMi.xaml"
            this.userControl.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.userControl_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bloo = ((Microsoft.Expression.Media.Effects.BloomEffect)(target));
            return;
            case 3:
            this.VisualStateGroup = ((System.Windows.VisualStateGroup)(target));
            return;
            case 4:
            this.Hover = ((System.Windows.VisualState)(target));
            return;
            case 5:
            this.Normal = ((System.Windows.VisualState)(target));
            return;
            case 6:
            this.Pressed = ((System.Windows.VisualState)(target));
            return;
            case 7:
            this.disabled = ((System.Windows.VisualState)(target));
            return;
            case 8:
            this.coreButton = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\ButtonMi.xaml"
            this.coreButton.Click += new System.Windows.RoutedEventHandler(this.coreButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.caption = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


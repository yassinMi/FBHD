#pragma checksum "..\..\CLWItemPresenter.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75CE1AD31C72C82E67DA63C346DE794BA9C2378E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Interactivity.Core;
using Microsoft.Expression.Interactivity.Input;
using Microsoft.Expression.Interactivity.Layout;
using Microsoft.Expression.Interactivity.Media;
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
using System.Windows.Interactivity;
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
    /// CLWItemPresenter
    /// </summary>
    public partial class CLWItemPresenter : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock subTitle;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock linklbl;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button moreActionsButton;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image2;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup moreActionsPopup;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DloadButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CopyUrlButt;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\CLWItemPresenter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image3;
        
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
            System.Uri resourceLocater = new System.Uri("/fbhd;component/clwitempresenter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CLWItemPresenter.xaml"
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
            this.title = ((System.Windows.Controls.TextBlock)(target));
            
            #line 51 "..\..\CLWItemPresenter.xaml"
            this.title.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.title_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.subTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.linklbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.moreActionsButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\CLWItemPresenter.xaml"
            this.moreActionsButton.Click += new System.Windows.RoutedEventHandler(this.moreActionsButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.image2 = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.moreActionsPopup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            this.DloadButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\CLWItemPresenter.xaml"
            this.DloadButton.Click += new System.Windows.RoutedEventHandler(this.DloadButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.CopyUrlButt = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\CLWItemPresenter.xaml"
            this.CopyUrlButt.Click += new System.Windows.RoutedEventHandler(this.CopyUrlButt_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.image3 = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


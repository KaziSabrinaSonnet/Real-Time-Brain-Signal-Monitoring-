﻿#pragma checksum "..\..\RealTimeZoomScrollWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AB42BB8F87760B72FF7CF3F594CC7D8075F53F7709853EE7DBF5DF4213D34F12"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CSharpWPFCharts;
using ChartDirector;
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


namespace CSharpWPFCharts {
    
    
    /// <summary>
    /// RealTimeZoomScrollWindow
    /// </summary>
    public partial class RealTimeZoomScrollWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton pointerPB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton zoomInPB;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton zoomOutPB;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePB;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox samplePeriod;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label valueA;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label valueB;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label valueC;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChartDirector.WPFChartViewer WPFChartViewer1;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\RealTimeZoomScrollWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ScrollBar hScrollBar1;
        
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
            System.Uri resourceLocater = new System.Uri("/CSharpWPFCharts;component/realtimezoomscrollwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RealTimeZoomScrollWindow.xaml"
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
            
            #line 9 "..\..\RealTimeZoomScrollWindow.xaml"
            ((CSharpWPFCharts.RealTimeZoomScrollWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pointerPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\RealTimeZoomScrollWindow.xaml"
            this.pointerPB.Checked += new System.Windows.RoutedEventHandler(this.pointerPB_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.zoomInPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\RealTimeZoomScrollWindow.xaml"
            this.zoomInPB.Checked += new System.Windows.RoutedEventHandler(this.zoomInPB_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.zoomOutPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 27 "..\..\RealTimeZoomScrollWindow.xaml"
            this.zoomOutPB.Checked += new System.Windows.RoutedEventHandler(this.zoomOutPB_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.savePB = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\RealTimeZoomScrollWindow.xaml"
            this.savePB.Click += new System.Windows.RoutedEventHandler(this.savePB_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.samplePeriod = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\RealTimeZoomScrollWindow.xaml"
            this.samplePeriod.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.samplePeriod_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.valueA = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.valueB = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.valueC = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.WPFChartViewer1 = ((ChartDirector.WPFChartViewer)(target));
            
            #line 69 "..\..\RealTimeZoomScrollWindow.xaml"
            this.WPFChartViewer1.ViewPortChanged += new ChartDirector.WPFViewPortEventHandler(this.WPFChartViewer1_ViewPortChanged);
            
            #line default
            #line hidden
            
            #line 69 "..\..\RealTimeZoomScrollWindow.xaml"
            this.WPFChartViewer1.MouseMovePlotArea += new System.Windows.Input.MouseEventHandler(this.WPFChartViewer1_MouseMovePlotArea);
            
            #line default
            #line hidden
            return;
            case 11:
            this.hScrollBar1 = ((System.Windows.Controls.Primitives.ScrollBar)(target));
            
            #line 70 "..\..\RealTimeZoomScrollWindow.xaml"
            this.hScrollBar1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.hScrollBar1_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


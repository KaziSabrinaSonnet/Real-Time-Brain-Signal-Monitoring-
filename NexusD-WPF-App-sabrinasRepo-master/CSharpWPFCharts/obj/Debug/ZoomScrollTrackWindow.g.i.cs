﻿#pragma checksum "..\..\ZoomScrollTrackWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2796AFB753284ACAD017C106DF039C7F77824D12EE9998873425BC620F90F2B0"
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
    /// ZoomScrollTrackWindow
    /// </summary>
    public partial class ZoomScrollTrackWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\ZoomScrollTrackWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton pointerPB;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ZoomScrollTrackWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton zoomInPB;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ZoomScrollTrackWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton zoomOutPB;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ZoomScrollTrackWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ChartDirector.WPFChartViewer WPFChartViewer1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ZoomScrollTrackWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CSharpWPFCharts;component/zoomscrolltrackwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ZoomScrollTrackWindow.xaml"
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
            
            #line 9 "..\..\ZoomScrollTrackWindow.xaml"
            ((CSharpWPFCharts.ZoomScrollTrackWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pointerPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\ZoomScrollTrackWindow.xaml"
            this.pointerPB.Checked += new System.Windows.RoutedEventHandler(this.pointerPB_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.zoomInPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\ZoomScrollTrackWindow.xaml"
            this.zoomInPB.Checked += new System.Windows.RoutedEventHandler(this.zoomInPB_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.zoomOutPB = ((System.Windows.Controls.RadioButton)(target));
            
            #line 27 "..\..\ZoomScrollTrackWindow.xaml"
            this.zoomOutPB.Checked += new System.Windows.RoutedEventHandler(this.zoomOutPB_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.WPFChartViewer1 = ((ChartDirector.WPFChartViewer)(target));
            
            #line 35 "..\..\ZoomScrollTrackWindow.xaml"
            this.WPFChartViewer1.ViewPortChanged += new ChartDirector.WPFViewPortEventHandler(this.WPFChartViewer1_ViewPortChanged);
            
            #line default
            #line hidden
            
            #line 35 "..\..\ZoomScrollTrackWindow.xaml"
            this.WPFChartViewer1.MouseMovePlotArea += new System.Windows.Input.MouseEventHandler(this.WPFChartViewer1_MouseMovePlotArea);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hScrollBar1 = ((System.Windows.Controls.Primitives.ScrollBar)(target));
            
            #line 36 "..\..\ZoomScrollTrackWindow.xaml"
            this.hScrollBar1.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.hScrollBar1_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "C:\Users\Rand\Documents\GitHub\SWE7903\DemoPrototype\Trunk\HoodlumHookup\SilverlightPrototype1\SilverlightPrototype1Screens\DataSetGrid.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "33D4743E3CD653619AB305F18DE8762B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DataSetInDataGrid.Silverlight;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SilverlightPrototype1Screens {
    
    
    public partial class DataSetGrid : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox SQL;
        
        internal System.Windows.Controls.TextBox PageNumber;
        
        internal System.Windows.Controls.TextBox PageSize;
        
        internal DataSetInDataGrid.Silverlight.ProgressBar Progress;
        
        internal System.Windows.Controls.DataGrid theGrid;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SilverlightPrototype1.Screens;component/DataSetGrid.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.SQL = ((System.Windows.Controls.TextBox)(this.FindName("SQL")));
            this.PageNumber = ((System.Windows.Controls.TextBox)(this.FindName("PageNumber")));
            this.PageSize = ((System.Windows.Controls.TextBox)(this.FindName("PageSize")));
            this.Progress = ((DataSetInDataGrid.Silverlight.ProgressBar)(this.FindName("Progress")));
            this.theGrid = ((System.Windows.Controls.DataGrid)(this.FindName("theGrid")));
        }
    }
}

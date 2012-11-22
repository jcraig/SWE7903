using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Markup;
using System.Collections;
using System.Collections.ObjectModel;
using DataSetInDataGrid.Silverlight;
using DataSetInDataGrid.Silverlight.MyDataService;

namespace SilverlightPrototype1Screens
{
	public partial class Campus : UserControl
	{
		public int? Which 
  		{ 
    		get { return base.GetValue(SourceProperty) as int?; } 
    		set { base.SetValue(SourceProperty, value); } 
  		}
		
  		public static readonly DependencyProperty SourceProperty = 
    		DependencyProperty.Register("Which", typeof(int?), typeof(Campus), null); 

		public Campus()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			// TODO: Add event handler implementation here.
		}
		
#region WCF Web Services region
        IEnumerable _lookup;
		ObservableCollection <DataTableInfo> _tables;
        
        private void GetData()
        {
			object userState = "Data";
            var ws = WCF.GetService();
            ws.GetSchoolsCompleted += new EventHandler<GetSchoolsCompletedEventArgs>(ws_GetSchoolsCompleted);
            ws.GetSchoolsAsync(userState);
        }
#endregion
		void ws_GetSchoolsCompleted(object sender, GetSchoolsCompletedEventArgs e)
		{
            if (e.Error != null)
                System.Windows.Browser.HtmlPage.Window.Alert(e.Error.Message);
			else if (e.ServiceError != null)
				System.Windows.Browser.HtmlPage.Window.Alert(e.ServiceError.Message);
			else
			{
				_tables = e.Result.Tables;
                IEnumerable list = DynamicDataBuilder.GetDataList(e.Result);
                if (e.UserState as string == "Lookup")
                    _lookup = list;
                else
                {
                    //theGrid.Columns.Clear();
                    //theGrid.ItemsSource = e.Result;
				}
			}
        }
	}
}
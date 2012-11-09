using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
	}
}
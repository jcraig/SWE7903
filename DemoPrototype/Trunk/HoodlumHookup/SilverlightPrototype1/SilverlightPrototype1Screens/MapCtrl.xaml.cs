using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Microsoft.Maps.MapControl;
using Microsoft.Maps.MapControl.Design;

namespace SilverlightPrototype1Screens
{
	public partial class MapCtrl : UserControl
	{

		
		
		public double? zoomLevel 
  		{ 
    		get { return base.GetValue(zoomLevel_Property) as double?; } 
    		set { base.SetValue(zoomLevel_Property, value); Map_SetView(); } 
  		}
		
  		public static readonly DependencyProperty zoomLevel_Property = 
    		DependencyProperty.Register("zoomLevel", typeof(double?), typeof(MapCtrl),
			new PropertyMetadata(new PropertyChangedCallback(OnChanged_zoomLevel_Property))); 
		
		private static void OnChanged_zoomLevel_Property(
			DependencyObject d, DependencyPropertyChangedEventArgs e) 
		{
			//((MapCtrl)d).Map_SetView();
		}
		
		
		
		public double? latitude 
  		{ 
    		get { return base.GetValue(latitude_Property) as double?; } 
    		set { base.SetValue(latitude_Property, value); Map_SetView(); } 
  		}
		
  		public static readonly DependencyProperty latitude_Property = 
    		DependencyProperty.Register("latitude", typeof(double?), typeof(MapCtrl),
			new PropertyMetadata(new PropertyChangedCallback(OnChanged_latitude_Property))); 
		
		private static void OnChanged_latitude_Property(
			DependencyObject d, DependencyPropertyChangedEventArgs e) 
		{
			//((MapCtrl)d).Map_SetView();
		}
		
		
		
		public double? longitude 
  		{ 
    		get { return base.GetValue(longitude_Property) as double?; } 
    		set { base.SetValue(longitude_Property, value); Map_SetView(); } 
  		}
		
  		public static readonly DependencyProperty longitude_Property = 
    		DependencyProperty.Register("longitude", typeof(double?), typeof(MapCtrl),
			new PropertyMetadata(new PropertyChangedCallback(OnChanged_longitude_Property))); 
		
		private static void OnChanged_longitude_Property(
			DependencyObject d, DependencyPropertyChangedEventArgs e) 
		{
			//((MapCtrl)d).Map_SetView();
		}
		
		
		private bool Map_IsSetting = false;
		public void Map_SetView() 
		{
			Map_IsSetting = true;
			if (!latitude.HasValue) return;
			if (!longitude.HasValue) return;
			if (!zoomLevel.HasValue) return;
			
			MyMap.SetView(new Location(latitude.Value, longitude.Value), zoomLevel.Value);
			Map_IsSetting = false;
		}

		
		public MapCtrl()
		{
			// Required to initialize variables
			InitializeComponent();
			if (!latitude.HasValue) latitude = default(Double);
			if (!longitude.HasValue) longitude = default(Double);
			if (!zoomLevel.HasValue) zoomLevel = default(Double);
			
			MyMap.ViewChangeEnd +=new System.EventHandler<Microsoft.Maps.MapControl.MapEventArgs>(MyMap_ViewChangeEnd);
			Map_SetView();
		}

		
		private void MyMap_ViewChangeEnd(object sender, Microsoft.Maps.MapControl.MapEventArgs e)
		{
			if (Map_IsSetting) return;
			latitude = MyMap.Center.Latitude;
			longitude = MyMap.Center.Longitude;
			zoomLevel = MyMap.ZoomLevel;
		}
		

		
	}
}
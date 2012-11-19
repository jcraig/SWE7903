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

		
		public double? latStart 
  		{ 
    		get { return base.GetValue(latStart_Property) as double?; } 
    		set { base.SetValue(latStart_Property, value); } 
  		}
		
  		public static readonly DependencyProperty latStart_Property = 
    		DependencyProperty.Register("latStart", typeof(double?), typeof(MapCtrl),
			null); 
		
		
		
		public double? latEnd
  		{ 
    		get { return base.GetValue(latEnd_Property) as double?; } 
    		set { base.SetValue(latEnd_Property, value); } 
  		}
		
  		public static readonly DependencyProperty latEnd_Property = 
    		DependencyProperty.Register("latEnd", typeof(double?), typeof(MapCtrl),
			null); 
		
		
		
		public double? longStart
  		{ 
    		get { return base.GetValue(longStart_Property) as double?; } 
    		set { base.SetValue(longStart_Property, value); } 
  		}
		
  		public static readonly DependencyProperty longStart_Property = 
    		DependencyProperty.Register("longStart", typeof(double?), typeof(MapCtrl),
			null); 
		
		
		
		public double? longEnd
  		{ 
    		get { return base.GetValue(longEnd_Property) as double?; } 
    		set { base.SetValue(longEnd_Property, value); } 
  		}
		
  		public static readonly DependencyProperty longEnd_Property = 
    		DependencyProperty.Register("longEnd", typeof(double?), typeof(MapCtrl),
			null); 
		
		
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
			zoomLevel = MyMap.ZoomLevel;
			
			RetreivePoints(MyMap.ViewportSize);
			RetreiveLatLongs(MyMap);
		}
		
		
		private Double MapViewWidth, MapViewHeight;
		private Point topLeft_P = new Point(0,0);
		private Point botRight_P = new Point(0,0);
		private Point center_P = new Point(0,0);
		
		
		private void RetreivePoints(Size size) {
			MapViewWidth = size.Width;
			MapViewHeight= size.Height;
			topLeft_P.X = 0.0d;
			topLeft_P.Y = 0.0d;
			botRight_P.X = MapViewWidth;
			botRight_P.Y = MapViewHeight;
			center_P.X = MapViewWidth/2.0d;
			center_P.Y = MapViewHeight/2.0d;
		}
			
		
		
		private void RetreiveLatLongs(Microsoft.Maps.MapControl.Map map) {
			Location topLeft_L = map.ViewportPointToLocation(topLeft_P);
			Location botRight_L = map.ViewportPointToLocation(botRight_P);
			Location center_L = map.ViewportPointToLocation(center_P);
			
			latStart  = topLeft_L.Latitude;
			latitude  = center_L.Latitude;
			latEnd    = botRight_L.Latitude;
			
			longStart = topLeft_L.Longitude;
			longitude = center_L.Longitude;
			longEnd   = botRight_L.Longitude;
		}
		
	}
}
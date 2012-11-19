using System;
using System.Net;
using System.Windows;
using System.Windows.Data;

namespace DataSetInDataGrid.Silverlight
{
	public class FormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (parameter is string && parameter.ToString().Contains("{0}"))
			{
				return String.Format((string)parameter, value);
			}
			return value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

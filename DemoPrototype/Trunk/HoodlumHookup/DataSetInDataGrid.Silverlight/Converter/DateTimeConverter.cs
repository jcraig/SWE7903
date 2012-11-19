using System;
using System.Net;
using System.Windows.Data;

namespace DataSetInDataGrid.Silverlight
{
	public class DateTimeConverter : IValueConverter
	{
		public object Convert(object value,
						   Type targetType,
						   object parameter,
						   System.Globalization.CultureInfo culture)
		{
			try
			{
				DateTime date = (DateTime)value;
				if (parameter is string && parameter != null)
					return date.ToString((string)parameter);
				else
					return date.ToShortTimeString();
			}
			catch (Exception e)
			{
			}
			return "";
		}

		public object ConvertBack(object value,
								  Type targetType,
								  object parameter,
								  System.Globalization.CultureInfo culture)
		{
			string strValue = value.ToString();
			DateTime resultDateTime;
			if (DateTime.TryParse(strValue, out resultDateTime))
			{
				return resultDateTime;
			}
			return value;
		}
	}
}

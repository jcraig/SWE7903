using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;

using System.Linq;

namespace DataSetInDataGrid.Silverlight.Converter
{
    public class LookupConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<DataObject> lookup = parameter as IEnumerable<DataObject>;
            //if (lookup != null)
            //{
            //    var val = lookup.Single(d=>d.GetFieldValue(
                          
            //    return String.Format((string)parameter, value);
            //}
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

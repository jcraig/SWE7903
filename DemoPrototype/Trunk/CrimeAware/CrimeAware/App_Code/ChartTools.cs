using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;

/// <summary>
/// Summary description for ChartTools
/// </summary>
public class ChartTools
{
    public static void DataBind_ByEventType_Count(
        System.Data.DataTable dt, 
        System.Collections.Generic.List<string> event_ids,
        System.Collections.Generic.Dictionary<string, string> Data_CrimeType,
        System.Web.UI.DataVisualization.Charting.Chart Chart1)
    {
        List<double> yValues = new List<double>();
        List<String> xValues = new List<string>();
        
        foreach (string crimetype_id in event_ids)
        {
            string event_type_name = Data_CrimeType.First((i) => { return i.Value == crimetype_id; }).Key;

            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                if (Convert.ToString(r["EVENT_TYPE_NAME"]) == event_type_name)
                { count++; }
            }

            if (count > 0)
            {
                xValues.Add(event_type_name + "[" + count + "]");
                yValues.Add(count);
            }
        }

        Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
        Chart1.Series["Default"].ChartType = SeriesChartType.Pie;
        Chart1.Series["Default"]["PieLabelStyle"] = "Enabled";
        Chart1.Legends[0].Enabled = true;
    }

}
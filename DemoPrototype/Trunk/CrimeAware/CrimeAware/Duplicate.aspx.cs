using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Data;

public partial class Duplicate : System.Web.UI.Page
{
    private DB_Client SQL_session = new DB_Client();
    private MessageBox mb = new MessageBox();
    private Control calendarCtl;

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        Label1.Text = "View: " + (MultiView1.ActiveViewIndex + 1).ToString() + " of " + MultiView1.Views.Count.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar pop_calendar = (Calendar)calendar_panel.FindControl("dueCalendar");

        if (Session["calendar"] != null && pop_calendar == null)
            showCalendar();

        GoogleMapForASPNet2.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["AIzaSyAFdfLkydY34KobaHfiOGzLDbnG-niDhMU"];

        // this logic causes server side postback when navigating fromWelcome page in order to avoid a crash caused by client side Javascript url redirect failure to locate images
        if (Session["fromWelcome"] == null)
        {
            Session["fromWelcome"] = "yes";
            GoogleMapForASPNet2.Visible = false;
            Response.Redirect("~/Duplicate.aspx");
        }
        else
            GoogleMapForASPNet2.Visible = true;

        if (!Page.IsPostBack)
        {
            Initialize__();
        }  
    }

    private void Initialize__()
    {
        Populate_FilterChoices(); // Also sets default values, such as Campus1

        MultiView1.ActiveViewIndex = 0;

        GO_btn_Click(this, null); // (Re)Draw the screen. Uses Defaulted values
    }

    private void Populate_FilterChoices()
    {
        Populate_CampusDropDown();
        Populate_DateRange();
        Populate_Weather();
        Populate_CrimeType();
    }

    private void Populate_CrimeType()
    {
        Dictionary<string, string> data = Get_CrimeType();
        crimeType_clb.RepeatColumns = 3;
        crimeType_clb.RepeatDirection = RepeatDirection.Horizontal;
        crimeType_clb.DataSource = data;
        crimeType_clb.DataTextField = "Key";
        crimeType_clb.DataValueField = "Value";
        crimeType_clb.DataBind();
    }

    public Dictionary<string, string> Data_CrimeType
    { get { return Get_CrimeType(); } }
    private Dictionary<string, string> _CrimeType;
    private Dictionary<string, string> Get_CrimeType()
    {
        if (_CrimeType != null) return _CrimeType;
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("Arson", "1");
        data.Add("Assault", "2");
        data.Add("Conduct", "3");
        data.Add("Drugs", "4");
        data.Add("Murder", "5");
        data.Add("Other", "6");
        data.Add("Seven", "7");
        data.Add("Rape", "8");
        data.Add("Robbery", "9");
        data.Add("Shooting", "10");
        data.Add("Suicide", "11");
        data.Add("Theft", "12");
        data.Add("Vandalism", "13");
        data.Add("Arrest", "14");
        _CrimeType = data;
        return _CrimeType;
    }

    public Dictionary<string, string> Data_CrimeTypeIcons
    { get { return Get_CrimeTypeIcons(); } }
    private Dictionary<string, string> _CrimeTypeIcons;
    private Dictionary<string, string> Get_CrimeTypeIcons()
    {
        if (_CrimeTypeIcons != null) return _CrimeTypeIcons;
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("Arson", "icons/FireTruck.png");
        data.Add("Assault", "icons/Assault.png");
        data.Add("Other", "icons/pushpin-yellow.png");
        data.Add("Murder", "icons/homicide1.gif");
        data.Add("Rape", "icons/storm.png");
        data.Add("Robbery", "icons/Robbery.png");
        data.Add("Shooting", "icons/Shooting.png");
        data.Add("Theft", "icons/Theft.png");
        data.Add("Arrest", "icons/Arrest.png");
        data.Add("Disorderly Conduct", "icons/Unknown.png");
        data.Add("Drugs", "icons/Unknown.png");
        data.Add("Suicide", "icons/Unknown.png");
        data.Add("Vandalism", "icons/Unknown.png");
        data.Add("Public Intoxication", "icons/pushpin-yellow.png");               
        _CrimeTypeIcons = data;
        return _CrimeTypeIcons;
    }



    private string[] Get_CrimeType_Names()
    {
        return Data_CrimeType.Keys.ToArray();
    }

    private void Populate_Weather()
    {
        Populate_Precipitation();
        Populate_Temperature();
    }

    private void Populate_Temperature()
    {
        Dictionary<string, string> data = Get_Temperature();
        temp_drop.DataSource = data;
        temp_drop.DataTextField = "Key";
        temp_drop.DataValueField = "Value";
        temp_drop.DataBind();
    }

    private Dictionary<string, string> Get_Temperature()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("Any", "Any");
        data.Add("19 & below", "-100 AND 19");
        data.Add("20 - 32", "20 AND 32");
        data.Add("33 - 45", "33 AND 45");
        data.Add("46 - 60", "46 AND 60");
        data.Add("61 - 75", "61 AND 75");
        data.Add("76 - 85", "76 AND 85");
        data.Add("86 & up", "86 AND 130");
        return data;
    }

    private void Populate_Precipitation()
    {
        string[] data = Get_Precipitation();
        percipitation_drop.DataSource = data;
        percipitation_drop.DataBind();
    }

    private string[] Get_Precipitation()
    {
        string[] data = { "Any", "Rainy", "Sunny", "Cloudy" };
        return data;
    }

    private void Populate_DateRange()
    {
        string[] data = Get_Months();

        //from_drop.DataSource = data;
        //from_drop.DataBind();

        //to_drop.DataSource = data;
        //to_drop.DataBind();
    }

    private static string[] Get_Months()
    {
        string[] data = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        return data;
    }

    private void Populate_CampusDropDown()
    {
        string[] data = Get_Schools();
        campus1_drop.DataSource = data;
        campus1_drop.DataBind();
    }

    private static string[] Get_Schools()
    {
        string[] data = { "SPSU", "Georgia Tech", "UGA" };
        return data;
    }

    protected void GO_btn_Click(object sender, EventArgs e)
    {
        centerMap();
        DrawPolygon();  
        populatePins2();
    }

    void NextImage(object sender, System.EventArgs e)
    {
        MultiView1.ActiveViewIndex += 1;
    }

    protected void map_btn_Click(object sender, EventArgs e)
    {

        MultiView1.ActiveViewIndex = 0;

        centerMap();
       
    }

    protected void stat_btn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;

        createChart();
    }

    
    protected void compare_btn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }

    protected void db_test_btn_Click(object sender, EventArgs e)
    {
        // string report = SQL_session.getSchool_loc("SELECT * FROM SCHOOLS WHERE SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' ", "LAT_START", "LAT_END", "LONG_START", "LONG_END");

        //string report = SQL_session.fetch_polyPoints("SELECT * FROM SCHOOLS WHERE SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' ", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8","G9");
        //string[] loc_array = report.Split('&');

        //int GP_counter = 0;
        //GooglePoint[] GooglePoint_array = new GooglePoint[loc_array.Length/2];

        ////Create Polygon using GooglePoint_array points
        //GooglePolygon PG1 = new GooglePolygon();
        //PG1.ID = "PG1";
        ////Give Hex code for line color
        //PG1.FillColor = "#BBBBFF";
        //PG1.FillOpacity = 0.4;
        //PG1.StrokeColor = "#0000FF";
        //PG1.StrokeOpacity = 1;
        //PG1.StrokeWeight = 2;
        
        //for (int i = 0; i < loc_array.Length; i++)
        //{
        //    string point_id = "GP" + (GP_counter + 1);
        //    GooglePoint_array[GP_counter] = new GooglePoint();
        //    GooglePoint_array[GP_counter].ID = point_id + GP_counter;

        //    double lat, longi;
        //    double.TryParse(loc_array[i], out lat);
        //    double.TryParse(loc_array[i + 1], out longi);
        //    GooglePoint_array[GP_counter].Latitude = lat;
        //    GooglePoint_array[GP_counter].Longitude = longi;

        //    // add points to polygon
        //    PG1.Points.Add(GooglePoint_array[GP_counter]);

        //    i++;
        //    GP_counter++;
        //}

        //PG1.Points.Add(GooglePoint_array[0]);

        ////Add polygon to GoogleMap object
        //GoogleMapForASPNet2.GoogleMapObject.Polygons.Add(PG1);

        //double lat;
        //double.TryParse(loc_array[0], out lat);

        //double longi;
        //double.TryParse(loc_array[2], out longi);

        // mb.ShowMessageBox("Query result is: " + report);
        // mb.ShowMessageBox("Query result is: lat" + lat + " long " + longi);
        // mb.ShowMessageBox("ARRAY LENGTH is: " + loc_array.Length);

        string report = SQL_session.getSchool_loc("SELECT * FROM SCHOOLS WHERE SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' ", "LAT_START", "LAT_END", "LONG_START", "LONG_END");
    }

    protected void db_test2_btn_Click(object sender, EventArgs e)
    {
        string join_report = "empty";
        join_report = SQL_session.fetch_2params("SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END WHERE s.SCHOOL_ID = 1 AND edt.EVENT_TYPE_ID = '" + crime_drop.SelectedValue + "'", "LOCATION_LAT", "LOCATION_LONG");

        mb.ShowMessageBox("Query result is: " + join_report);
    }

    private void showLoc_populatePushpins(Double lat, Double longi)
    {       

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet2.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet2.GoogleMapObject.Height = "500px";

        //Specify initial Zoom level.
        GoogleMapForASPNet2.GoogleMapObject.ZoomLevel = 14;

        //Specify Center Point for map. Map will be centered on this point.
        //GoogleMapForASPNet2.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.69, -79.4042);
        GoogleMapForASPNet2.GoogleMapObject.CenterPoint = new GooglePoint("1", lat, longi);

        //Define Points for polygon
        GooglePoint GP1 = new GooglePoint();
        GP1.ID = "GP1";
        GP1.Latitude = 43.66675;
        GP1.Longitude = -79.4042;

        GooglePoint GP2 = new GooglePoint();
        GP2.ID = "GP2";
        GP2.Latitude = 43.67072;
        GP2.Longitude = -79.38677;

        GooglePoint GP3 = new GooglePoint();
        GP3.ID = "GP3";
        GP3.Latitude = 43.66706;
        GP3.Longitude = -79.37879;

        GooglePoint GP4 = new GooglePoint();
        GP4.ID = "GP4";
        GP4.Latitude = 43.66135;
        GP4.Longitude = -79.383;

        GooglePoint GP5 = new GooglePoint();
        GP5.ID = "GP5";
        GP5.Latitude = 43.65787;
        GP5.Longitude = -79.40016;

        GooglePoint GP6 = new GooglePoint();
        GP6.ID = "GP6";
        GP6.Latitude = 43.66066;
        GP6.Longitude = -79.40943;

        GooglePoint GP7 = new GooglePoint();
        GP7.ID = "GP7";
        GP7.Latitude = 43.66656;
        GP7.Longitude = -79.40445;

        //Create Polygon using above points
        GooglePolygon PG1 = new GooglePolygon();
        PG1.ID = "PG1";
        //Give Hex code for line color
        PG1.FillColor = "#DDDDFF";
        PG1.FillOpacity = 0.4;
        PG1.StrokeColor = "#0000FF";
        PG1.StrokeOpacity = 1;
        PG1.StrokeWeight = 2;

        PG1.Points.Add(GP1);
        PG1.Points.Add(GP2);
        PG1.Points.Add(GP3);
        PG1.Points.Add(GP4);
        PG1.Points.Add(GP5);
        PG1.Points.Add(GP6);
        PG1.Points.Add(GP7);

        //Add polygon to GoogleMap object
        GoogleMapForASPNet2.GoogleMapObject.Polygons.Add(PG1);

        // add pushpins
        GooglePoint GP10 = new GooglePoint();
        GP10.ID = "Toronto";
        GP10.Latitude = 43.668;
        GP10.Longitude = -79.385;
        //Specify bubble text here. You can use standard HTML tags here.
        GP10.InfoHTML = "This is Pushpin 1";

        //Specify icon image. This should be relative to root folder.
        //GP10.IconImage = "icons/Burglary.png";
        GoogleMapForASPNet2.GoogleMapObject.Points.Add(GP10);

        GooglePoint GP11 = new GooglePoint();
        GP11.ID = "Montreal";
        GP11.Latitude = 43.665; //+0.001
        GP11.Longitude = -79.39;
        GP11.InfoHTML = "This is Pushpin 2";
        GP11.IconImage = "icons/Shooting.png";
        GoogleMapForASPNet2.GoogleMapObject.Points.Add(GP11);

        GooglePoint GP12 = new GooglePoint();
        GP12.ID = "Halifax";
        GP12.Latitude = 43.66;
        GP12.Longitude = -79.403;
        GP12.InfoHTML = "This is Pushpin 3";
        GP12.IconImage = "icons/Arrest.png";

        GoogleMapForASPNet2.GoogleMapObject.Points.Add(GP12);
    }

    private void centerMap()
    {
        int selectedCampus_index = campus1_drop.SelectedIndex;

        string report = SQL_session.getSchool_loc("SELECT * FROM SCHOOLS WHERE SCHOOL_ID = '" + (selectedCampus_index + 1) + "' ", "LAT_START", "LAT_END", "LONG_START", "LONG_END");
        string[] loc_array = report.Split('&');

        double lat_start;
        double.TryParse(loc_array[0], out lat_start);
        double lat_end;
        double.TryParse(loc_array[1], out lat_end);

        double longi_start;
        double.TryParse(loc_array[2], out longi_start);
        double longi_end;
        double.TryParse(loc_array[3], out longi_end);

        //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
        GoogleMapForASPNet2.GoogleMapObject.Width = "700px"; // You can also specify percentage(e.g. 80%) here
        GoogleMapForASPNet2.GoogleMapObject.Height = "500px";

        //Specify initial Zoom level.
        GoogleMapForASPNet2.GoogleMapObject.ZoomLevel = 14;

        //Specify Center Point for map. Map will be centered on this point.
        //GoogleMapForASPNet2.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.69, -79.4042);
        GoogleMapForASPNet2.GoogleMapObject.CenterPoint = new GooglePoint("1", ((lat_start+lat_end)/2), ((longi_start+longi_end)/2));
    }


    private void DrawPolygon()
    {
        GoogleMapForASPNet2.GoogleMapObject.Polygons.Clear();

        string report = SQL_session.fetch_polyPoints("SELECT * FROM SCHOOLS WHERE SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' ", "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9");
        string[] loc_array = report.Split('&');

        int GP_counter = 0;
        GooglePoint[] GooglePoint_array = new GooglePoint[loc_array.Length / 2];

        //Create Polygon using GooglePoint_array points
        GooglePolygon PG1 = new GooglePolygon();
        PG1.ID = "PG1";
        //Give Hex code for line color
        PG1.FillColor = "#CCCCFF";
        PG1.FillOpacity = 0.4;
        PG1.StrokeColor = "#0000FF";
        PG1.StrokeOpacity = 1;
        PG1.StrokeWeight = 2;

        for (int i = 0; i < loc_array.Length; i++)
        {
            string point_id = "GP" + (GP_counter + 1);
            GooglePoint_array[GP_counter] = new GooglePoint();
            GooglePoint_array[GP_counter].ID = point_id + GP_counter;

            double lat, longi;
            double.TryParse(loc_array[i], out lat);
            double.TryParse(loc_array[i + 1], out longi);
            GooglePoint_array[GP_counter].Latitude = lat;
            GooglePoint_array[GP_counter].Longitude = longi;

            // add points to polygon
            PG1.Points.Add(GooglePoint_array[GP_counter]);

            i++;
            GP_counter++;
        }

        PG1.Points.Add(GooglePoint_array[0]);

        //Add polygon to GoogleMap object
        GoogleMapForASPNet2.GoogleMapObject.Polygons.Add(PG1);
    } // end DrawPOlygon


    private void createChart()
    {
        List<double> yValues = new List<double>();
        List<String> xValues = new List<string>();

        DataTable dt = Filter_GetDataTable();

        foreach (string crimetype_id in GetSelected_EventTypeIds())
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


    private void populatePins2()
    {
        GoogleMapForASPNet2.GoogleMapObject.Points.Clear();

        DataTable dt = Filter_GetDataTable();
        int i = 0;
        foreach (DataRow r in dt.Rows)
        {
            string event_type_name = Convert.ToString(r["EVENT_TYPE_NAME"]);
            GooglePoint p = new GooglePoint();
            p.ID = event_type_name + i;
            p.Latitude  = Convert.ToDouble(r["LOCATION_LAT"]);
            p.Longitude = Convert.ToDouble(r["LOCATION_LONG"]);
            p.InfoHTML = "This was a case of " + event_type_name;
            p.IconImage = Data_CrimeTypeIcons[event_type_name];

            GoogleMapForASPNet2.GoogleMapObject.Points.Add(p);
        }
    }



    private static string StringJoin(List<string> list, string joiner)
    {
        string result = "";
        int i = 0;
        foreach (string s in list)
        {
            result += s;
            result += (i < list.Count - 1) ? joiner : "";
            i++;
        }
        return result;
    }

    private List<string> GetSelected_EventTypeIds()
    {
        List<string> event_type_ids;
        event_type_ids = new List<string>();
        foreach (ListItem li in crimeType_clb.Items) { if (li.Selected) event_type_ids.Add(li.Value); }
        return event_type_ids;
    } 


    protected void all_btn_Click(object sender, EventArgs e)
    {
        foreach (ListItem i in crimeType_clb.Items) { i.Selected = true; }
    }

    protected void clear_btn_Click(object sender, EventArgs e)
    {
        crimeType_clb.ClearSelection();
    }

    protected void weather_btn_Click(object sender, EventArgs e)
    {   
        /* string weather_fetch = "SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID"
            + " JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END LEFT JOIN WEATHER_INFO wi ON ed.EVENT_DATE BETWEEN wi.WEATHER_START_DATE AND wi.WEATHER_END_DATE "
                + "AND wi.SCHOOL_ID = s.SCHOOL_ID WHERE s.SCHOOL_ID = 1 AND edt.EVENT_TYPE_ID IN (1,2,3) AND ed.EVENT_DATE BETWEEN '01-JUN-2012' AND '01-NOV-2012' AND (wi.RAINY_IND = 'T' OR wi.SUNNY_IND = 'T') "
                    + " AND (wi.TEMPERATURE BETWEEN 50 AND 80)"; */

        string weather_fetch_BASE = "SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID"
            + " JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END LEFT JOIN WEATHER_INFO wi ON ed.EVENT_DATE BETWEEN wi.WEATHER_START_DATE AND wi.WEATHER_END_DATE "
                + "AND wi.SCHOOL_ID = s.SCHOOL_ID WHERE s.SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' ";
        
        string fetch_weather="", fetch_dateRange="", weather_fetch_COMPLETE="";

        fetch_weather = Filter_BuildQuery_ByWeather(fetch_weather);

        // if (Date selected)  -- do stuff   
       
        if (arrest_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '14' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Arrest.png", "This was an arrest!", "arrest");
        }

        if (arson_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '1' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/FireTruck.png", "This was a case of arsen !", "arsen");
        }

        if (assault_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '2' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Assault.png", "This was an assault !", "assault");
        }

        if (rape_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '8' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/storm.png", "This was a rape !", "rape");
        }

        if (robbery_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '9' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Robbery.png", "This was a robbery !", "robbery");
        }

        if (shooting_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '10' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Shooting.png", "This was some kind of shooting!", "shooting");
        }

        if (theft_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '10' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Theft.png", "This was theft!", "theft");
        }

        if (other_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '3' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "Disorderly conduct went down here!", "dc");

            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '4' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "A drug case!", "drug");

            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '6' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "Some other crime occured here!", "other");

            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '11' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "This was a suicide!", "suicide");

            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '13' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Vandalism.png", "Vandalism occured here", "vandalism");
        }

        if (murder_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + " AND edt.EVENT_TYPE_ID = '5' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/homicide1.gif", "Site of a homicide!", "homicide");
        }

        mb.ShowMessageBox("fetch string result is " + SQL_session.fetch_2params(weather_fetch_COMPLETE, "LOCATION_LAT", "LOCATION_LONG"));

    } // end weather_btn_Click



    private DataTable Filter_GetDataTable()
    {
        string fetch_string
            = "SELECT * "
            + "FROM EVENT_DATA ed "
            + "JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID "
            + "JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID "
            + "JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END "
            + "WHERE "
            + Filter_BuildQuery_ByCampus("s")
            + " AND " + Filter_BuildQuery_ByCrimeType("edt");
        // + " AND " + Filter_BuildQuery_ByWeather("wi");
        return SQL_session.fetch_datatable(fetch_string);
    }


    private string Filter_BuildQuery_ByCampus(string table_name)
    {
        string result = "(" + table_name + ".SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "')";
        return result;
    }


    private string Filter_BuildQuery_ByCrimeType(string table_name)
    {
        string event_type_ids = StringJoin(GetSelected_EventTypeIds(), ",");
        string result = "(" + table_name + ".EVENT_TYPE_ID IN (" + event_type_ids + "))";
        return result;
    }

    private string Filter_BuildQuery_ByWeather(string table_name)
    {
        string result = "(TRUE)";
        // result += Filter_BuildQuery_ByPrecipitation(table_name);
        result = "(" + Filter_BuildQuery_ByTemperature(table_name) + ")";
        return result;
    }

    private string Filter_BuildQuery_ByPrecipitation(string table_name)
    {
        string result = "(TRUE)";
        if (percipitation_drop.SelectedIndex > 0)
        {
            if (percipitation_drop.SelectedIndex == 1)
            {
                result += "(" + table_name + ".RAINY_IND = 'T')";
            }
            if (percipitation_drop.SelectedIndex == 2)
            {
                result += "(" + table_name + ".SUNNY_IND = 'T')";
            }
            if (percipitation_drop.SelectedIndex == 3)
            {
                result += "(" + table_name + ".CLOUDY_IND = 'T')";
            }
        }
        return result;
    }

    private string Filter_BuildQuery_ByTemperature(string table_name)
    {
        string result = "(TRUE)";
        if (temp_drop.SelectedValue != "Any")
        {
            result += "(" + table_name + ".TEMPERATURE BETWEEN " + temp_drop.SelectedValue + ")";
        }
        return result;
    }

    private void Place_Pins(String fetch_string, String image, String tooltip_message, String crime_ID)
    {        
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string, "LOCATION_LAT", "LOCATION_LONG");

            string[] crime_array = join_report.Split('&');

            double lat, longi;

            int counter = 0;
            GooglePoint[] point = new GooglePoint[crime_array.Length / 2];

            if (crime_array.Length > 1)
            {
                for (int i = 0; i < crime_array.Length - 1; i++)
                {
                    double.TryParse(crime_array[i], out lat);
                    double.TryParse(crime_array[i + 1], out longi);

                    point[counter] = new GooglePoint();
                    point[counter].ID = crime_ID + (counter + 1);
                    point[counter].Latitude = lat;
                    point[counter].Longitude = longi;
                    point[counter].InfoHTML = tooltip_message;
                    point[counter].IconImage = image;
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(point[counter]);

                    i++;
                    counter++;
                }// end for loop
            }
    } // end void Place_Pins(String fetch_string, String crime_tripe, String image)
    protected void calendar_btn_Click(object sender, EventArgs e)
    {           
        showCalendar();

        Session["calendar"] = "yes";
        filters_div.Style.Add("border-bottom-style", "none");
    }

    private void showCalendar()
    {
        calendar_btn.Visible = false;
        close_btn.Visible = true;   
        calendarCtl = LoadControl("~/Calendar.ascx");
        calendarCtl.ID = "dueCalendar";

        calendar_div.Style.Add("height", "540px");
        calendar_panel.Style.Add("height", "540px");
        //repeaters_div.Style.Add("height", "355px");
        //WO_Panel.Style.Add("height", "355px");
        calendar_div.Controls.Add(calendarCtl);
        calendarCtl.Visible = true;        
    }

    protected void close_btn_Click(object sender, EventArgs e)
    {
        Calendar pop_calendar = (Calendar)calendar_panel.FindControl("dueCalendar");
        mb.ShowMessageBox("start date is " + pop_calendar.getStart_date() + " end date is " + pop_calendar.getEnd_date());

        calendar_div.Style.Add("height", "40px");
        calendar_panel.Style.Add("height", "40px");
        calendar_div.Controls.Remove(calendarCtl);

        close_btn.Visible = false;
        calendar_btn.Visible = true;

        Session["calendar"] = null;        
    }
}
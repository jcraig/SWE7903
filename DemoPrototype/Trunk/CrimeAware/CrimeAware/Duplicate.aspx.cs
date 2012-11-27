using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class Duplicate : System.Web.UI.Page
{
    private DB_Client SQL_session = new DB_Client();
    private MessageBox mb = new MessageBox();
    

    protected void Page_PreRender(object sender, System.EventArgs e)
    {
        Label1.Text = "View: " + (MultiView1.ActiveViewIndex + 1).ToString() + " of " + MultiView1.Views.Count.ToString();
    }  

    protected void Page_Load(object sender, EventArgs e)
    {
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
            MultiView1.ActiveViewIndex = 0;
        }  
    }
    protected void GO_btn_Click(object sender, EventArgs e)
    {
        int selectedCampus_index = campus1_drop.SelectedIndex;
         
        //MultiView1.ActiveViewIndex = selectedCampus_index;

        centerMap();

        DrawPolygon();  
      
        populatePins();

        //if (robbery_box.Checked)
        //{
        //    //string[] loc_array;

        //    string join_report = "empty";
        //    join_report = SQL_session.fetch_2params("SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END WHERE s.SCHOOL_ID = 1 AND edt.EVENT_TYPE_ID = 9", "LOCATION_LAT", "LOCATION_LONG");

        //    string[] robbery_array = join_report.Split('&');

        //    double lat, longi;
            

        //    int robbery_counter = 0;
        //    GooglePoint[] robbery_point = new GooglePoint[robbery_array.Length / 2];

        //    for (int i = 0; i < robbery_array.Length; i++)
        //    {
        //        double.TryParse(robbery_array[i], out lat);
        //        double.TryParse(robbery_array[i + 1], out longi);

        //        robbery_point[robbery_counter] = new GooglePoint();
        //        robbery_point[robbery_counter].ID = "robbery" + (robbery_counter + 1);
        //        robbery_point[robbery_counter].Latitude = lat;
        //        robbery_point[robbery_counter].Longitude = longi;
        //        robbery_point[robbery_counter].InfoHTML = "This was a robbery";
        //        robbery_point[robbery_counter].IconImage = "icons/Robbery.png";
        //        GoogleMapForASPNet2.GoogleMapObject.Points.Add(robbery_point[robbery_counter]);

        //        i++;
        //        robbery_counter++;
        //    }
        //} // end if (robbery_box.Checked)
        //else
        //{
        //    GoogleMapForASPNet2.GoogleMapObject.Points.Clear();
        //}


        // showLoc_populatePushpins( ((lat_start+lat_end)/2), ((longi_start+longi_end)/2));
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

    private void populatePins()
    {
        string fetch_string = "SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END WHERE s.SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "'";

        GoogleMapForASPNet2.GoogleMapObject.Points.Clear();

        // #1
        if (arson_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + "AND edt.EVENT_TYPE_ID = 1", "LOCATION_LAT", "LOCATION_LONG");

            string[] arson_array = join_report.Split('&');

            double arson_lat, arson_longi;

            int arson_counter = 0;
            GooglePoint[] arson_point = new GooglePoint[arson_array.Length / 2];

            if (arson_array.Length > 1)
            {
                for (int i = 0; i < arson_array.Length - 1; i++)
                {
                    double.TryParse(arson_array[i], out arson_lat);
                    double.TryParse(arson_array[i + 1], out arson_longi);

                    arson_point[arson_counter] = new GooglePoint();
                    arson_point[arson_counter].ID = "arson" + (arson_counter + 1);
                    arson_point[arson_counter].Latitude = arson_lat;
                    arson_point[arson_counter].Longitude = arson_longi;
                    arson_point[arson_counter].InfoHTML = "This was a case of arsen";
                    arson_point[arson_counter].IconImage = "icons/FireTruck.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(arson_point[arson_counter]);

                    i++;
                    arson_counter++;
                }  // end for loop
            }
        } // end if (arson_box.Checked)

        // #2
        if (arrest_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + "AND edt.EVENT_TYPE_ID = 14", "LOCATION_LAT", "LOCATION_LONG");

            string[] arrest_array = join_report.Split('&');

            double arrest_lat, arrest_longi;

            int arrest_counter = 0;
            GooglePoint[] arrest_point = new GooglePoint[arrest_array.Length / 2];

            // #1
            if (arrest_array.Length > 1) 
            {
                for (int i = 0; i < arrest_array.Length - 1; i++)
                {
                    double.TryParse(arrest_array[i], out arrest_lat);
                    double.TryParse(arrest_array[i + 1], out arrest_longi);

                    arrest_point[arrest_counter] = new GooglePoint();
                    arrest_point[arrest_counter].ID = "arrest" + (arrest_counter + 1);
                    arrest_point[arrest_counter].Latitude = arrest_lat;
                    arrest_point[arrest_counter].Longitude = arrest_longi;
                    arrest_point[arrest_counter].InfoHTML = "This was a case of arrest!";
                    arrest_point[arrest_counter].IconImage = "icons/Arrest.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(arrest_point[arrest_counter]);

                    i++;
                    arrest_counter++;
                }  // end for loop
            }
        } // end if (arson_box.Checked)

        // #3
        if (assault_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 2", "LOCATION_LAT", "LOCATION_LONG");

            string[] assault_array = join_report.Split('&');

            double assault_lat, assault_longi;

            int assault_counter = 0;
            GooglePoint[] assault_point = new GooglePoint[assault_array.Length / 2];

            if (assault_array.Length > 1)
            {
                for (int i = 0; i < assault_array.Length - 1; i++)
                {
                    double.TryParse(assault_array[i], out assault_lat);
                    double.TryParse(assault_array[i + 1], out assault_longi);

                    assault_point[assault_counter] = new GooglePoint();
                    assault_point[assault_counter].ID = "assault" + (assault_counter + 1);
                    assault_point[assault_counter].Latitude = assault_lat;
                    assault_point[assault_counter].Longitude = assault_longi;
                    assault_point[assault_counter].InfoHTML = "This was an assault";
                    assault_point[assault_counter].IconImage = "icons/Assault.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(assault_point[assault_counter]);

                    i++;
                    assault_counter++;
                }// end for loop
            }
        } // end if (assault_box.Checked)

        // #4
        if (murder_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + "AND edt.EVENT_TYPE_ID = 5", "LOCATION_LAT", "LOCATION_LONG");

            string[] murder_array = join_report.Split('&');

            double murder_lat, murder_longi;

            int murder_counter = 0;
            GooglePoint[] murder_point = new GooglePoint[murder_array.Length / 2];

            if (murder_array.Length > 1)
            {
                for (int i = 0; i < murder_array.Length - 1; i++)
                {
                    double.TryParse(murder_array[i], out murder_lat);
                    double.TryParse(murder_array[i + 1], out murder_longi);

                    murder_point[murder_counter] = new GooglePoint();
                    murder_point[murder_counter].ID = "homicide" + (murder_counter + 1);
                    murder_point[murder_counter].Latitude = murder_lat;
                    murder_point[murder_counter].Longitude = murder_longi;
                    murder_point[murder_counter].InfoHTML = "This was homicide";
                    murder_point[murder_counter].IconImage = "icons/homicide1.gif";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(murder_point[murder_counter]);

                    i++;
                    murder_counter++;
                }  // end for loop
            }
        } // end if (murder_box.Checked)

        // #5
        if (other_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 3", "LOCATION_LAT", "LOCATION_LONG");
            join_report += SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 4", "LOCATION_LAT", "LOCATION_LONG");
            join_report += SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 6", "LOCATION_LAT", "LOCATION_LONG");
            join_report += SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 11", "LOCATION_LAT", "LOCATION_LONG");
            join_report += SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 13", "LOCATION_LAT", "LOCATION_LONG");


            string[] other_array = join_report.Split('&');

            double other_lat, other_longi;

            int other_counter = 0;
            GooglePoint[] other_point = new GooglePoint[other_array.Length / 2];

            if (other_array.Length > 1)
            {
                for (int i = 0; i < other_array.Length - 1; i++)
                {
                    double.TryParse(other_array[i], out other_lat);
                    double.TryParse(other_array[i + 1], out other_longi);

                    other_point[other_counter] = new GooglePoint();
                    other_point[other_counter].ID = "other" + (other_counter + 1);
                    other_point[other_counter].Latitude = other_lat;
                    other_point[other_counter].Longitude = other_longi;
                    other_point[other_counter].InfoHTML = "This was some other crime !";
                    other_point[other_counter].IconImage = "icons/pushpin-yellow.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(other_point[other_counter]);

                    i++;
                    other_counter++;
                }// end for loop
            }
        } // end if (other_box.Checked)

        // #6
        if (rape_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 8", "LOCATION_LAT", "LOCATION_LONG");

            string[] rape_array = join_report.Split('&');

            double rape_lat, rape_longi;

            int rape_counter = 0;
            GooglePoint[] rape_point = new GooglePoint[rape_array.Length / 2];

            if (rape_array.Length > 1)
            {
                for (int i = 0; i < rape_array.Length - 1; i++)
                {
                    double.TryParse(rape_array[i], out rape_lat);
                    double.TryParse(rape_array[i + 1], out rape_longi);

                    rape_point[rape_counter] = new GooglePoint();
                    rape_point[rape_counter].ID = "rape" + (rape_counter + 1);
                    rape_point[rape_counter].Latitude = rape_lat;
                    rape_point[rape_counter].Longitude = rape_longi;
                    rape_point[rape_counter].InfoHTML = "This was a rape!";
                    rape_point[rape_counter].IconImage = "icons/storm.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(rape_point[rape_counter]);

                    i++;
                    rape_counter++;
                } // end for loop
            }
        } // end if (rape_box.Checked)

        // #7
        if (robbery_box.Checked)
        {            
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 9", "LOCATION_LAT", "LOCATION_LONG");

            string[] robbery_array = join_report.Split('&');

            double rob_lat, rob_longi;

            int robbery_counter = 0;
            GooglePoint[] robbery_point = new GooglePoint[robbery_array.Length / 2];

            if (robbery_array.Length > 1)
            {
                for (int i = 0; i < robbery_array.Length - 1; i++)
                {
                    double.TryParse(robbery_array[i], out rob_lat);
                    double.TryParse(robbery_array[i + 1], out rob_longi);

                    robbery_point[robbery_counter] = new GooglePoint();
                    robbery_point[robbery_counter].ID = "robbery" + (robbery_counter + 1);
                    robbery_point[robbery_counter].Latitude = rob_lat;
                    robbery_point[robbery_counter].Longitude = rob_longi;
                    robbery_point[robbery_counter].InfoHTML = "This was a robbery";
                    robbery_point[robbery_counter].IconImage = "icons/Robbery.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(robbery_point[robbery_counter]);

                    i++;
                    robbery_counter++;
                } // end for loop
            }
        } // end if (robbery_box.Checked)

        // #8
        if (shooting_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 10", "LOCATION_LAT", "LOCATION_LONG");

            string[] shooting_array = join_report.Split('&');

            double shooting_lat, shooting_longi;

            int shooting_counter = 0;
            GooglePoint[] shooting_point = new GooglePoint[shooting_array.Length / 2];

            if (shooting_array.Length > 1)
            {
                for (int i = 0; i < shooting_array.Length - 1; i++)
                {
                    double.TryParse(shooting_array[i], out shooting_lat);
                    double.TryParse(shooting_array[i + 1], out shooting_longi);

                    shooting_point[shooting_counter] = new GooglePoint();
                    shooting_point[shooting_counter].ID = "shooting" + (shooting_counter + 1);
                    shooting_point[shooting_counter].Latitude = shooting_lat;
                    shooting_point[shooting_counter].Longitude = shooting_longi;
                    shooting_point[shooting_counter].InfoHTML = "This was a shooting !";
                    shooting_point[shooting_counter].IconImage = "icons/Shooting.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(shooting_point[shooting_counter]);

                    i++;
                    shooting_counter++;
                }// end for loop
            }
        } // end if (shooting_box.Checked)

        // #9
        if (theft_box.Checked)
        {
            string join_report = "empty";
            join_report = SQL_session.fetch_2params(fetch_string + " AND edt.EVENT_TYPE_ID = 12", "LOCATION_LAT", "LOCATION_LONG");

            string[] theft_array = join_report.Split('&');

            double theft_lat, theft_longi;

            int theft_counter = 0;
            GooglePoint[] theft_point = new GooglePoint[theft_array.Length / 2];

            if (theft_array.Length > 1 )
            {
                for (int i = 0; i < theft_array.Length - 1; i++)
                {
                    double.TryParse(theft_array[i], out theft_lat);
                    double.TryParse(theft_array[i + 1], out theft_longi);

                    theft_point[theft_counter] = new GooglePoint();
                    theft_point[theft_counter].ID = "theft" + (theft_counter + 1);
                    theft_point[theft_counter].Latitude = theft_lat;
                    theft_point[theft_counter].Longitude = theft_longi;
                    theft_point[theft_counter].InfoHTML = "This was some thieving !";
                    theft_point[theft_counter].IconImage = "icons/Theft.png";
                    GoogleMapForASPNet2.GoogleMapObject.Points.Add(theft_point[theft_counter]);

                    i++;
                    theft_counter++;
                }// end for loop
            }
        } // end if (theft_box.Checked)

    } // end populatePins()
    protected void all_btn_Click(object sender, EventArgs e)
    {
        arrest_box.Checked = true;
        arson_box.Checked = true;
        assault_box.Checked = true;
        rape_box.Checked = true;
        robbery_box.Checked = true;
        shooting_box.Checked = true;
        theft_box.Checked = true;
        other_box.Checked = true;
        murder_box.Checked = true;
    }
    protected void clear_btn_Click(object sender, EventArgs e)
    {
        arrest_box.Checked = false;
        arson_box.Checked = false;
        assault_box.Checked = false;
        rape_box.Checked = false;
        robbery_box.Checked = false;
        shooting_box.Checked = false;
        theft_box.Checked = false;
        other_box.Checked = false;
        murder_box.Checked = false;
    }

    protected void weather_btn_Click(object sender, EventArgs e)
    {   
        /* string weather_fetch = "SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID"
            + " JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END LEFT JOIN WEATHER_INFO wi ON ed.EVENT_DATE BETWEEN wi.WEATHER_START_DATE AND wi.WEATHER_END_DATE "
                + "AND wi.SCHOOL_ID = s.SCHOOL_ID WHERE s.SCHOOL_ID = 1 AND edt.EVENT_TYPE_ID IN (1,2,3) AND ed.EVENT_DATE BETWEEN '01-JUN-2012' AND '01-NOV-2012' AND (wi.RAINY_IND = 'T' OR wi.SUNNY_IND = 'T') "
                    + " AND (wi.TEMPERATURE BETWEEN 50 AND 80)"; */

        string weather_fetch_BASE = "SELECT * FROM EVENT_DATA ed JOIN EVENT_DATA_TYPES edt ON ed.EVENT_ID = edt.EVENT_ID JOIN EVENT_TYPES et ON et.EVENT_TYPE_ID = edt.EVENT_TYPE_ID"
            + " JOIN SCHOOLS s ON ed.LOCATION_LAT BETWEEN s.LAT_START AND s.LAT_END AND ed.LOCATION_LONG BETWEEN s.LONG_START AND s.LONG_END LEFT JOIN WEATHER_INFO wi ON ed.EVENT_DATE BETWEEN wi.WEATHER_START_DATE AND wi.WEATHER_END_DATE "
                + "AND wi.SCHOOL_ID = s.SCHOOL_ID WHERE s.SCHOOL_ID = '" + (campus1_drop.SelectedIndex + 1) + "' AND edt.EVENT_TYPE_ID =";
        
        string fetch_weather="", fetch_dateRange="", weather_fetch_COMPLETE="";

        if (percipitation_drop.SelectedIndex > 0 )
        {
            if (percipitation_drop.SelectedIndex == 1)
                fetch_weather += " AND wi.RAINY_IND = 'T' ";
            if (percipitation_drop.SelectedIndex == 2)
                fetch_weather += " AND wi.SUNNY_IND = 'T' ";
            if (percipitation_drop.SelectedIndex ==3)
                fetch_weather += " AND wi.CLOUDY_IND = 'T' ";
        }

        if (temp_drop.SelectedIndex > 0)
        {
            if (temp_drop.SelectedIndex == 1)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN -100 AND 19 ";
            if (temp_drop.SelectedIndex == 2)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 20 AND 32 ";
            if (temp_drop.SelectedIndex == 3)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 33 AND 45 ";
            if (temp_drop.SelectedIndex == 4)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 46 AND 60 ";
            if (temp_drop.SelectedIndex == 5)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 61 AND 75 ";
            if (temp_drop.SelectedIndex == 6)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 76 AND 85 ";
            if (temp_drop.SelectedIndex == 7)
                fetch_weather += " AND wi.TEMPERATURE BETWEEN 86 AND 120 ";
        }



        // if (Date selected)  -- do stuff   
       
        if (arrest_box.Checked)
        {           
            weather_fetch_COMPLETE = weather_fetch_BASE + "'14' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Arrest.png", "This was an arrest!", "arrest");
        }

        if (arson_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'1' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/FireTruck.png", "This was a case of arsen !", "arsen");
        }

        if (assault_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'2' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Assault.png", "This was an assault !", "assault");
        }

        if (rape_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'8' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/storm.png", "This was a rape !", "rape");
        }

        if (robbery_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'9' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Robbery.png", "This was a robbery !", "robbery");
        }

        if (shooting_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'10' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Shooting.png", "This was some kind of shooting!", "shooting");
        }

        if (theft_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'10' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Theft.png", "This was theft!", "theft");
        }

        if (other_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'3' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "Disorderly conduct went down here!", "dc");

            weather_fetch_COMPLETE = weather_fetch_BASE + "'4' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "A drug case!", "drug");

            weather_fetch_COMPLETE = weather_fetch_BASE + "'6' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "Some other crime occured here!", "other");

            weather_fetch_COMPLETE = weather_fetch_BASE + "'11' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/pushpin-yellow.png", "This was a suicide!", "suicide");

            weather_fetch_COMPLETE = weather_fetch_BASE + "'13' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/Vandalism.png", "Vandalism occured here", "vandalism");
        }

        if (murder_box.Checked)
        {
            weather_fetch_COMPLETE = weather_fetch_BASE + "'5' " + fetch_dateRange + fetch_weather;
            Place_Pins(weather_fetch_COMPLETE, "icons/homicide1.gif", "Site of a homicide!", "homicide");
        }

        mb.ShowMessageBox("fetch string result is " + SQL_session.fetch_2params(weather_fetch_COMPLETE, "LOCATION_LAT", "LOCATION_LONG"));

    } // end weather_btn_Click

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
}
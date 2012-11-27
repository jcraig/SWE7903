using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    private GooglePoint GP12 = new GooglePoint();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fromWelcome"] == null)
        {
            Session["fromWelcome"] = "yes";
            GoogleMapForASPNet2.Visible = false;
            Response.Redirect("~/Default.aspx");
        }
        else
            GoogleMapForASPNet2.Visible = true;

        img01.Src="ashx/DrawIt.ashx?width=300&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=40,10, 35, 15;&titles=stabbing,tickling, stabbing, burglary;&";

        if (!IsPostBack)
        {
            //You must specify Google Map API Key for this component. You can obtain this key from http://code.google.com/apis/maps/signup.html
            //For samples to run properly, set GoogleAPIKey in Web.Config file.
            GoogleMapForASPNet2.GoogleMapObject.APIKey = ConfigurationManager.AppSettings["AIzaSyAFdfLkydY34KobaHfiOGzLDbnG-niDhMU"];

            //Specify width and height for map. You can specify either in pixels or in percentage relative to it's container.
            GoogleMapForASPNet2.GoogleMapObject.Width = "800px"; // You can also specify percentage(e.g. 80%) here
            GoogleMapForASPNet2.GoogleMapObject.Height = "600px";

            //Specify initial Zoom level.
            GoogleMapForASPNet2.GoogleMapObject.ZoomLevel = 14;

            //Specify Center Point for map. Map will be centered on this point.
            GoogleMapForASPNet2.GoogleMapObject.CenterPoint = new GooglePoint("1", 43.69, -79.4042);

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
            
            
            GP12.ID = "Halifax";
            GP12.Latitude = 43.66;
            GP12.Longitude = -79.403;
            GP12.InfoHTML = "This is Pushpin 3";
            GP12.IconImage = "icons/Arrest.png";

            GoogleMapForASPNet2.GoogleMapObject.Points.Add(GP12);

        } // end if (!IsPostBack)

    } // end Page_Load

    protected void Map(object sender, EO.Web.NavigationItemEventArgs e)
    {
        // Session["fromWelcome"] = "yes";
    }

    protected void GO_btn_Click(object sender, EventArgs e)
    {
        if (Session["fromWelcome"] == null)
        {
            Session["fromWelcome"] = "yes";
            GoogleMapForASPNet2.Visible = true;
        }
    }
}

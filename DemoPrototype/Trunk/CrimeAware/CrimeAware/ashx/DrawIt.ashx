<%@ WebHandler Language="C#" Class="DrawIt" debug="true" %>
using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public class DrawIt : IHttpHandler
{
 public void ProcessRequest (HttpContext context)
 {
  string    strWidth, strHeight, strBackground, strXaxis, strYaxis, strCaption, strBars, strRectangles;
  string    strChartParms, strChartType, strURL;
  string[]  strChartTypes;
  int       ii, ij, im, intWidth, intHeight, intLeft, intTop, intRight, intBottom;
  int[]     intCoords = new int[4];
  Bitmap    oBmp;
  Color     oColor;
  DrawAll   oDraw;
  Rectangle oRect;

  // Chart Types
  strChartTypes = new string[] {"bullgraph", "circlegraph", "graph", "barchart", "piechart", "points", "squares", "circles", "dots", "bullseyes"};
  
  // Get Request Object
  HttpRequest Request = context.Request;
  
  // Convert input width/height from string to integer
  strWidth   = Request.QueryString.Get("width");
  strHeight  = Request.QueryString.Get("height");
  strWidth   = (strWidth == ""  || strWidth == null ) ? "400" : strWidth;
  strHeight  = (strHeight == "" || strHeight == null) ? "300" : strHeight;
  intWidth   = System.Convert.ToInt32(strWidth);
  intHeight  = System.Convert.ToInt32(strHeight);

  // Get Background Color
  strBackground = Request.QueryString.Get("background");
  strBackground = (strBackground == null || strBackground == "") ? "gray" : strBackground;
  
  // Create Drawing Object
  oDraw      = new DrawAll();

  // Create Chart
  strChartParms = "";
  strChartType  = "";

  strURL = Request.RawUrl;
  strURL.ToLower();  
  for (ii=0;ii<strChartTypes.Length;ii++)
  {
   if (strURL.IndexOf(strChartTypes[ii] + "=") > -1) 
   {
    strChartType  = strChartTypes[ii];
    strChartParms = Request.QueryString.Get(strChartType);
    break;
   }
  }

  if (strChartType != "")
  {
   string   strTemp;
   string[] strTitles;
   int[]    intV;
   int      intLength;

   strChartParms  = strChartParms.Replace(";", "");
   
   // Create intV Array Length Dynamically (count parms)
   intLength = 0;
   strTemp   = strChartParms + ",";
   ii        = strTemp.IndexOf(",");
   while (ii > 0)
   { 
    strTemp = strTemp.Substring(ii + 1);
    ii      = strTemp.IndexOf(",");
    intLength++;
   }
   intV = new int[intLength];

   // Insert converted values into intV
   strTemp = strChartParms + ",";
   for (ii=0;ii<intLength;ii++)
   { 
    ij       = strTemp.IndexOf(",");
    intV[ii] = System.Convert.ToInt32(strTemp.Substring(0, ij));
    strTemp  = strTemp.Substring(ij + 1);
   }

   // Create strTitles Array Length Dynamically (count parms)
   strTemp = Request.QueryString.Get("titles");
   if (strTemp != "" && strTemp != null)
   {
    intLength = 0;
    strTemp   = strTemp.Replace(";","") + ",";
    ii        = strTemp.IndexOf(",");
    while (ii > 0)
    { 
     strTemp = strTemp.Substring(ii + 1);
     ii      = strTemp.IndexOf(",");
     intLength++;
    }
    strTitles = new string[intLength];

    // Insert converted values into intV
    strTemp = Request.QueryString.Get("titles");
    strTemp   = strTemp.Replace(";","") + ",";
    for (ii=0;ii<intLength;ii++)
    { 
     ij            = strTemp.IndexOf(",");
     strTitles[ii] = strTemp.Substring(0, ij);
     strTemp       = strTemp.Substring(ij + 1);
    }
   }
   else {strTitles = new string[0];}
   
  // Create Outside area (marginleft, margintop, marginright, marginbottom)
  strXaxis   = (Request.QueryString.Get("xaxis") == ""    || Request.QueryString.Get("xaxis") == null )   ? "" : Request.QueryString.Get("xaxis");
  strYaxis   = (Request.QueryString.Get("yaxis") == ""    || Request.QueryString.Get("yaxis") == null )   ? "" : Request.QueryString.Get("yaxis");
  strCaption = (Request.QueryString.Get("caption") == ""  || Request.QueryString.Get("caption") == null ) ? "" : Request.QueryString.Get("caption");

  intLeft    = (strYaxis   == "") ? 0 : 80;
  intTop     = (strCaption == "") ? 0 : 50;
  intRight   = (strTitles.Length == 0 || (strChartType.IndexOf("chart") == -1) ) ? 0 : 150;  // Only add space for legend for charts
  intBottom  = (strXaxis   == "") ? 4 : 20;
  oRect      = new Rectangle(intLeft, intTop, intRight, intBottom);
       
  oBmp       = new Bitmap (oRect.Right + intWidth/2 + intWidth/8, oRect.Top + oRect.Height + intHeight, PixelFormat.Format24bppRgb);
   

   if      (strChartType == "piechart") {oBmp = oDraw.drawPieChart (oBmp, oRect, intWidth, intHeight, strBackground, strCaption, intV, strTitles);}
   else if (strChartType == "barchart") {oBmp = oDraw.drawBarChart (oBmp, oRect, intWidth, intHeight, strBackground, strCaption, strXaxis, strYaxis, intV, strTitles);}
   else                                 {oBmp = oDraw.drawGraph    (oBmp, oRect, intWidth, intHeight, strBackground, strCaption, strXaxis, strYaxis, intV, strChartType);}
  }
  else
  {
   // Create Bitmap
   oBmp   = new Bitmap (intWidth, intHeight, PixelFormat.Format24bppRgb);
   oColor = oDraw.colorGet(strBackground);  
   oBmp   = oDraw.clearBmp (oBmp, oColor);
   
   strRectangles = Request.QueryString.Get("rectangles");
   if (strRectangles != "" && strRectangles != null)
   {
    ii = strRectangles.IndexOf(";");
    while (ii > 0)
    { 
     string strRectangle  = strRectangles.Substring(0, ii) + ",";
     strRectangles = strRectangles.Substring(ii + 1);
     ii            = strRectangles.IndexOf(";");
     
     ij = strRectangle.IndexOf(",");
     for (int ik=0;ik<4;ik++)
     {    
      intCoords[ik] = System.Convert.ToInt32(strRectangle.Substring(0, ij));
      strRectangle  = strRectangle.Substring(ij + 1);
      ij            = strRectangle.IndexOf(",");
     }    
     oColor = Color.FromArgb(0,0,0);
     oBmp   = oDraw.drawRectangle (oBmp, intCoords[0], intCoords[1], intCoords[2], intCoords[3], oColor);
    }
   }
   
   strBars = Request.QueryString.Get("bars");
   if (strBars != "" && strBars != null)
   {
    ii = strBars.IndexOf(";");
    while (ii > 0)
    { 
     string strBar = strBars.Substring(0, ii) + ",";
     strBars       = strBars.Substring(ii + 1);
     ii            = strBars.IndexOf(";");
     
     ij = strBar.IndexOf(",");
     for (int ik=0;ik<4;ik++)
     {         
      if (ik < 3) {intCoords[ik] = System.Convert.ToInt32(strBar.Substring(0, ij));}
      else
      {
       oColor = oDraw.colorGet(strBar.Substring(0, ij));
      }
      strBar  = strBar.Substring(ij + 1);
      ij      = strBar.IndexOf(",");
     }    
     oBmp   = oDraw.drawBar (oBmp, intCoords[0], intCoords[1], intCoords[2], oColor);
    }
   }
  }
  
  // Set the context's content type to JPEG files and clear all response headers
  context.Response.ContentType = "image/jpeg";
  context.Response.Clear();
  context.Response.BufferOutput = true;

  oBmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
  context.Response.Flush();
 }

 public bool IsReusable
 {
  get
  {
   return true;
  }
 }
  
}

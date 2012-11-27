using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// Summary description for DrawAll
/// </summary>
public class DrawAll
{
 public DrawAll()
	{
		//
		// TODO: Add constructor logic here
		//
	}

public Bitmap drawGraph (Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, string astrXaxis, string astrYaxis, int[] aintV, string astrType)
 {
  int       ii, intUpb;
  int       intX1, intX2, intY1, intY2;
  Single    sngYMax, sngXMax;
  Graphics oGraphic;
	 Font     oFont;

  oGraphic     = Graphics.FromImage(aoBmp);
	 oFont        = new Font("Small Fonts", 7);

  oGraphic.FillRectangle(brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);

  // Draw axes
  // Note: Y-Axis begins at top !!
  oGraphic.DrawLine(penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left + aintWidth, aoRect.Top + aintHeight - aoRect.Height)); 
  oGraphic.DrawLine(penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left, aoRect.Top + 0));
    
  
  // Write Headers
  writeHeaders(aoRect, oGraphic, astrXaxis, astrYaxis, astrCaption, aintWidth, aintHeight);

  // TBD Tickmarks

  // Set Limit values
  sngXMax = 0;
  sngYMax = 0;
  intUpb  = aintV.Length;
  for (ii=0;ii<intUpb-1;ii=ii+2)
  {
   sngXMax  = (aintV[ii] > sngXMax)   ? aintV[ii]   : sngXMax;
   sngYMax  = (aintV[ii+1] > sngYMax) ? aintV[ii+1] : sngYMax;
  }

  // Diagnostics
  // oGraphic.DrawString("X Max: " + sngXMax.ToString() , oFont, brushGet("black"), new PointF(aintWidth - 100, 1));
  // oGraphic.DrawString("Y Max: " + sngYMax.ToString() , oFont, brushGet("black"), new PointF(aintWidth - 100, 10));

  if (astrType == "graph" || astrType == "bullgraph" || astrType == "circlegraph")
  {
   for (ii=0;ii<intUpb-2;ii=ii+2)
   {
    intY1 = (int) (aoRect.Top + aintHeight - aoRect.Height - ( (aintHeight - 50) * (aintV[ii + 1]/sngYMax)));
    intY2 = (int) (aoRect.Top + aintHeight - aoRect.Height - ( (aintHeight - 50) * (aintV[ii + 3]/sngYMax)));
    intX1 = (int) (aoRect.Left +                ( (aintWidth - aoRect.Left - 10) * (aintV[ii]/sngXMax)));
    intX2 = (int) (aoRect.Left +                ( (aintWidth - aoRect.Left - 10) * (aintV[ii + 2]/sngXMax)));
    // Diagnostics
    // oGraphic.DrawString(astrType, oFont, brushGet("black"), new PointF(aintWidth - 100, 1));
    oGraphic.DrawLine(penGet("black", 1), new Point(intX1, intY1), new Point(intX2, intY2));
   }
  }

  if (astrType == "bullgraph" || astrType == "circlegraph" || astrType == "points" || astrType == "squares" ||  astrType == "circles" ||  astrType == "dots" ||  astrType == "bullseyes" )
  {
   for (ii=0;ii<intUpb-1;ii=ii+2)
   {
    intY1 = (int) (aoRect.Top + aintHeight - aoRect.Height - ( (aintHeight - 50) * (aintV[ii + 1]/sngYMax)));
    intX1 = (int) (aoRect.Left +                ( (aintWidth - aoRect.Left - 10) * (aintV[ii]/sngXMax)));
    if      (astrType == "points" || astrType == "squares")        {oGraphic.DrawRectangle(penGet("blue",2),intX1 - 1, intY1 - 1, 2, 2);}
    else if (astrType == "dots")                                   {oGraphic.DrawRectangle(penGet("black",1),intX1, intY1, 1, 1);}
    else if (astrType == "circles"   || astrType == "circlegraph") {oGraphic.DrawEllipse(penGet("blue",1),intX1 - 2, intY1 - 2, 4, 4);}
    else if (astrType == "bullseyes" || astrType == "bullgraph") 
    {
     oGraphic.DrawRectangle(penGet("black", 1), intX1 - 4, intY1 - 4, 8, 8);
     oGraphic.DrawEllipse(penGet("black",1),intX1 - 3, intY1 - 3, 6, 6);
     oGraphic.DrawLine(penGet("black", 1), new Point(intX1 - 4, intY1 - 4), new Point(intX1 + 4, intY1 + 4));
     oGraphic.DrawLine(penGet("black", 1), new Point(intX1 - 4, intY1 + 4), new Point(intX1 + 4, intY1 - 4));
    }
   }
  }
  return aoBmp;
 }

public Bitmap drawBarChart (Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, string astrXaxis, string astrYaxis, int[] aintV, string[] astrTitles)
{
 Single[]  sngY      = new Single[aintV.Length];
 float     flTotal;
 Single    sngMax;
 int       ii, intUpb, intBarWidth, intLegendHeight, intSpace, intTopOffset, intTop;
 Graphics oGraphic;
 Font     oFont;

 oGraphic     = Graphics.FromImage(aoBmp);
 oFont        = new Font("Small Fonts", 7);
 intTopOffset = (astrCaption == "") ? 4 : 20;

 oGraphic.FillRectangle(brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);

 // Draw axes
 // Note: Y-Axis begins at top !!
 oGraphic.DrawLine(penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left + aintWidth, aoRect.Top + aintHeight - aoRect.Height)); 
 oGraphic.DrawLine(penGet("black", 1), new Point(aoRect.Left, aoRect.Top + aintHeight - aoRect.Height), new Point(aoRect.Left, aoRect.Top + 0));

 // Write Headers
 writeHeaders(aoRect, oGraphic, astrXaxis, astrYaxis, astrCaption, aintWidth, aintHeight);
 
 intUpb          = aintV.Length;
 intSpace        = 10;
 intBarWidth     = (int) ((aintWidth/intUpb) - intSpace);
 intLegendHeight = (int) ((aintHeight/intUpb) - 5);

 // Set Upper Y value
 sngMax  = 1;
 flTotal = 0;
 for (ii=0;ii<intUpb;ii++) 
 {
  sngMax = (aintV[ii] > sngMax) ? aintV[ii] : sngMax;
  flTotal += aintV[ii];
 }
 for (ii=0;ii<intUpb;ii++) {sngY[ii] = (aintV[ii] / sngMax) * (aintHeight - 10);}                // Set Proportional Y values

 // Draw Bars
 for (ii=0;ii<intUpb;ii++) {oGraphic.FillRectangle(brushGet(colorName(ii + 7)), aoRect.Left + intSpace + (intSpace + intBarWidth) * ii, aoRect.Top - intTopOffset + aintHeight - sngY[ii], intBarWidth, sngY[ii]);}

 // Draw Legend
 writeLegend(aoRect, oGraphic, astrCaption, astrTitles, aintV, aintWidth, flTotal);
 
 return aoBmp;
}

public Bitmap drawPieChart (Bitmap aoBmp, Rectangle aoRect, int aintWidth, int aintHeight, string astrBackground, string astrCaption, int[] aintV, string[] astrTitles)
{
 string    strPercent;
 int       ii, intUpb, intLegendHeight, intTopOffset;
 float     flStart, flAngle, flTotal;
 Graphics  oGraphic  = Graphics.FromImage(aoBmp);
 Font      oFont     = new Font("Small Fonts", 7);

 // Clear background
 oGraphic.FillRectangle(brushGet(astrBackground), 0, 0, aoRect.Left + aintWidth + aoRect.Width, aoRect.Top + aintHeight + aoRect.Bottom);

 // Bounding rectangle for PieChart
 Rectangle rect = new Rectangle(10, 10, aintWidth - 20, aintHeight - 20);

 // Draw piechart
 intUpb  = aintV.Length;
 flTotal = 0;
 for (ii=0;ii<intUpb;ii++) {flTotal += aintV[ii];}
 flStart = 0.0F;
 for (ii=0;ii<intUpb;ii++)
 {
  flAngle = (360.0F * aintV[ii]/flTotal);
  oGraphic.FillPie(brushGet(colorName(ii + 7)), rect, flStart, flAngle);
  flStart += flAngle;
 } 

 // Draw Legend
 writeLegend(aoRect, oGraphic, astrCaption, astrTitles, aintV, aintWidth, flTotal);

 return aoBmp;
}
 
 public Bitmap drawBar (Bitmap aoBmp, int aLeft, int aWidth, int aHeight, Color aColor)
 {
  int intX, intY;

  if ((aLeft + aWidth) < aoBmp.Width && aHeight < aoBmp.Height)
  {
   for (intX=aLeft;intX<(aLeft + aWidth);intX++)
   {
    for (intY=aHeight;intY<aoBmp.Height;intY++)  {aoBmp.SetPixel(intX, intY, aColor);}
   }
  }
  return aoBmp;
 }

 public Bitmap drawRectangle (Bitmap aoBmp, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
 {
  int intX, intY;

  for (intX=aLeft;intX<aRight;intX++) 
  {
   aoBmp.SetPixel(intX, aTop,    aColor);
   aoBmp.SetPixel(intX, aBottom, aColor);
  }
  for (intY=aTop;intY<aBottom;intY++) 
  {
   aoBmp.SetPixel(aLeft,  intY, aColor);
   aoBmp.SetPixel(aRight, intY, aColor);
  }
  return aoBmp;
 }

 public Bitmap drawLine (Bitmap aoBmp, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
 {
  int intX, intY, intXdelta, intYdelta;
  decimal decRatio, decPrev;
  
  if (aRight < aoBmp.Width && aBottom < aoBmp.Height)
  {
   intXdelta = aRight  - aLeft;
   intYdelta = aBottom - aTop;   

   // aColor = Color.FromArgb(0,0,0);
   
   if (intXdelta * intYdelta > 0)
   {
    decPrev = 0;
    if (intXdelta >= intYdelta)
    {
     decRatio = intXdelta / intYdelta;
     for (intY=aTop;intY<aBottom;intY++)
     {
      intX = aLeft + (int) decPrev;
      aoBmp.SetPixel(intX, intY, aColor);
      decPrev += decRatio;
     }
    }
    else
    {
     decRatio = intYdelta / intXdelta;
     //  for (intX=aLeft;intX<aRight;intX++)
     for (intX=10;intX<100;intX++)
     {
      intY = aTop + (int) decPrev;
      aoBmp.SetPixel(intX, intY, aColor);
      decPrev += decRatio;
     }
    }
   }
 }
 return aoBmp;
}

 public Bitmap drawEllipse (Bitmap aoBmp, int aWidth, int aLeft, int aTop, int aRight, int aBottom, Color aColor)
{
 Graphics oGraphic = Graphics.FromImage(aoBmp);
 Pen      oPen     = new Pen(aColor, aWidth);

 Rectangle oRect = new Rectangle(aLeft, aTop, aRight, aBottom);
 oGraphic.DrawEllipse(oPen, oRect);

 return aoBmp;
}

public bool writeLegend(Rectangle aoRect, Graphics oGraphic, string astrCaption, string[] astrTitles, int[] aintV, int aintWidth, float flTotal)
{
 // Legend
 int    ii, intTop, intLegendHeight, intTopOffset;
 string strPercent;
 Font   oFont, oFontHeader;
 
 intLegendHeight = 8;
 intTopOffset    = (astrCaption == "") ? 4 : 20;
 oFont           = new Font("Small Fonts", 7);
 oFontHeader     = new Font("Small Fonts", 7, FontStyle.Bold);

 for (ii=0;ii<aintV.Length;ii++)
 {
  strPercent = getPercent(aintV[ii], flTotal);
  intTop     = (astrCaption == "") ? intTopOffset + 10 : aoRect.Top;

  oGraphic.FillRectangle(brushGet(colorName(ii + 7)), aoRect.Left + 10 + aintWidth/2 + aintWidth/5, intTop + (ii * (intLegendHeight + 2)), 25, intLegendHeight);
  oGraphic.DrawString(strPercent + "% ", oFont, brushGet("black"), new PointF(aoRect.Left + 38 + aintWidth/2 + aintWidth/5, intTop - 2 + (ii * (intLegendHeight + 2))));
  if (ii < astrTitles.Length) { oGraphic.DrawString(astrTitles[ii], oFont, brushGet("black"), new PointF(aoRect.Left + 72 + aintWidth/2 + aintWidth/5, intTop - 2 + (ii * (intLegendHeight + 2)))); }
 }

 // Legend Header
 intTopOffset = (astrCaption == "") ? -14 : 0;
 if (astrTitles.Length > 0) { oGraphic.DrawString("Legend", oFontHeader, brushGet("black"), new PointF(aoRect.Left + 8 + aintWidth/2 + aintWidth/5, aoRect.Top - intTopOffset - 14)); }

 return true;
}

public bool writeHeaders(Rectangle aoRect, Graphics oGraphic, string astrXaxis, string astrYaxis, string astrCaption, int aintWidth, int aintHeight)
{
 Font oFontAxis    = new Font("Arial", 8);
 Font oFontCaption = new Font("Arial", 11, FontStyle.Bold);
 
 astrXaxis = astrXaxis.Replace(@"%20", " ");
 if (astrXaxis != "") {oGraphic.DrawString(astrXaxis, oFontAxis, brushGet("black"), new PointF( (aintWidth - 4*astrXaxis.Length)/2, aintHeight + aoRect.Bottom - 20) );}

 astrYaxis = astrYaxis.Replace(@"%20", " ");
 if (astrYaxis != "") {oGraphic.DrawString(astrYaxis, oFontAxis, brushGet("black"), new PointF(4, (aintHeight + aoRect.Top)/2));}

 astrCaption = astrCaption.Replace(@"%20", " ");
 if (astrCaption != "") {oGraphic.DrawString(astrCaption, oFontCaption, brushGet("black"), new PointF((aintWidth - aoRect.Left - 3*astrCaption.Length)/2, 5));}

 return true;
}

 public Bitmap clearBmp (Bitmap aoBmp, Color aColor)
 {
  int intX, intY;

  for (intX=0;intX<aoBmp.Width;intX++)
  {
   for (intY=0;intY<aoBmp.Height;intY++) {aoBmp.SetPixel(intX, intY, aColor);}
  }
  return aoBmp;
 }

 public string colorName(int ai)
 {
  string[]  strColors = {"black", "white", "gray", "grey", "lightgray", "lightgrey", "darkgray", "red", "green", "blue", "yellow", "teal", "cyan", "purple", "brown", "sandybrown", "beige", "tan", "darkgrey", "coral", "plum", "pink", "salmon", "lightsteelblue", "magenta", "maroon", "dodgerblue", "skyblue", "indigo", "navy", "steelblue", "lightsalmon", "blueviolet"};

  return strColors[ai];
 }

 public Color colorGet(string astrColor)
 {
  Color oColor;

  switch (astrColor)
  {
   case "black":
    oColor = Color.Black;
    break;

   case "white":
    oColor = Color.White;
    break;

   case "gray":
   case "grey":
    oColor = Color.Gray;
    break;

   case "lightgray":
   case "lightgrey":
    oColor = Color.LightGray;
    break;

   case "darkgray":
   case "darkgrey":
    oColor = Color.DarkGray;
    break;

   case "red":
    oColor = Color.Red;
    break;

   case "green":
    oColor = Color.Green;
    break;

   case "blue":
    oColor = Color.Blue;
    break;

   case "yellow":
    oColor = Color.Yellow;
    break;

   case "lightyellow":
    oColor = Color.LightYellow;
    break;

   case "teal":
    oColor = Color.Teal;
    break;

   case "cyan":
    oColor = Color.Cyan;
    break;

   case "brown":
    oColor = Color.Brown;
    break;

   case "sandybrown":
    oColor = Color.SandyBrown;
    break;

   case "beige":
    oColor = Color.Beige;
    break;

   case "tan":
    oColor = Color.Tan;
    break;

   case "coral":
    oColor = Color.Coral;
    break;

   case "fuchsia":
    oColor = Color.Fuchsia;
    break;

   case "violet":
    oColor = Color.Violet;
    break;

   case "pink":
    oColor = Color.Pink;
    break;

   case "salmon":
    oColor = Color.Salmon;
    break;

   case "lightsalmon":
    oColor = Color.LightSalmon;
    break;

   case "magenta":
    oColor = Color.Magenta;
    break;

   case "maroon":
    oColor = Color.Maroon;
    break;

   case "plum":
    oColor = Color.Plum;
    break;

   case "powderblue":
    oColor = Color.PowderBlue;
    break;

   case "royalblue":
    oColor = Color.RoyalBlue;
    break;

   case "seashell":
    oColor = Color.SeaShell;
    break;

   case "silver":
    oColor = Color.Silver;
    break;

   case "snow":
    oColor = Color.Snow;
    break;

   case "thistle":
    oColor = Color.Thistle;
    break;

   case "whitesmoke":
    oColor = Color.WhiteSmoke;
    break;

   case "yellowgreen":
    oColor = Color.YellowGreen;
    break;

   case "azure":
    oColor = Color.Azure;
    break;

   case "dodgerblue":
    oColor = Color.DodgerBlue;
    break;

   case "skyblue":
    oColor = Color.SkyBlue;
    break;

   case "indigo":
    oColor = Color.Indigo;
    break;

   case "navy":
    oColor = Color.Navy;
    break;

   case "steelblue":
    oColor = Color.SteelBlue;
    break;

   case "lightsteelblue":
    oColor = Color.LightSteelBlue;
    break;

   case "blueviolet":
    oColor = Color.BlueViolet;
    break;

   case "purple":
    oColor = Color.Purple;
    break;

   default:
    oColor = Color.LightGray;;
    break;
  }
  return oColor;
 }
  
 public SolidBrush brushGet(string astrColor)
 {
  SolidBrush oBrush = new SolidBrush(colorGet(astrColor));
  return oBrush;
 }

 public Pen penGet(string astrColor, int aintWidth)
 {
  Pen oPen = new Pen(colorGet(astrColor), aintWidth);
  return oPen;
 }

 public string getPercent(int aintV, float aflTotal)
 {
  Double dblPercent;
  string strPercent;

  dblPercent = (double) (100*aintV)/aflTotal;
  strPercent = Convert.ToString(dblPercent);

  if (strPercent.IndexOf(".") == -1) {strPercent += ".";}
  strPercent += "000";
  strPercent  = strPercent.Substring(0, strPercent.IndexOf(".") + 3);

  return strPercent;
 }
}

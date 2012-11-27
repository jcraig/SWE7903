<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
 .mini   {font-family: Small Fonts, Smalls;        font-size: 7pt; text-align: left;}
 .minir  {font-family: Small Fonts, Smalls;        font-size: 7pt; text-align: right;}
 .avg    {font-family: Arial, Verdana, Sans-Serif; font-size: 8pt; text-align: left;}
 .red    {font-family: Arial, Verdana, Sans-Serif; font-size: 8pt; color: #FF0000; font-weight: 800;}
    #top_margin_div
    {
        height: 100px;
    }
    #Div1
    {
        height: 338px;
    }
    #welcome_div
    {
        height: 513px;
    }
 </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

     <div id="top_margin_div" >  
         <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
             Visible="False" Width="168px" />
     </div>  
   <asp:Panel ID="Welcome_panel" runat="server" Height="703px" 
    BackImageUrl="~/rsrcs/images/dots1.gif"> 
        
        <div id="welcome_div"  style="float:left; height: 570px; width: 1324px;"> 
         
        <div style="float:left; height: 512px; width: 80px;"></div>
        <div style="float:left; height: 512px; width: 249px; background-image: url('rsrcs/images/cubes_x2d.gif'); background-repeat: no-repeat;"></div>
        <div style="float:left; height: 562px; width: 566px; background-color: #FFFFFF;">
            <br />
            <asp:Image ID="Image1" runat="server" Height="116px" Width="555px" 
                ImageUrl="~/rsrcs/images/welcome.png" />
            <br />
            <br />
            <br />
            <asp:Image ID="aware_question" runat="server" Height="98px" Width="472px" 
                ImageUrl="~/rsrcs/images/aware.png" />
            <br />
            <br />
               
               <center><embed src="http://www.satisfaction.com/photo-cube-generator/show.swf?baseURL=http://www.satisfaction.com/photo-cube-generator/&clickURL=Duplicate.aspx/&flashLABEL=Gain Awareness&clickLABEL=Photo Cube Generator&file=http%3A%2F%2Fwww%2Esatisfaction%2Ecom%2Fphoto%2Dcube%2Dgenerator%2Fuploads%2F21%5F11%5F2012%2F15%2Fpic61859597%2Egif" quality="high" bgcolor="#ffffff" width="300" height="250" name="show" align="middle" wmode="transparent" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" /></center>
            </div>
        <div style="float:left; height: 510px; width: 248px; background-image: url('rsrcs/images/cubes_x2d.gif'); background-repeat: no-repeat;"></div>
         
       </div>
        
     </asp:Panel>
    
</asp:Content>

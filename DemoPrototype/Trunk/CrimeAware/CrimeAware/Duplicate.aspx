<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Duplicate.aspx.cs" Inherits="Duplicate" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
 .mini   {font-family: Small Fonts, Smalls;        font-size: 7pt; text-align: left;}
 .minir  {font-family: Small Fonts, Smalls;        font-size: 7pt; text-align: right;}
 .avg    {font-family: Arial, Verdana, Sans-Serif; font-size: 8pt; text-align: left;}
 .red    {font-family: Arial, Verdana, Sans-Serif; font-size: 8pt; color: #FF0000; font-weight: 800;}
    #Tabtop_margin_div
    {
        height: 49px;
    }
    #Tabtop_margin_div2
    {
        height: 129px;
    }
        #main_div
        {
            height: 610px;
        }
        #tabs_div
        {
            height: 32px;
        }
        #tabButtons_div
        {
            
        }
 </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/css" language="javascript">  

     function f_load_image(ai) {
         var ls_href;

         ls_href = document.getElementById("theurl0" + ai).value;
         document.getElementById("img0" + ai).src = ls_href;
     }

     function f_example(aobj) {
         document.getElementById('theurl01').value = aobj.value;
         f_load_image(1);
     }
    
    </script>
       

   <asp:Panel ID="Panel1" runat="server" Height="861px"  >  
    <div id="Tabtop_margin_div2" >  </div>  
          <div id="tabs_div" style="float:left; height: 30px; width:1267px" >  
          <div id="tabSpacer_div" style="float:right; height: 30px; width:58px"> </div>
          <div id="tabButtons_div" 
                  
                  style="border-style: dashed dashed none none; border-width: 1px; border-color: #000000; float:right; height: 30px; width:298px">
          <asp:Button ID="map_btn" runat="server" Text="Map" Font-Bold="True" 
                  Font-Names="Rockwell Extra Bold" Font-Size="Medium" Height="30px" 
                  Width="69px" onclick="map_btn_Click" />
              <asp:Button ID="stat_btn" runat="server" onclick="stat_btn_Click" 
                  Text="Statistics" Width="112px" CausesValidation="False" Font-Bold="True" 
                  Font-Names="Rockwell Extra Bold" Font-Size="Medium" Height="30px" />          
              <asp:Button ID="compare_btn" runat="server" Text="Compare" Width="104px" 
                  Font-Bold="True" Font-Names="Rockwell Extra Bold" Font-Size="Medium" 
                  Height="30px" onclick="compare_btn_Click" />             
          </div> 
           <div id="Div1" 
                  style="border-color: #000000; border-style: none dashed dashed none; border-width: 1px; float:right; height: 30px; width:640px">
               <asp:Button ID="db_test_btn" runat="server" onclick="db_test_btn_Click" 
                   Text="DB Test" Width="195px" />
               &nbsp;
               <asp:Button ID="db_test2_btn" runat="server" Font-Bold="True" 
                   onclick="db_test2_btn_Click" Text="DB Test (joins)" Width="140px" />
               &nbsp;<asp:DropDownList ID="crime_drop" runat="server" Height="19px" 
                   Width="131px">
                   <asp:ListItem Value="1">Arson</asp:ListItem>
                   <asp:ListItem Value="2">Asssault</asp:ListItem>
                   <asp:ListItem Value="3">Disorderly C</asp:ListItem>
                   <asp:ListItem Value="4">Drugs</asp:ListItem>
                   <asp:ListItem Value="5">Homicide</asp:ListItem>
                   <asp:ListItem Value="6">Other</asp:ListItem>
                   <asp:ListItem Value="7">Public Intoxication</asp:ListItem>
                   <asp:ListItem Value="8">Rape</asp:ListItem>
                   <asp:ListItem Value="9">Robbery</asp:ListItem>
                   <asp:ListItem Value="10">Shooting</asp:ListItem>
                   <asp:ListItem Value="11">Suicide</asp:ListItem>
                   <asp:ListItem Value="12">Theft</asp:ListItem>
                   <asp:ListItem Value="13">Vandalism</asp:ListItem>
               </asp:DropDownList>
              </div> 
          </div>
          
                <div id="main_div" 
           style="float:left; width:1400px; background-image: none;">
                <div id="filters_div"                        
                        style="float:left; width: 242px; height: 591px; border-left-style: dashed; border-left-width: 1px; border-right-style: none; border-right-width: 1px; border-top-style: dashed; border-top-width: 1px; border-bottom-style: dashed; border-bottom-width: 1px;">
                    <br />
                    &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" 
                        Font-Size="Medium" ForeColor="#00006F" 
                        style="text-decoration: underline; font-size: x-large" Text="Filter Criteria"></asp:Label>
                    <br />
                    <br />
                    <br />
&nbsp;
                    <asp:DropDownList ID="campus1_drop" runat="server" Height="26px" Width="156px">
                        <asp:ListItem>SPSU</asp:ListItem>
                        <asp:ListItem>Georgia Tech</asp:ListItem>
                        <asp:ListItem>UGA</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
&nbsp;
                    <asp:Label ID="date_lbl" runat="server" Font-Names="Eras Demi ITC" 
                        Font-Size="Medium" ForeColor="Black" Text="Date Range - 2012"></asp:Label>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="from_lbl" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="#333333" Text="from -&gt;"></asp:Label>
                    &nbsp;&nbsp;<asp:DropDownList ID="from_drop" runat="server" Height="26px" 
                        Width="144px">
                        <asp:ListItem>January</asp:ListItem>
                        <asp:ListItem>February</asp:ListItem>
                        <asp:ListItem>March</asp:ListItem>
                        <asp:ListItem>April</asp:ListItem>
                        <asp:ListItem>May</asp:ListItem>
                        <asp:ListItem>June</asp:ListItem>
                        <asp:ListItem>July</asp:ListItem>
                        <asp:ListItem>August</asp:ListItem>
                        <asp:ListItem>September</asp:ListItem>
                        <asp:ListItem>October</asp:ListItem>
                        <asp:ListItem>November</asp:ListItem>
                        <asp:ListItem>December</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    &nbsp;&nbsp;
                    <asp:Label ID="to_lbl" runat="server" Font-Bold="True" Font-Size="Small" 
                        ForeColor="#666666" Text="to          -&gt;"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="to_drop" runat="server" Height="26px" Width="143px">
                     <asp:ListItem>January</asp:ListItem>
                        <asp:ListItem>February</asp:ListItem>
                        <asp:ListItem>March</asp:ListItem>
                        <asp:ListItem>April</asp:ListItem>
                        <asp:ListItem>May</asp:ListItem>
                        <asp:ListItem>June</asp:ListItem>
                        <asp:ListItem>July</asp:ListItem>
                        <asp:ListItem>August</asp:ListItem>
                        <asp:ListItem>September</asp:ListItem>
                        <asp:ListItem>October</asp:ListItem>
                        <asp:ListItem>November</asp:ListItem>
                        <asp:ListItem>December</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />                    
                    <div style="height: 20px; margin-left: 8px">
                    <div style="float:right; width:176px; height:20px">
                    <asp:Label ID="weather_lbl" runat="server" Font-Names="MV Boli" Font-Size="Large" ForeColor="Black" Text="Weather:" Font-Bold="True"></asp:Label> 
                        </div>
                        </div>
                        <div style="margin-left: 8px"> 
                        <div style="float:right; width:118px; height:14px"> 
                            <asp:Label ID="temp_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Small" ForeColor="#292929"  Text="Temperature"></asp:Label>
                            </div>
                            <asp:Label ID="percipitation_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Small" ForeColor="#292929" Text="Percipitation"></asp:Label>
                        </div>
                     <div style="height: 24px; margin-left: 8px; margin-top:5px">
                    <asp:DropDownList ID="percipitation_drop" runat="server" Height="20px" Width="100px">
                        <asp:ListItem>Any</asp:ListItem>
                        <asp:ListItem>Rainy</asp:ListItem>
                        <asp:ListItem>Sunny</asp:ListItem>
                        <asp:ListItem>Cloudy</asp:ListItem>
                    </asp:DropDownList>
                         &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="temp_drop" runat="server" Height="20px" Width="100px">
                            <asp:ListItem>Any</asp:ListItem>
                            <asp:ListItem Value="-50 AND 19">19 &amp; below</asp:ListItem>
                            <asp:ListItem Value="20 AND 32">20-32</asp:ListItem>
                            <asp:ListItem Value="33 AND 45">33 - 45</asp:ListItem>
                            <asp:ListItem Value="46 AND 60">46 - 60</asp:ListItem>
                            <asp:ListItem Value="61 AND 75">61 - 75</asp:ListItem>
                            <asp:ListItem Value="76 AND 85">76 - 85</asp:ListItem>
                            <asp:ListItem Value="86 AND 130">86 &amp; up</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="weather_btn" runat="server" onclick="weather_btn_Click" 
                        Text="GO" Width="120px" />
                    <br />
                    <br />
                    &nbsp;
                    <asp:Label ID="crimeType_lbl" runat="server" Font-Names="Eras Demi ITC" 
                        Font-Size="Medium" ForeColor="Black" Text="Crime Type:"></asp:Label>
                    <br />
                    <br />
                    <div style="height: 24px" >
                    <div style="float:left; width:80px; height:24px">
                        &nbsp;&nbsp;
                    <asp:CheckBox ID="arrest_box" runat="server" ForeColor="Black" Text=" Arrest" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="arson_box" runat="server" ForeColor="Black" Text=" Arson" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="assault_box" runat="server" ForeColor="Black" Text=" Assault" />
                    </div>
                    </div>

                   <div style="height: 24px; margin-top:8px;" >
                    <div style="float:left; width:80px; height:24px">
                        &nbsp;&nbsp;
                    <asp:CheckBox ID="rape_box" runat="server" ForeColor="Black" Text=" Rape" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="robbery_box" runat="server" ForeColor="Black" Text=" Robbery" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="shooting_box" runat="server" ForeColor="Black" Text=" Shooting" />
                    </div>
                    </div>

                    <div style="height: 24px; margin-top:8px;" >
                    <div style="float:left; width:80px; height:24px">
                        &nbsp;&nbsp;
                    <asp:CheckBox ID="theft_box" runat="server" ForeColor="Black" Text=" Theft" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="other_box" runat="server" ForeColor="Black" 
                            Text="Other" />
                    </div>
                    <div style="float:left; width:80px; height:24px">
                    <asp:CheckBox ID="murder_box" runat="server" ForeColor="Black" Text=" Murder" />
                    </div>
                    </div>

                    <div style="height: 24px; margin-top:8px;" >
                    <div style="float:left; width:80px; height:24px">
                        &nbsp;&nbsp;                    
                        <asp:Button ID="all_btn" runat="server" Height="20px" Text="All" Width="58px" 
                            Font-Italic="True" Font-Names="Bookman Old Style" onclick="all_btn_Click" />                    
                    </div>
                    <div style="float:left; width:80px; height:24px">                    
                    </div>
                    <div style="float:left; width:80px; height:24px">                   
                        <asp:Button ID="clear_btn" runat="server" Height="20px" Text="Clear" 
                            Width="58px" Font-Italic="True" Font-Names="Bookman Old Style" 
                            onclick="clear_btn_Click" />
                    </div>
                    </div>

                <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="GO_btn" runat="server" Text="GO" 
                    Width="114px" onclick="GO_btn_Click" Font-Bold="True" />
                
            </div>  <!-- end filters_div -->
              <div id="spacer_div"                        
                        
                        style="float:left; width: 18px; height: 591px; border-left-style: dashed; border-left-width: 1px; border-right-style: none; border-right-width: 1px; border-top-style: dashed; border-top-width: 1px; border-bottom-style: dashed; border-bottom-width: 1px; background-color: #C0C0C0;">
                        </div>
                        <div id="whitespacer_div"                        
                        
                        
                        style="border-style: dashed none dashed dashed; float:left; width: 8px; height: 591px; border-left-width: 1px; border-right-width: 1px; border-top-width: 1px; border-bottom-width: 1px; ">
                        </div>
            <div id="Tab_content_div"                         
                        style=" border-right: 1px dashed #171717; border-top: 1px none #171717; border-bottom: 1px dashed #171717; float:left; width: 937px; height: 592px;">
                &nbsp;
                <br />
                &nbsp;&nbsp;
               <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Crimson"></asp:Label>  
        <br /><br />  
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet2" runat="server" visible="true"/>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                   <img ID="img01" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=350&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=20,30,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    </asp:View>
                    <asp:View ID="View3" runat="server">               
                    <img ID="img4" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=20,30,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    <img ID="img5" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=50,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    </asp:View>
                </asp:MultiView>
            </div>
             
            </div>  <!-- end main_div -->
                 
                                                   
                          
    </asp:Panel>
    
</asp:Content>

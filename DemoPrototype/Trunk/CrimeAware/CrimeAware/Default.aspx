<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register assembly="EO.Web" namespace="EO.Web" tagprefix="eo" %>

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
        height: 35px;
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

       
   <asp:Panel ID="Panel1" runat="server" Height="960px"  >  
    <div id="Tabtop_margin_div2" >  </div>  
         
         <eo:Splitter ID="Splitter2" runat="server" 
    BorderColor="#BED6E0" BorderStyle="Solid" BorderWidth="1px" 
    ControlSkinID="None" DividerCenterImage="00080402" DividerImage="00080401" 
    DividerSize="11" Height="688px" Width="1150px">
            <eo:SplitterPane ID="SplitterPane1" runat="server" Height="250px" Width="327px" >
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#00006F" style="text-decoration: underline; font-size: x-large" 
                    Text="Filter Criteria"></asp:Label>
                <br />
                <br />
                <br />
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="26px" 
                    Width="156px">
                    <asp:ListItem>Campus 1</asp:ListItem>
                    <asp:ListItem>Campus 2</asp:ListItem>
                    <asp:ListItem>Campus 3</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="Small">
                    <asp:ListItem>Stabbing</asp:ListItem>
                    <asp:ListItem>Burglary</asp:ListItem>
                    <asp:ListItem>Arrest</asp:ListItem>
                    <asp:ListItem>Tickling</asp:ListItem>
                    <asp:ListItem>Vandalism</asp:ListItem>
                    <asp:ListItem>Theft</asp:ListItem>
                    <asp:ListItem>Assault</asp:ListItem>
                    <asp:ListItem>Robbery</asp:ListItem>
                    <asp:ListItem>Shooting</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="GO_btn" runat="server" Text="GO" 
                    Width="114px" onclick="GO_btn_Click" />
                <br />
            </eo:SplitterPane>
            <eo:SplitterPane ID="SplitterPane2" runat="server" Height="250px" Width="666px" BackImageUrl="~/rsrcs/images/cubes1.gif">
                
                <eo:TabStrip ID="MultiView" runat="server" ControlSkinID="None" 
                    MultiPageID="MultiPage1" Width="95%" TopLevelItemAlign="Right" onitemclick="Map" >
                    <LookItems>
                        <eo:TabItem Height="16" ItemID="_Default" LeftIcon-SelectedUrl="00010605" 
                            LeftIcon-Url="00010604" 
                            NormalStyle-CssText="background-image: url(00010602); background-repeat: repeat-x; font-weight: normal; color: black;" 
                            RightIcon-SelectedUrl="00010607" RightIcon-Url="00010606" 
                            SelectedStyle-CssText="background-image: url(00010603); background-repeat: repeat-x; font-weight: bold; color: #ff7e00;" 
                            Text-Padding-Bottom="6" Text-Padding-Top="6">
                            <SubGroup ItemSpacing="0" 
                                Style-CssText="background-image:url(00010601);background-position-y:bottom;background-repeat:repeat-x;color:black;cursor:hand;font-family:Verdana;font-size:12px;">
                            </SubGroup>
                        </eo:TabItem>
                    </LookItems>
                    <TopGroup Orientation="Horizontal" 
                        
                        Style-CssText="border-bottom-style:none;border-left-style:none;border-left-width:2px;border-right-style:none;border-right-width:2px;border-top-style:none;border-top-width:2px;">
                        <Items>
                            <eo:TabItem Text-Html="Map">
                            </eo:TabItem>
                            <eo:TabItem Text-Html="Compare">
                            </eo:TabItem>
                            <eo:TabItem Text-Html="Statistics">
                            </eo:TabItem>
                        </Items>
                    </TopGroup>
                </eo:TabStrip>
                <eo:MultiPage ID="MultiPage1" 
                    style="border-left: #7f9db9 2px solid; border-right: #7f9db9 2px solid; border-bottom: #7f9db9 2px solid;" 
                    runat="server" Height="303px" Width="95%" >
                <eo:PageView ID="map_PageView1" runat="server" Width="100%" Font-Names="Tahoma" 
                        Height="66px">
                    <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet2" runat="server" visible="true"/>
                    </eo:PageView>
                    <eo:PageView ID="compare_PageView2" runat="server" Width="100%" Height="66px">
                        <img ID="img2" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=20,30,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                        <img ID="img3" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=50,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    </eo:PageView>
                    <eo:PageView ID="statistics_PageView3" runat="server" Width="100%" 
                        Height="85px">                    
                          <img ID="img01" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=350&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=20,30,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    </eo:PageView>
                </eo:MultiPage>
            </eo:SplitterPane>
        </eo:Splitter>
</asp:Panel>
    
</asp:Content>

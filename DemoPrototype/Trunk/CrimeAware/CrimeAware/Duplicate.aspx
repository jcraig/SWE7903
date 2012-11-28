<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Duplicate.aspx.cs" Inherits="Duplicate" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
    <asp:Panel ID="Panel1" runat="server">
        <div id="tabs_div" style="position: relative; height: 30px; right: 0px;">
            <div id="tabButtons_div" style="position: absolute; right: 1em;">
                <asp:Button ID="map_btn" class="button" runat="server" OnClick="map_btn_Click" Text="Map" />
                <asp:Button ID="stat_btn" class="button" runat="server" OnClick="stat_btn_Click"
                    Text="Statistics" />
                <asp:Button ID="compare_btn" class="button" runat="server" OnClick="compare_btn_Click"
                    Text="Compare" />
            </div>
        </div>
        <div id="main_div">
            <div id="filters_div" style="position: absolute; width: 24em; height: 100%; overflow: auto;">
                &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium"
                    ForeColor="#00006F" Style="text-decoration: underline; font-size: x-large" Text="Filter Criteria"></asp:Label>
                <asp:Button class="button" ID="GO_btn" runat="server" Text="Update" Width="114px"
                    OnClick="GO_btn_Click" Font-Bold="True" />
                <div id="filter_content_div">
                    <div id="filter_content_items_div">
                        <asp:DropDownList ID="campus1_drop" runat="server" Height="26px" Width="156px" />
                        <asp:Label ID="date_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Medium"
                            ForeColor="Black" Text="Date Range - 2012"></asp:Label>
                        <asp:Label ID="from_lbl" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#333333"
                            Text="from -&gt;"></asp:Label>
                        <asp:DropDownList ID="from_drop" runat="server" Height="26px" Width="144px" />
                        <asp:Label ID="to_lbl" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#666666"
                            Text="to          -&gt;"></asp:Label>
                        <asp:DropDownList ID="to_drop" runat="server" Height="26px" Width="143px" />
                        <div style="height: 20px; margin-left: 8px">
                            <div style="float: right; width: 176px; height: 20px">
                                <asp:Label ID="weather_lbl" runat="server" Font-Names="MV Boli" Font-Size="Large"
                                    ForeColor="Black" Text="Weather:" Font-Bold="True"></asp:Label>
                            </div>
                        </div>

                        <div style="margin-left: 8px">
                            <div style="float: right; width: 118px; height: 14px">
                                <asp:Label ID="temp_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Small"
                                    ForeColor="#292929" Text="Temperature"></asp:Label>
                            </div>
                            <asp:Label ID="percipitation_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Small"
                                ForeColor="#292929" Text="Percipitation"></asp:Label>
                        </div>

                        <div style="height: 24px; margin-left: 8px; margin-top: 5px">
                            <asp:DropDownList ID="percipitation_drop" runat="server" Height="20px" Width="100px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="temp_drop" runat="server" Height="20px" Width="100px" />
                        </div>

                        <asp:Label ID="crimeType_lbl" runat="server" Font-Names="Eras Demi ITC" Font-Size="Medium"
                            ForeColor="Black" Text="Crime Type:"></asp:Label>
                        <asp:CheckBoxList ID="crimeType_clb" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" />
                        <asp:Button ID="all_btn" runat="server" Text="All" OnClick="all_btn_Click" />
                        <asp:Button ID="clear_btn" runat="server" Text="Clear" OnClick="clear_btn_Click" />

                    </div>
                </div>
            </div>
            <!-- end filters_div -->
            <div id="Tab_content_div" class="dash-border" style="position: absolute; top: 30px;
                bottom: 0px; right: 0px; left: 28em;">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet2" runat="server" Visible="true" />
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Title1" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                    LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Default" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <img id="img4" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=20,30,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                        <img id="img5" alt="chart of crime percentages" runat="server" src="ashx/DrawIt.ashx?width=320&height=250&xaxis=pushes&yaxis=pulls&background=powderblue&piechart=50,10,10,25,5;&titles=one,two,three,four,five,six,seven,eight,nine,ten;&" />
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
        <!-- end main_div -->
    </asp:Panel>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar.ascx.cs" Inherits="Calendar"  %>

<asp:Panel  ID="Panel1" runat="server" Height="493px" Width="199px" 
    BorderColor="#666666" BorderStyle="Ridge" 
    style="font-size: xx-small; background-color: #FEF9ED; margin-top: 13px; margin-bottom: 0px;" >
<div style="float:left; height: 17px; width:173px; margin-top:0px"> 
            
            <asp:Label ID="startDT_label" runat="server" Font-Bold="True" Font-Italic="True" 
                Text="Start Date:" ForeColor="#32785A" Font-Size="Small"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="today_lbl" runat="server" Font-Bold="True" 
                Font-Size="Small" ForeColor="#51AEAC"   ></asp:Label> </div>                    

            <div id = "startCalendarSection" runat="server"
                style="float:left; height: 205px; width: 193px; margin-left: 0px">
                <asp:Calendar ID="start_calendar" runat="server" BackColor="White" 
                    BorderColor="#999999"  AutoPostBack="False"
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="85px" 
                    Width="166px" CellPadding="4" DayNameFormat="Shortest" 
                    onselectionchanged="start_calendar_SelectionChanged" ViewStateMode="Enabled">
                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                <!--/end start time div-->
                &nbsp;</div>
                
                <div style="height: 37px">
                <div style="float:left; height: 17px; width: 164px; margin-top: 16px;">
                 <asp:Label ID="end_lbl" runat="server" Font-Bold="True" Font-Italic="True" 
                Text="End Date:" ForeColor="#9C2338" Font-Size="Small"></asp:Label>
                </div>
                </div>
                  <div id="dueDiv" runat="server" 
                style="float:left; height: 197px; width:170px; margin-right: 0px;">
                    <asp:Calendar ID="due_calendar" runat="server" BackColor="White" 
                        BorderColor="#999999"  
                        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="85px" 
                        Width="166px" CellPadding="4" DayNameFormat="Shortest" 
                          ViewStateMode="Enabled">
                        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <!-- end dueTime div -->  
            </div>
            </asp:Panel>

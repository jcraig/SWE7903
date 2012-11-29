<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calendar.ascx.cs" Inherits="Calendar" %>

<asp:Panel  ID="Panel1" runat="server" Height="563px" Width="199px" 
    BorderColor="#666666" BorderStyle="Ridge" 
    
    
    
    
    
    
    
    
    style="font-size: xx-small; background-color: #FEF9ED; margin-top: 13px; margin-bottom: 0px;" >
<div style="float:left; height: 17px; width:173px; margin-top:0px"> 
            
            <asp:Label ID="startDT_label" runat="server" Font-Bold="True" Font-Italic="True" 
                Text="Start Date:" ForeColor="#32785A" Font-Size="Small"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="today_lbl" runat="server" Font-Bold="True" 
                Font-Size="Small" ForeColor="#51AEAC"   ></asp:Label> </div>                    

            <div id = "startCalendarSection" runat="server"
                style="float:left; height: 246px; width: 193px; margin-left: 0px">
                <asp:Calendar ID="start_calendar" runat="server" BackColor="White" 
                    BorderColor="#999999" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="85px" 
                    Width="166px" CellPadding="4" DayNameFormat="Shortest">
                    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
                <div id="startTime_div" 
                        style="height: 23px; margin-top: 6px; width: 164px; margin-left: 3px;"> 
                        <asp:DropDownList ID="startTime_drop" runat="server" Height="25px" 
                            Width="140px" style="margin-left: 0px">
                            <asp:ListItem Value="8">  8:00 am</asp:ListItem>
                            <asp:ListItem Value="8.5">  8:30 am</asp:ListItem>
                            <asp:ListItem Value="9">  9:00 am</asp:ListItem>
                            <asp:ListItem Value="9.5">  9:30 am</asp:ListItem>
                            <asp:ListItem Value="10">  10:00 am</asp:ListItem>
                            <asp:ListItem Value="10.5">  10:30 am</asp:ListItem>
                            <asp:ListItem Value="11">  11:00 am</asp:ListItem>
                            <asp:ListItem Value="11.5">  11:30 am</asp:ListItem>
                            <asp:ListItem Value="12">  12:00 pm</asp:ListItem>
                            <asp:ListItem Value="12.5">  12:30 pm</asp:ListItem>
                            <asp:ListItem Value="13">  1:00 pm</asp:ListItem>
                            <asp:ListItem Value="13.5">  1:30 pm</asp:ListItem>
                            <asp:ListItem Value="14">  2:00 pm</asp:ListItem>
                            <asp:ListItem Value="14.5">  2:30 pm</asp:ListItem>
                            <asp:ListItem Value="15">  3:00 pm</asp:ListItem>
                            <asp:ListItem Value="15.5">  3:30 pm</asp:ListItem>
                            <asp:ListItem Value="16">  4:00 pm</asp:ListItem>
                            <asp:ListItem Value="16.5">  4:30 pm</asp:ListItem>
                            <asp:ListItem Value="17">  5:00 pm</asp:ListItem>
                            <asp:ListItem Value="17.5">  5:30 pm</asp:ListItem>
                            <asp:ListItem Value="18">  6:00 pm</asp:ListItem>
                            <asp:ListItem Value="18.5">  6:30 pm</asp:ListItem>
                            <asp:ListItem Value="19">  7:00 pm</asp:ListItem>
                            <asp:ListItem Value="19.5">  7:30 pm</asp:ListItem>
                            <asp:ListItem Value="20">  8:00 pm </asp:ListItem>
                            <asp:ListItem Value="20.5">  8:30 pm</asp:ListItem>
                            <asp:ListItem Value="21">  9:00 pm</asp:ListItem>
                            <asp:ListItem Value="21.5">  9:30 pm</asp:ListItem>
                            <asp:ListItem Value="22">  10:00 pm</asp:ListItem>
                            <asp:ListItem Value="22.5">  10:30 pm</asp:ListItem>
                            <asp:ListItem Value="23">  11:00 pm</asp:ListItem>
                            <asp:ListItem Value="23.5">  11:30 pm</asp:ListItem>
                     </asp:DropDownList>
                      &nbsp;
                      </div>
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
                        Width="166px" CellPadding="4" DayNameFormat="Shortest">
                        <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                    <div id="due time" 
                            
                        style="height: 22px; margin-top: 0px; width: 154px; margin-left: 3px;" >
                        <asp:DropDownList ID="dueTime_drop" runat="server" Height="25px" Width="140px">
                            <asp:ListItem Value="8">  8:00 am</asp:ListItem>
                            <asp:ListItem Value="8.5">  8:30 am</asp:ListItem>
                            <asp:ListItem Value="9">  9:00 am</asp:ListItem>
                            <asp:ListItem Value="9.5">  9:30 am</asp:ListItem>
                            <asp:ListItem Value="10">  10:00 am</asp:ListItem>
                            <asp:ListItem Value="10.5">  10:30 am</asp:ListItem>
                            <asp:ListItem Value="11">  11:00 am</asp:ListItem>
                            <asp:ListItem Value="11.5">  11:30 am</asp:ListItem>
                            <asp:ListItem Value="12">  12:00 pm</asp:ListItem>
                            <asp:ListItem Value="12.5">  12:30 pm</asp:ListItem>
                            <asp:ListItem Value="13">  1:00 pm</asp:ListItem>
                            <asp:ListItem Value="13.5">  1:30 pm</asp:ListItem>
                            <asp:ListItem Value="14">  2:00 pm</asp:ListItem>
                            <asp:ListItem Value="14.5">  2:30 pm</asp:ListItem>
                            <asp:ListItem Value="15">  3:00 pm</asp:ListItem>
                            <asp:ListItem Value="15.5">  3:30 pm</asp:ListItem>
                            <asp:ListItem Value="16">  4:00 pm</asp:ListItem>
                            <asp:ListItem Value="16.5">  4:30 pm</asp:ListItem>
                            <asp:ListItem Value="17">  5:00 pm</asp:ListItem>
                            <asp:ListItem Value="17.5">  5:30 pm</asp:ListItem>
                            <asp:ListItem Value="18">  6:00 pm</asp:ListItem>
                            <asp:ListItem Value="18.5">  6:30 pm</asp:ListItem>
                            <asp:ListItem Value="19">  7:00 pm</asp:ListItem>
                            <asp:ListItem Value="19.5">  7:30 pm</asp:ListItem>
                            <asp:ListItem Value="20">  8:00 pm </asp:ListItem>
                            <asp:ListItem Value="20.5">  8:30 pm</asp:ListItem>
                            <asp:ListItem Value="21">  9:00 pm</asp:ListItem>
                            <asp:ListItem Value="21.5">  9:30 pm</asp:ListItem>
                            <asp:ListItem Value="22">  10:00 pm</asp:ListItem>
                            <asp:ListItem Value="22.5">  10:30 pm</asp:ListItem>
                            <asp:ListItem Value="23">  11:00 pm</asp:ListItem>
                            <asp:ListItem Value="23.5">  11:30 pm</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- end dueTime div -->  
            </div>
            </asp:Panel>

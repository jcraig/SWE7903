using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calendar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void start_calendar_SelectionChanged(object sender, EventArgs e)
    {

    }

    public DateTime getStart_date()
    {
        DateTime start = start_calendar.SelectedDate;
        return start;
    }

    public DateTime getEnd_date()
    {
        DateTime end = due_calendar.SelectedDate;
        return end;
    }
}
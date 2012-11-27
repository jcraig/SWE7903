 <TABLE>
  <TR>
   <TD CLASS="mini">
    In order to use graphics simply add the following files to your project with the respective folders:
   </TD>
  </TR>
   
  <TR>
   <TD CLASS="mini">
    <TABLE>
     <TR><TD CLASS="mini"><IMG SRC="rsrcs/images/pc_open.gif" /></TD><TD CLASS="mini"><B>ashx</B></TD></TR>
     <TR>   
      <TD CLASS="mini"></TD>
      <TD CLASS="mini">
       <TABLE>
        <TR><TD CLASS="mini" STYLE="padding-right: 20px;">DrawIt.ashx</TD><TD CLASS="mini">UI interface for Graphics</TD></TR>
        <TR><TD CLASS="mini" STYLE="padding-right: 20px;">Images.ashx</TD><TD CLASS="mini">UI interface for Database Images</TD></TR>
        <TR>
         <TD CLASS="mini" STYLE="padding-right: 20px;"></TD>
         <TD CLASS="mini">
          You need to edit the <B>SQL</B> and <B>Connection</B> parameters in <B>Images.ashx</B> to get images from the relavent table in your database
          <BR />Likewise, in the <B>SRC</B> attribute the selection parameter(s) required in your SQL must be altered accordingly
         </TD>
        </TR>
       </TABLE>   
      </TD>
     </TR>   
    </TABLE>
   </TD>
  </TR>
  
  <TR>
   <TD CLASS="mini">
    <TABLE>
     <TR><TD CLASS="mini"><IMG SRC="rsrcs/images/pc_open.gif" /></TD><TD CLASS="mini"><B>App_Code</B></TD></TR>
     <TR>   
      <TD CLASS="mini"></TD>
      <TD CLASS="mini">
       <TABLE>
        <TR><TD CLASS="mini" STYLE="padding-right: 20px;">DrawAll.cs</TD><TD CLASS="mini">The graphics class required by <B>DrawIt.ashx</B></TD></TR>
       </TABLE>
      </TD>
     </TR>   
    </TABLE>
   </TD>
  </TR>

  <TR><TD CLASS="mini"><HR /></TD></TR>

   <TR>
    <TD CLASS="mini">
     <I>
      The following is only relavent to allow the example here to work because it uses a masterpage
     <BR />The MasterPage can be replaced with a Webpage of your own. </I>
     <TABLE>
      <TR><TD CLASS="mini"><IMG SRC="rsrcs/images/pc_open.gif" /></TD><TD CLASS="mini"><B>MasterPages</B></TD></TR>
      <TR>   
       <TD CLASS="mini"></TD>
       <TD CLASS="mini">
        <TABLE>
         <TR><TD CLASS="mini" STYLE="padding-right: 20px;">masterOneAfterOther.master</TD><TD CLASS="mini">The masterpage in use here</TD></TR>
        </TABLE>
       </TD>
      </TR>   
     </TABLE>
    </TD>
   </TR>

 </TABLE>

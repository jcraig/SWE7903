using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;



namespace SilverlightDataAccessClassLibrary
{
    /// <summary>
    /// Inspiration for this access solution is from
    /// [http://social.msdn.microsoft.com/forums/en-US/wpf/thread/4eba18e4-45eb-43f0-80fa-b4c5f427560c]
    /// 
    /// DataAccess is purposed to provide Database access to Silverlight Applications
    /// </summary>
    public class DataAccess
    {
        public DataTable SQLSelect_Generic(String SQL, String ConnectionString)
{
try
{
//If no connection string is passed in just break out
//and return an empty DataTable
if (ConnectionString == String.Empty) return null;
//Set up a data table to hold the querey results
DataTable dt = new DataTable();
SqlConnection Connect = ConnectToDB(ConnectionString);
SqlDataAdapter adapter = new SqlDataAdapter(SQL, Connect);
adapter.Fill(dt);
DisconnectFromDB();
return dt;
}
catch (Exception e)
{
sErrorMessage += e.Message;
throw e;
}
}//End SQLSelect_Generic(String, String) public DataTable SQLSelect_Generic(String SQL, String ConnectionString)
{
try
{
//If no connection string is passed in just break out
//and return an empty DataTable
if (ConnectionString == String.Empty) return null;
//Set up a data table to hold the querey results
DataTable dt = new DataTable();
SqlConnection Connect = ConnectToDB(ConnectionString);
SqlDataAdapter adapter = new SqlDataAdapter(SQL, Connect);
adapter.Fill(dt);
DisconnectFromDB();
return dt;
}
catch (Exception e)
{
sErrorMessage += e.Message;
throw e;
}



/**************************************************************
* ConnectToDB(String) *
**************************************************************
* Recieves a string that contains a ConnectionString. *
* Then it goes and tries to connect to the database, and it *
* returns a SqlConnection object (conn) with the connection *
* whether it is null or full. If there is an error it will *
* the error message, and then return null. *
* *
* Example of a ConnectionString: TestResultsConnectionString *
* L--> Gotten from app.config as the string used to connect*
**************************************************************/
public SqlConnection ConnectToDB(String ConnectionString)
{
try
{
//Format a connection using the passed in ConnectionString (FOUND IN APP.CONFIG!!)
//Then use it to open the connection
conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString);
conn.Open(); //Open the connection to the DB
return conn; //return the connection object
}
catch (Exception ex)
{
//If no connection can be made
//return an error message and an empty object
sErrorMessage += ex.Message;
return null;
}
}//End ConnectToDB(String)


/**************************************************************
* DisconnectFromDB() *
**************************************************************
* Disconnects from the database. Invokes the .Close() *
* method of the SqlConnection object. If it can't close the *
* connection it will throw an error, and add its message to *
* the sErrorMessage string. *
**************************************************************/
public void DisconnectFromDB()
{
try
{
//close the db
conn.Close();
}
catch (Exception e)
{
//If object is NULL or the database cannot be
//closed, pick up on it and deal with it
sErrorMessage += e.Message;
throw e;
}
}//End DisconnectFromDB()


    }
}

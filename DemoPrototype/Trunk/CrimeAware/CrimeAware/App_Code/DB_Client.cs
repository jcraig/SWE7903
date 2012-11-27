using System;
using System.Web;
using System.Text;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;


// [ServiceContract(Namespace = "")]
// [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

/// <summary>
/// Summary description for DB_Client
/// </summary>
public class DB_Client
{
    private static string sqlconnect = @"workstation id=CrimeDatabase.mssql.somee.com;packet size=4096;user id=crimeaware_SQLLogin_1;pwd=capstone1$;data source=CrimeDatabase.mssql.somee.com;persist security info=False;initial catalog=CrimeDatabase";

    private SqlDataAdapter adapter = new SqlDataAdapter();

    private DataSet ds = new DataSet();

    // class global SqlCeCommands
    private SqlCommand insert_command;

    public SqlConnection connection = new SqlConnection(sqlconnect);
    
    MessageBox SQL_msg = new MessageBox();

	public DB_Client()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    # region retrieve methods

    // retrieve with 1 param to get all column values of a specific row
    //[OperationContract]
    public string getSchool_data(String fetch)
    {
        SqlDataReader reader = null;
        SqlCommand command = null;

        string report = "";

        try
        {
            connection.Open();
            command = new SqlCommand(fetch);
            command.Connection = connection;
            reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                report += reader["SCHOOL_ID"] + "&" + reader["WO_instance"];
            }
        }
        catch (Exception ex)
        {
            SQL_msg.ShowMessageBox(ex.Message);
            
        }
        finally
        {
            if (reader != null)
                reader.Close();

            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        return report;
    }

    public string getSchool_loc(String fetch, String lat_start, String lat_end, String long_start, String long_end )
    {
        SqlDataReader reader = null;
        SqlCommand command = null;
        int counter = 1;

        string report = "";

        try
        {
            connection.Open();
            command = new SqlCommand(fetch);
            command.Connection = connection;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                report += reader[lat_start] + "&" + reader[lat_end] + "&" + reader[long_start] + "&" + reader[long_end];

                counter++;
            }
        }
        catch (Exception ex)
        {
            SQL_msg.ShowMessageBox(ex.Message);
        }
        finally
        {
            if (reader != null)
                reader.Close();

            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        return report;
    }

    public string fetch_2params(String fetch, String lat, String longi)
    {
        SqlDataReader reader = null;
        SqlCommand command = null;
        int counter = 1;

        string report = "";

        try
        {
            connection.Open();
            command = new SqlCommand(fetch);
            command.Connection = connection;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                report += reader[lat] + "&" + reader[longi] + "&";

                counter++;
            }
        }
        catch (Exception ex)
        {
            SQL_msg.ShowMessageBox(ex.Message);
        }
        finally
        {
            if (reader != null)
                reader.Close();

            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        return report;
    }

    public string fetch_polyPoints(String fetch, String g1, String g2, String g3, String g4, String g5, String g6, String g7, String g8, String g9)
    {
        SqlDataReader reader = null;
        SqlCommand command = null;
        int counter = 1;

        string report = "";

        try
        {
            connection.Open();
            command = new SqlCommand(fetch);
            command.Connection = connection;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                report += reader[g1] + "&" + reader[g2] + "&" + reader[g3] + "&" + reader[g4] + "&" + reader[g5] + "&" + reader[g6] + "&" + reader[g7] + "&" + reader[g8] + "&" + reader[g9];

                counter++;
            }
        }
        catch (Exception ex)
        {
            SQL_msg.ShowMessageBox(ex.Message);
        }
        finally
        {
            if (reader != null)
                reader.Close();

            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        return report;
    }

    #endregion
}
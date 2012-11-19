using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataTestConsoleApplication
{
    class Program
    {

        //private static string connectionString = @"Data Source=None/SQLEXPRESS;Initial Catalog=CCSS;Integrated Security=False;";
        private static string connectionString = @"Server=None\SQLEXPRESS;Database=ccss;User Id=ccss;Password=ccss;";

        static void Main(string[] args)
        {
            Program program = new Program();


            string SQLStatement = "SELECT * FROM SCHOOLS";
            int pageNumber = 1;
            int pageSize = 1000;
            CustomException serviceError;

            Console.WriteLine("Connection String: ");
            Console.WriteLine(connectionString);

            Console.WriteLine("SQL Statement: ");
            Console.WriteLine(SQLStatement);

            Console.WriteLine("Calling GetDataSetData()...");

            DataSetData dsd = program.GetDataSetData(SQLStatement, pageNumber, pageSize, out serviceError);

            if (dsd == null || serviceError != null)
            {
                Console.WriteLine("There was a problem.");
                Console.WriteLine(serviceError.Message);
            }
            else
            {
                Console.WriteLine("Response:");
                Console.WriteLine(dsd.DataXML);
            }
            
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }

        public DataSetData GetDataSetData(string SQL, int PageNumber, int PageSize, out CustomException ServiceError)
        {
            try
            {
                DataSet ds = GetDataSet(SQL, PageNumber, PageSize);
                ServiceError = null;
                return DataSetData.FromDataSet(ds);
            }
            catch (Exception ex)
            {
                ServiceError = new CustomException(ex);
            }
            return null;
        }

        private DataSet GetDataSet(string SQL, int PageNumber, int PageSize)
        {
            DataSet ds;
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(SQL);
                adapter.SelectCommand.Connection = Connection;
                if (PageSize > 0)// Set rowcount =PageNumber * PageSize for best performance
                {
                    long RowCount = PageNumber * PageSize;
                    SqlCommand cmd = new SqlCommand("SET ROWCOUNT " + RowCount.ToString() + " SET NO_BROWSETABLE ON", (SqlConnection)Connection);
                    cmd.ExecuteNonQuery();
                }
                ds = new DataSet();
                adapter.Fill(ds, (PageNumber - 1) * PageSize, PageSize, "Data");
                adapter.FillSchema(ds, SchemaType.Mapped, "DataSchema");
                if (PageSize > 0) // Reset Rowcount back to 0
                {
                    SqlCommand cmd = new SqlCommand("SET ROWCOUNT 0 SET NO_BROWSETABLE OFF", (SqlConnection)Connection);
                    cmd.ExecuteNonQuery();
                }
                if (ds.Tables.Count > 1)
                {
                    DataTable data = ds.Tables["Data"];
                    DataTable schema = ds.Tables["DataSchema"];
                    data.Merge(schema);
                    ds.Tables.Remove(schema);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                Connection.Close();
            }
            return ds;
        }
    }


    public class DataSetData
    {
        public ObservableCollection<DataTableInfo> Tables { get; set; }
        public string DataXML { get; set; }

        public static DataSetData FromDataSet(DataSet ds)
        {
            DataSetData dsd = new DataSetData();
            dsd.Tables = new ObservableCollection<DataTableInfo>();
            foreach (DataTable t in ds.Tables)
            {
                DataTableInfo tableInfo = new DataTableInfo { TableName = t.TableName };
                dsd.Tables.Add(tableInfo);
                tableInfo.Columns = new ObservableCollection<DataColumnInfo>();
                foreach (DataColumn c in t.Columns)
                {
                    DataColumnInfo col = new DataColumnInfo { ColumnName = c.ColumnName, ColumnTitle = c.ColumnName, DataTypeName = c.DataType.FullName, MaxLength = c.MaxLength, IsKey = c.Unique, IsReadOnly = (c.Unique || c.ReadOnly), IsRequired = !c.AllowDBNull };
                    if (c.DataType == typeof(System.Guid))
                    {
                        col.IsReadOnly = true;
                        col.DisplayIndex = -1;
                    }
                    tableInfo.Columns.Add(col);
                }
            }
            dsd.DataXML = ds.GetXml();
            return dsd;
        }

        public static DataSet ToDataSet(DataSetData dsd)
        {
            DataSet ds = new DataSet();
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(dsd.DataXML);
            MemoryStream stream = new MemoryStream(byteArray);
            XmlReader reader = new XmlTextReader(stream);
            ds.ReadXml(reader);
            XDocument xd = XDocument.Parse(dsd.DataXML);
            foreach (DataTable dt in ds.Tables)
            {
                var rs = from row in xd.Descendants(dt.TableName)
                         select row;

                int i = 0;
                foreach (var r in rs)
                {
                    DataRowState state = (DataRowState)Enum.Parse(typeof(DataRowState), r.Attribute("RowState").Value);
                    DataRow dr = dt.Rows[i];
                    dr.AcceptChanges();
                    if (state == DataRowState.Deleted)
                        dr.Delete();
                    else if (state == DataRowState.Added)
                        dr.SetAdded();
                    else if (state == DataRowState.Modified)
                        dr.SetModified();
                    i++;
                }
            }
            return ds;
        }
    }

    public class DataTableInfo
    {
        public string TableName { get; set; }
        public ObservableCollection<DataColumnInfo> Columns { get; set; }
    }

    public class DataColumnInfo
    {
        public string ColumnName { get; set; }
        public string ColumnTitle { get; set; }
        public string DataTypeName { get; set; }
        public bool IsRequired { get; set; }
        public bool IsKey { get; set; }
        public bool IsReadOnly { get; set; }
        public int DisplayIndex { get; set; }
        public string EditControlType { get; set; }
        public int MaxLength { get; set; }
    }

    public class CustomException
    {
        public string Message { get; set; }
        public CustomException InnerException;

        public CustomException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            this.Message = ex.Message + ex.StackTrace;
        }

        public Exception ToException()
        {
            Exception e;
            CustomException ce = this;
            if (ce.InnerException != null)
            {
                Exception inner = ce.InnerException.ToException();
                e = new Exception(ce.Message, inner);
            }
            else
                e = new Exception(ce.Message);
            return e;
        }
    }


}

using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;

namespace BusinessLib
{

    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// To open the database, instantiate a class then call initialize
    /// This should return an observable collection that has all the data rows. 
    /// might want to consider observable collections later
    /// Some of this has been adapted from:
    /// http://www.codeproject.com/Articles/35805/MVVM-in-WPF-Part-II
    /// </summary>
    public class Database
    {

        private   OleDbConnection connection;
        public   OleDbConnection GetConnection() { return connection; }
        private   bool result;
        public   bool GetResult() { return result; }

        public   Database()
        {
            FileData = new DataTable();
        }
        public   DataTable FileData
        {
            get; set;
        }
        
        public   void Initialize()
        {

            string connectionString = GetConnectionString();
            connection = new OleDbConnection(connectionString);
            result = OpenConnection();
        }

        public bool GetFileData(string TableName)
        {
            string connectionString = GetConnectionString();
            connection = new OleDbConnection(connectionString);
            result = OpenConnection();
            string commandText = string.Format("Select * from { 0}", TableName);

            OleDbDataAdapter da = new OleDbDataAdapter(commandText, connection);
            DataSet temp = new DataSet();
            da.Fill(temp);
            FileData = temp.Tables[0];
            return true;
        }

        private string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = "D:\\MAIZSIM07\\Taiwan\\Wufeng inputs.xlsx";
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }
            return sb.ToString();
        }

        //open connection to database
        private   bool OpenConnection()
        {
            try
            {
                connection.Open();
                // MessageBox.Show("Open successful");
                return true;
            }
            catch (OleDbException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                MessageBoxResult result = MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
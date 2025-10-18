using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmcAs400Query
{
    public static class QueryManager
    {
        public static OdbcConnection connection;
        private static string connectionString;

        public static DataTable lastQueryResult;

        public static string GetConnectionStatus()
        {
            if (connection == null)
            {
                return "Not Connected";
            }
            return connection.State.ToString();
        }

        public static void Connect(string dbsource, string user, string password, string defaultLibs)
        {
            try
            {
                connectionString = $"DSN={dbsource};UID={user};PWD={password};DefaultLibraries={defaultLibs};"; //braucht den namen des ODBC Driver bei dem die IP und alles hinterlegt ist

                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = new OdbcConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MainForm.Instance.errorLabelnew.Text = ex.Message;
            }
        }

        public static DataTable ExecuteQuery(string query)
        {
            Debug.WriteLine(connectionString);
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection = new OdbcConnection(connectionString);
                connection.Open();

                OdbcDataAdapter dataAdapt = new OdbcDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                dataAdapt.Fill(dataTable);
                lastQueryResult = dataTable;
                return dataTable;
            }
            catch (Exception ex)
            {
                MainForm.Instance.Invoke((MethodInvoker)(() => {
                    MainForm.Instance.errorLabelnew.Text = ex.Message;
                }));

                return null;
            }
        }

        public static void Disconnect()
        {
            if (connection == null) { return; }
            connection.Close();
            connection.Dispose();
        }
    }
}

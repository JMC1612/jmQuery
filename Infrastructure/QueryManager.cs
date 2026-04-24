using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JmcAs400Query
{
    public static class QueryManager
    {
        public static OdbcConnection connection;
        private static string connectionString;
        
        public static string selectedDsn = string.Empty;

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
                connectionString = $"DSN={dbsource};UID={user};PWD={password};DefaultLibraries={defaultLibs};CONNTYPE=1;ALLOWPROCCALLS=1;"; //braucht den namen des ODBC Driver bei dem die IP und alles hinterlegt ist
                selectedDsn = dbsource;

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
            //MainForm.Instance.StartProgressbar();
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
                //MainForm.Instance.EndProgressbar();
                return dataTable;
            }
            catch (Exception ex)
            {
                MainForm.Instance.Invoke((MethodInvoker)(() =>
                {
                    MainForm.Instance.errorLabelnew.Text = ex.Message;
                }));
                //MainForm.Instance.EndProgressbar();
                return null;
            }
        }

        public static void ExecuteCommand(string command)
        {
            try
            {
                using var cmd = connection.CreateCommand();
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Command Successful");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MainForm.Instance.errorLabelnew.Text = ex.Message;
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

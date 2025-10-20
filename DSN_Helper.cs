using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmcAs400Query
{
    public static class DSN_Helper
    {

        public static void UserDsnToCombobox(ComboBox dsnCombobox)
        {
            var userDsns = GetDsns(RegistryHive.CurrentUser, RegistryView.Default);

            dsnCombobox.Items.Clear();
            dsnCombobox.Items.AddRange(userDsns.ToArray());
            if (dsnCombobox.Items.Count > 0)
            {
                dsnCombobox.SelectedIndex = dsnCombobox.Items.Count - 1;
            } else
            {
                dsnCombobox.Text = "No DSN found.";
            }
        }

        private static IEnumerable<string> GetDsns(RegistryHive hive, RegistryView view)
        {
            var dsns = new List<string>();
            using (var baseKey = RegistryKey.OpenBaseKey(hive, view))
            using (var key = baseKey.OpenSubKey(@"SOFTWARE\ODBC\ODBC.INI\ODBC Data Sources"))
            {
                if (key != null)
                {
                    foreach (var name in key.GetValueNames())
                        dsns.Add(name);
                }
            }
            return dsns;
        }
    }
}

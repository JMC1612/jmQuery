using System;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace JmcAs400Query
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public MainForm()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            InitializeComponent();

            passwordTextBox.PasswordChar = '*';

            DSN_Helper.UserDsnToCombobox(datasourceComboBox);

            SetupQuickMenu();
        }

        private void SetupQuickMenu()
        {
            var panel = new Panel
            {
                Size = new Size(220, 140),
                BackColor = SystemColors.ControlLight
            };

            Button loadcsvButton = new Button { Text = "Load CSV", AutoSize = true, Location = new Point(10, 10) };
            loadcsvButton.Click += (s, e) =>
            {
                using OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*" };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable csvData = CsvManager.LoadDataTableFromCsv(openFileDialog.FileName);
                    LoadTableIntoDataDisplay(csvData);
                }
            };

            panel.Controls.Add(loadcsvButton);
            panel.Controls.Add(new Button { Text = "Manage Aliases", AutoSize = true, Location = new Point(10, 40) });
            panel.Controls.Add(new CheckBox { Text = "Query only mode", AutoSize = true, Location = new Point(10, 70) });

            quickMenuPopoutbutton.DropDownContent = panel;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            QueryManager.Connect(datasourceComboBox.Text, userTextBox.Text, passwordTextBox.Text, libsTextbox.Text);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            statusLabel.Text = "Status: " + QueryManager.GetConnectionStatus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "Status: Not Connected";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            QueryManager.Disconnect();
            base.OnFormClosing(e);
        }

        private async void executeQryButton_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            errorLabelnew.Text = string.Empty;

            Task<DataTable> queryTask = Task.Run(() => QueryManager.ExecuteQuery(queryTextBox.Text));
            DataTable queryData = await queryTask;

            LoadTableIntoDataDisplay(queryData);

            UpdateStatus();

        }

        private void LoadTableIntoDataDisplay(DataTable tableData)
        {
            if (tableData != null)
            {
                queryinfoLabel.Text = string.Empty;

                dataDisplay.DataSource = tableData;
                dataDisplay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                int rowCount = tableData.Rows.Count;
                int colCount = tableData.Columns.Count;

                queryinfoLabel.Text += $"Name: {tableData.TableName}";
                queryinfoLabel.Text += $"\nColumns: {colCount}";
                queryinfoLabel.Text += $"\nRows: {rowCount}";
            }
            else
            {
                queryinfoLabel.Text += $"\nQuery failed.";
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            QueryManager.Disconnect();
            UpdateStatus();
        }

        private void exportToCsvButton_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveDialog = new SaveFileDialog { Filter = "CSV (*.csv)|*csv", FileName = "jmcquery.csv" };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, CsvManager.CreateCsvContent(QueryManager.lastQueryResult), Encoding.UTF8);
            }
        }

        private void executeQryButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.jmQuery, new Rectangle(8, 13, 80, 80));
        }
    }
}
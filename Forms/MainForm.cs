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

            //queryTextBox.SchemaObjects.AddRange(new[] { });

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

            var as400joblogButton = new Button { BackColor = Color.White, Text = "View JOBLOG", AutoSize = true, Location = new Point(10, 10) };
            as400joblogButton.Click += (s, e) => { ShowAs400Joblog(); };
            panel.Controls.Add(as400joblogButton);

            quickMenuPopoutbutton.DropDownContent = panel;
        }

        private void ShowAs400Joblog()
        {
            queryTextBox.Text = "SELECT ORDINAL_POSITION, MESSAGE_ID, MESSAGE_TYPE, MESSAGE_TEXT\r\nFROM TABLE(QSYS2.JOBLOG_INFO('*'))\r\nORDER BY ORDINAL_POSITION DESC\r\nFETCH FIRST 20 ROWS ONLY";
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

            string query = queryTextBox.Text;
            Task<DataTable> queryTask = Task.Run(() => QueryManager.ExecuteQuery(query));
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

                string tableVisualName = tableData.TableName;
                if (string.IsNullOrEmpty(tableVisualName)) { tableVisualName = "???"; }

                queryinfoLabel.Text += $"Name: {tableVisualName}";
                queryinfoLabel.Text += $"\nColumns: {colCount}";
                queryinfoLabel.Text += $"\nRows: {rowCount}";
                queryinfoLabel.Text += $"\n\nTimestamp: {DateTime.Now}";
            }
            else
            {
                queryinfoLabel.Text = $"\nQuery failed.";
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            QueryManager.Disconnect();
            UpdateStatus();
        }

        private void exportToCsvButton_Click(object sender, EventArgs e)
        {
            CsvManager.ExportToCsvButtonClick();
        }

        private void executeQryButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.jmQuery, new Rectangle(8, 13, 80, 80));
        }

        private void quickMenuPopoutbutton_Click(object sender, EventArgs e)
        {
        }

        private void executeCommandButton_Click(object sender, EventArgs e)
        {
            errorLabelnew.Text = string.Empty;

            QueryManager.ExecuteCommand(commandTextbox.Text);
        }

        public void StartProgressbar()
        {
            progressBar1.Value = 10;
        }

        public void EndProgressbar()
        {
            progressBar1.Value = 100;
        }
    }
}
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
<<<<<<< Updated upstream:MainForm.cs
=======

            var panel = new Panel
            {
                Size = new Size(220, 140),
                BackColor = SystemColors.ControlLight
            };
            panel.Controls.Add(new Button { Text = "Manage Aliases", AutoSize = true, Location = new Point(10, 10) });
            panel.Controls.Add(new CheckBox { Text = "Enable feature X", AutoSize = true, Location = new Point(10, 70) });
            panel.Controls.Add(new TrackBar { Minimum = 0, Maximum = 10, TickStyle = TickStyle.None, Width = 200, Location = new Point(10, 100) });

            settingsPopoutmenuButton.DropDownContent = panel;
>>>>>>> Stashed changes:Forms/MainForm.cs
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            QueryManager.Connect(dbsourceTextBox.Text, userTextBox.Text, passwordTextBox.Text, libsTextbox.Text);
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

            dataDisplay.DataSource = queryData;
            dataDisplay.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            UpdateStatus();

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
            e.Graphics.DrawImage(Properties.Resources.jmQuery, new Rectangle(8, 11, 80, 80));
        }
    }
}
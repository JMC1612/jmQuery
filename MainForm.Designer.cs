using JmcAs400Query.UI_Controls.PopoutDemo;
using System.Data;

namespace JmcAs400Query
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            label2 = new Label();
            userTextBox = new TextBox();
            label3 = new Label();
            passwordTextBox = new TextBox();
            label4 = new Label();
            queryTextBox = new TextBox();
            label5 = new Label();
            connectButton = new Button();
            statusLabel = new Label();
            dataDisplay = new DataGridView();
            executeQryButton = new Button();
            disconnectButton = new Button();
            libsTextbox = new TextBox();
            exportToCsvButton = new Button();
            errorLabelnew = new Label();
            quickMenuPopoutbutton = new PopoutMenuButton();
            datasourceComboBox = new ComboBox();
            panel1 = new Panel();
            label6 = new Label();
            queryinfoLabel = new Label();
            CommandTab = new TabControl();
            QueryTab = new TabPage();
            tabPage2 = new TabPage();
            executeCommandButton = new Button();
            label7 = new Label();
            commandTextbox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataDisplay).BeginInit();
            CommandTab.SuspendLayout();
            QueryTab.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "ODBC-Source:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(150, 16);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "User:";
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(150, 34);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(100, 23);
            userTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 16);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(256, 34);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(362, 16);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 7;
            label4.Text = "Default Libraries:";
            // 
            // queryTextBox
            // 
            queryTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            queryTextBox.ForeColor = Color.Black;
            queryTextBox.Location = new Point(15, 31);
            queryTextBox.Margin = new Padding(3, 4, 3, 4);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.ScrollBars = ScrollBars.Vertical;
            queryTextBox.Size = new Size(774, 239);
            queryTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 12);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 10;
            label5.Text = "SELECT-Query:";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(150, 62);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 11;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(12, 65);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(122, 15);
            statusLabel.TabIndex = 12;
            statusLabel.Text = "Status: not connected";
            // 
            // dataDisplay
            // 
            dataDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataDisplay.Location = new Point(15, 278);
            dataDisplay.Name = "dataDisplay";
            dataDisplay.RowHeadersWidth = 51;
            dataDisplay.Size = new Size(878, 343);
            dataDisplay.TabIndex = 13;
            // 
            // executeQryButton
            // 
            executeQryButton.ImageAlign = ContentAlignment.BottomCenter;
            executeQryButton.Location = new Point(794, 31);
            executeQryButton.Name = "executeQryButton";
            executeQryButton.RightToLeft = RightToLeft.No;
            executeQryButton.Size = new Size(96, 96);
            executeQryButton.TabIndex = 18;
            executeQryButton.Text = "Execute query";
            executeQryButton.TextAlign = ContentAlignment.TopCenter;
            executeQryButton.TextImageRelation = TextImageRelation.TextAboveImage;
            executeQryButton.UseVisualStyleBackColor = true;
            executeQryButton.Click += executeQryButton_Click;
            executeQryButton.Paint += executeQryButton_Paint;
            // 
            // disconnectButton
            // 
            disconnectButton.Location = new Point(231, 62);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(87, 23);
            disconnectButton.TabIndex = 19;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // libsTextbox
            // 
            libsTextbox.Location = new Point(362, 34);
            libsTextbox.Name = "libsTextbox";
            libsTextbox.Size = new Size(195, 23);
            libsTextbox.TabIndex = 20;
            // 
            // exportToCsvButton
            // 
            exportToCsvButton.Location = new Point(15, 630);
            exportToCsvButton.Margin = new Padding(3, 2, 3, 2);
            exportToCsvButton.Name = "exportToCsvButton";
            exportToCsvButton.Size = new Size(112, 22);
            exportToCsvButton.TabIndex = 21;
            exportToCsvButton.Text = "Export to CSV";
            exportToCsvButton.UseVisualStyleBackColor = true;
            exportToCsvButton.Click += exportToCsvButton_Click;
            // 
            // errorLabelnew
            // 
            errorLabelnew.BackColor = Color.Transparent;
            errorLabelnew.Font = new Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, 0);
            errorLabelnew.ForeColor = Color.Red;
            errorLabelnew.Location = new Point(334, 57);
            errorLabelnew.Name = "errorLabelnew";
            errorLabelnew.Size = new Size(454, 55);
            errorLabelnew.TabIndex = 22;
            errorLabelnew.TextAlign = ContentAlignment.BottomLeft;
            // 
            // quickMenuPopoutbutton
            // 
            quickMenuPopoutbutton.AccessibleRole = AccessibleRole.PushButton;
            quickMenuPopoutbutton.FlatStyle = FlatStyle.System;
            quickMenuPopoutbutton.Location = new Point(794, 34);
            quickMenuPopoutbutton.Name = "quickMenuPopoutbutton";
            quickMenuPopoutbutton.Size = new Size(96, 23);
            quickMenuPopoutbutton.TabIndex = 23;
            quickMenuPopoutbutton.Text = "Quick menu";
            quickMenuPopoutbutton.UseVisualStyleBackColor = true;
            quickMenuPopoutbutton.Click += quickMenuPopoutbutton_Click;
            // 
            // datasourceComboBox
            // 
            datasourceComboBox.FormattingEnabled = true;
            datasourceComboBox.Location = new Point(12, 34);
            datasourceComboBox.Name = "datasourceComboBox";
            datasourceComboBox.Size = new Size(132, 23);
            datasourceComboBox.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(795, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(90, 137);
            panel1.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(808, 138);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 26;
            label6.Text = "Query info:";
            // 
            // queryinfoLabel
            // 
            queryinfoLabel.BackColor = Color.Transparent;
            queryinfoLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            queryinfoLabel.ForeColor = Color.CornflowerBlue;
            queryinfoLabel.Location = new Point(799, 153);
            queryinfoLabel.Name = "queryinfoLabel";
            queryinfoLabel.Size = new Size(82, 116);
            queryinfoLabel.TabIndex = 27;
            queryinfoLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // CommandTab
            // 
            CommandTab.Controls.Add(QueryTab);
            CommandTab.Controls.Add(tabPage2);
            CommandTab.Location = new Point(12, 115);
            CommandTab.Name = "CommandTab";
            CommandTab.SelectedIndex = 0;
            CommandTab.Size = new Size(909, 686);
            CommandTab.TabIndex = 28;
            // 
            // QueryTab
            // 
            QueryTab.Controls.Add(queryinfoLabel);
            QueryTab.Controls.Add(dataDisplay);
            QueryTab.Controls.Add(label6);
            QueryTab.Controls.Add(panel1);
            QueryTab.Controls.Add(exportToCsvButton);
            QueryTab.Controls.Add(executeQryButton);
            QueryTab.Controls.Add(label5);
            QueryTab.Controls.Add(queryTextBox);
            QueryTab.Location = new Point(4, 24);
            QueryTab.Name = "QueryTab";
            QueryTab.Padding = new Padding(3);
            QueryTab.Size = new Size(901, 666);
            QueryTab.TabIndex = 0;
            QueryTab.Text = "Query";
            QueryTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(executeCommandButton);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(commandTextbox);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(901, 658);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Command";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // executeCommandButton
            // 
            executeCommandButton.Font = new Font("Segoe UI", 7.5F);
            executeCommandButton.ImageAlign = ContentAlignment.BottomCenter;
            executeCommandButton.Location = new Point(794, 31);
            executeCommandButton.Name = "executeCommandButton";
            executeCommandButton.RightToLeft = RightToLeft.No;
            executeCommandButton.Size = new Size(96, 96);
            executeCommandButton.TabIndex = 19;
            executeCommandButton.Text = "Execute command";
            executeCommandButton.TextAlign = ContentAlignment.TopCenter;
            executeCommandButton.TextImageRelation = TextImageRelation.TextAboveImage;
            executeCommandButton.UseVisualStyleBackColor = true;
            executeCommandButton.Click += executeCommandButton_Click;
            executeCommandButton.Paint += executeQryButton_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 12);
            label7.Name = "label7";
            label7.Size = new Size(148, 15);
            label7.TabIndex = 12;
            label7.Text = "Non-Query DB Command:";
            // 
            // commandTextbox
            // 
            commandTextbox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            commandTextbox.ForeColor = Color.Black;
            commandTextbox.Location = new Point(15, 31);
            commandTextbox.Margin = new Padding(3, 4, 3, 4);
            commandTextbox.Multiline = true;
            commandTextbox.Name = "commandTextbox";
            commandTextbox.ScrollBars = ScrollBars.Vertical;
            commandTextbox.Size = new Size(774, 239);
            commandTextbox.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 788);
            Controls.Add(CommandTab);
            Controls.Add(datasourceComboBox);
            Controls.Add(quickMenuPopoutbutton);
            Controls.Add(errorLabelnew);
            Controls.Add(libsTextbox);
            Controls.Add(disconnectButton);
            Controls.Add(statusLabel);
            Controls.Add(connectButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(userTextBox);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(815, 635);
            Name = "MainForm";
            Text = "jmQuery";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataDisplay).EndInit();
            CommandTab.ResumeLayout(false);
            QueryTab.ResumeLayout(false);
            QueryTab.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox userTextBox;
        private Label label3;
        private TextBox passwordTextBox;
        private Label label4;
        private TextBox queryTextBox;
        private Label label5;
        private Button connectButton;
        private Label statusLabel;
        private DataGridView dataDisplay;
        private Button executeQryButton;
        private Button disconnectButton;
        private TextBox libsTextbox;
        private Button exportToCsvButton;
        public Label errorLabelnew;
        private PopoutMenuButton quickMenuPopoutbutton;
        private ComboBox datasourceComboBox;
        private Panel panel1;
        private Label label6;
        public Label queryinfoLabel;
        private TabControl CommandTab;
        private TabPage QueryTab;
        private TabPage tabPage2;
        private Label label7;
        private TextBox commandTextbox;
        private Button executeCommandButton;
    }
}

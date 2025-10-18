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
            dbsourceTextBox = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)dataDisplay).BeginInit();
            SuspendLayout();
            // 
            // dbsourceTextBox
            // 
            dbsourceTextBox.Location = new Point(19, 45);
            dbsourceTextBox.Margin = new Padding(3, 4, 3, 4);
            dbsourceTextBox.Name = "dbsourceTextBox";
            dbsourceTextBox.Size = new Size(114, 27);
            dbsourceTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 21);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 1;
            label1.Text = "ODBC-Source:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 21);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 3;
            label2.Text = "User:";
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(140, 45);
            userTextBox.Margin = new Padding(3, 4, 3, 4);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(114, 27);
            userTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 21);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(261, 45);
            passwordTextBox.Margin = new Padding(3, 4, 3, 4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(114, 27);
            passwordTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 21);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 7;
            label4.Text = "Default Libraries:";
            // 
            // queryTextBox
            // 
            queryTextBox.BorderStyle = BorderStyle.FixedSingle;
            queryTextBox.Location = new Point(14, 153);
            queryTextBox.Margin = new Padding(3, 4, 3, 4);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.Size = new Size(771, 119);
            queryTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 129);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 10;
            label5.Text = "Query:";
            // 
            // connectButton
            // 
            connectButton.Location = new Point(172, 82);
            connectButton.Margin = new Padding(3, 4, 3, 4);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(86, 31);
            connectButton.TabIndex = 11;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(14, 87);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(151, 20);
            statusLabel.TabIndex = 12;
            statusLabel.Text = "Status: not connected";
            // 
            // dataDisplay
            // 
            dataDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataDisplay.Location = new Point(14, 280);
            dataDisplay.Margin = new Padding(3, 4, 3, 4);
            dataDisplay.Name = "dataDisplay";
            dataDisplay.RowHeadersWidth = 51;
            dataDisplay.Size = new Size(887, 457);
            dataDisplay.TabIndex = 13;
            // 
            // executeQryButton
            // 
            executeQryButton.Location = new Point(791, 153);
            executeQryButton.Margin = new Padding(3, 4, 3, 4);
            executeQryButton.Name = "executeQryButton";
            executeQryButton.Size = new Size(110, 119);
            executeQryButton.TabIndex = 18;
            executeQryButton.Text = "Execute query";
            executeQryButton.UseVisualStyleBackColor = true;
            executeQryButton.Click += executeQryButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.Location = new Point(264, 82);
            disconnectButton.Margin = new Padding(3, 4, 3, 4);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(99, 31);
            disconnectButton.TabIndex = 19;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // libsTextbox
            // 
            libsTextbox.Location = new Point(382, 45);
            libsTextbox.Margin = new Padding(3, 4, 3, 4);
            libsTextbox.Name = "libsTextbox";
            libsTextbox.Size = new Size(519, 27);
            libsTextbox.TabIndex = 20;
            // 
            // exportToCsvButton
            // 
            exportToCsvButton.Location = new Point(14, 745);
            exportToCsvButton.Name = "exportToCsvButton";
            exportToCsvButton.Size = new Size(128, 29);
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
            errorLabelnew.Location = new Point(382, 76);
            errorLabelnew.Name = "errorLabelnew";
            errorLabelnew.Size = new Size(519, 73);
            errorLabelnew.TabIndex = 22;
            errorLabelnew.TextAlign = ContentAlignment.BottomLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 786);
            Controls.Add(errorLabelnew);
            Controls.Add(exportToCsvButton);
            Controls.Add(libsTextbox);
            Controls.Add(disconnectButton);
            Controls.Add(executeQryButton);
            Controls.Add(dataDisplay);
            Controls.Add(statusLabel);
            Controls.Add(connectButton);
            Controls.Add(label5);
            Controls.Add(queryTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(passwordTextBox);
            Controls.Add(label2);
            Controls.Add(userTextBox);
            Controls.Add(label1);
            Controls.Add(dbsourceTextBox);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(929, 833);
            MinimumSize = new Size(929, 833);
            Name = "MainForm";
            Text = "jmQuery";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox dbsourceTextBox;
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
    }
}

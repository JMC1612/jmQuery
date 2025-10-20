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
            dbsourceTextBox.Location = new Point(17, 34);
            dbsourceTextBox.Name = "dbsourceTextBox";
            dbsourceTextBox.Size = new Size(100, 23);
            dbsourceTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 16);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 1;
            label1.Text = "ODBC-Source:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 16);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "User:";
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(122, 34);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(100, 23);
            userTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 16);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 5;
            label3.Text = "Password:";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(228, 34);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(334, 16);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 7;
            label4.Text = "Default Libraries:";
            // 
            // queryTextBox
            // 
            queryTextBox.BackColor = Color.White;
            queryTextBox.BorderStyle = BorderStyle.FixedSingle;
<<<<<<< Updated upstream:MainForm.Designer.cs
            queryTextBox.Location = new Point(12, 115);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.Size = new Size(675, 90);
=======
            queryTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            queryTextBox.ForeColor = Color.Black;
            queryTextBox.Location = new Point(14, 153);
            queryTextBox.Margin = new Padding(3, 4, 3, 4);
            queryTextBox.Multiline = true;
            queryTextBox.Name = "queryTextBox";
            queryTextBox.ScrollBars = ScrollBars.Vertical;
            queryTextBox.Size = new Size(771, 239);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
            queryTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 97);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 10;
            label5.Text = "Query:";
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
<<<<<<< Updated upstream:MainForm.Designer.cs
            dataDisplay.Location = new Point(12, 210);
=======
            dataDisplay.Location = new Point(14, 400);
            dataDisplay.Margin = new Padding(3, 4, 3, 4);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
            dataDisplay.Name = "dataDisplay";
            dataDisplay.RowHeadersWidth = 51;
            dataDisplay.Size = new Size(776, 343);
            dataDisplay.TabIndex = 13;
            // 
            // executeQryButton
            // 
            executeQryButton.ImageAlign = ContentAlignment.BottomCenter;
<<<<<<< Updated upstream:MainForm.Designer.cs
            executeQryButton.Location = new Point(692, 115);
=======
            executeQryButton.Location = new Point(789, 153);
            executeQryButton.Margin = new Padding(3, 4, 3, 4);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
            executeQryButton.Name = "executeQryButton";
            executeQryButton.RightToLeft = RightToLeft.No;
            executeQryButton.Size = new Size(96, 89);
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
            libsTextbox.Location = new Point(334, 34);
            libsTextbox.Name = "libsTextbox";
            libsTextbox.Size = new Size(455, 23);
            libsTextbox.TabIndex = 20;
            // 
            // exportToCsvButton
            // 
<<<<<<< Updated upstream:MainForm.Designer.cs
            exportToCsvButton.Location = new Point(12, 559);
            exportToCsvButton.Margin = new Padding(3, 2, 3, 2);
=======
            exportToCsvButton.Location = new Point(14, 865);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< Updated upstream:MainForm.Designer.cs
            ClientSize = new Size(799, 596);
            Controls.Add(errorLabelnew);
=======
            ClientSize = new Size(911, 906);
            Controls.Add(settingsPopoutmenuButton);
            Controls.Add(infoLabelnew);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
<<<<<<< Updated upstream:MainForm.Designer.cs
            MaximumSize = new Size(815, 635);
            MinimumSize = new Size(815, 635);
=======
            MinimumSize = new Size(929, 831);
>>>>>>> Stashed changes:Forms/MainForm.Designer.cs
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

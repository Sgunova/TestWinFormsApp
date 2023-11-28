namespace TestWinFormsApp.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PassengersView = new DataGridView();
            DepartureTime = new DataGridViewTextBoxColumn();
            FlightNumber = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            MiddleName = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            LoadDataMenuItem = new ToolStripMenuItem();
            AboutMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)PassengersView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // PassengersView
            // 
            PassengersView.AllowUserToAddRows = false;
            PassengersView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PassengersView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PassengersView.Columns.AddRange(new DataGridViewColumn[] { DepartureTime, FlightNumber, LastName, FirstName, MiddleName });
            PassengersView.Dock = DockStyle.Fill;
            PassengersView.Location = new Point(0, 24);
            PassengersView.Name = "PassengersView";
            PassengersView.RowTemplate.Height = 25;
            PassengersView.Size = new Size(800, 449);
            PassengersView.TabIndex = 0;
            // 
            // DepartureTime
            // 
            DepartureTime.HeaderText = "Время вылета";
            DepartureTime.Name = "DepartureTime";
            // 
            // FlightNumber
            // 
            FlightNumber.HeaderText = "Номер рейса";
            FlightNumber.Name = "FlightNumber";
            // 
            // LastName
            // 
            LastName.HeaderText = "Фамилия";
            LastName.Name = "LastName";
            // 
            // FirstName
            // 
            FirstName.HeaderText = "Имя";
            FirstName.Name = "FirstName";
            // 
            // MiddleName
            // 
            MiddleName.HeaderText = "Отчество";
            MiddleName.Name = "MiddleName";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { LoadDataMenuItem, AboutMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // LoadDataMenuItem
            // 
            LoadDataMenuItem.Name = "LoadDataMenuItem";
            LoadDataMenuItem.Size = new Size(117, 20);
            LoadDataMenuItem.Text = "Загрузить данные";
            LoadDataMenuItem.Click += LoadDataMenuItem_Click;
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new Size(94, 20);
            AboutMenuItem.Text = "О программе";
            AboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(PassengersView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Данные о пассажирах";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)PassengersView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView PassengersView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem LoadDataMenuItem;
        private ToolStripMenuItem AboutMenuItem;
        private OpenFileDialog openFileDialog;
        private DataGridViewTextBoxColumn DepartureTime;
        private DataGridViewTextBoxColumn FlightNumber;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn MiddleName;
    }
}
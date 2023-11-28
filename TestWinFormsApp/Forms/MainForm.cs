using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestWinFormsApp.Classes;
using TestWinFormsApp.Core.Classes;
using TestWinFormsApp.Properties;

namespace TestWinFormsApp.Forms
{
    public partial class MainForm : Form
    {
        CSVReader reader;
        PassengerReader passengers;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.Multiselect = false;

            reader = new CSVReader();
            passengers = new(reader);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.About_Message,
                Resources.About_Caption);
        }

        private void LoadDataMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
            {
                reader.ChengePath(openFileDialog.FileName);
                passengers.UpdateData();
                SetPassengers();
            }
        }

        private void SetPassengers()
        {
            PassengersView.Rows.Clear();

            foreach (var passenger in passengers.Information)
                PassengersView.Rows.Add(passenger.GetRow());
        }


        private void MainForm_Load(object sender, EventArgs e) =>
            LoadDataMenuItem_Click(sender, e);
    }
}

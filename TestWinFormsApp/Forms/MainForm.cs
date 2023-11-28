using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestWinFormsApp.Classes;
using TestWinFormsApp.Core.Classes;

namespace TestWinFormsApp.Forms
{
    public partial class MainForm : Form
    {
        CSVReader<Passenger> reader;
        PassengerReader passengers;

        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.Multiselect = false;

            reader = new CSVReader<Passenger>();
            passengers = new(reader);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данный продукт реализует следующее тестовое задание:\n\n" +
                "\tРазработать программу с формой вывода в табличном виде пассажиров рейса самолета с указанием времени вылета, номера рейса, ФИО пассажиров. Эти данные должны сохраняться в файле. При открытии файла таблица заполняется данными из файла." +
                "\n\tСтек:  WinForms С# с использованием .Net 6.",
                "О программе");
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

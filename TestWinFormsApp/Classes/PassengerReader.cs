using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWinFormsApp.Core.Classes;
using TestWinFormsApp.Core.Interfaces;

namespace TestWinFormsApp.Classes
{
    public class PassengerReader
    {
        public List<Passenger> Information;
        IReader<Passenger> DataReader;

        public PassengerReader(IReader<Passenger> dataReader)
        {
            this.DataReader = dataReader;
            Information = new();
        }

        public void UpdateData()
        {
            Information = DataReader.ReadData();
        }
    }
}

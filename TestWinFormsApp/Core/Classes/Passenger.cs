using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestWinFormsApp.Core.Classes
{
    public class Passenger
    {
        public DateTime DepartureTime { get; }
        public string FlightNumber { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }

        public Passenger(params string[] values)
        {
            if (values.Length != 5)
            {
                throw new ArgumentException("Ожидалось 5 значений.");
            }

            if (!DateTime.TryParse(values[0], out DateTime departureTime))
            {
                throw new ArgumentException("Неверный формат даты и времени.");
            }

            if (!ValidateFlightNumber(values[1]))
            {
                throw new ArgumentException("Неверный формат номера рейса.");
            }

            if (!ValidatePassengerData(values[2], values[3], values[4]))
            {
                throw new ArgumentException("Неверный формат данных пассажира.");
            }

            DepartureTime = DateTime.Parse(values[0]);
            FlightNumber = values[1];
            LastName = values[2];
            FirstName = values[3];
            MiddleName = values[4];
        }

        private bool ValidateFlightNumber(string flightNumber)
        {
            string pattern = @"^[a-zA-Zа-яА-Я0-9]{3,}$";

            return Regex.IsMatch(flightNumber, pattern);
        }

        private bool ValidatePassengerData(string lastName, string firstName, string middleName)
        {
            string pattern = @"^[a-zA-Zа-яА-Я]{2,}$";

            return Regex.IsMatch(lastName, pattern) &&
                Regex.IsMatch(firstName, pattern) &&
                Regex.IsMatch(middleName, pattern);
        }

        public object[] GetRow()
        {
            return new object[] { DepartureTime, FlightNumber, LastName, FirstName, MiddleName };
        }
    }
}

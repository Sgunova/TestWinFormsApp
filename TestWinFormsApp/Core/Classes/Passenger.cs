using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestWinFormsApp.Core.Interfaces;

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
            DepartureTime = DateTime.Parse(values[0]);
            FlightNumber = values[1];
            LastName = values[2];
            FirstName = values[3];
            MiddleName = values[4];
        }

        public static bool Validate(params string[] values)
        {
            return values.Length >= 5 &&
                DateTime.TryParse(values[0], out DateTime departureTime)&&
                ValidateFlightNumber(values[1])&&
                ValidatePassengerData(values[2], values[3], values[4]);
        }

        private static bool ValidateFlightNumber(string flightNumber)
        {
            string pattern = @"^[a-zA-Zа-яА-Я0-9]{3,}$";

            return Regex.IsMatch(flightNumber, pattern);
        }

        private static bool ValidatePassengerData(string lastName, string firstName, string middleName)
        {
            string pattern = @"^[a-zA-Zа-яА-Я]{2,}$";

            return Regex.IsMatch(lastName, pattern) &&
                Regex.IsMatch(firstName, pattern) &&
                Regex.IsMatch(middleName, pattern);
        }

        public object[] GetRow()
        {
            return new object[] { DepartureTime.ToUniversalTime(), FlightNumber, LastName, FirstName, MiddleName };
        }
    }
}

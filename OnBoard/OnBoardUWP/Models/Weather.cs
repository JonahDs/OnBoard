using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }
        private int _minTemperature;
        public int MinTemperature
        {
            get
            {
                return ConvertToCelcius(_minTemperature);
            }
            set
            {
                _minTemperature = value;
            }
        }

        private int _maxTemperature;
        public int MaxTemperature
        {
            get
            {
                return ConvertToCelcius(_maxTemperature);
            }
            set
            {
                _maxTemperature = value;
            }
        }

        public int DayIcon { get; set; }
        public string DayPhrase { get; set; }


        public string GetDayOfDate()
        {
            return Date.DayOfWeek.ToString();
        }

        private int ConvertToCelcius(int temperature)
        {
            return (temperature - 32) * 5 / 9;
        }
    }
}

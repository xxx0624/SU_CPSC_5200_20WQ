using System;

namespace restapi.Models
{
    public class DocumentLine
    {
        public DocumentLine() { }

        public DocumentLine(TimecardLine line)
        {
            Week = line.Week;
            Year = line.Year;
            Day = line.Day;
            Hours = line.Hours;
            Project = line.Project;
        }

        public int Week { get; set; }

        public int Year { get; set; }

        public DayOfWeek Day { get; set; }

        public float Hours { get; set; }

        public string Project { get; set; }
    }
}
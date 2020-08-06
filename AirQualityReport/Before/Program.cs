// This program takes the real-time generated air-quality index in different cities in India 
// and generates as the output a City-Wise PDF report with the air quality details

// This code does not adhere to SOLID principles and has numerous smells 
// Axis of change: the report may have to be generated Pollutant-wise in addition to City-wise reports 

// For excel reading, use Aspose library 
// For the PDF generation, using the iTextSharp library 
// Source for the dataset: https://www.kaggle.com/venky73/airquality 

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Cells; 
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace AirQualityReport.Before
{
    public class Location
    {
        public Location(string Country, string State, string City, string Place, string Pollutant)
        {
            this.Country = Country;
            this.State = State;
            this.City = City;
            this.Place = Place;
            this.Pollutant = Pollutant;
        }

        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Place { get; private set; }
        public string Pollutant { get; private set; }
    }

    public class PollutantReading
    {
        public PollutantReading(string lastUpdatedTime, int average, int max, int min)
        {
            this.Average = average;
            this.Max = max;
            this.Min = min;
        }

        public string LastUpdatedTime { get; private set; }
        public int Average { get; private set; }
        public int Max { get; private set; }
        public int Min { get; private set; }
    }

    class CitywisePollutantReport
    {
        
        public void GeneratePdf(string path, string heading, int MARGIN)
        {
            var document = OpenPDFFileFromPath(path, MARGIN);

            var html = string.Empty;
            // build the document
            var s = $"<h1> {heading} </h1> <br> <br> <h2> Generated on: {AirQualityReporter.CityWiseEntry.LastUpdatedTime} </h2> <br> ";
            html += s + "<body>";

            foreach (var (key, value) in AirQualityReporter.CityWiseEntry.CityWiseReadings)
            {
                html += $"<h2> {key} </h2>";
                html += @"<br><table border=""1""> <tr> <th>Average</th> <th>Max</th><th>Min</th><th>Pollutant</th>";
                foreach (var reading in value)
                {
                    html += $"<tr> <td>{reading.Item1}</td> <td>{reading.Item2}</td><td>{reading.Item3}</td><td>{reading.Item4}</td></tr>";
                }

                html += @"</table><br>";
            }

            html += "</body>";
            html += "</html>";
            var elements =
                HTMLWorker.ParseToList(new StringReader(html), null);

            // add the collection to the document
            foreach (var element in elements)
            {
                document.Add(element);
            }

            //close the document
            document.Close();
        }

        private static Document OpenPDFFileFromPath(string path, int MARGIN)
        {
            if (MARGIN <= 0) throw new ArgumentOutOfRangeException(nameof(MARGIN));
            // instantiate a new document
            var document = new Document(PageSize.LETTER, MARGIN, MARGIN, MARGIN, MARGIN);

            // instantiate the writer that will listen to the document
            var writer =
                PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

            // open the document
            document.Open();
            return document;
        }
    }

    class AirQualityReporter
    {
        public static List<Entry> ReadXLS(string PathToMyExcel)
        {
            // open the workbook 
            var wb = new Workbook(PathToMyExcel);

            // open the first worksheet from the workbook 
            var worksheet = wb.Worksheets[0];

            // Get the cells inside the worksheet 
            var cells = worksheet.Cells;

            // Get the row and column count
            var rowCount = cells.MaxDataRow;
            var columnCount = cells.MaxDataColumn;

            // Current cell value
            var strCell = "";

            var entries = new List<Entry>();
            // for every entry in the row - skip first one
            try
            {
                for (var row = 1; row <= rowCount; row++)
                {
                    var column1 = Convert.ToString(cells[row, 0].Value); // Country
                    var column2 = Convert.ToString(cells[row, 1].Value); // State 
                    var column3 = Convert.ToString(cells[row, 2].Value); // City  
                    var column4 = Convert.ToString(cells[row, 3].Value); // Place 
                    var column5 = Convert.ToString(cells[row, 4].Value); // Last Updated Time

                    var column6 = -1; // Average - could be "NA" instead of a int, so the ToInt32 will fail for that
                    try
                    {
                        column6 = Convert.ToInt32(cells[row, 5].Value);
                    }
                    catch (FormatException fe)
                    {
                    }

                    var column7 = -1; // Max -- could be "NA" instead of a int, so the ToInt32 will fail for that
                    try
                    {
                        column7 = Convert.ToInt32(cells[row, 6].Value);
                    }
                    catch (FormatException fe)
                    {
                    }

                    var column8 = -1; // Min - could be "NA" instead of a int, so the ToInt32 will fail for that
                    try
                    {
                        column8 = Convert.ToInt32(cells[row, 7].Value);
                    }
                    catch (FormatException fe)
                    {
                    }

                    var column9 = Convert.ToString(cells[row, 8].Value); // Pollutant  

                    var entry = Entry.CreateEntry(new Location(column1, column2, column3, column4, column9), new PollutantReading(column5, column6, column7, column8));

                    entries.Add(entry);
                }
            }
            catch (Exception fe)
            {
                // doesn't occur for this .csv when I tested, so ignoring any exceptions  
            }

            return entries;
        }
                private static void ConvertEntriesToCitywiseEntries(List<AirQualityReporter.Entry> entries)
        {
            foreach (var entry in entries)
                CityWiseEntry.AddToCityWiseEntry(entry.Country, entry.State, entry.City, entry.Place,
                    entry.LastUpdatedTime, entry.Average, entry.Max, entry.Min, entry.Pollutant);
        }

        public static void Main(string[] args)
        {
            var path = @"./Assets/CityWiseReport.pdf";

            // first read the file 
            var entries = ReadXLS(@"./Assets/AirQuality-India-Realtime.xlsx");

            // now transform into the desired class structure for generating the city-wise entries 
            // the values are now in CityWiseEntry class 
            ConvertEntriesToCitywiseEntries(entries);

            // also transform into the desired class structure for pollutant-wise reports

            // now generate the report for each city 
            new CitywisePollutantReport().GeneratePdf(path, "India Pollution Report", 15);

            var ReportFooter = $"Report has been generated at {path}";
            Console.WriteLine(ReportFooter);

            Console.ReadLine();

        }


        public class Entry
        {
            public static Entry CreateEntry(Location location, PollutantReading pollutantReading)
            {
                return new Entry(location, pollutantReading);
            }

            protected Entry(Location location, PollutantReading pollutantReading)
            {
                this.Country = location.Country;
                this.State = location.State;
                this.City = location.City;
                this.Place = location.Place;
                this.LastUpdatedTime = pollutantReading.LastUpdatedTime;
                this.Average = pollutantReading.Average;
                this.Max = pollutantReading.Max;
                this.Min = pollutantReading.Min;
                this.Pollutant = location.Pollutant;
            }

            public string Country { get; }
            public string State { get; }
            public string City { get; }
            public string Place { get; }
            public string LastUpdatedTime { get; }
            public int Average { get; }
            public int Max { get; }
            public int Min { get; }
            public string Pollutant { get; }

            public override string ToString()
            {
                return $"{Country}:{State}:{City}:{Place}:{LastUpdatedTime}:{Average}:{Max}:{Min}:{Pollutant}";
            }
        }

        public class CityWiseEntry : AirQualityReporter.Entry
        {
            // string CityHeading is the key
            // LastUpdatedTime is the common value 
            // values are the tuple of Average, Max, Min, Pollutants 

            public static Dictionary<string, List<Tuple<int, int, int, string>>> CityWiseReadings =
                new Dictionary<string, List<Tuple<int, int, int, string>>>();

            public static string LastUpdatedTime = string.Empty;

            // Don't call CityWiseEntry constructor - rather, call the AddToCityWiseEntry to add a new entry 
            public CityWiseEntry() : base(new Location(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty), new PollutantReading(string.Empty, 0, 0, 0))
            {
            }

            public static void AddToCityWiseEntry(string Country, string State, string City, string Place,
                string UpdatedTime, int Average, int Max, int Min, string Pollutant)
            {
                var heading = $"{Country} - {State} - {City} - {Place}";
                if (UpdatedTime != null) LastUpdatedTime = UpdatedTime;
                var cityEntry = new Tuple<int, int, int, string>(Average, Max, Min, Pollutant);
                if (!CityWiseReadings.ContainsKey(heading))
                    CityWiseReadings[heading] = new List<Tuple<int, int, int, string>>();
                CityWiseReadings[heading].Add(cityEntry);
            }
        }
    }
}
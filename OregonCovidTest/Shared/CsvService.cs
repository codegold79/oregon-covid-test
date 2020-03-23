using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CsvHelper;

namespace OregonCovidTest.Shared
{

    public class Pin
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
    }

    public class CsvService
    {
        private List<Pin> _pins;

        public List<Pin> Pins => _pins ??= GetPins();

        public CsvService()
        {
           
        }

        private List<Pin> GetPins()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "OregonCovidTest.Shared.CovidTestSites.csv";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);

            using var reader = new StreamReader(stream);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var pins = csv.GetRecords<Pin>().ToList();
                return pins;
            }
            
        }

    }
}

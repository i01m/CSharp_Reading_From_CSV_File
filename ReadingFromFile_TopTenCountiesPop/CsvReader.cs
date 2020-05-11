using System.Collections.Generic;
using System.IO;

namespace ReadingFromFile_CountiesPop
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public Dictionary<string,List<Country>> ReadAllNCountries()
        {
            var countries = new Dictionary<string,List<Country>>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                //read header line
                sr.ReadLine();

                string csvLine;
                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    if (countries.ContainsKey(country.Region))
                    {
                        countries[country.Region].Add(country);
                    }
                    else
                    {
                        List<Country> countriesInRegion = new List<Country>() { country };
                        countries.Add(country.Region, countriesInRegion);
                    }
                }
            }

            return countries;

            //using (StreamReader sr = new StreamReader(_csvFilePath))
            //{
            //    //read header line
            //    sr.ReadLine();

            //    string csvLine;
            //    while ((csvLine = sr.ReadLine()) != null)
            //    {
            //        Country country = ReadCountryFromCsvLine(csvLine);
            //        countries.Add(country.Region,country);
            //    }
            //}
            //return countries;
        }

        public void RemoveCountriesWithSpace(List<Country> countries)
        {
            countries.RemoveAll(x => x.Name.Contains(" "));
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            string name = parts[0];
            string code = parts[1];
            string region = parts[2];
            int population = int.Parse(parts[3]);

            return new Country(name, code, region, population);
        }
    }
}

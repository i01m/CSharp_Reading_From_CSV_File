using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ReadingFromFile_CountiesPop
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\ProjectDevVm\C#\ReadingFromFile_TopTenCountiesPop\ReadingFromFile_TopTenCountiesPop\ReadingFromFile_TopTenCountiesPop\bin\Debug\population.csv";

            CsvReader reader = new CsvReader(filePath);

            Dictionary<string,List<Country>> countries = reader.ReadAllNCountries();

            foreach (string region in countries.Keys)
            {
                WriteLine(region);
            }

            Write("Which of the above regions would you like to display?");
            string chosenRegion = ReadLine();

            if (countries.ContainsKey(chosenRegion))
            {
                foreach (Country country in countries[chosenRegion].Take(10))
                    WriteLine($"{country.Name} has population {country.Population}");
            }
            else
            {
                WriteLine("This is not a valid region.");
            }
                


            //reader.RemoveCountriesWithSpace(countries);


            //foreach (Country country in countries.Where(x => ! x.Name.Contains(" ")))
            //{
            //    Console.WriteLine($"{country.Population} : {country.Name}");
            //}

            //**Displaying countries in batch (few at a time)
            //Write("Enter number of countries to display: ");
            //bool isInputInt = int.TryParse(ReadLine(), out int userInput);

            //if (!isInputInt || userInput <= 0)
            //{
            //    WriteLine("Enter positive number");
            //    return;
            //}

            //int maxToDisplay = userInput;
            //for (int i=0; i<countries.Count; i++)
            //{
            //    if (i > 0 && (i % maxToDisplay == 0))
            //    {
            //        WriteLine("Hit return to continue, anything else to quit>");
            //        if (ReadLine() != "")
            //            break;
            //    }            
            //    Country country = countries[i];
            //    Console.WriteLine($"{i+1} : {country.Population} : {country.Name}");
            //}
            
            
            
            //Dictionary<string, Country> countries = reader.ReadAllNCountries();

            //Console.WriteLine("Which country code do you want to look up?");
            //string userInput = Console.ReadLine();

            //bool gotCountry = countries.TryGetValue(userInput, out Country country);

            //if (gotCountry)
            //{
            //    Console.WriteLine($"{country.Name} has population {country.Population}");
            //}
            //else
            //{
            //    Console.WriteLine($"There is no country with the code {userInput}");
            //}





            Console.ReadKey();
        }
    }
}

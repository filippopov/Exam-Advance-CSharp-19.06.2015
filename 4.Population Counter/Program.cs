using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Population_Counter
{
    class Program
    {
        private static Dictionary<string, Dictionary<string, long>> countrysAndCitys; 
        static void Main(string[] args)
        {
            countrysAndCitys=new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            
            while (input != "report")
            {
                string[] inputArray = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string city = inputArray[0].Trim();
                string country = inputArray[1].Trim();
                int countPeople = int.Parse(inputArray[2].Trim());
                if (!countrysAndCitys.ContainsKey(country))
                {
                    countrysAndCitys.Add(country,new Dictionary<string, long>());
                    if (!countrysAndCitys[country].ContainsKey(city))
                    {
                        countrysAndCitys[country].Add(city,countPeople);
                    }
                    else
                    {
                        long oldValue = countrysAndCitys[country][city];
                        oldValue += countPeople;
                        countrysAndCitys[country][city] = oldValue;
                    }
                }
                else
                {
                    if (!countrysAndCitys[country].ContainsKey(city))
                    {
                        countrysAndCitys[country].Add(city, countPeople);
                    }
                    else
                    {
                        long oldValue = countrysAndCitys[country][city];
                        oldValue += countPeople;
                        countrysAndCitys[country][city] = oldValue;
                    }
                }
                
                input = Console.ReadLine();
            }

            var newCountrysAndCitys = countrysAndCitys.OrderByDescending(a => a.Value.Values.Sum());
            
                

            foreach (var country in newCountrysAndCitys)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Values.Sum()})");
                var orderCountry = country.Value.OrderByDescending(a => a.Value);

                foreach (var city in orderCountry)
                {
                    
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}

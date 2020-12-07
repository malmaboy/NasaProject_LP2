using System;
using System.Collections.Generic;
using System.Linq;

namespace NasaProject
{
    /// <summary>
    /// This Class filter the parameters
    /// </summary>
    public class Filter
    {

        IEnumerable<Planet> filteredPlanets;
        IEnumerable<Star> filteredStars;

        public Filter(FileReader file)
        {
            filteredPlanets = file.GetPlanets();
            filteredStars = file.GetStars();
        }

        public void FilterName(string name)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.Name == name
                select planet;
        }

        public void FilterMaxEqt(float max)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.Eqt < max
            select planet;
        }
        public void FilterMinEqt(float min)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.Eqt > min
            select planet;
        }

        public void FilterMaxRade(float max)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.Rade < max
            select planet;
        }
        public void FilterMinRade(float min)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.Rade > min
            select planet;
        }

        public void FilterDiscMethod(string method)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.DiscMethod == method
            select planet;
        }
        public void FilterMaxDiscYear(int max)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.DiscYear < max
            select planet;
        }
        public void FilterMinDiscYear(int min)
        {
            filteredPlanets =
            from planet in filteredPlanets
            where planet.DiscYear > min
            select planet;
        }

        public void PrintPlanets()
        {
            foreach(Planet planet in filteredPlanets)
            {
                System.Console.WriteLine($"{planet.Name} {planet.Eqt}");
            }
        }
    }
}
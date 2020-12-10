using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

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
                where planet.Eqt != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Double.Parse(planet.Eqt, NumberStyles.Any,
                     CultureInfo.InvariantCulture) <= max
                select planet;
        }
        public void FilterMinEqt(float min)
        {

            filteredPlanets =
                from planet in filteredPlanets
                where planet.Eqt != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Double.Parse(planet.Eqt, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select planet;
        }

        public void FilterMaxRade(float max)
        {

            filteredPlanets =
                from planet in filteredPlanets
                where planet.Rade != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Double.Parse(planet.Rade, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select planet;
        }
        public void FilterMinRade(float min)
        {

            filteredPlanets =
                from planet in filteredPlanets
                where planet.Rade != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Single.Parse(planet.Rade, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
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
                where planet.DiscYear != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Int32.Parse(planet.DiscYear, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select planet;
        }
        public void FilterMinDiscYear(int min)
        {

            filteredPlanets =
                from planet in filteredPlanets
                where planet.DiscYear != "N/A" && planet.Eqt != ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Int32.Parse(planet.DiscYear, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select planet;
        }

        public void FilterStarName(string name)
        {
            filteredStars =
                from star in filteredStars
                where star.Name == name
                select star;
        }

        public void FilterMaxStarTeff(float max)
        {

            filteredStars =
                from star in filteredStars
                where star.Teff != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Teff, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }
        public void FilterMinStarTeff(float min)
        {

            filteredStars =
                from star in filteredStars
                where star.Teff != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Teff, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public void FilterMaxStarMass(float max)
        {

            filteredStars =
                from star in filteredStars
                where star.Mass != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Mass, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }

        public void FilterMinStarMass(float min)
        {

            filteredStars =
                from star in filteredStars
                where star.Mass != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Mass, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public void FilterMinStarRad(float min)
        {

            filteredStars =
                from star in filteredStars
                where star.Rad != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Rad, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= min
                select star;
        }

        public void FilterMaxStarRad(float max)
        {

            filteredStars =
                from star in filteredStars
                where star.Rad != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.Rad, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= max
                select star;
        }

        public void FilterMaxStarDistance(float max)
        {

            filteredStars =
                from star in filteredStars
                where star.DistanceStarToSun != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.DistanceStarToSun, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }
        public void FilterMinStarDistance(float min)
        {

            filteredStars =
                from star in filteredStars
                where star.DistanceStarToSun != "N/A" && star.Teff != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.DistanceStarToSun, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public IEnumerable<Planet> GetFilteredPlanets()
        {
            foreach (Planet planet in filteredPlanets)
            {
                yield return planet;
            }
        }

        public IEnumerable<Star> GetFilteredStars()
        {
            foreach (Star star in filteredStars)
            {
                yield return star;
            }
        }
    }
}
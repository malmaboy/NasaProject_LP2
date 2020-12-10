
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
                where Single.Parse(planet.Eqt, NumberStyles.Any,
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
                where Single.Parse(planet.Eqt, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select planet;
        }

        public void FilterMaxRade(float max)
        {

            filteredPlanets =
                from planet in filteredPlanets
                where planet.Rade != "N/A" && planet.Rade != ""
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
                where planet.Rade != "N/A" && planet.Rade != ""
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
                where planet.DiscYear != "N/A" && planet.DiscYear != ""
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
                where planet.DiscYear != "N/A" && planet.DiscYear!= ""
                select planet;

            filteredPlanets =
                from planet in filteredPlanets
                where Int32.Parse(planet.DiscYear, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select planet;
        }

        public void FilterMinOrbPer(float min)
        {
            filteredPlanets =
                 from planet in filteredPlanets
                 where planet.OrbPer != "N/A" && planet.OrbPer!= ""
                 select planet;

            filteredPlanets=
                from planet in filteredPlanets
                where   Int32.Parse(planet.OrbPer, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >=min
                select planet;
        }

        public void FilterMaxOrbPer(int max)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.OrbPer != "N/A" && planet.OrbPer != ""
                select planet;

                filteredPlanets=
                from planet in filteredPlanets
                where   Int32.Parse(planet.OrbPer, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <=max
                select planet;
        }
        public void FilterMinMasse(float min)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.Masse != "N/A" && planet.Masse != ""
                select planet;

                filteredPlanets=
                from planet in filteredPlanets
                where   Int32.Parse(planet.Masse, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >=min
                select planet;
        }
        public void FilterMaxMasse(float max)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.Masse != "N/A" && planet.Masse != ""
                select planet;

                filteredPlanets=
                from planet in filteredPlanets
                where Single.Parse(planet.Masse, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <=max
                select planet;
        }

        // Star Filters

        
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
                where star.Mass != "N/A" && star.Mass != ""
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
                where star.Mass != "N/A" && star.Mass != ""
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
                where star.Rad != "N/A" && star.Rad != ""
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
                where star.Rad != "N/A" && star.Rad != ""
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
                where star.DistanceStarToSun != "N/A" && star.DistanceStarToSun != ""
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
                where star.DistanceStarToSun != "N/A" && star.DistanceStarToSun != ""
                select star;

            filteredStars =
                from star in filteredStars
                where Single.Parse(star.DistanceStarToSun, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public void FilterMinStarAge(int min)
        {
            filteredStars =
                from star in filteredStars
                where star.StarAge != "N/A" && star.StarAge != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarAge, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public void FilterMaxStarAge(int max)
        {
            filteredStars =
                from star in filteredStars
                where star.StarAge != "N/A" && star.StarAge != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarAge, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }

        public void FilterMaxStarRVelocity(float max)
        {
            filteredStars =
                from star in filteredStars
                where star.StarRotationVelocity != "N/A" && star.StarRotationVelocity != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarRotationVelocity, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }

        public void FilterMinStarRVelocity(float min)
        {
            filteredStars =
                from star in filteredStars
                where star.StarRotationVelocity != "N/A" && star.StarRotationVelocity != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarRotationVelocity, NumberStyles.Any,
                    CultureInfo.InvariantCulture) >= min
                select star;
        }

        public void FilterMaxStarRPeriod(float max)
        {
            filteredStars =
                from star in filteredStars
                where star.StarRotationPeriod != "N/A" && star.StarRotationPeriod != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarRotationPeriod, NumberStyles.Any,
                    CultureInfo.InvariantCulture) <= max
                select star;
        }

        public void FilterMinStarRPeriod(float min)
        {
            filteredStars =
                from star in filteredStars
                where star.StarRotationPeriod != "N/A" && star.StarRotationPeriod != ""
                select star;

                filteredStars =
                from star in filteredStars
                where Single.Parse(star.StarRotationPeriod, NumberStyles.Any,
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
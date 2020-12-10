
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
        
        /// Variables 

        /// <summary>
        /// Filter the Planets Arguments 
        /// </summary>
        IEnumerable<Planet> filteredPlanets;
        /// <summary>
        /// Filter the Star Arguments 
        /// </summary>
        IEnumerable<Star> filteredStars;


        /// <summary>
        /// Filter Constructor 
        /// </summary>
        /// <param name="file">File Path</param>
        public Filter(FileReader file)
        {
            filteredPlanets = file.GetPlanets();
            filteredStars = file.GetStars();
        }

        /// <summary>
        /// Filter Planet Name 
        /// </summary>
        /// <param name="name"></param>
        public void FilterName(string name)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.Name == name
                select planet;
        }

        /// <summary>
        /// Filter the max Temperature 
        /// </summary>
        /// <param name="max"></param>
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

        /// <summary>
        /// Filter the Min temperature 
        /// </summary>
        /// <param name="min"></param>
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

        /// <summary>
        /// Filter the Max Radius
        /// </summary>
        /// <param name="max"></param>

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

        /// <summary>
        /// Filter the Min Radius
        /// </summary>
        /// <param name="min"></param>
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
        /// <summary>
        /// Filters the Discovery Method 
        /// </summary>
        /// <param name="method"></param>
        public void FilterDiscMethod(string method)
        {
            filteredPlanets =
                from planet in filteredPlanets
                where planet.DiscMethod == method
                select planet;
        }
        /// <summary>
        /// Filters the Max Discovery Year
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filters the Min Discovery Year
        /// </summary>
        /// <param name="min"></param>
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

        /// <summary>
        /// Filters the Min orbital Period
        /// </summary>
        /// <param name="min"></param>

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

        /// <summary>
        /// Filters the Max Orbital Period
        /// </summary>
        /// <param name="max"></param>
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

        /// <summary>
        /// Filters the min Mass
        /// </summary>
        /// <param name="min"></param>
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
        /// <summary>
        /// Filters the Max Mass
        /// </summary>
        /// <param name="max"></param>
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

        /// Star Filters

        /// <summary>
        /// Filters The Star Name
        /// </summary>
        /// <param name="name"></param>
        public void FilterStarName(string name)
        {
            filteredStars =
                from star in filteredStars
                where star.Name == name
                select star;
        }
        /// <summary>
        /// Filters the Max Temperature
        /// </summary>
        /// <param name="max"></param>

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

        /// <summary>
        /// Filters the Min Temperature
        /// </summary>
        /// <param name="min"></param>
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

        /// <summary>
        /// Filters the Max Mass
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filters the Min Mass
        /// </summary>
        /// <param name="min"></param>
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

        /// <summary>
        /// Filters the min Radius 
        /// </summary>
        /// <param name="min"></param>
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
        /// <summary>
        /// Filter the Max Radius 
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filters the Max Distance between the Star ans Sun
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filters the Min Distance between the Star ans Sun
        /// </summary>
        /// <param name="min"></param>
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
        /// <summary>
        /// Filters the Min Age
        /// </summary>
        /// <param name="min"></param>
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
        /// <summary>
        /// Filter the Max Age
        /// </summary>
        /// <param name="max"></param>

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

        /// <summary>
        /// Filter the Max Star Rotation Velocity
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filter the Min Star Rotation Velocity
        /// </summary>
        /// <param name="min"></param>

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
        /// <summary>
        /// Filters the Max Star Rotation Period 
        /// </summary>
        /// <param name="max"></param>
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
        /// <summary>
        /// Filters the Min Star Rotation Period 
        /// </summary>
        /// <param name="min"></param>
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

        /// <summary>
        /// Returns the filtered Planet one by one
        /// </summary>
        /// <returns>Filtered Planets</returns>
        public IEnumerable<Planet> GetFilteredPlanets()
        {
            foreach (Planet planet in filteredPlanets)
            {
                yield return planet;
            }
        }
        /// <summary>
        /// Returns the filtered Stars one by one
        /// </summary>
        /// <returns>Filtered Stars</returns>
        public IEnumerable<Star> GetFilteredStars()
        {
            foreach (Star star in filteredStars)
            {
                yield return star;
            }
        }
    }
}
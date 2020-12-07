using System;
using System.Globalization;

namespace NasaProject
{
    /// <summary>
    /// Contains all the info of Stars
    /// </summary>
    public class Star
    {

        /// Variables

        /// Star Name
        public string Name { get; private set; }
        /// Star Tempererature (kelvins)
        public float Teff { get; private set; }
        /// Star Radius(comparing to the sun)
        public float Rad { get; private set; }

        ///  Star Mass (Comparing to Sun)
        public int Mass { get; private set; }

        /// Star Age (Giga-Years)
        public float StarAge { get; private set; }

        /// Star Rotatation Velocity(km/s)
        public float StarRotationVelocity { get; private set; }

        /// Star Rotation Period (days)
        public float StarRotationPeriod { get; private set; }

        /// Distance to Sun (Parcecs)
        public double DistanceStarToSun { get; private set; }

        /// <summary>
        /// Star Constructor 
        /// </summary>
        /// <param name="_teff"></param>
        /// <param name="_rad"></param>
        /// <param name="_mass"></param>
        /// <param name="_starAge"></param>
        /// <param name="_starRotationVelocity"></param>
        /// <param name="_starRotationPeriod"></param>
        /// <param name="_distanceStarToSun"></param>
        public Star(string _name, string _teff, string _rad,
            string _mass, string _starAge, string _starRotationVelocity,
            string _starRotationPeriod, string _distanceStarToSun)
        {
            /// <summary>
            /// Convert the number's to strings
            /// </summary>
            /// <value></value>
            Name = _name;

            if (_teff.Length > 0)
            {
                Teff = Single.Parse(_teff, NumberStyles.Any,
                CultureInfo.InvariantCulture);
            }
            else
            {
                Teff = 0;
            }

            if (_rad.Length > 0)
            {
                Rad = Single.Parse(_rad, NumberStyles.Any,
                CultureInfo.InvariantCulture);
            }
            else
            {
                Rad = 0;
            }

            if (_mass.Length > 0)
            {
                Mass = (int)Math.Round(Double.Parse(_mass, NumberStyles.Any,
                CultureInfo.InvariantCulture));
            }

            else
            {
                Mass = 0;
            }

            if (_starAge.Length > 0)
            {
                StarAge = Single.Parse(_starAge, NumberStyles.Any,
                CultureInfo.InvariantCulture);
            }
            else
            {
                StarAge = 0;
            }

            if (_starRotationVelocity.Length > 0)
            {
                StarRotationVelocity = Single.Parse(_starRotationVelocity, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            }
            else
            {
                StarRotationVelocity = 0;
            }

            if (_starRotationPeriod.Length > 0)
            {
                StarRotationPeriod = Single.Parse(_starRotationPeriod, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            }
            else
            {
                StarRotationPeriod = 0;
            }

            if (_distanceStarToSun.Length > 0)
            {
                DistanceStarToSun = Single.Parse(_distanceStarToSun, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            }
            else
            {
                DistanceStarToSun = 0;
            }
        }
    }
}
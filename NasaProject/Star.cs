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
        public string Name { get;  set; }
        /// Star Tempererature (kelvins)
        public string Teff { get;  set; }
        /// Star Radius(comparing to the sun)
        public string Rad { get;  set; }

        ///  Star Mass (Comparing to Sun)
        public string Mass { get;  set; }

        /// Star Age (Giga-Years)
        public string StarAge { get;  set; }

        /// Star Rotatation Velocity(km/s)
        public string StarRotationVelocity { get;  set; }

        /// Star Rotation Period (days)
        public string StarRotationPeriod { get;  set; }

        /// Distance to Sun (Parsecs)
        public string DistanceStarToSun { get;  set; }

        /// <summary>
        /// Star Constructor 
        /// </summary>
        /// <param name="_teff">Star Temperature</param>
        /// <param name="_rad">Star Radius</param>
        /// <param name="_mass">Star Mass</param>
        /// <param name="_starAge">Star Age</param>
        /// <param name="_starRotationVelocity">Star Rotation Velocity</param>
        /// <param name="_starRotationPeriod">Star Rotation Period(days)</param>
        /// <param name="_distanceStarToSun">Distance from Star to Sun</param>
        public Star(string _name, string _teff, string _rad,
            string _mass, string _starAge, string _starRotationVelocity,
            string _starRotationPeriod, string _distanceStarToSun)
        {
            /// <summary>
            /// Checks if there is a value and sets it or not (N/A)
            /// </summary>
            /// <value></value>
            Name = _name;
            Teff = _teff != "" ? _teff : "N/A";
            Rad = _rad != "" ? _rad : "N/A";
            Mass = _mass != "" ? _mass : "N/A";
            StarAge = _starAge != "" ? _starAge : "N/A";
            StarRotationVelocity = _starRotationVelocity != "" ?
            _starRotationVelocity : "N/A";
            StarRotationPeriod = _starRotationPeriod != "" ?
             _starRotationPeriod : "N/A";
            DistanceStarToSun = _distanceStarToSun != "" ?
            _distanceStarToSun : "N/A";

        }
    }
}
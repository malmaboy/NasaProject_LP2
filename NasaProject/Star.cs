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
        public string Teff { get; private set; }
        /// Star Radius(comparing to the sun)
        public string Rad { get; private set; }

        ///  Star Mass (Comparing to Sun)
        public string Mass { get; private set; }

        /// Star Age (Giga-Years)
        public string StarAge { get; private set; }

        /// Star Rotatation Velocity(km/s)
        public string StarRotationVelocity { get; private set; }

        /// Star Rotation Period (days)
        public string StarRotationPeriod { get; private set; }

        /// Distance to Sun (Parcecs)
        public string DistanceStarToSun { get; private set; }

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
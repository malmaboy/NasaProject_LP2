using System;
using System.Globalization;

namespace NasaProject {
    public class Planet {
        /// <summary>
        /// Variables
        /// </summary>

        // Planet name 
        public string Name { get; private set; }
        // Star name
        public string Hostname { get; private set; }
        // Discovery Method
        public string DiscMethod { get; private set; }
        // Year Found 
        public int DiscYear { get; private set; }

        // Orbital Period (days)
        public int OrbPer { get; private set; }

        // Planet Radius Relative to Earth
        public float Rade { get; private set; }
        // Planet Mass Relative to Earth
        public float Masse { get; private set; }

        // Planet Equilibrium Temperature (kelvins)
        public float Eqt { get; private set; }

        /// <summary>
        /// Planet Constructor 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_hostname"></param>
        /// <param name="_discMethod"></param>
        /// <param name="_discYear"></param>
        /// <param name="_orbper"></param>
        /// <param name="_rade"></param>
        /// <param name="_masse"></param>
        /// <param name="_eqt"></param>
        public Planet (string _name, string _hostname,
            string _discMethod, string _discYear,
            string _orbPer, string _rade, string _masse, string _eqt) {
            Name = _name;
            Hostname = _hostname;
            DiscMethod = _discMethod;
            DiscYear = Int32.Parse (_discYear);

            if (_orbPer.Length > 0)
                OrbPer = (int) Math.Round (Double.Parse (_orbPer, NumberStyles.Any,
                    CultureInfo.InvariantCulture));
            else
                OrbPer = 0;

            if (_rade.Length > 0)
                Rade = Single.Parse (_rade, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            else
                Rade = 0;

            if (_masse.Length > 0)
                Masse = Single.Parse (_masse, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            else
                Masse = 0;

            if (_eqt.Length > 0)
                Eqt = Single.Parse (_eqt, NumberStyles.Any,
                    CultureInfo.InvariantCulture);
            else
                Eqt = 0;
        }

    }
}
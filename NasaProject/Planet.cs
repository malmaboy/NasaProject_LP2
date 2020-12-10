using System;
namespace NasaProject
{
    public class Planet
    {
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
        public string DiscYear { get; private set; }

        // Orbital Period (days)
        public string OrbPer { get; private set; }

        // Planet Radius Relative to Earth
        public string Rade { get; private set; }
        // Planet Mass Relative to Earth
        public string Masse { get; private set; }

        // Planet Equilibrium Temperature (kelvins)
        public string Eqt { get; private set; }

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
        public Planet(string _name, string _hostname,
            string _discMethod, string _discYear,
            string _orbPer, string _rade, string _masse, string _eqt)
        {
            Name = _name;
            Hostname = _hostname != "" ? _hostname : "N/A";
            DiscMethod = _discMethod != "" ? _discMethod : "N/A";
            DiscYear = _discYear != "" ? _discYear : "N/A";
            OrbPer = _orbPer != "" ? _orbPer : "N/A";
            Rade = _rade != "" ? _rade : "N/A";
            Masse = _masse != "" ? _masse : "N/A";
            Eqt = _eqt != "" ? _eqt : "N/A";
        }
    }
}
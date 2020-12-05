using System;

namespace NasaProject
{
    public class Planet
    {
        /// <summary>
        /// Variables
        /// </summary>
        public readonly string name; // Planet name 
        private readonly string hostname; // Star name
        private readonly string discMethod; // Method found
        private readonly string discYear; // Year Found 
        private readonly string orbper; // Orbital Period (days)
        private readonly string rade; // Planet Radius 

        private readonly string masse; // Planet Mass

        private readonly string eqt; // Planet Equilibrium Temperarture (kelvins)

        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_hostname"></param>
        /// <param name="_discMethod"></param>
        /// <param name="_discYear"></param>
        /// <param name="_orbper"></param>
        /// <param name="_rade"></param>
        /// <param name="_masse"></param>
        /// <param name="_eqt"></param>
        public Planet(string _name, string _hostname, string _discMethod, string _discYear,
            string _orbper,string _rade, string _masse,string _eqt)
        {
            name = _name;
            hostname = _hostname;
            discMethod = _discMethod;
            discYear=_discYear;
            orbper = _orbper;
            rade = _rade;
            masse = _masse;
            eqt = _eqt; 
        }
    }
}
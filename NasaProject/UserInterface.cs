using System;
using System.Globalization;

namespace NasaProject
{
    /// <summary>
    /// This Class reads the arguments given by the user and 
    /// prints the informations
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// The 
        /// </summary>
        /// <value></value>
        public string FilePath { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        private Filter filteredSearch;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Arguments given by the user</param>
        public void Start(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--file")
                {
                    FilePath = args[i + 1];
                    break;
                }
            }

            if (FilePath != null)
            {
                FileReader nasaInfo = new FileReader();

                try
                {
                    nasaInfo.ReadFile(FilePath);
                }
                catch (Exception e)
                {
                    FileError(e);
                    Environment.Exit(0);
                }

                filteredSearch = new Filter(nasaInfo);

                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "search-planets")
                    {
                        SearchPlanets(args);
                        break;
                    }

                    else if (args[i] == "search-stars")
                    {
                        SearchStars(args);
                        break;
                    }

                    else if (args[i] == "planet-info")
                    {
                        PlanetInfo(args);
                        break;
                    }
                }
            }
            else
                Environment.Exit(0);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private void SearchPlanets(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--eqt-max")
                {
                    filteredSearch.FilterMaxEqt(Single.Parse(args[i + 1],
                        NumberStyles.Any, CultureInfo.InvariantCulture));
                }
                if (args[i] == "--eqt-min")
                {
                    filteredSearch.FilterMinEqt(Single.Parse(args[i + 1],
                        NumberStyles.Any, CultureInfo.InvariantCulture));
                }
                if (args[i] == "--rade-max")
                {
                    filteredSearch.FilterMaxRade(Single.Parse(args[i + 1],
                        NumberStyles.Any, CultureInfo.InvariantCulture));
                }
                if (args[i] == "--rade-min")
                {
                    filteredSearch.FilterMinRade(Single.Parse(args[i + 1],
                        NumberStyles.Any, CultureInfo.InvariantCulture));
                }
                if (args[i] == "--years-min")
                {
                    filteredSearch.FilterMinDiscYear(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture));
                }
                if (args[i] == "--years-max")
                {
                    filteredSearch.FilterMaxDiscYear(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture));

                }
            }

            PrintPlanetResults();
        }

        private void SearchStars(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--dist-max")
                {
                    filteredSearch.FilterMaxStarDistance(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture));
                }

                if (args[i] == "--dist-min")
                {
                    filteredSearch.FilterMinStarDistance(Single.Parse(args[i + 1],
                        NumberStyles.Any, CultureInfo.InvariantCulture));
                }

            }

            PrintStarResults();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Argument given by user</param>
        private void PlanetInfo(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--pl_name")
                {
                    filteredSearch.FilterName(args[i + 1]);
                }
            }

            PrintPlanetResults();
        }




        /// <summary>
        /// Print the top info about planets
        /// </summary>
        private void PrintTableTopPlanets()
        {
            Console.WriteLine("\n\nPlanet name     Star name      Disc. method   " +
            "  Year    Orbital         Radius      Mass        Eq. Temp.");
            Console.WriteLine("                                      " +
            "                  Period (days)   (vs Earth)  (vs Earth)   " +
            "(Kelvin)");
            Console.WriteLine("------------------------------------" +
            "--------------------------------------------------------------" +
            "-------");
        }
        /// <summary>
        /// Print the top info about stars
        /// </summary>
        private void PrintTableTopStars()
        {
            Console.WriteLine("\n\nStar name     Star Temperature      Star Radius   " +
            "  Star Mass         Star Age        Star Rotation.");
            Console.WriteLine("                                      " +
            "                  Period (days)   (vs Earth)  (vs Earth)   " +
            "(Kelvin)");
            Console.WriteLine("------------------------------------" +
            "--------------------------------------------------------------" +
            "-------");
        }
        /// <summary>
        /// Prints all the Planets within the users restrictions
        /// </summary>
        public void PrintPlanetResults()
        {
            PrintTableTopPlanets();

            foreach (Planet planet in filteredSearch.GetFilteredPlanets())
            {
                System.Console.WriteLine(
                    $"{planet.Name}\t{planet.Hostname}\t{planet.DiscMethod}"
                    + $"\t{planet.DiscYear}\t{planet.OrbPer}\t" +
                    $"{planet.Rade}\t{planet.Masse}\t{planet.Eqt}");
            }
        }

        /// <summary>
        /// Prints all the Star results given by the user
        /// </summary>
        public void PrintStarResults()
        {
            PrintTableTopStars();

            foreach (Star star in filteredSearch.GetFilteredStars())
            {
                System.Console.WriteLine(
                    $"{star.Name}\t{star.Teff}\t{star.Rad}"
                    + $"\t{star.Mass}\t{star.StarAge}\t" +
                    $"{star.StarRotationVelocity}");
            }
        }

        /// <summary>
        /// Prints errors if there's an error in the file
        /// </summary>
        /// <param name="e">Expection Error</param>
        private void FileError(Exception e)
        {
            Console.WriteLine($"Houve um problema com o ficheiro.");
        }
    }
}
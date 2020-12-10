
using System;
using System.Globalization;
using System.IO;

namespace NasaProject
{
    /// <summary>
    /// This Class reads the arguments given by the user and 
    /// prints the informations
    /// </summary>
    public class UserInterface
    {
        /// Variables 
        /// 
        ///         /// <summary>
        /// The location of the file
        /// </summary>
        /// <value></value>
        public string FilePath { get; private set; }
        /// <summary>
        /// The filter
        /// </summary>
        private Filter filteredSearch;

        /// <summary>
        /// Read the file and the arguments given by the user 
        /// </summary>
        /// <param name="args">Arguments given by the user</param>
        public void Start(string[] args)
        {
            int mode = 0;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--file")
                {
                    try
                    {
                        FilePath = args[i + 1];
                    }
                    catch (Exception e)
                    {
                        FileError(e, "file");
                    }
                }
                else if (args[i] == "--csv")
                {
                    mode = 1;
                }
            }

            if (FilePath != null)
            {
                FileReader nasaInfo = new FileReader();

                try
                {
                    nasaInfo.ReadFile(FilePath, mode);
                }
                catch (Exception e)
                {
                    FileError(e, "read");
                    Environment.Exit(0);
                }

                if (mode == 0)
                {
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
                        else
                        {
                            SearchMethodError();
                        }
                    }
                }
                else if (mode == 1)
                {
                    PrintRawCsv(nasaInfo);
                }

            }
            else
                Environment.Exit(0);

        }
        /// <summary>
        /// Planets Filters
        /// </summary>
        /// <param name="args">Arguments given by the user </param>
        private void SearchPlanets(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    if (args[i] == "--pl_name")
                    {
                        filteredSearch.FilterName(args[i + 1]);
                    }
                    else if (args[i] == "--hostname")
                    {
                        filteredSearch.FilterStarName(args[i + 1]);
                    }
                    else if (args[i] == "--discmethod")
                    {
                        filteredSearch.FilterDiscMethod(args[i + 1]);
                    }
                    else if (args[i] == "--years-min")
                    {
                        filteredSearch.FilterMinDiscYear(Int32.Parse(args[i + 1],
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--years-max")
                    {
                        filteredSearch.FilterMaxDiscYear(Int32.Parse(args[i + 1],
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--eqt-max")
                    {
                        filteredSearch.FilterMaxEqt(Single.Parse(args[i + 1],
                            NumberStyles.Any, CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--eqt-min")
                    {
                        filteredSearch.FilterMinEqt(Single.Parse(args[i + 1],
                            NumberStyles.Any, CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rade-max")
                    {
                        filteredSearch.FilterMaxRade(Single.Parse(args[i + 1],
                            NumberStyles.Any, CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rade-min")
                    {
                        filteredSearch.FilterMinRade(Single.Parse(args[i + 1],
                            NumberStyles.Any, CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--orbper-min")
                    {
                        filteredSearch.FilterMinOrbPer(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--orbper-max")
                    {
                        filteredSearch.FilterMaxOrbPer(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--masse-min")
                    {
                        filteredSearch.FilterMaxMasse(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--masse-max")
                    {
                        filteredSearch.FilterMinMasse(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                }
                catch (Exception e)
                {
                    ArgumentError(e);
                }
            }

            PrintPlanetResults();
        }

        /// <summary>
        /// Star Filters
        /// </summary>
        /// <param name="args"></param>
        private void SearchStars(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    if (args[i] == "--st_name")
                    {
                        filteredSearch.FilterStarName(args[i + 1]);
                    }
                    else if (args[i] == "--teff-max")
                    {
                        filteredSearch.FilterMaxStarTeff(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--teff-min")
                    {
                        filteredSearch.FilterMinStarTeff(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rad-max")
                    {
                        filteredSearch.FilterMaxRade(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rad-min")
                    {
                        filteredSearch.FilterMinRade(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--mass-max")
                    {
                        filteredSearch.FilterMaxMasse(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--mass-min")
                    {
                        filteredSearch.FilterMinMasse(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--dist-max")
                    {
                        filteredSearch.FilterMaxStarDistance(Single.Parse(args[i + 1],
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }

                    else if (args[i] == "--dist-min")
                    {
                        filteredSearch.FilterMinStarDistance(Single.Parse(args[i + 1],
                            NumberStyles.Any, CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--age-max")
                    {
                        filteredSearch.FilterMaxStarAge(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--age-min")
                    {
                        filteredSearch.FilterMaxStarAge(Int32.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rotv-max")
                    {
                        filteredSearch.FilterMaxStarRVelocity(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rotv-min")
                    {
                        filteredSearch.FilterMinStarRVelocity(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rotp-max")
                    {
                        filteredSearch.FilterMaxStarRPeriod(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                    else if (args[i] == "--rotp-min")
                    {
                        filteredSearch.FilterMinStarRPeriod(Single.Parse(args[i + 1],
                        NumberStyles.Any,
                            CultureInfo.InvariantCulture));
                    }
                }
                catch (Exception e)
                {
                    ArgumentError(e);
                }


            }

            PrintStarResults();

        }

        /// <summary>
        /// Print the top info about planets
        /// </summary>
        private void PrintTableTopPlanets()
        {
            Console.WriteLine("\n\nPlanet name     Star name      Disc. method   " +
                "  Year    Orbital         Radius      Mass        Eq. Temp");
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
                "  Star Mass         Star Age        Star Rotation        Star Distance to Sun");
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
                    $"{planet.Name}\t{planet.Hostname}\t{planet.DiscMethod}" +
                    $"\t{planet.DiscYear}\t{planet.OrbPer}\t" +
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
                    $"{star.Name}\t\t{star.Teff}\t\t{star.Rad}" +
                    $"\t\t{star.Mass}\t\t{star.StarAge}\t" +
                    $"\t{star.StarRotationVelocity}\t{star.DistanceStarToSun}");
            }
        }

        /// <summary>
        /// Prints all the values in raw
        /// </summary>
        public void PrintRawCsv(FileReader file)
        {
            foreach (string s in file.GetLines())
            {
                System.Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Prints a Error
        /// </summary>
        public void FileFormatError()
        {
            System.Console.WriteLine("\nOcorreu um erro.\nFormato de ficheiro inválido.");
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints errors if there's an error in the file
        /// </summary>
        /// <param name="e">Expection Error</param>
        private void FileError(Exception e, string where)
        {
            Console.WriteLine("\nOcorreu um erro.");

            switch (e)
            {
                case FileNotFoundException:
                    if (where == "file")
                    {
                        System.Console.WriteLine("Caminho do ficheiro em falta.");
                    }
                    else if (where == "read")
                    {
                        Console.WriteLine(
                        "O ficheiro especificado não foi encontrado.");
                    }
                    break;

                case DirectoryNotFoundException:
                    Console.WriteLine(
                        "A diretoria especificada não foi encontrada.");
                    break;

                case ArgumentException:
                    Console.WriteLine(
                        $"Argumento inválido.");
                    break;

                case IndexOutOfRangeException:
                    if (where == "file")
                        Console.WriteLine(
                            "Caminho do ficheiro em falta.");

                    else if (where == "read")
                        System.Console.WriteLine("Argumento em falta");

                    break;

                case FormatException:
                    if (where == "read")
                        System.Console.WriteLine("Argumento inválido.");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Prints an error relative to the search argument
        /// </summary>
        private void SearchMethodError()
        {
            Console.WriteLine("\nOcorreu um erro.");
            Console.WriteLine("Método de pesquisa não referido ou inválido.");
            Environment.Exit(0);
        }
        /// <summary>
        /// Prints an error relative to the arguments
        /// </summary>
        /// <param name="e">Exception found</param>
        private void ArgumentError(Exception e)
        {
            Console.WriteLine("\nOcorreu um erro.");
            switch (e)
            {
                case FormatException:
                    Console.WriteLine("Um ou mais argumentos são inválidos.");
                    break;

                case IndexOutOfRangeException:
                    Console.WriteLine("Um ou mais argumentos em falta.");
                    break;

                default:
                    break;
            }

            Environment.Exit(0);
        }
    }
}

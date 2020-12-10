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
                    $"\t{star.StarRotationVelocity}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PrintRawCsv(FileReader file)
        {
            foreach (string s in file.GetLines())
            {
                System.Console.WriteLine(s);
            }
        }

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

        private void SearchMethodError()
        {
            System.Console.WriteLine("\nMétodo de pesquisa não referido ou inválido.");
            Environment.Exit(0);
        }
    }
}

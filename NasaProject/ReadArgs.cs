using System;
using System.Globalization;
using System.Linq;

namespace NasaProject
{
    public class ReadArgs
    {
        public string FilePath { get; private set; }

        private Filter filteredSearch;
        public void Read(string[] args)
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
                    System.Console.WriteLine(
                        $"Houve um problema com o ficheiro.\n\nErro:{e}");
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

            filteredSearch.PrintPlanets();
        }

        private void SearchStars(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "--dist-max")
                {
                    filteredSearch.FilterMaxStarDistance(Single.Parse(args[i+1], 
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture));
                }

                if (args[i] == "--dist-min")
                {
                    filteredSearch.FilterMinStarDistance(Single.Parse(args[i+1],
                        NumberStyles.Any,CultureInfo.InvariantCulture));
                }
                
            }

            filteredSearch.PrintStars();
        }

        private void PlanetInfo(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "pl_name")
                {
                    filteredSearch.FilterName(args[i + 1]);
                }
            }
        }
    }
}
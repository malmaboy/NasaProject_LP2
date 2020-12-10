using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

namespace NasaProject
{
    /// <summary>
    /// This class reads the file
    /// Does collections about planets and stars 
    /// </summary>
    public class FileReader
    {
        private List<Planet> planets;
        private List<Star> stars;
        private List<string> lines;
        int[] indexes;

        public FileReader()
        {
            planets = new List<Planet>();
            stars = new List<Star>();
            lines = new List<string>();
            indexes = new int[15]
                {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        }

        /// <summary>
        /// Read The File 
        /// </summary>
        public void ReadFile(string filePath, int mode)
        {
            string line;
            string[] lineValues;
            bool newStar;

            using (FileStream fileStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader =
                    new StreamReader(fileStream))
                {
                    if (mode == 0)
                    {
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("#") || line.Length == 0)
                            {
                                continue;
                            }
                            else

                                lineValues = line.Split(",");

                            if (line.Contains("pl_name"))
                            {
                                indexes[0] = Array.IndexOf(
                                    lineValues, "pl_name");
                                indexes[1] = Array.IndexOf(
                                    lineValues, "hostname");
                                indexes[2] = Array.IndexOf(
                                    lineValues, "discoverymethod");
                                indexes[3] = Array.IndexOf(
                                    lineValues, "disc_year");
                                indexes[4] = Array.IndexOf(
                                    lineValues, "pl_orbper");
                                indexes[5] = Array.IndexOf(
                                    lineValues, "pl_rade");
                                indexes[6] = Array.IndexOf(
                                    lineValues, "pl_masse");
                                indexes[7] = Array.IndexOf(
                                    lineValues, "pl_eqt");
                            }
                            else
                            {
                                planets.Add(new Planet(
                                    indexes[0] != -1 ? lineValues[indexes[0]] :
                                    "N/A",
                                    indexes[1] != -1 ? lineValues[indexes[1]] :
                                    "N/A",
                                    indexes[2] != -1 ? lineValues[indexes[2]] :
                                    "N/A",
                                    indexes[3] != -1 ? lineValues[indexes[3]] :
                                    "N/A",
                                    indexes[4] != -1 ? lineValues[indexes[4]] :
                                    "N/A",
                                    indexes[5] != -1 ? lineValues[indexes[5]] :
                                    "N/A",
                                    indexes[6] != -1 ? lineValues[indexes[6]] :
                                    "N/A",
                                    indexes[7] != -1 ? lineValues[indexes[7]] :
                                    "N/A"
                                ));


                                newStar = true;

                                for (int i = 0; i < stars.Count; i++)
                                {
                                    if (stars[i].Name == lineValues[1])
                                    {
                                        newStar = false;
                                        break;
                                    }
                                }

                                if (newStar)
                                {
                                    stars.Add(new Star(
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                        "0",
                                        "0"));
                                }
                            }

                        }
                    }
                    else if (mode == 1)
                    {
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("#") || line.Length == 0)
                            {
                                continue;
                            }
                            else
                            {
                                lines.Add(line);
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Get a list of planets
        /// </summary>
        /// <returns>Planets</returns>
        public List<Planet> GetPlanets() => planets;

        /// <summary>
        /// Get a list of Stars
        /// </summary>
        /// <returns>Stars</returns>
        public List<Star> GetStars() => stars;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetLines()
        {
            foreach (string s in lines)
            {
                yield return s;
            }
        }
    }
}
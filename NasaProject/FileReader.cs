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
        /// <summary>
        /// Variables
        /// </summary>
        private List<Planet> planets;
        private List<Star> stars;
        private List<string> lines;
        private int headers;
        int[] indexes;
        private UserInterface userInterface;

        /// <summary>
        /// File Reader Constructor 
        /// </summary>
        public FileReader()
        {
            userInterface = new UserInterface();
            planets = new List<Planet>();
            stars = new List<Star>();
            lines = new List<string>();
            indexes = new int[15]
                {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
        }

        /// <summary>
        /// Reads the File 
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
                                headers = lineValues.Length;

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
                                indexes[8] = Array.IndexOf(
                                    lineValues, "st_teff");
                                indexes[9] = Array.IndexOf(
                                    lineValues, "st_rad");
                                indexes[10] = Array.IndexOf(
                                    lineValues, "st_mass");
                                indexes[11] = Array.IndexOf(
                                    lineValues, "st_age");
                                indexes[12] = Array.IndexOf(
                                    lineValues, "st_vsin");
                                indexes[13] = Array.IndexOf(
                                    lineValues, "st_rotp");
                                indexes[14] = Array.IndexOf(
                                    lineValues, "sy_dist");

                                if (indexes[0] == -1 || indexes[1] == -1)
                                    userInterface.FileFormatError();
                            }
                            else if (lineValues.Length == headers)
                            {
                                if (lineValues[indexes[0]] == "" ||
                                    lineValues[indexes[1]] == "")
                                    userInterface.FileFormatError();

                                planets.Add(new Planet(
                                    lineValues[indexes[0]],
                                    lineValues[indexes[1]],
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
                                    if (stars[i].Name == lineValues[indexes[1]])
                                    {
                                        if (indexes[8] != -1 &&
                                            stars[i].Teff == "N/A" &&
                                        lineValues[indexes[8]] != "") stars[i].
                                        Teff = lineValues[indexes[8]];

                                        if (indexes[9] != -1 &&
                                        stars[i].Rad == "N/A" &&
                                        lineValues[indexes[9]] != "") stars[i].
                                         Rad = lineValues[indexes[9]];

                                        if (indexes[10] != -1 &&
                                        stars[i].Mass == "N/A" &&
                                        lineValues[indexes[10]] != "") stars[i].
                                        Mass = lineValues[indexes[10]];

                                        if (indexes[11] != -1 &&
                                        stars[i].StarAge == "N/A" &&
                                        lineValues[indexes[11]] != "") stars[i].
                                        StarAge = lineValues[indexes[11]];

                                        if (indexes[12] != -1 &&
                                        stars[i].StarRotationVelocity ==
                                        "N/A" && lineValues[indexes[12]] != "")
                                            stars[i].StarRotationVelocity =
                                             lineValues[indexes[12]];

                                        if (indexes[13] != -1 &&
                                        stars[i].StarRotationPeriod ==
                                        "N/A" && lineValues[indexes[13]] != "")
                                            stars[i].StarRotationPeriod =
                                            lineValues[indexes[13]];

                                        if (indexes[14] != -1 &&
                                        stars[i].DistanceStarToSun ==
                                        "N/A" && lineValues[indexes[14]] != "")
                                            stars[i].DistanceStarToSun =
                                           lineValues[indexes[14]];

                                        newStar = false;
                                        break;
                                    }
                                }

                                if (newStar)
                                {
                                    stars.Add(new Star(
                                        indexes[1] != -1 ? lineValues
                                        [indexes[1]] : "N/A",
                                        indexes[8] != -1 ? lineValues
                                        [indexes[8]] : "N/A",
                                        indexes[9] != -1 ? lineValues
                                        [indexes[9]] : "N/A",
                                        indexes[10] != -1 ? lineValues
                                        [indexes[10]] : "N/A",
                                        indexes[11] != -1 ? lineValues
                                        [indexes[11]] : "N/A",
                                        indexes[12] != -1 ? lineValues
                                        [indexes[12]] : "N/A",
                                        indexes[13] != -1 ? lineValues
                                        [indexes[13]] : "N/A",
                                        indexes[14] != -1 ? lineValues
                                        [indexes[14]] : "N/A"));
                                }
                            }
                            else
                            {
                                userInterface.FileFormatError();
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
        /// Returns a list of planets
        /// </summary>
        /// <returns>Planets</returns>
         public List<Planet> GetPlanets() => planets;


        /// <summary>
        /// Returns a list of Stars
        /// </summary>
        /// <returns>Stars</returns>
        public List<Star> GetStars() => stars;

        /// <summary>
        /// Returns every string in lines, one by one
        /// </summary>
        /// <returns>string</returns>
        public IEnumerable<string> GetLines()
        {
            foreach (string s in lines)
            {
                yield return s;
            }
        }
    }
}
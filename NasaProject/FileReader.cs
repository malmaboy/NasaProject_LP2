using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NasaProject
{
    /// <summary>
    /// This class reads the file
    /// Does collections about planets and stars 
    /// </summary>
    public class FileReader
    {
        private string filePath;
        List<Planet> planets = new List<Planet>();
        List<Star> stars = new List<Star>();

        /// <summary>
        /// Constructor
        /// Gets the path file
        /// </summary>
        public FileReader()
        {
            filePath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop), "File.csv");
        }

        /// <summary>
        /// Read The File 
        /// </summary>
        public void ReadFile()
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
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.StartsWith("#") || line.StartsWith("pl_name"))
                        {
                            continue;
                        }
                        else
                        {
                            lineValues = line.Split(",");

                            planets.Add(new Planet(
                                lineValues[0],
                                lineValues[1],
                                lineValues[5],
                                lineValues[6],
                                lineValues[11],
                                lineValues[13],
                                lineValues[15],
                                lineValues[20]));

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
                                    lineValues[1],
                                    lineValues[23],
                                    lineValues[24],
                                    lineValues[25],
                                    "0",
                                    "0",
                                    "0",
                                    lineValues[34]));
                            }
                        }
                    }
                }
            }
        }
    }
}
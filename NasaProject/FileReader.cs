using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace NasaProject {
    /// <summary>
    /// This class reads the file
    /// Does collections about planets and stars 
    /// </summary>
    public class FileReader {
        List<Planet> planets;
        List<Star> stars;
        List<string> lines;

        public FileReader () {
            planets = new List<Planet> ();
            stars = new List<Star> ();
            lines = new List<string> ();
        }

        /// <summary>
        /// Read The File 
        /// </summary>
        public void ReadFile (string filePath, int mode) {
            string line;
            string[] lineValues;
            bool newStar;

            using (FileStream fileStream = new FileStream (filePath,
                FileMode.Open, FileAccess.Read)) {
                using (StreamReader streamReader =
                    new StreamReader (fileStream)) {
                    if (mode == 0) {
                        while ((line = streamReader.ReadLine ()) != null) {
                            if (line.StartsWith ("#") || line.StartsWith ("pl_name") || line.Length == 0) {
                                continue;
                            } else {
                                lineValues = line.Split (",");

                                planets.Add (new Planet (
                                    lineValues[0],
                                    lineValues[1],
                                    lineValues[5],
                                    lineValues[6],
                                    lineValues[11],
                                    lineValues[13],
                                    lineValues[15],
                                    lineValues[20]));

                                newStar = true;

                                for (int i = 0; i < stars.Count; i++) {
                                    if (stars[i].Name == lineValues[1]) {
                                        newStar = false;
                                        break;
                                    }
                                }

                                if (newStar) {
                                    stars.Add (new Star (
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
                    } else if (mode == 1) {
                        while ((line = streamReader.ReadLine ()) != null) {
                            if (line.StartsWith ("#") || line.Length == 0) {
                                continue;
                            } else {
                                lines.Add (line);
                            }
                        }
                    }
                }
            }
        }

        public List<Planet> GetPlanets () => planets;

        public List<Star> GetStars () => stars;

        public IEnumerable<string> GetLines () {
            foreach (string s in lines) {
                yield return s;
            }
        }
    }
}
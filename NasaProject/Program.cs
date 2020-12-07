using System;

namespace NasaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader nasaInfo = new FileReader();

            nasaInfo.ReadFile();
        }
    }
}

using System;

namespace NasaProject {
    class Program {
        
        static void Main (string[] args) {
            ReadArgs reader;
            reader = new ReadArgs();
            
            reader.Read(args);
        }
    }
}
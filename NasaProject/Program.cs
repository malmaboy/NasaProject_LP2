namespace NasaProject
{
    /// <summary>
    /// Main class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            UserInterface UI = new UserInterface();

            UI.Start(args);
        }
    }
}